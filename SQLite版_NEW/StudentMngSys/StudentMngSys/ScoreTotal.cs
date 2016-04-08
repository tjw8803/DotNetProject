using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tianjw.Common;
using TJWCommon;
using TJWUIData;

namespace TJWForms
{
    public partial class ScoreTotal : Form
    {
        private DataAccess _dataAccess;
        private string _orgStuID = string.Empty;
        private DataWork _stuInfo;
        private ScoreDateSet _scoreDataSet;
        private Dictionary<string, DataWork> _scoreAvgDic;

        private string scoreKey = "{0}_{1}_{2}_{3}";
        private string rankKey = "{0}_{1}_{2}_{3}_{4}";

        public ScoreTotal()
        {
            InitializeComponent();

            _dataAccess = new DataAccess();
            _scoreDataSet = new ScoreDateSet();
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton_Search_Click(object sender, EventArgs e)
        {
            this.tb_StuID_Leave(sender, e);
            Search();
        }

        private void Search()
        {
            _scoreDataSet.Clear();

            LoadingForm waiting = new LoadingForm();
            waiting.Title = "查询成绩";
            waiting.Message = "正在查询学生成绩……";
            waiting.Show();

            // 条件
            DataWork param = new DataWork();
            // 班级
            ListItem liClass = (ListItem)this.comboBox_Class.SelectedItem;
            param.ClassID = liClass.Key;
            // 学号
            param.StuID = this.tb_StuID.Text.Trim();
            param.SearchScoreByStuID = true;
            // 类型
            param.ExamTypeID = this.comboBox_Type.SelectedIndex - 1;
            // 章节
            ListItem liPassage = (ListItem)this.comboBox_Course.SelectedItem;
            int courseID = 0;
            if (liPassage != null)
            {
                Int32.TryParse(liPassage.Key, out courseID);
            }
            param.CourseID = courseID;
            // 科目
            int courseNewID = 1;
            if (param.ExamTypeID == 1)
            {
                ListItem liCourse = (ListItem)this.comboBox_CourName.SelectedItem;
                if (liCourse != null)
                {
                    Int32.TryParse(liCourse.Key, out courseNewID);
                }
            }
            param.CourseNewID = courseNewID;
            // 日期

            // 查询
            List<DataWork> scoreInfoList = null;
            string message = string.Empty;
            int status = _dataAccess.GetScoreInfo(param, out scoreInfoList, out message);

            if (status == 0 && scoreInfoList.Count > 0)
            {
                // 排名用成绩查询
                param.SearchScoreByStuID = false;
                List<DataWork> scoreInfoList4Rank = null;
                status = _dataAccess.GetScoreInfo(param, out scoreInfoList4Rank, out message);

                Dictionary<string, int> rankDic;
                ArrangeData(scoreInfoList4Rank, ref scoreInfoList, out rankDic);
                foreach (DataWork scoreInfo in scoreInfoList)
                {
                    ScoreDateSet.ScoreTableRow dr = _scoreDataSet.ScoreTable.NewScoreTableRow();

                    dr.ClassID = scoreInfo.ClassID;
                    dr.ClassName = scoreInfo.ClassName;
                    dr.StuID = scoreInfo.StuID;
                    dr.StuName = scoreInfo.StuName;
                    dr.TypeID = scoreInfo.ExamTypeID;
                    string typeName = string.Empty;
                    string courseName = string.Empty;

                    Dictionary<string, string> examDic = DataWork.GetExamType();
                    if (examDic.ContainsKey(dr.TypeID.ToString()))
                    {
                        typeName = examDic[dr.TypeID.ToString()];
                    }
                    dr.TypeName = typeName;
                    dr.CourseNewID = scoreInfo.CourseNewID;
                    if (scoreInfo.ExamTypeID == 1)
                    {
                        dr.CourseNewName = scoreInfo.CourseNewName;
                    }
                    else
                    {
                        dr.CourseNewName = "-";
                    }

                    dr.CourseID = scoreInfo.CourseID;
                    dr.CourseName = scoreInfo.CourseName;
                    dr.Pass = scoreInfo.Pass;
                    dr.ScoreOrig = scoreInfo.OrigScore;
                    dr.Score = scoreInfo.Score;
                    dr.TestAgain = scoreInfo.TestAgain;
                    dr.ExamDate = scoreInfo.ExamDate;

                    // 平时作业不需要统计
                    if (dr.TypeID != 0)
                    {
                        string key1 = string.Format(rankKey, scoreInfo.ClassID, scoreInfo.StuID, scoreInfo.ExamTypeID, scoreInfo.CourseNewID, scoreInfo.CourseID);
                        if (rankDic.ContainsKey(key1))
                        {
                            dr.Rank = rankDic[key1];
                        }

                        string key2 = string.Format(scoreKey, scoreInfo.ClassID, scoreInfo.ExamTypeID, scoreInfo.CourseNewID, scoreInfo.CourseID);
                        if (_scoreAvgDic != null && _scoreAvgDic.ContainsKey(key2))
                        {
                            dr.Average = _scoreAvgDic[key2].Average;
                            dr.Up90Cnt = _scoreAvgDic[key2].Up90Cnt;
                            dr._8090Cnt = _scoreAvgDic[key2].Between8090Cnt;
                            dr._7080Cnt = _scoreAvgDic[key2].Between7080Cnt;
                            dr._6070Cnt = _scoreAvgDic[key2].Between6070Cnt;
                            dr.Down60Cnt = _scoreAvgDic[key2].Down60Cnt;
                        }
                    }


                    _scoreDataSet.ScoreTable.AddScoreTableRow(dr);
                }

                this.radioButton_AllDisplay.Checked = true;

                // GridView隔行变色
                GridViewRowColor(gridView_Score);
                GridViewRowBGColor(gridView_Score);

                // 工具栏按钮设置
                SetToolButtonEnable(true);

                waiting.Dispose();
            }
            else
            {
                SetToolButtonEnable(false);
                waiting.Dispose();
                MessageBox.Show(this, "未查询到数据！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void ArrangeData(List<DataWork> scoreInfoList4Rank, ref List<DataWork> scoreInfoList, out Dictionary<string, int> rankDic)
        {
            Dictionary<string, List<DataWork>> scoreDicForRank = new Dictionary<string, List<DataWork>>(); // 统计名次
            rankDic = new Dictionary<string, int>(); // 统计名次

            foreach (DataWork scoreInfo in scoreInfoList4Rank)
            {
                // 平时作业不需要统计
                if (scoreInfo.ExamTypeID != 0)
                {
                    string key = string.Format(scoreKey, scoreInfo.ClassID, scoreInfo.ExamTypeID, scoreInfo.CourseNewID, scoreInfo.CourseID);

                    // 统计名次
                    if (!scoreDicForRank.ContainsKey(key))
                    {
                        List<DataWork> list = new List<DataWork>();
                        list.Add(scoreInfo);

                        scoreDicForRank.Add(key, list);
                    }
                    else
                    {
                        scoreDicForRank[key].Add(scoreInfo);
                    }
                }
            }

            foreach (DataWork scoreInfo in scoreInfoList)
            {
                scoreInfo.OrigScore = scoreInfo.Score;
                if (scoreInfo.Pass == 0)
                {
                    scoreInfo.Score = scoreInfo.Score;
                }
                else
                {
                    if (scoreInfo.TestAgain == 0)
                    {
                        scoreInfo.Score = scoreInfo.Score;
                    }
                    else
                    {
                        scoreInfo.Score = scoreInfo.Score2;
                    }
                }
            }

            // 统计名次
            foreach (KeyValuePair<string, List<DataWork>> pair in scoreDicForRank)
            {
                List<DataWork> list = pair.Value;
                List<DataWork> retList = list.OrderByDescending(i => i.Score).ToList<DataWork>(); // 按成绩从大到小排序

                int rank = 1;
                int realRank = 0;
                int index = 0;
                foreach (DataWork work in retList)
                {
                    realRank++;

                    if (index > 0)
                    {
                        DataWork prevWork = retList[index - 1];
                        if (work.Score != prevWork.Score)
                        {
                            rank = realRank;
                        }
                    }

                    string key = string.Format(rankKey, work.ClassID, work.StuID, work.ExamTypeID, work.CourseNewID, work.CourseID);
                    if (!rankDic.ContainsKey(key))
                    {
                        rankDic.Add(key, rank);
                    }
                    else
                    {
                        rankDic[key] = rank;
                    }

                    index++;
                }
            }

        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton)
            {
                RadioButton radioBtn = (RadioButton)sender;
                switch (radioBtn.Name)
                {
                    case "radioButton_Pass":
                        {
                           this._scoreDataSet.ScoreTable.DefaultView.RowFilter = "Pass=1";
                        }
                        break;
                    case "radioButton_NoReTest":
                        {
                            this._scoreDataSet.ScoreTable.DefaultView.RowFilter = "Pass=1 AND TestAgain=0";
                        }
                        break;
                    case "radioButton_AllDisplay":
                        {
                            this._scoreDataSet.ScoreTable.DefaultView.RowFilter = "";
                        }
                        break;
                }
            }

            // GridView隔行变色
            GridViewRowColor(gridView_Score);
            GridViewRowBGColor(gridView_Score);

            if (gridView_Score.Rows.Count > 0)
            {
                // 工具栏按钮设置
                SetToolButtonEnable(true);
            }
            else
            {
                // 工具栏按钮设置
                SetToolButtonEnable(false);
            }
        }

        private void SetToolButtonEnable(bool enable)
        {
            this.toolStripButton_Excel.Enabled = enable;
        }

        private void toolStripButton_Excel_Click(object sender, EventArgs e)
        {
            string excelExportPath = string.Empty;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.InitialDirectory = Application.StartupPath + "\\OutPut\\";
            sfd.Filter = "Excel2007文件(*.xlsx)|*.xlsx|Excel2003文件(*.xls)|*.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                excelExportPath = sfd.FileName;

                LoadingForm waiting = new LoadingForm();
                waiting.Title = "导出Excel";
                waiting.Message = "正在导出Excel中……";
                waiting.Show();

                int status = 0;
                // Excel导入
                List<DataWorkForExcel> excelTableList = new List<DataWorkForExcel>();
                // 导出窗口的查询结果
                DataWorkForExcel work = new DataWorkForExcel();
                work.SheetName = "学生成绩";
                work.ExcelDataTable = GetDgvToTable(this.gridView_Score);
                excelTableList.Add(work);

                if (status == 0)
                {
                    if (excelExportPath.Last() == 's')
                    {
                        // Excel2003
                        status = NPOIExcelHelper.TableToExcelForXLS(excelTableList, excelExportPath);
                    }
                    else
                    {
                        // Excel2007
                        status = NPOIExcelHelper.TableToExcelForXLSX(excelTableList, excelExportPath);
                    }
                }

                waiting.Dispose();

                if (status == 0)
                {
                    MessageBox.Show(this, "Excel导出成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(this, "Excel导出失败！", this .Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        ///  <summary>
        /// 方法实现把dgv里的数据完整的复制到一张内存表
        ///  </summary>
        ///  <param name="dgv">dgv控件作为参数 </param>
        ///  <returns>返回临时内存表 </returns>
        private DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            for (int count = 0; count < dgv.Columns.Count; count++)
            {
                if (!dgv.Columns[count].Visible) continue;
                DataColumn dc = new DataColumn(dgv.Columns[count].Name.ToString());
                dc.Caption = dgv.Columns[count].HeaderText;
                dt.Columns.Add(dc);
            }
            for (int count = 0; count < dgv.Rows.Count; count++)
            {
                DataRow dr = dt.NewRow();
                int index = 0;
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    if (!dgv.Columns[countsub].Visible) continue;
                    object cellValue = dgv.Rows[count].Cells[countsub].Value;
                    dr[index++] = cellValue == DBNull.Value ? string.Empty : cellValue.ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void ScoreTotal_Load(object sender, EventArgs e)
        {
            InitScreen();
        }

        private void InitScreen()
        { 
            // 班级取得
            this.comboBox_Class.Items.Clear();
            this.comboBox_Class.Items.Add(new ListItem("0", "全部"));
            string errMsg = string.Empty;
            DataWork param = new DataWork();
            List<DataWork> classInfoList = null;
            int status = _dataAccess.GetClassInfo(param, out classInfoList, out errMsg);

            if (status == 0 && classInfoList.Count > 0)
            {
                foreach (DataWork classInfo in classInfoList)
                {
                    this.comboBox_Class.Items.Add(new ListItem(classInfo.ClassID, classInfo.ClassName));
                }
                this.comboBox_Class.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(this, "班级没有设置，请先设置班级！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }

            // 类型取得
            this.comboBox_Type.Items.Add(new ListItem("0", "全部"));
            Dictionary<string, string> examDic = DataWork.GetExamType();
            foreach (KeyValuePair<string, string> pair in examDic)
            {
                int key = Int32.Parse(pair.Key) + 1;
                this.comboBox_Type.Items.Add(new ListItem(key.ToString(), pair.Value));
            }
            this.comboBox_Type.SelectedIndex = 0;

            // 课程取得
            errMsg = string.Empty;
            param = new DataWork();
            List<DataWork> courseInfoList = null;
            status = _dataAccess.GetCourseInfo(param, out courseInfoList, out errMsg);

            if (status == 0 && courseInfoList.Count > 0)
            {
                foreach (DataWork courseInfo in courseInfoList)
                {
                    this.comboBox_CourName.Items.Add(new ListItem(courseInfo.CourseID.ToString(), courseInfo.CourseName));
                }
            }

            // 平均分，分数段人数查询
            string message = string.Empty;
            List<DataWork> scoreInfoList = new List<DataWork>();
            status = _dataAccess.GetAvgScore(param, out scoreInfoList, out message);
            if (status == 0 && scoreInfoList.Count > 0)
            {
                _scoreAvgDic = new Dictionary<string, DataWork>();
                foreach (DataWork scoreInfo in scoreInfoList)
                {
                    string key = string.Format(scoreKey, scoreInfo.ClassID, scoreInfo.ExamTypeID, scoreInfo.CourseNewID, scoreInfo.CourseID);
                    if (!_scoreAvgDic.ContainsKey(key))
                    {
                        _scoreAvgDic.Add(key, scoreInfo);
                    }
                }
            }

            this._scoreDataSet.ScoreTable.Clear();

            this.gridView_Score.DataSource = this._scoreDataSet.ScoreTable.DefaultView;

            InitGridView();

            SetToolButtonEnable(false);

            this.tb_StuID.Focus();
        }

        private void InitGridView()
        {
            DataGridViewColumnCollection columns =  gridView_Score.Columns;
            for (int i = 0; i < columns.Count; i++)
            {
                //this.gridView_Score.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                this.gridView_Score.Columns[i].Visible = false;
            }
            int index = 0;

            columns[this._scoreDataSet.ScoreTable.ClassIDColumn.ColumnName].HeaderText = "班级编号";
            columns[this._scoreDataSet.ScoreTable.ClassIDColumn.ColumnName].DisplayIndex = index++;

            columns[this._scoreDataSet.ScoreTable.ClassNameColumn.ColumnName].HeaderText = "班级";
            columns[this._scoreDataSet.ScoreTable.ClassNameColumn.ColumnName].Visible = true;
            columns[this._scoreDataSet.ScoreTable.ClassNameColumn.ColumnName].DisplayIndex = index++;

            columns[this._scoreDataSet.ScoreTable.StuIDColumn.ColumnName].HeaderText = "学号";
            columns[this._scoreDataSet.ScoreTable.StuIDColumn.ColumnName].Visible = true;
            columns[this._scoreDataSet.ScoreTable.StuIDColumn.ColumnName].DisplayIndex = index++;

            columns[this._scoreDataSet.ScoreTable.StuNameColumn.ColumnName].HeaderText = "姓名";
            columns[this._scoreDataSet.ScoreTable.StuNameColumn.ColumnName].Visible = true;
            columns[this._scoreDataSet.ScoreTable.StuNameColumn.ColumnName].DisplayIndex = index++;

            columns[this._scoreDataSet.ScoreTable.TypeIDColumn.ColumnName].HeaderText = "类型ID";
            columns[this._scoreDataSet.ScoreTable.TypeIDColumn.ColumnName].DisplayIndex = index++;

            columns[this._scoreDataSet.ScoreTable.TypeNameColumn.ColumnName].HeaderText = "考试类型";
            columns[this._scoreDataSet.ScoreTable.TypeNameColumn.ColumnName].Visible = true;
            columns[this._scoreDataSet.ScoreTable.TypeNameColumn.ColumnName].DisplayIndex = index++;

            columns[this._scoreDataSet.ScoreTable.CourseNewNameColumn.ColumnName].HeaderText = "科目";
            columns[this._scoreDataSet.ScoreTable.CourseNewNameColumn.ColumnName].Visible = true;
            columns[this._scoreDataSet.ScoreTable.CourseNewNameColumn.ColumnName].DisplayIndex = index++;

            columns[this._scoreDataSet.ScoreTable.CourseNameColumn.ColumnName].HeaderText = "章节";
            columns[this._scoreDataSet.ScoreTable.CourseNameColumn.ColumnName].Visible = true;
            columns[this._scoreDataSet.ScoreTable.CourseNameColumn.ColumnName].DisplayIndex = index++;

            columns[this._scoreDataSet.ScoreTable.RankColumn.ColumnName].HeaderText = "名次";
            columns[this._scoreDataSet.ScoreTable.RankColumn.ColumnName].Visible = true;
            columns[this._scoreDataSet.ScoreTable.RankColumn.ColumnName].Width = 70;
            columns[this._scoreDataSet.ScoreTable.RankColumn.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columns[this._scoreDataSet.ScoreTable.RankColumn.ColumnName].DisplayIndex = index++;

            columns[this._scoreDataSet.ScoreTable.ScoreColumn.ColumnName].HeaderText = "考试成绩";
            columns[this._scoreDataSet.ScoreTable.ScoreColumn.ColumnName].Visible = true;
            columns[this._scoreDataSet.ScoreTable.ScoreColumn.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columns[this._scoreDataSet.ScoreTable.ScoreColumn.ColumnName].DisplayIndex = index++;

            columns[this._scoreDataSet.ScoreTable.AverageColumn.ColumnName].HeaderText = "平均分";
            columns[this._scoreDataSet.ScoreTable.AverageColumn.ColumnName].Visible = true;
            columns[this._scoreDataSet.ScoreTable.AverageColumn.ColumnName].DefaultCellStyle.Format =  "0.00";
            columns[this._scoreDataSet.ScoreTable.AverageColumn.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columns[this._scoreDataSet.ScoreTable.AverageColumn.ColumnName].DisplayIndex = index++;

            columns[this._scoreDataSet.ScoreTable.Up90CntColumn.ColumnName].HeaderText = "90分以上";
            columns[this._scoreDataSet.ScoreTable.Up90CntColumn.ColumnName].Visible = true;
            columns[this._scoreDataSet.ScoreTable.Up90CntColumn.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columns[this._scoreDataSet.ScoreTable.Up90CntColumn.ColumnName].DisplayIndex = index++;

            columns[this._scoreDataSet.ScoreTable._8090CntColumn.ColumnName].HeaderText = "80～90";
            columns[this._scoreDataSet.ScoreTable._8090CntColumn.ColumnName].Visible = true;
            columns[this._scoreDataSet.ScoreTable._8090CntColumn.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columns[this._scoreDataSet.ScoreTable._8090CntColumn.ColumnName].DisplayIndex = index++;

            columns[this._scoreDataSet.ScoreTable._7080CntColumn.ColumnName].HeaderText = "70～80";
            columns[this._scoreDataSet.ScoreTable._7080CntColumn.ColumnName].Visible = true;
            columns[this._scoreDataSet.ScoreTable._7080CntColumn.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columns[this._scoreDataSet.ScoreTable._7080CntColumn.ColumnName].DisplayIndex = index++;

            columns[this._scoreDataSet.ScoreTable._6070CntColumn.ColumnName].HeaderText = "60～70";
            columns[this._scoreDataSet.ScoreTable._6070CntColumn.ColumnName].Visible = true;
            columns[this._scoreDataSet.ScoreTable._6070CntColumn.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columns[this._scoreDataSet.ScoreTable._6070CntColumn.ColumnName].DisplayIndex = index++;

            columns[this._scoreDataSet.ScoreTable.Down60CntColumn.ColumnName].HeaderText = "60分以下";
            columns[this._scoreDataSet.ScoreTable.Down60CntColumn.ColumnName].Visible = true;
            columns[this._scoreDataSet.ScoreTable.Down60CntColumn.ColumnName].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            columns[this._scoreDataSet.ScoreTable.Down60CntColumn.ColumnName].DisplayIndex = index++;

        }

        private void gridView_Score_Sorted(object sender, EventArgs e)
        {
            // GridView隔行变色
            GridViewRowColor(gridView_Score);
            GridViewRowBGColor(gridView_Score);
        }

        /// <summary>
        /// 隔行变色
        /// </summary>
        /// <param name="dgv"></param>
        private void GridViewRowColor(DataGridView dgv)
        {
            if (dgv.Rows.Count != 0)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    if ((i + 1) % 2 == 0)
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        dgv.Rows[i].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(240, 248, 255);
                    }
                }
            }
        }

        private void GridViewRowBGColor(DataGridView dgv)
        {
            if (dgv.Rows.Count != 0)
            {
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    int pass = (int)dgv.Rows[i].Cells[this._scoreDataSet.ScoreTable.PassColumn.ColumnName].Value;
                    int testAgain = (int)dgv.Rows[i].Cells[this._scoreDataSet.ScoreTable.TestAgainColumn.ColumnName].Value;
                    if (pass == 1)
                    {
                        if (testAgain == 0)
                        {
                            dgv.Rows[i].Cells[this._scoreDataSet.ScoreTable.ScoreColumn.ColumnName].Style.BackColor = Color.FromArgb(255, 170, 170);
                            dgv.Rows[i].Cells[this._scoreDataSet.ScoreTable.ScoreColumn.ColumnName].Style.ForeColor = Color.Red;
                        }
                        else
                        {
                            dgv.Rows[i].Cells[this._scoreDataSet.ScoreTable.ScoreColumn.ColumnName].Style.BackColor = Color.FromArgb(255, 170, 170);
                            dgv.Rows[i].Cells[this._scoreDataSet.ScoreTable.ScoreColumn.ColumnName].Style.ForeColor = Color.Blue;
                        }
                    }
                }
            }
        }

        private void comboBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBox_Type.SelectedIndex)
            {
                case 1:
                case 2:
                    if (this.comboBox_Type.SelectedIndex == 2)
                    {
                        this.label_Mark.Visible = true;
                        this.comboBox_CourName.Visible = true;

                        if (this.comboBox_CourName.Items.Count > 0)
                        {
                            this.comboBox_CourName.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        this.label_Mark.Visible = false;
                        this.comboBox_CourName.Visible = false;

                        // 章节取得
                        GetCourseInfo();
                    }

                    this.comboBox_Course.Enabled = true;

                    break;
                case 0:
                    {
                        this.comboBox_Course.Enabled = false;
                        this.comboBox_Course.Items.Clear();
                        this.label_Mark.Visible = false;
                        this.comboBox_CourName.Visible = false;
                    }
                    break;
            }
        }

        private void comboBox_CourName_SelectedIndexChanged(object sender, EventArgs e)
        { 
            // 章节取得
            GetCourseInfo();
        }

        private void GetCourseInfo()
        {
            this.comboBox_Course.Items.Clear();
            this.comboBox_Course.Items.Add(new ListItem("0", "全部"));
            string errMsg = string.Empty;
            DataWork param = new DataWork();
            param.ExamTypeID = this.comboBox_Type.SelectedIndex - 1;
            if (this.comboBox_Type.SelectedIndex == 2)
            {
                param.CourseNewID = this.comboBox_CourName.SelectedIndex + 1;
            }
            List<DataWork> examTypeInfoList = null;
            int status = _dataAccess.GetExamTypeInfo(param, out examTypeInfoList, out errMsg);

            if (status == 0 && examTypeInfoList.Count > 0)
            {
                foreach (DataWork examTypeInfo in examTypeInfoList)
                {
                    this.comboBox_Course.Items.Add(new ListItem(examTypeInfo.CourseID.ToString(), examTypeInfo.CourseName));
                }
            }
            if (this.comboBox_Course.Items.Count > 0)
            {
                this.comboBox_Course.SelectedIndex = 0;
            }
        }

        private void tb_StuID_Leave(object sender, EventArgs e)
        {
            _stuInfo = null;
            string stuID = this.tb_StuID.Text.Trim();
            if (_orgStuID != stuID)
            {
                _orgStuID = stuID;
                DataWork param = new DataWork();
                param.StuID = stuID;
                List<DataWork> stuInfoList = null;
                if (!string.IsNullOrEmpty(stuID))
                {
                    string errMsg = string.Empty;
                    int status = _dataAccess.GetStuInfo(param, out stuInfoList, out errMsg);

                    if (status == 0 && stuInfoList.Count > 0)
                    {
                        _stuInfo = stuInfoList[0];
                        this.tb_StuID.Text = _stuInfo.StuID;
                        this.tb_StuName.Text = _stuInfo.StuName;
                        this.tb_ClassName.Text = _stuInfo.ClassName;
                    }
                    else
                    {
                        MessageBox.Show(this, "该学生未登录！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _orgStuID = string.Empty;
                        this.tb_StuID.Clear();
                        this.tb_StuName.Clear();
                        this.tb_ClassName.Clear();
                        this.tb_StuID.Focus();
                    }
                }
                else
                {
                    _orgStuID = string.Empty;
                    this.tb_StuID.Clear();
                    this.tb_StuName.Clear();
                    this.tb_ClassName.Clear();
                }
            }
        }

        private void tb_StuID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }

        private void timer_Time_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        /// <summary>
        /// 添加行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_Score_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                gridView_Score.RowHeadersWidth,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                gridView_Score.RowHeadersDefaultCellStyle.Font,
                rectangle,
                gridView_Score.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        private void toolStripButton_Clear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Clear()
        {
            this.comboBox_Class.SelectedIndex = 0;
            this.tb_StuID.Clear();
            this.tb_StuName.Clear();
            this.tb_ClassName.Clear();
            this.comboBox_Type.SelectedIndex = 0;

            this._scoreDataSet.ScoreTable.Clear();
            SetToolButtonEnable(false);
        }

        private void toolStripButton_Refresh_Click(object sender, EventArgs e)
        {
            InitScreen();
            MessageBox.Show(this, "已取得最新数据！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void gridView_Score_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            int cellColumnIndex = e.ColumnIndex;
            int cellRowIndex = e.RowIndex;
            // 成绩列
            if (cellColumnIndex == 9 && cellRowIndex >= 0)
            {
                int pass = (int)gridView_Score.Rows[cellRowIndex].Cells[this._scoreDataSet.ScoreTable.PassColumn.ColumnName].Value;
                int testAgain = (int)gridView_Score.Rows[cellRowIndex].Cells[this._scoreDataSet.ScoreTable.TestAgainColumn.ColumnName].Value;
                double score = (double)gridView_Score.Rows[cellRowIndex].Cells[this._scoreDataSet.ScoreTable.ScoreOrigColumn.ColumnName].Value;

                if (pass == 1 && testAgain == 1)
                {
                    DataGridViewCell dgvc = this.gridView_Score[cellColumnIndex, cellRowIndex];
                    Rectangle rec = dgvc.ContentBounds;
                    string tip = "原成绩： " + score + "/补考成绩：" + dgvc.Value;
                    gridView_Score.Rows[cellRowIndex].Cells[cellColumnIndex].ToolTipText = tip;
                    toolStripStatusLabel1.Text = tip;
                }
                else
                {
                    toolStripStatusLabel1.Text = string.Empty;
                }
            }
            else 
            {
                toolStripStatusLabel1.Text = string.Empty;
            }
        }

        private void gridView_Score_Leave(object sender, EventArgs e)
        {
            this.gridView_Score.ClearSelection();
        }

        private void toolStripButton_ScoreTotalChart_Click(object sender, EventArgs e)
        {
            ScoreTotalChart chart = new ScoreTotalChart();
            chart.ShowDialog();
        }

        private void ScoreTotal_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}

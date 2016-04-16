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
    public partial class ScoreTotalChart : Form
    {
        private DataAccess _dataAccess;
        private bool _formLoaded = false;
        private List<DataWork> _scoreInfoList = null;
        private List<DataWork> _stuScoreInfoList = null;
        private DataWork _param;
        private List<DataWork> _examTypeInfoList;
        private List<DataWork> _stuInfoList;

        public ScoreTotalChart()
        {
            InitializeComponent();

            _dataAccess = new DataAccess();
        }

        private void ScoreTotalChart_Load(object sender, EventArgs e)
        {
            InitScreen();

            _formLoaded = true;
        }

        private void InitScreen()
        {
            this.comboBox_TotalType.SelectedIndex = 0;

            // 班级取得
            this.comboBox_Class.Items.Clear();
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

            // 课程取得
            errMsg = string.Empty;
            param = new DataWork();
            List<DataWork> courseInfoList = null;
            status = _dataAccess.GetCourseInfo(param, out courseInfoList, out errMsg);

            if (status == 0 && courseInfoList.Count > 0)
            {
                foreach (DataWork courseInfo in courseInfoList)
                {
                    this.comboBox_CourseName.Items.Add(new ListItem(courseInfo.CourseID.ToString(), courseInfo.CourseName));
                }
                this.comboBox_CourseName.SelectedIndex = 0;
            }

            // 考试批次
            ReadExamInfo readExamInfo = new ReadExamInfo();
            readExamInfo.Deserialize();
            if (readExamInfo.UserSetting != null &&
                readExamInfo.UserSetting.ExamItemList != null &&
                readExamInfo.UserSetting.ExamItemList.Count > 0)
            {
                int index = 0;
                foreach (string str in readExamInfo.UserSetting.ExamItemList)
                {
                    this.comboBox_Course.Items.Add(new ListItem(index.ToString(), str));
                    index++;
                }
                this.comboBox_Course.SelectedIndex = 0;
            }

            // 学年
            this.comboBox_AcademicYear.SelectedIndex = InitAcademicYear(DateTime.Now);
            this.comboBox_Term.SelectedIndex = 0;

            this.comboBox_Class.Focus();
        }
        private int InitAcademicYear(DateTime currentTime)
        {
            int minAcademicYear = currentTime.Year * 100 + 2; // 201602
            int maxAcademicYear = currentTime.Year * 100 + 9; // 201609
            int selectIndex = 0;

            if (currentTime.Year * 100 + currentTime.Day < minAcademicYear)
            {
                selectIndex = currentTime.Year - 2010;
            }
            else if (currentTime.Year * 100 + currentTime.Day > maxAcademicYear)
            {
                selectIndex = currentTime.Year - 2011;
            }

            return selectIndex;
        }

        private void comboBox_CourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 章节取得
            //GetCourseInfo();
        }

        private void GetCourseInfo()
        {
            this.comboBox_Course.Items.Clear();
            string errMsg = string.Empty;
            DataWork param = new DataWork();
            param.ExamTypeID = 1;
            param.CourseNewID = this.comboBox_CourseName.SelectedIndex + 1;
            _examTypeInfoList = null;
            int status = _dataAccess.GetExamTypeInfo(param, out _examTypeInfoList, out errMsg);

            if (status == 0 && _examTypeInfoList.Count > 0)
            {
                foreach (DataWork examTypeInfo in _examTypeInfoList)
                {
                    this.comboBox_Course.Items.Add(new ListItem(examTypeInfo.CourseID.ToString(), examTypeInfo.CourseName));
                }
            }
            if (this.comboBox_Course.Items.Count > 0)
            {
                this.comboBox_Course.SelectedIndex = 0;
            }
            else
            {
            }
        }

        private int Search()
        {
            int status = -1;
            string message = string.Empty;

            // 平均分，分数段人数查询

            // 条件
            _param = new DataWork();
            // 班级
            ListItem liClass = (ListItem)this.comboBox_Class.SelectedItem;
            _param.ClassID = liClass.Key;
            _param.ClassName = liClass.Value;
            // 类型
            _param.ExamTypeID = 1;
            // 课程
            _param.CourseNewID = this.comboBox_CourseName.SelectedIndex + 1;
            _param.CourseNewName = this.comboBox_CourseName.SelectedItem.ToString();
            if (this.comboBox_TotalType.SelectedIndex == 0)
            {
                // 考试批次
                ListItem liCourse = (ListItem)this.comboBox_Course.SelectedItem;
                int courseID = 0;
                Int32.TryParse(liCourse.Key, out courseID);
                _param.CourseID = courseID + 1;
                _param.CourseName = liCourse.Value;
            }
            else if (this.comboBox_TotalType.SelectedIndex == 3)
            {
                DataWork wk = new DataWork();
                wk.YearName = this.comboBox_AcademicYear.SelectedItem.ToString();
                wk.TermId = this.comboBox_Term.SelectedIndex + 1;

                List<DataWork> termList = null;
                string errMsg = string.Empty;
                this._dataAccess.GetTermInfo(wk, out termList, out errMsg);

                if (termList != null && termList.Count > 0)
                {
                    _param.SearchDateTimeSt = termList[0].TermDateSt;
                    _param.SearchDateTimeEd = termList[0].TermDateEd;
                }
                _param.SearchMode = 1;
            }

            // 平均分查询
            _scoreInfoList = new List<DataWork>();
            List<DataWork> list = new List<DataWork>();
            status = _dataAccess.GetAvgScore(_param, out list, out message);

            if (status != 0 || list.Count == 0)
            {
                MessageBox.Show(this, "未查询到数据！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return status;
            }
            else
            {
                if (this.comboBox_TotalType.SelectedIndex == 0)
                {
                    // 考试批次名
                    foreach (DataWork scoreWork in list)
                    {
                        ListItem item = ListItem.FindByKey(this.comboBox_Course, (scoreWork.CourseID - 1).ToString());
                        if (item != null)
                        {
                            scoreWork.CourseName = item.Value;
                        }
                    }
                    _scoreInfoList = list;
                }
                else if (this.comboBox_TotalType.SelectedIndex == 1 || this.comboBox_TotalType.SelectedIndex == 2)
                {
                    // 平均分->Dictionary
                    Dictionary<string, DataWork> avgScoreDic = new Dictionary<string, DataWork>();
                    foreach (DataWork avgScoreWork in list)
                    {
                        // 考试批次名
                        ListItem item = ListItem.FindByKey(this.comboBox_Course, (avgScoreWork.CourseID - 1).ToString());
                        if (item != null)
                        {
                            avgScoreWork.CourseName = item.Value;
                        }

                        string key = (avgScoreWork.CourseID - 1).ToString();
                        if (!avgScoreDic.ContainsKey(key))
                        {
                            avgScoreDic.Add(key, avgScoreWork);
                        }
                    }

                    // 循环章节
                    foreach (ListItem courseWork in this.comboBox_Course.Items)
                    {
                        string key = courseWork.Key;
                        if (avgScoreDic.ContainsKey(key))
                        {
                            _scoreInfoList.Add(avgScoreDic[key]);
                        }
                        else
                        {
                            DataWork newWork = new DataWork();
                            newWork.ClassID = _param.ClassID;
                            newWork.ClassName = _param.ClassName;
                            newWork.ExamTypeID = _param.ExamTypeID;
                            newWork.CourseNewID = _param.CourseNewID;
                            newWork.CourseID = int.Parse(courseWork.Key) + 1;
                            newWork.CourseName = courseWork.Value;
                            newWork.Average = 0;
                            newWork.Up90Cnt = 0;
                            newWork.Between8090Cnt = 0;
                            newWork.Between7080Cnt = 0;
                            newWork.Between6070Cnt = 0;
                            newWork.Down60Cnt = 0;

                            _scoreInfoList.Add(newWork);
                        }
                    }

                    // 按章节排序
                    _scoreInfoList.OrderBy(work => work.CourseID);
                }
                else if (this.comboBox_TotalType.SelectedIndex == 3)
                {
                    // 平均分->Dictionary
                    Dictionary<string, DataWork> avgScoreDic = new Dictionary<string, DataWork>();
                    foreach (DataWork avgScoreWork in list)
                    {
                        string key = avgScoreWork.ClassID + "-" + avgScoreWork.StuID;
                        if (!avgScoreDic.ContainsKey(key))
                        {
                            avgScoreDic.Add(key, avgScoreWork);
                        }
                    }

                    foreach (DataWork stuInfo in _stuInfoList)
                    {
                        string key = stuInfo.ClassID + "-" + stuInfo.StuID;
                        if (avgScoreDic.ContainsKey(key))
                        {
                            _scoreInfoList.Add(avgScoreDic[key]);
                        }
                        else
                        {
                            DataWork newWork = new DataWork();
                            newWork.ClassID = _param.ClassID;
                            newWork.ClassName = _param.ClassName;
                            newWork.ExamTypeID = _param.ExamTypeID;
                            newWork.StuID = stuInfo.StuID;
                            newWork.StuName = stuInfo.StuName;
                            newWork.Average = 0;
                            newWork.Up90Cnt = 0;
                            newWork.Between8090Cnt = 0;
                            newWork.Between7080Cnt = 0;
                            newWork.Between6070Cnt = 0;
                            newWork.Down60Cnt = 0;

                            _scoreInfoList.Add(newWork);
                        }
                    }

                    // 按章节排序
                    _scoreInfoList.OrderBy(work => work.StuID);
                }

                if (this.comboBox_TotalType.SelectedIndex == 2)
                {
                    // 学生成绩查询
                    _param.SearchScoreByStuID = true;
                    ListItem liStu = (ListItem)this.comboBox_Student.SelectedItem;
                    _param.StuID = liStu.Key;
                    _param.StuName = liStu.Value;

                    _stuScoreInfoList = new List<DataWork>();
                    List<DataWork> stuScoreList = new List<DataWork>();

                    status = _dataAccess.GetScoreInfo(_param, out stuScoreList, out message);
                    if (status != 0 || stuScoreList.Count == 0)
                    {
                        MessageBox.Show(this, "未查询到数据！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return status;
                    }
                    else
                    {
                        // 学生成绩->Dictionary
                        Dictionary<string, DataWork> scoreDic = new Dictionary<string, DataWork>();
                        foreach (DataWork scoreWork in stuScoreList)
                        {
                            // 考试批次名
                            ListItem item = ListItem.FindByKey(this.comboBox_Course, (scoreWork.CourseID - 1).ToString());
                            if (item != null)
                            {
                                scoreWork.CourseName = item.Value;
                            }

                            string key = (scoreWork.CourseID - 1).ToString();
                            if (!scoreDic.ContainsKey(key))
                            {
                                scoreDic.Add(key, scoreWork);
                            }
                        }

                        foreach (ListItem courseWork in this.comboBox_Course.Items)
                        {
                            string key = courseWork.Key;
                            if (scoreDic.ContainsKey(key))
                            {
                                _stuScoreInfoList.Add(scoreDic[key]);
                            }
                            else
                            {

                                DataWork newWork = new DataWork();
                                newWork.ClassID = _param.ClassID;
                                newWork.ClassName = _param.ClassName;
                                newWork.StuID = _param.StuID;
                                newWork.StuName = _param.StuName;
                                newWork.ExamTypeID = _param.ExamTypeID;
                                newWork.CourseNewID = _param.CourseNewID;
                                //newWork.CourseNewName = courseWork.CourseNewName;
                                newWork.CourseID = int.Parse(courseWork.Key) + 1;
                                newWork.CourseName = courseWork.Value;
                                newWork.Score = 0;
                                newWork.Pass = 0;
                                newWork.Score2 = 0;
                                newWork.TestAgain = 0;
                                newWork.ExamDate = DateTime.MinValue;

                                _scoreInfoList.Add(newWork);
                            }
                        }

                        // 按章节排序
                        _stuScoreInfoList.OrderBy(work => work.CourseID);
                    }
                }
            }
            return status;
        }

        private void btn_Total_Click(object sender, EventArgs e)
        {
            if (Search() == 0 && _scoreInfoList.Count > 0)
            {
                ChartTab chart = new ChartTab( this.comboBox_TotalType.SelectedIndex, _scoreInfoList, _stuScoreInfoList);
                if (this.comboBox_TotalType.SelectedIndex == 0)
                {
                    AddTabControl(_param, this.tabControl_AvgTotal1, chart);
                }
                else if (this.comboBox_TotalType.SelectedIndex == 1)
                {
                    AddTabControl(_param, this.tabControl_AvgTotal2, chart);
                }
                else if (this.comboBox_TotalType.SelectedIndex == 2)
                {
                    AddTabControl(_param, this.tabControl_AvgTotal3, chart);
                }
                else if (this.comboBox_TotalType.SelectedIndex == 3)
                {
                    chart.TitleContent = this.comboBox_AcademicYear.SelectedItem + "/" + this.comboBox_Term.SelectedItem;
                    AddTabControl(_param, this.tabControl_TermTotal, chart);

                }
                this.TopMost = true;
                this.Activate();
                this.TopMost = false;
            }
        }

        private void AddTabControl(DataWork work, TabControl objTabControl, ChartTab objfrm)
        {
            try
            {
                string pageName = string.Empty;
                string pageText = string.Empty;
                switch (this.comboBox_TotalType.SelectedIndex)
                {
                    case 0:
                        pageName = "tabPage" + work.ClassID + work.ExamTypeID + work.CourseNewID + work.CourseID;
                        pageText = work.ClassName + "/" + work.CourseNewName + work.CourseName;
                        break;
                    case 1:
                        pageName = "tabPage" + work.ClassID + work.ExamTypeID + work.CourseNewID + work.CourseID;
                        pageText = work.ClassName + "/" + work.CourseNewName;
                        break;
                    case 2:
                        pageName = "tabPage" + work.ClassID + work.ExamTypeID + work.CourseNewID + work.CourseID + work.StuID;
                        pageText = work.ClassName + "/" + work.CourseNewName + "/" + work.StuName;
                        break;
                    case 3:
                        pageName = "tabPage" + work.ClassID + work.ExamTypeID + work.CourseNewID + this.comboBox_AcademicYear.SelectedIndex + this.comboBox_Term.SelectedIndex;
                        pageText = work.ClassName + "/" + work.CourseNewName;
                        break;
                }
                if (ErgodicModiForm(pageName, objTabControl))
                {
                    //声明一个选项卡对象
                    TabPage tabPage = new TabPage();
                    //选项卡的名称
                    tabPage.Name = pageName;
                    //选项卡的文本
                    tabPage.Text = pageText;
                    //tabPage.TabIndex = node.Index;
                    tabPage.BackColor = Color.Lavender;
                    //向选项卡集合添加新选项卡
                    objTabControl.Controls.Add(tabPage);
                    //子窗体大小设置为选项卡大小
                    objfrm.Size = tabPage.Size;
                    objfrm.Text = pageText;
                    objfrm.TopLevel = false;
                    objfrm.Dock = DockStyle.Fill;
                    //子窗体显示
                    objfrm.Show();
                    //将子窗体添加到选项卡中
                    tabPage.Controls.Add(objfrm);
                    //设置当前选项卡为新增选项卡
                    objTabControl.SelectTab(pageName);
                }
                else
                {
                    //设为当前选中的选项
                    objTabControl.SelectTab(pageName);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(this, "添加选项卡时出错！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private Boolean ErgodicModiForm(string MainTabControlKey, TabControl objTabControl)
        {
            //遍历选项卡判断是否存在该子窗体
            foreach (Control con in objTabControl.Controls)
            {
                TabPage tab = (TabPage)con;
                if (tab.Name == MainTabControlKey)
                {
                    return false;//存在
                }
            }
            return true;//不存在
        }

        private void comboBox_TotalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBox_TotalType.SelectedIndex)
            {
                case 0:
                    this.groupBox_Course.Visible = true;
                    this.groupBox_Student.Visible = false;
                    this.panel_Year.Visible = false;
                    break;
                case 1:
                    this.groupBox_Course.Visible = false;
                    this.groupBox_Student.Visible = false;
                    this.panel_Year.Visible = false;
                    break;
                case 2:
                    this.groupBox_Course.Visible = false;
                    this.groupBox_Student.Visible = true;
                    this.panel_Year.Visible = false;
                    break;
                case 3:
                    this.groupBox_Course.Visible = false;
                    this.groupBox_Student.Visible = false;
                    this.panel_Year.Visible = true;
                    break;
            }
            this.tabControl1.SelectedIndex = this.comboBox_TotalType.SelectedIndex;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox_TotalType.SelectedIndex = this.tabControl1.SelectedIndex;
        }

        private void comboBox_Class_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 学生取得
            this.comboBox_Student.Items.Clear();
            string errMsg = string.Empty;
            DataWork param = new DataWork();
            // 班级
            ListItem liClass = (ListItem)this.comboBox_Class.SelectedItem;
            param.ClassID = liClass.Key;
            _stuInfoList = null;
            int status = _dataAccess.GetStuInfo(param, out _stuInfoList, out errMsg);

            if (status == 0 && _stuInfoList.Count > 0)
            {
                foreach (DataWork stuInfo in _stuInfoList)
                {
                    this.comboBox_Student.Items.Add(new ListItem(stuInfo.StuID, stuInfo.StuName));
                }
                this.comboBox_Student.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(this, "学生没有设置，请先设置学生！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
                return;
            }
        }
    }
}

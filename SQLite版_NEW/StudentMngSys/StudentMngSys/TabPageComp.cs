using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TJWCommon;
using TJWUIData;

namespace TJWForms
{
    public partial class TabPageComp : Form
    {
        private int _mode; // 模式（0:班级设定 1:学生设定 2:考试类型设定）
        private int _selectedRowIndex = -1; // 选择数据行
        private DataAccess _dataAccess;

        private const string STU_ID = "stuID"; // 学号
        private const string STU_NAME = "stuName"; // 姓名
        private const string CLASS_ID = "classID"; // 班级编号
        private const string CLASS_NAME = "className"; // 班级
        private const string TYPE_ID = "typeID"; // 类型编号
        private const string TYPE_NAME = "typeName"; // 类型
        private const string COURSE_NEWID = "courseNewID"; // 课程编号
        private const string COURSE_NAME = "courseName"; // 课程名
        private const string COURSE_ID = "courseID"; // 章节编号
        private const string PASSAGE = "passage"; // 章节

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="mode"></param>
        public TabPageComp(int mode)
        {
            InitializeComponent();

            _mode = mode;
            _dataAccess = new DataAccess();

        }

        /// <summary>
        /// Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabPageComp_Load(object sender, EventArgs e)
        {
            ShowDataToGrid(_mode);

            InitGridView(_mode);
        }

        /// <summary>
        /// Grid初始化
        /// </summary>
        /// <param name="mode"></param>
        private void InitGridView(int mode)
        {
            DataGridViewColumnCollection columns = gridView.Columns;
            for (int i = 0; i < columns.Count; i++)
            {
                this.gridView.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                this.gridView.Columns[i].Visible = false;
            }

            switch (mode)
            {
                case 0: // 班级
                    {
                        columns[CLASS_ID].HeaderText = "班级编号";
                        columns[CLASS_ID].Visible = true;

                        columns[CLASS_NAME].HeaderText = "班级";
                        columns[CLASS_NAME].Visible = true;
                    }
                    break;
                case 1: // 学生
                    {
                        columns[STU_ID].HeaderText = "学号";
                        columns[STU_ID].Visible = true;

                        columns[STU_NAME].HeaderText = "姓名";
                        columns[STU_NAME].Visible = true;


                        columns[CLASS_ID].HeaderText = "班级编号";
                        columns[CLASS_ID].Visible = true;

                        columns[CLASS_NAME].HeaderText = "班级";
                        columns[CLASS_NAME].Visible = true;
                    }
                    break;
                case 2: // 考试类型
                    {
                        columns[TYPE_ID].HeaderText = "类型ID";

                        columns[TYPE_NAME].HeaderText = "考试类型";
                        columns[TYPE_NAME].Visible = true;

                        columns[COURSE_NAME].HeaderText = "课程名";
                        columns[COURSE_NAME].Visible = true;

                        columns[COURSE_NEWID].HeaderText = "课程编号";

                        columns[COURSE_ID].HeaderText = "章节编号";

                        columns[PASSAGE].HeaderText = "章节";
                        columns[PASSAGE].Visible = true;
                    }
                    break;
            }

        }

        /// <summary>
        /// 行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            Rectangle rectangle = new Rectangle(e.RowBounds.Location.X,
                e.RowBounds.Location.Y,
                gridView.RowHeadersWidth,
                e.RowBounds.Height);

            TextRenderer.DrawText(e.Graphics, (e.RowIndex + 1).ToString(),
                gridView.RowHeadersDefaultCellStyle.Font,
                rectangle,
                gridView.RowHeadersDefaultCellStyle.ForeColor,
                TextFormatFlags.VerticalCenter | TextFormatFlags.Right);
        }

        /// <summary>
        /// 数据反映到Grid
        /// </summary>
        /// <param name="mode"></param>
        private void ShowDataToGrid(int mode)
        {
            // 创建DataTable
            DataTable table = CreateTable(mode);

            // 查询
            string errMsg = string.Empty;
            DataWork param = new DataWork();
            List<DataWork> retList = new List<DataWork>();
            int status = -1;
            switch (mode)
            {
                case 0: // 班级
                    {
                        status = _dataAccess.GetClassInfo(param, out retList, out errMsg);

                        if (status == 0)
                        {
                            foreach (DataWork work in retList)
                            {
                                DataRow dr = table.NewRow();
                                dr[CLASS_ID] = work.ClassID;
                                dr[CLASS_NAME] = work.ClassName;

                                table.Rows.Add(dr);
                            }
                        }
                    }
                    break;
                case 1: // 学生
                    {
                        status = _dataAccess.GetStuInfo(param, out retList, out errMsg);

                        if (status == 0)
                        {
                            foreach (DataWork work in retList)
                            {
                                DataRow dr = table.NewRow();
                                dr[STU_ID] = work.StuID;
                                dr[STU_NAME] = work.StuName;
                                dr[CLASS_ID] = work.ClassID;
                                dr[CLASS_NAME] = work.ClassName;

                                table.Rows.Add(dr);
                            }
                        }
                    }
                    break;
                case 2: // 考试类型
                    {
                        status = _dataAccess.GetExamTypeInfo(param, out retList, out errMsg);

                        if (status == 0)
                        {
                            foreach (DataWork work in retList)
                            {
                                DataRow dr = table.NewRow();
                                dr[TYPE_ID] = work.ExamTypeID;
                                string typeName = string.Empty;

                                Dictionary<string, string> examDic = DataWork.GetExamType();
                                if (examDic.ContainsKey(work.ExamTypeID.ToString()))
                                {
                                    typeName = examDic[work.ExamTypeID.ToString()];
                                }
                                dr[TYPE_NAME] = typeName;
                                dr[COURSE_NEWID] = work.CourseNewID;

                                if (work.ExamTypeID == 1)
                                {
                                    dr[COURSE_NAME] = work.CourseNewName;
                                }
                                else
                                {
                                    dr[COURSE_NAME] = "-";
                                }
                                dr[COURSE_ID] = work.CourseID;
                                dr[PASSAGE] = work.CourseName;

                                table.Rows.Add(dr);
                            }
                        }
                    }
                    break;
            }

            tb_DataCount.Text = "共有 " + retList.Count.ToString("#,##0") + " 条数据";

            this.gridView.DataSource = table;
            GridViewRowColor(gridView);
            SetToolButton();
        }

        private void SetToolButton()
        {
            if (this.gridView.Rows.Count > 0)
            {
                this.btn_Modify.Enabled = true;
                this.btn_Delete.Enabled = true;
            }
            else
            {
                this.btn_Modify.Enabled = false;
                this.btn_Delete.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tb_DataCount_TextChanged(object sender, EventArgs e)
        {
            Graphics g = this.tb_DataCount.CreateGraphics();
            System.Drawing.SizeF s = g.MeasureString(this.tb_DataCount.Text, this.tb_DataCount.Font);

            this.tb_DataCount.Width = (int)s.Width + 3;
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

        /// <summary>
        /// 创建DataTable
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        private DataTable CreateTable(int mode)
        {
            DataTable table = new DataTable();
            switch (mode)
            {
                case 0: // 班级
                    {
                        DataColumn column1 = new DataColumn(CLASS_ID, typeof(string));
                        column1.Caption = "班级编号";
                        table.Columns.Add(column1);

                        DataColumn column2 = new DataColumn(CLASS_NAME, typeof(string));
                        column2.Caption = "班级";
                        table.Columns.Add(column2);
                    }
                    break;
                case 1: // 学生
                    {
                        DataColumn column1 = new DataColumn(STU_ID, typeof(string));
                        column1.Caption = "学号";
                        table.Columns.Add(column1);

                        DataColumn column2 = new DataColumn(STU_NAME, typeof(string));
                        column2.Caption = "姓名";
                        table.Columns.Add(column2);

                        DataColumn column3 = new DataColumn(CLASS_ID, typeof(string));
                        column3.Caption = "班级编号";
                        table.Columns.Add(column3);

                        DataColumn column4 = new DataColumn(CLASS_NAME, typeof(string));
                        column4.Caption = "班级";
                        table.Columns.Add(column4);
                    }
                    break;
                case 2: // 考试类型
                    {
                        DataColumn column1 = new DataColumn(TYPE_ID, typeof(Int32));
                        column1.Caption = "类型编号";
                        table.Columns.Add(column1);

                        DataColumn column2 = new DataColumn(TYPE_NAME, typeof(string));
                        column2.Caption = "考试类型";
                        table.Columns.Add(column2);

                        DataColumn column3 = new DataColumn(COURSE_NEWID, typeof(Int32));
                        column3.Caption = "课程编号";
                        table.Columns.Add(column3);

                        DataColumn column4 = new DataColumn(COURSE_NAME, typeof(string));
                        column4.Caption = "课程名";
                        table.Columns.Add(column4);

                        DataColumn column5 = new DataColumn(COURSE_ID, typeof(Int32));
                        column5.Caption = "章节编号";
                        table.Columns.Add(column5);

                        DataColumn column6 = new DataColumn(PASSAGE, typeof(string));
                        column6.Caption = "章节";
                        table.Columns.Add(column6);
                    }
                    break;
            }

            return table;
        }

        /// <summary>
        /// 双击行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
            {
                return;
            }

            int cellRowIndex = e.RowIndex;
            DataWork dataWork = GetSelectedData(_mode, cellRowIndex);
            AddModifyData(_mode, dataWork, cellRowIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            this._selectedRowIndex = e.RowIndex;
        }

        /// <summary>
        /// 获得选择行数据
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="rowIndex"></param>
        /// <returns></returns>
        private DataWork GetSelectedData(int mode, int rowIndex)
        {
            if (rowIndex < 0)
            {
                return null;
            }

            DataWork dataWork = new DataWork();
            int cellRowIndex = rowIndex;

            string classID = string.Empty;
            string className = string.Empty;
            string stuID = string.Empty;
            string stuName = string.Empty;
            int typeID = 0;
            int courseNewID = 0;
            int courseID = 0;
            string passage = string.Empty;

            switch (_mode)
            {
                case 0: // 班级
                    {
                        classID = gridView.Rows[cellRowIndex].Cells[CLASS_ID].Value.ToString();
                        className = gridView.Rows[cellRowIndex].Cells[CLASS_NAME].Value.ToString();

                        dataWork.ClassID = classID;
                        dataWork.ClassName = className;
                    }
                    break;
                case 1: // 学生
                    {
                        stuID = gridView.Rows[cellRowIndex].Cells[STU_ID].Value.ToString();
                        stuName = gridView.Rows[cellRowIndex].Cells[STU_NAME].Value.ToString();
                        classID = gridView.Rows[cellRowIndex].Cells[CLASS_ID].Value.ToString();
                        className = gridView.Rows[cellRowIndex].Cells[CLASS_NAME].Value.ToString();

                        dataWork.StuID = stuID;
                        dataWork.StuName = stuName;
                        dataWork.ClassID = classID;
                        dataWork.ClassName = className;
                    }
                    break;
                case 2: // 考试类型
                    {
                        typeID = (int)gridView.Rows[cellRowIndex].Cells[TYPE_ID].Value;
                        courseNewID = (int)gridView.Rows[cellRowIndex].Cells[COURSE_NEWID].Value;
                        courseID = (int)gridView.Rows[cellRowIndex].Cells[COURSE_ID].Value;
                        passage = gridView.Rows[cellRowIndex].Cells[PASSAGE].Value.ToString();

                        dataWork.ExamTypeID = typeID;
                        dataWork.CourseNewID = courseNewID;
                        dataWork.CourseID = courseID;
                        dataWork.CourseName = passage;
                    }
                    break;
            }

            return dataWork;
        }

        /// <summary>
        /// 创建新数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            AddModifyData(_mode, null, -1);
        }

        /// <summary>
        /// 创建或者修改数据
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="work"></param>
        /// <param name="index"></param>
        private void AddModifyData(int mode, DataWork work, int index)
        {
            switch (mode)
            {
                case 0: // 班级
                    {
                        ClassOpt classOpt = new ClassOpt(work, index);
                        classOpt.UnDisplaying += new UnDisplayEventHandler(Undisplaying);
                        classOpt.ShowDialog();
                    }
                    break;
                case 1: // 学生
                    {
                        StuOpt stuOpt = new StuOpt(work, index);
                        stuOpt.UnDisplaying += new UnDisplayEventHandler(Undisplaying);
                        stuOpt.ShowDialog();
                    }
                    break;
                case 2: // 考试类型
                    {
                        ExamOpt examOpt = new ExamOpt(work, index);
                        examOpt.UnDisplaying += new UnDisplayEventHandler(Undisplaying);
                        examOpt.ShowDialog();
                    }
                    break;
            }
        }

        /// <summary>
        /// 数据显示Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Undisplaying(object sender, EventArgs e)
        {
            ShowDataToGrid(_mode);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            DataWork dataWork = GetSelectedData(_mode, _selectedRowIndex);
            AddModifyData(_mode, dataWork, _selectedRowIndex);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (_selectedRowIndex >= 0 && MessageBox.Show(this, "您确定要删除当前行吗？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                DataWork dataWork = GetSelectedData(_mode, _selectedRowIndex);
                int status = DeleteData(dataWork, _mode);
                if (status == 0)
                {
                    MessageBox.Show(this, "数据删除成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    ShowDataToGrid(_mode);
                }
                else
                {
                    MessageBox.Show(this, "数据删除失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dataWork"></param>
        /// <param name="mode"></param>
        /// <returns></returns>
        private int DeleteData(DataWork dataWork, int mode)
        {
            int status = -1;
            string errMessage = string.Empty;
            switch (mode)
            {
                case 0: // 班级
                    {
                        status = _dataAccess.DeleteClass(dataWork, out errMessage);
                    }
                    break;
                case 1: // 学生
                    {
                        status = _dataAccess.DeleteStu(dataWork, out errMessage);
                    }
                    break;
                case 2: // 考试类型
                    {
                        status = _dataAccess.DeleteExamType(dataWork, out errMessage);
                    }
                    break;
            }

            return status;
        }
    }
}

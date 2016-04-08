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
    public partial class ExamOpt : Form, IFormOpreation
    {
        private DataAccess _dataAccess;
        private DataWork _examTypeInfo;
        private int _index = -1;

        public event UnDisplayEventHandler UnDisplaying;

        public ExamOpt(DataWork examTypeInfo, int index)
        {
            InitializeComponent();

            _dataAccess = new DataAccess();
            _examTypeInfo = examTypeInfo;
            _index = index;
        }

        private void ExamOpt_Load(object sender, EventArgs e)
        {
            // 类型取得
            Dictionary<string, string> examDic = DataWork.GetExamType();
            foreach (KeyValuePair<string, string> pair in examDic)
            {
                this.comboBox_Type.Items.Add(new ListItem(pair.Key, pair.Value));
            }

            // 课程取得
            string errMsg = string.Empty;
            DataWork param = new DataWork();
            List<DataWork> courseInfoList = null;
            int status = _dataAccess.GetCourseInfo(param, out courseInfoList, out errMsg);

            if (status == 0 && courseInfoList.Count > 0)
            {
                foreach (DataWork courseInfo in courseInfoList)
                {
                    this.comboBox_Course.Items.Add(new ListItem(courseInfo.CourseID.ToString(), courseInfo.CourseName));
                }
            }
            if (this.comboBox_Course.Items.Count > 0)
            {
                this.comboBox_Course.SelectedIndex = 0;
            }

            DataToScreen(_examTypeInfo);
        }

        private void DataToScreen(DataWork examTypeInfo)
        {
            Clear();

            if (_index >= 0)
            {
                this.comboBox_Type.SelectedIndex = examTypeInfo.ExamTypeID;
                this.tb_Course.Text = examTypeInfo.CourseName;
                switch (this.comboBox_Type.SelectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        this.comboBox_Course.SelectedValue = examTypeInfo.CourseNewID;
                        break;
                }

                this.comboBox_Type.Enabled = false;
                this.comboBox_Course.Enabled = false;
                this.tb_Course.Focus();
            }
            else
            {
                this.comboBox_Type.Focus();
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DataWork examTypeInfo = new DataWork();
            examTypeInfo.ExamTypeID = this.comboBox_Type.SelectedIndex;
            examTypeInfo.CourseNewID = this.comboBox_Course.SelectedIndex + 1;

            examTypeInfo.CourseName = this.tb_Course.Text.Trim();
            if (_index >= 0)
            {
                examTypeInfo.CourseID = this._examTypeInfo.CourseID;
            }

            if (InputCheck(examTypeInfo) != 0)
            {
                MessageBox.Show(this, "请输入章节！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.tb_Course.Focus();
                return;
            }

            string message = string.Empty;
            int status = _dataAccess.WriteExamType(examTypeInfo, out message);

            if (status == 0)
            {
                MessageBox.Show(this, "章节设置成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tb_Course.Clear();
                this.tb_Course.Focus();

                if (UnDisplaying != null)
                {
                    UnDisplaying(this, null);
                }

                if (_index< 0)
                {
                    return;
                }
                else
                {
                    this.Close();
                }
            }
            else if (status == 1)
            {
                MessageBox.Show(this, "该章节已经存在！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tb_Course.Clear();
                this.tb_Course.Focus();
                return;
            }
            else
            {
                MessageBox.Show(this, "章节设置失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.tb_Course.Focus();
                return;
            }
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBox_Type.SelectedIndex)
            {
                case 0:
                    this.label_Mark.Visible = false;
                    this.comboBox_Course.Visible = false;
                    break;
                case 1:
                    this.label_Mark.Visible = true;
                    this.comboBox_Course.Visible = true;
                    break;
            }
        }

        public void Clear()
        {
            this.comboBox_Type.SelectedIndex = 0;
            this.tb_Course.Clear();
        }

        public int InputCheck(DataWork param)
        {
            int status = -1;

            if (string.IsNullOrEmpty(param.CourseName))
            {
                status = -1;
            }
            else
            {
                status = 0;
            }

            return status;
        }
    }
}

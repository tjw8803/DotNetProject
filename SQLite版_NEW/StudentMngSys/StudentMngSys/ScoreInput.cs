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
    public partial class ScoreInput : Form
    {
        private DataAccess _dataAccess;
        private bool _formLoaded = false;

        public ScoreInput()
        {
            InitializeComponent();

            _dataAccess = new DataAccess();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            int examType = this.comboBox_Type.SelectedIndex;
            //章节编号
            int courseID = 1;
            ListItem liPassage = (ListItem)this.comboBox_Course.SelectedItem;
            Int32.TryParse(liPassage.Key, out courseID);
            //课程
            int courseNewID = 1;
            ListItem liCourse = (ListItem)this.comboBox_CourName.SelectedItem;
            if (liCourse != null)
            {
                Int32.TryParse(liCourse.Key, out courseNewID);
            }
            //班级
            ListItem liClass = (ListItem)this.comboBox_Class.SelectedItem;
            string classID = liClass.Key;
            DateTime examDate = this.dateTimePicker1.Value;

            #region Log
            string tips = string.Format("{0}-{1}-{2}", this.comboBox_Type.SelectedItem, this.comboBox_CourName.SelectedItem, 
                this.comboBox_Class.SelectedItem);
            #endregion

            StartInputScore startIpnut = new StartInputScore(examType, courseNewID, courseID, classID, examDate);
            startIpnut.ClassName = this.comboBox_Class.SelectedItem.ToString();
            startIpnut.CourseName = this.comboBox_CourName.SelectedItem == null ? "XXXXX" : this.comboBox_CourName.SelectedItem.ToString();
            this.Hide();
            if (startIpnut.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
            {
                this.Show();
            }
        }

        private void ScoreInput_Load(object sender, EventArgs e)
        {
            // 类型取得
            Dictionary<string, string> examDic = DataWork.GetExamType();
            foreach (KeyValuePair<string, string> pair in examDic)
            {
                this.comboBox_Type.Items.Add(new ListItem(pair.Key, pair.Value));
            }
            this.comboBox_Type.SelectedIndex = 0;

            // 班级取得
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
            }
            if (this.comboBox_Class.Items.Count > 0)
            {
                this.comboBox_Class.SelectedIndex = 0;
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
                    this.comboBox_CourName.Items.Add(new ListItem(courseInfo.CourseID.ToString(), courseInfo.CourseName));
                }
            }

            _formLoaded = true;
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBox_Course.Enabled = true;

            switch (this.comboBox_Type.SelectedIndex)
            {
                case 0:
                    {
                        this.label_Mark.Visible = false;
                        this.comboBox_CourName.Visible = false;

                        // 章节取得
                        GetCourseInfo();
                    }
                    break;
                case 1:
                    {
                        this.label_Mark.Visible = true;
                        this.comboBox_CourName.Visible = true;

                        if (this.comboBox_CourName.Items.Count > 0)
                        {
                            this.comboBox_CourName.SelectedIndex = 0;
                        }
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
            comboBox_Course.Items.Clear();
            string errMsg = string.Empty;
            DataWork param = new DataWork();
            param.ExamTypeID = this.comboBox_Type.SelectedIndex;
            if (this.comboBox_Type.SelectedIndex == 1)
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
            else
            {
                Dictionary<string, string> examDic = DataWork.GetExamType();
                string tips = "章节没有设置，请先设置章节！";
                string dicValue = examDic[this.comboBox_Type.SelectedIndex.ToString()];
                string message = dicValue + tips;
                if (this.comboBox_Type.SelectedIndex == 1)
                {
                    message = this.comboBox_CourName.SelectedItem + tips;
                }
                MessageBox.Show(this, message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                if (!_formLoaded)
                {
                    this.Close();
                }
                else
                {
                    this.comboBox_Type.SelectedIndex = 0;
                }
            }
        }

        private void ScoreInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show(this, "是否停止成绩录入？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        private void ScoreInput_FormClosed(object sender, FormClosedEventArgs e)
        {
        }
    }
}

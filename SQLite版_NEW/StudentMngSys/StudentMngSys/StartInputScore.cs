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
    public partial class StartInputScore : Form, IFormOpreation
    {
        private DataAccess _dataAccess;
        private string _orgStuID = string.Empty;
        private DataWork _stuInfo;

        private int _examType;
        private int _courseNewID;
        private int _courseID;
        private string _classID;
        private DateTime _examDate = DateTime.MinValue;

        public string CourseName { set; get; }
        public string ClassName { set; get; }

        public event UnDisplayEventHandler UnDisplaying;

        public StartInputScore(int examType, int courseNewID, int courseID, string classID, DateTime date)
        {
            InitializeComponent();

            _examType = examType;
            _courseNewID = courseNewID;
            _courseID = courseID;
            _classID = classID;
            _examDate = date;

            if (_examType == 0)
            {
                this.panel_ReTest.Enabled = true;
            }

            _dataAccess = new DataAccess();
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StartInputScore_Load(object sender, EventArgs e)
        {
            this.tb_ClassName.Text = ClassName;
            this.tb_CourseName.Text = CourseName;
            this.dateTimePicker1.Value = _examDate;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            _stuInfo = null;
            string stuID = this.tb_StuID.Text.Trim();
            if (_orgStuID != stuID)
            {
                _orgStuID = stuID;
                DataWork param = new DataWork();
                param.StuID = stuID;
                param.SearchScoreByStuID = true;
                param.ClassID = _classID;
                param.ExamTypeID = _examType;
                param.CourseNewID = _courseNewID;
                param.CourseID = _courseID;
                param.ExamDate = _examDate;
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

                        List<DataWork> scoreInfoList = null;
                        status = _dataAccess.GetScoreInfo(param, out scoreInfoList, out errMsg);
                        if (status == 0 && scoreInfoList.Count > 0)
                        {
                            DataWork scoreInfo = scoreInfoList[0];
                            this.tb_Score.Text = scoreInfo.Score.ToString();
                            this.tb_Score2.Text = scoreInfo.Score2.ToString();
                            this.checkBox1.Checked = scoreInfo.TestAgain == 0 ? false : true;
                        }
                        else
                        {
                            this.tb_Score.Clear();
                            this.tb_Score2.Clear();
                            this.checkBox1.Checked = false;
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "该学生未登录或不属于该班级！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        _orgStuID = string.Empty;
                        Clear();
                        this.tb_StuID.Focus();
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (sender is TextBox && 
                    (
                    ((TextBox)sender).Name == "tb_Score2" || 
                    (((TextBox)sender).Name == "tb_Score" && !this.panel_ReTest.Enabled)
                    ))
                {
                    Save();
                }
                else
                {
                    SendKeys.Send("{tab}");
                }
            }
        }

        private void Save()
        {  
            //保存
            DataWork param = new DataWork();
            param.StuID = this.tb_StuID.Text.Trim();
            param.ClassID = _classID;
            param.ExamTypeID = _examType;
            param.CourseNewID = _courseNewID;
            param.CourseID = _courseID;
            double scoure = 0;
            double.TryParse(this.tb_Score.Text.Trim(), out scoure);
            param.Score = scoure;
            param.Pass = scoure < 60 ? 1 : 0;
            double scoure2 = 0;
            param.TestAgain = this.checkBox1.Checked ? 1 : 0;
            double.TryParse(this.tb_Score2.Text.Trim(), out scoure2);
            param.Score2 = scoure2;
            param.ExamDate = _examDate;

            //输入检查
            int status = InputCheck(param);
            if (status == 1)
            {
                MessageBox.Show(this, "请输入学号！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.tb_StuID.Focus();
                return;
            }
            else if (status == 2)
            {
                MessageBox.Show(this, "请勾上已补考！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.checkBox1.Focus();
                return;
            }

            #region Log
            string tips = string.Format("{0}:{1}", this.tb_StuName.Text, this.tb_Score.Text);
            #endregion

            string errMsg = string.Empty;
            status = _dataAccess.WriteScore(param, out errMsg);

            if (status == 0)
            {
                MessageBox.Show(this, "学生成绩登录成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Clear();
                this._orgStuID = string.Empty;
                this.tb_StuID.Focus();
                return;
            }
            else
            {
                MessageBox.Show(this, "学生成绩登录失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.tb_Score.Clear();
                this.tb_Score.Focus();
                return;
            }
        }

        private void StartInputScore_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (MessageBox.Show(this, "是否停止成绩录入？", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }

        public void Clear()
        {
            this.tb_StuID.Clear();
            this.tb_StuName.Clear();
            this.tb_Score.Clear();
            this.tb_Score2.Clear();
            this.checkBox1.Checked = false;
        }

        public int InputCheck(DataWork param)
        {
            int status = -1;

            if (string.IsNullOrEmpty(param.StuID))
            {
                status = 1;
            }
            else if (param.Score2 > 0 && !this.checkBox1.Checked)
            {
                status = 2;
            }
            else
            {
                status = 0;
            }

            return status;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}

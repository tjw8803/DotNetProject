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
    public partial class ClassOpt : Form, IFormOpreation
    {
        private DataAccess _dataAccess;
        private DataWork _classInfo;
        private int _index = -1;

        public event UnDisplayEventHandler UnDisplaying;

        public ClassOpt(DataWork classInfo, int index)
        {
            InitializeComponent();

            _dataAccess = new DataAccess();
            _classInfo = classInfo;
            _index = index;
        }

        private void ClassOpt_Load(object sender, EventArgs e)
        {
            DataToScreen(_classInfo);
        }

        private void DataToScreen(DataWork classInfo)
        {
            Clear();

            if (_index >= 0)
            {
                this.tb_ClassID.Text = _classInfo.ClassID;
                this.tb_ClassName.Text = _classInfo.ClassName;

                this.tb_ClassID.Enabled = false;
                this.tb_ClassName.Focus();
            }
            else
            {
                this.tb_ClassID.Focus();
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string classID = this.tb_ClassID.Text.Trim();
            string className = this.tb_ClassName.Text.Trim();

            DataWork param = new DataWork();
            param.ClassID = classID;
            param.ClassName = className;

            //输入检查
            int status = InputCheck(param);
            if (status == 1)
            {
                MessageBox.Show(this, "请输入班级编号！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.tb_ClassID.Focus();
                return;
            }
            else if (status == 2)
            {
                MessageBox.Show(this, "请输入班级名称！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.tb_ClassName.Focus();
                return;
            }

            if (status == 0)
            {
                string errMsg = string.Empty;
                status = _dataAccess.WriteClass(param, out errMsg);

                if (status == 0)
                {
                    MessageBox.Show(this, "班级设置成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    this.tb_ClassID.Enabled = true;
                    this.tb_ClassID.Focus();

                    if (UnDisplaying != null)
                    {
                        UnDisplaying(this, null);
                    }

                    if (_index < 0)
                    {
                        return;
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show(this, "班级设置失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.tb_ClassName.Focus();
                    return;
                }
            }


        }

        public void Clear()
        {
            this.tb_ClassID.Clear();
            this.tb_ClassName.Clear();
        }

        public int InputCheck(DataWork param)
        {
            int status = -1;

            if (string.IsNullOrEmpty(param.ClassID))
            {
                status = 1;
            }
            else if (string.IsNullOrEmpty(param.ClassName))
            {
                status = 2;
            }
            else
            {
                status = 0;
            }

            return status;
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tb_ClassID_Leave(object sender, EventArgs e)
        {
            _classInfo = null;
            string classID = this.tb_ClassID.Text.Trim();
            if (!string.IsNullOrEmpty(classID))
            {
                string errMsg = string.Empty;
                DataWork param = new DataWork();
                param.ClassID = classID;
                List<DataWork> classInfoList = null;
                int status = _dataAccess.GetClassInfo(param, out classInfoList, out errMsg);

                if (status == 0 && classInfoList.Count > 0)
                {
                    _classInfo = classInfoList[0];
                    this.tb_ClassID.Text = _classInfo.ClassID;
                    this.tb_ClassName.Text = _classInfo.ClassName;

                    this.tb_ClassID.Enabled = false;
                }
                else
                {
                    this.tb_ClassName.Clear();
                    _classInfo = null;
                }
            }
        }

        private void tb_ClassID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendKeys.Send("{tab}");
            }
        }
    }
}

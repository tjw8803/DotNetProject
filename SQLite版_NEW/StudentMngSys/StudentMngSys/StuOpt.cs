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
    public partial class StuOpt : Form, IFormOpreation
    {
        private DataAccess _dataAccess;
        private DataWork _stuInfo;
        private string _orgStuID = string.Empty;
        private int _index = -1;

        public event UnDisplayEventHandler UnDisplaying;

        public StuOpt(DataWork stuInfo, int index)
        {
            InitializeComponent();

            _dataAccess = new DataAccess();
            _stuInfo = stuInfo;
            _index = index;
        }

        private void StuOpt_Load(object sender, EventArgs e)
        {
            InitScreen();
        }

        private void InitScreen()
        {
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

            DataToScreen(_stuInfo);
        }

        private void DataToScreen(DataWork stuInfo)
        {
            Clear();

            if (_index >= 0)
            {
                this.tb_StuID.Text = _stuInfo.StuID;
                this.tb_StuName.Text = _stuInfo.StuName;
                this.comboBox_Class.SelectedItem = ListItem.FindByKey(this.comboBox_Class, _stuInfo.ClassID);

                this.tb_StuID.Enabled = false;

                this.tb_StuID.Focus();
            }
            else
            {
                this.tb_StuName.Focus();
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            string stuID = this.tb_StuID.Text.Trim();
            string stuName = this.tb_StuName.Text.Trim();

            DataWork param = new DataWork();
            param.StuID = stuID;
            param.StuName = stuName;
            ListItem li = (ListItem)this.comboBox_Class.SelectedItem;
            param.ClassID = li.Key;

            //输入检查
            int status = InputCheck(param);
            if (status == 1)
            {
                MessageBox.Show(this, "请输入学号！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.tb_StuID.Enabled = true;
                this.tb_StuID.Focus();
                return;
            }
            else if (status == 2)
            {
                MessageBox.Show(this, "请输入姓名！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.tb_StuName.Focus();
                return;
            }

            if (status == 0)
            {
                string errMsg = string.Empty;

                status = _dataAccess.WriteStu(param, out errMsg);

                if (status == 0)
                {
                    MessageBox.Show(this, "学生设置成功！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                    this.tb_StuID.Enabled = true;
                    this.tb_StuID.Focus();

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
                    MessageBox.Show(this, "学生设置失败！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.tb_StuID.Focus();
                    return;
                }
            }
        }

        private void btn_Cancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Clear()
        {
            _orgStuID = string.Empty;
            this.tb_StuID.Clear();
            this.tb_StuName.Clear();
            this.tb_StuID.Enabled = true;
        }

        public int InputCheck(DataWork param)
        {
            int status = -1;

            if (string.IsNullOrEmpty(param.StuID))
            {
                status = 1;
            }
            else if (string.IsNullOrEmpty(param.StuName))
            {
                status = 2;
            }
            else
            {
                status = 0;
            }

            return status;
        }

        private void tb_StuID_Leave(object sender, EventArgs e)
        {
            _stuInfo = null;
            ListItem li = (ListItem)this.comboBox_Class.SelectedItem;
            string classID = li.Key;
            string stuID = this.tb_StuID.Text.Trim();
            DataWork param = new DataWork();
            param.StuID = stuID;
            param.ClassID = classID;
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
                    this.comboBox_Class.SelectedItem = ListItem.FindByKey(this.comboBox_Class, _stuInfo.ClassID);

                    this.tb_StuID.Enabled = false;
                }
                else
                {
                    this.tb_StuName.Clear();
                    _stuInfo = null;
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

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            InitScreen();
            MessageBox.Show(this, "已取得最新数据！", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TJWUIData;

namespace TJWForms
{
    public partial class PopupApplication : Form
    {
        private List<DataWork> _dataList;

        public PopupApplication()
        {
            InitializeComponent();

            _dataList = GetDataList();
        }

        private List<DataWork> GetDataList()
        {
            List<DataWork> stList = new List<DataWork>();
            stList.Add(new DataWork() { StuID = "1", StuName = "张阳" });
            stList.Add(new DataWork() { StuID = "2", StuName = "欧阳新文" });
            stList.Add(new DataWork() { StuID = "3", StuName = "宇文化及" });
            stList.Add(new DataWork() { StuID = "4", StuName = "温斯特梅拉" });
            stList.Add(new DataWork() { StuID = "6", StuName = "唐兵" });
            stList.Add(new DataWork() { StuID = "8", StuName = "杨红军" });
            
            return stList;
        }

        private void PopupApplication_Load(object sender, EventArgs e)
        {
            this.skinDataGridView1.DataSource = _dataList;
        }

        private void skinTextBox1_SkinTxt_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.skinTextBox1.Text))
            {
                return;
            }

            var resultList = _dataList.FindAll(std => std.StuID.Contains(skinTextBox1.Text) || std.StuName.Contains(skinTextBox1.Text));
            skinDataGridView1.DataSource = resultList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TJWCommon;

namespace TJWForms
{
    public partial class StudentMngSys : Form
    {
        private Color activeBgColor = Color.FromArgb(212, 170, 255);
        private DataAccess _dataAccess;
        private Point _treeNotePi;

        public StudentMngSys()
        {
            InitializeComponent();

            _dataAccess = new DataAccess();
        }

        private void StudentMngSys_Load(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void toolStripButton_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_InitOpt_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
        }

        private void btn_ScoreOpt_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
        }

        private void btn_ScoreInput_Click(object sender, EventArgs e)
        {
            ScoreInput input = new ScoreInput();
            input.Show();
        }

        private void btn_ScoreTotal_Click(object sender, EventArgs e)
        {
            ScoreTotal total = new ScoreTotal();
            total.Show();
        }

        private void toolStripButton_About_Click(object sender, EventArgs e)
        {
            AboutForm about = new AboutForm();
            about.Show();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case 0:
                    {
                        btn_InitOpt.BackColor = activeBgColor;
                        btn_ScoreOpt.BackColor = Color.Transparent;

                        // 初始设定
                        BindTreeView();
                    }
                    break;
                case 1:
                    {
                        btn_ScoreOpt.BackColor = activeBgColor;
                        btn_InitOpt.BackColor = Color.Transparent;
                    }
                    break;
            }
        }

        private void BindTreeView()
        {
            treeView1.Nodes.Clear();
            treeView1.LabelEdit = false;//不可编辑
            //添加结点
            TreeNode root = new TreeNode();
            root.Text = "初始设定";
            //一级
            TreeNode node1 = new TreeNode();
            node1.Text = "班级设定";
            TreeNode node2 = new TreeNode();
            node2.Text = "学生设定";
            TreeNode node3 = new TreeNode();
            node3.Text = "※已停用"; 
            TreeNode node4 = new TreeNode();
            node4.Text = "学年设定";
            //一级加入根
            root.Nodes.Add(node1);
            root.Nodes.Add(node2);
            root.Nodes.Add(node3);
            root.Nodes.Add(node4);
            //
            treeView1.Nodes.Add(root);
            this.treeView1.ExpandAll();
        }

        private void timer_Datetime_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        }

        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            _treeNotePi = new Point(e.X, e.Y);
        }

        private void treeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode node = this.treeView1.GetNodeAt(_treeNotePi);
            if (_treeNotePi.X < node.Bounds.Left || _treeNotePi.X > node.Bounds.Right)
            {
                return;
            }
            else
            {
                // 章节设定删除
                if (node.Index != 2)
                {
                    TabPageComp comp = new TabPageComp(node.Index);
                    AddTabControl(node, this.tabControl2, comp);
                }
            }	 
        }

        private void AddTabControl(TreeNode node, TabControl objTabControl, TabPageComp objfrm)
        {
            try
            {
                string pageName = "tabPage" + node.Index;
                if (ErgodicModiForm(pageName, objTabControl))
                {
                    //声明一个选项卡对象
                    TabPage tabPage = new TabPage();
                    //选项卡的名称
                    tabPage.Name = pageName;
                    //选项卡的文本
                    tabPage.Text = node.Text;
                    tabPage.TabIndex = node.Index;
                    tabPage.BackColor = Color.Lavender;
                    //向选项卡集合添加新选项卡
                    objTabControl.Controls.Add(tabPage);
                    //子窗体大小设置为选项卡大小
                    objfrm.Size = tabPage.Size;
                    objfrm.Text = node.Text;
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

        private void btn_ScoreTotalChart_Click(object sender, EventArgs e)
        {
            ScoreTotalChart chart = new ScoreTotalChart();
            chart.Show();
        }

        private void btn_Total2_Click(object sender, EventArgs e)
        {
            ScoreTotal2 total = new ScoreTotal2();
            total.Show();
        }
    }
}

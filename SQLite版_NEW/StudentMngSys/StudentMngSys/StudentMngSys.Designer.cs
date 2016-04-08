namespace TJWForms
{
    partial class StudentMngSys
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentMngSys));
            this.panel_All = new System.Windows.Forms.Panel();
            this.panel_Full = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tabControl2 = new TJWForms.MyTabControl();
            this.panel_Left2 = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ScoreTotalChart = new System.Windows.Forms.Button();
            this.btn_ScoreInput = new System.Windows.Forms.Button();
            this.btn_ScoreTotal = new System.Windows.Forms.Button();
            this.panel_Left = new System.Windows.Forms.Panel();
            this.panel_ScoreInput = new System.Windows.Forms.Panel();
            this.btn_ScoreOpt = new System.Windows.Forms.Button();
            this.panel_Opt = new System.Windows.Forms.Panel();
            this.btn_InitOpt = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_About = new System.Windows.Forms.ToolStripButton();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer_Datetime = new System.Windows.Forms.Timer(this.components);
            this.panel_All.SuspendLayout();
            this.panel_Full.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel_Left2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel_Left.SuspendLayout();
            this.panel_ScoreInput.SuspendLayout();
            this.panel_Opt.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel_Bottom.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_All
            // 
            this.panel_All.BackColor = System.Drawing.Color.Lavender;
            this.panel_All.Controls.Add(this.panel_Full);
            this.panel_All.Controls.Add(this.panel_Left);
            this.panel_All.Controls.Add(this.toolStrip1);
            this.panel_All.Controls.Add(this.panel_Bottom);
            this.panel_All.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_All.Location = new System.Drawing.Point(0, 0);
            this.panel_All.Margin = new System.Windows.Forms.Padding(4);
            this.panel_All.Name = "panel_All";
            this.panel_All.Size = new System.Drawing.Size(774, 521);
            this.panel_All.TabIndex = 0;
            // 
            // panel_Full
            // 
            this.panel_Full.Controls.Add(this.tabControl1);
            this.panel_Full.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Full.Location = new System.Drawing.Point(150, 25);
            this.panel_Full.Name = "panel_Full";
            this.panel_Full.Size = new System.Drawing.Size(624, 470);
            this.panel_Full.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(624, 470);
            this.tabControl1.TabIndex = 3;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Lavender;
            this.tabPage1.Controls.Add(this.panel6);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(616, 441);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "初始设定";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.tabControl2);
            this.panel6.Controls.Add(this.panel_Left2);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(3, 3);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(610, 435);
            this.panel6.TabIndex = 2;
            // 
            // tabControl2
            // 
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl2.ItemSize = new System.Drawing.Size(90, 25);
            this.tabControl2.Location = new System.Drawing.Point(123, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(485, 433);
            this.tabControl2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl2.TabIndex = 1;
            // 
            // panel_Left2
            // 
            this.panel_Left2.Controls.Add(this.treeView1);
            this.panel_Left2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Left2.Location = new System.Drawing.Point(0, 0);
            this.panel_Left2.Name = "panel_Left2";
            this.panel_Left2.Size = new System.Drawing.Size(123, 433);
            this.panel_Left2.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.Lavender;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(123, 433);
            this.treeView1.TabIndex = 0;
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDoubleClick);
            this.treeView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeView1_MouseDown);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Lavender;
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(616, 441);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "成绩录入";
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.btn_ScoreTotalChart);
            this.panel3.Controls.Add(this.btn_ScoreInput);
            this.panel3.Controls.Add(this.btn_ScoreTotal);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(610, 435);
            this.panel3.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Location = new System.Drawing.Point(130, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 2);
            this.label3.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Location = new System.Drawing.Point(130, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(2, 109);
            this.label2.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(209, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 2);
            this.label1.TabIndex = 4;
            // 
            // btn_ScoreTotalChart
            // 
            this.btn_ScoreTotalChart.Image = ((System.Drawing.Image)(resources.GetObject("btn_ScoreTotalChart.Image")));
            this.btn_ScoreTotalChart.Location = new System.Drawing.Point(353, 224);
            this.btn_ScoreTotalChart.Name = "btn_ScoreTotalChart";
            this.btn_ScoreTotalChart.Size = new System.Drawing.Size(125, 60);
            this.btn_ScoreTotalChart.TabIndex = 3;
            this.btn_ScoreTotalChart.Text = "成绩统计图";
            this.btn_ScoreTotalChart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ScoreTotalChart.UseVisualStyleBackColor = true;
            this.btn_ScoreTotalChart.Click += new System.EventHandler(this.btn_ScoreTotalChart_Click);
            // 
            // btn_ScoreInput
            // 
            this.btn_ScoreInput.Image = ((System.Drawing.Image)(resources.GetObject("btn_ScoreInput.Image")));
            this.btn_ScoreInput.Location = new System.Drawing.Point(78, 85);
            this.btn_ScoreInput.Name = "btn_ScoreInput";
            this.btn_ScoreInput.Size = new System.Drawing.Size(125, 60);
            this.btn_ScoreInput.TabIndex = 1;
            this.btn_ScoreInput.Text = "成绩录入";
            this.btn_ScoreInput.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ScoreInput.UseVisualStyleBackColor = true;
            this.btn_ScoreInput.Click += new System.EventHandler(this.btn_ScoreInput_Click);
            // 
            // btn_ScoreTotal
            // 
            this.btn_ScoreTotal.Image = ((System.Drawing.Image)(resources.GetObject("btn_ScoreTotal.Image")));
            this.btn_ScoreTotal.Location = new System.Drawing.Point(353, 85);
            this.btn_ScoreTotal.Name = "btn_ScoreTotal";
            this.btn_ScoreTotal.Size = new System.Drawing.Size(125, 60);
            this.btn_ScoreTotal.TabIndex = 2;
            this.btn_ScoreTotal.Text = "成绩统计";
            this.btn_ScoreTotal.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ScoreTotal.UseVisualStyleBackColor = true;
            this.btn_ScoreTotal.Click += new System.EventHandler(this.btn_ScoreTotal_Click);
            // 
            // panel_Left
            // 
            this.panel_Left.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Left.Controls.Add(this.panel_ScoreInput);
            this.panel_Left.Controls.Add(this.panel_Opt);
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Left.Location = new System.Drawing.Point(0, 25);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(150, 470);
            this.panel_Left.TabIndex = 1;
            // 
            // panel_ScoreInput
            // 
            this.panel_ScoreInput.Controls.Add(this.btn_ScoreOpt);
            this.panel_ScoreInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_ScoreInput.Location = new System.Drawing.Point(0, 60);
            this.panel_ScoreInput.Name = "panel_ScoreInput";
            this.panel_ScoreInput.Size = new System.Drawing.Size(148, 60);
            this.panel_ScoreInput.TabIndex = 1;
            // 
            // btn_ScoreOpt
            // 
            this.btn_ScoreOpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_ScoreOpt.Image = global::TJWForms.Properties.Resources.save_as;
            this.btn_ScoreOpt.Location = new System.Drawing.Point(0, 0);
            this.btn_ScoreOpt.Name = "btn_ScoreOpt";
            this.btn_ScoreOpt.Size = new System.Drawing.Size(148, 60);
            this.btn_ScoreOpt.TabIndex = 0;
            this.btn_ScoreOpt.Text = "成绩录入";
            this.btn_ScoreOpt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_ScoreOpt.UseVisualStyleBackColor = true;
            this.btn_ScoreOpt.Click += new System.EventHandler(this.btn_ScoreOpt_Click);
            // 
            // panel_Opt
            // 
            this.panel_Opt.Controls.Add(this.btn_InitOpt);
            this.panel_Opt.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Opt.Location = new System.Drawing.Point(0, 0);
            this.panel_Opt.Name = "panel_Opt";
            this.panel_Opt.Size = new System.Drawing.Size(148, 60);
            this.panel_Opt.TabIndex = 0;
            // 
            // btn_InitOpt
            // 
            this.btn_InitOpt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_InitOpt.Image = global::TJWForms.Properties.Resources.options_2;
            this.btn_InitOpt.Location = new System.Drawing.Point(0, 0);
            this.btn_InitOpt.Name = "btn_InitOpt";
            this.btn_InitOpt.Size = new System.Drawing.Size(148, 60);
            this.btn_InitOpt.TabIndex = 0;
            this.btn_InitOpt.Text = "初始设定";
            this.btn_InitOpt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_InitOpt.UseVisualStyleBackColor = true;
            this.btn_InitOpt.Click += new System.EventHandler(this.btn_InitOpt_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Close,
            this.toolStripButton_About});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(774, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_Close
            // 
            this.toolStripButton_Close.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Close.Image")));
            this.toolStripButton_Close.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Close.Name = "toolStripButton_Close";
            this.toolStripButton_Close.Size = new System.Drawing.Size(68, 22);
            this.toolStripButton_Close.Text = "关闭(&X)";
            this.toolStripButton_Close.Click += new System.EventHandler(this.toolStripButton_Close_Click);
            // 
            // toolStripButton_About
            // 
            this.toolStripButton_About.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_About.Image")));
            this.toolStripButton_About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_About.Name = "toolStripButton_About";
            this.toolStripButton_About.Size = new System.Drawing.Size(68, 22);
            this.toolStripButton_About.Text = "关于(&A)";
            this.toolStripButton_About.Click += new System.EventHandler(this.toolStripButton_About_Click);
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.Controls.Add(this.statusStrip1);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Bottom.Location = new System.Drawing.Point(0, 495);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(774, 26);
            this.panel_Bottom.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 4);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(774, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(379, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(379, 17);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // timer_Datetime
            // 
            this.timer_Datetime.Enabled = true;
            this.timer_Datetime.Interval = 1000;
            this.timer_Datetime.Tick += new System.EventHandler(this.timer_Datetime_Tick);
            // 
            // StudentMngSys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 521);
            this.Controls.Add(this.panel_All);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StudentMngSys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学生成绩管理系统";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StudentMngSys_FormClosed);
            this.Load += new System.EventHandler(this.StudentMngSys_Load);
            this.panel_All.ResumeLayout(false);
            this.panel_All.PerformLayout();
            this.panel_Full.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel_Left2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel_Left.ResumeLayout(false);
            this.panel_ScoreInput.ResumeLayout(false);
            this.panel_Opt.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel_Bottom.ResumeLayout(false);
            this.panel_Bottom.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_All;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.Panel panel_Full;
        private System.Windows.Forms.Panel panel_Left;
        private System.Windows.Forms.Panel panel_Opt;
        private System.Windows.Forms.Button btn_InitOpt;
        private System.Windows.Forms.Panel panel_ScoreInput;
        private System.Windows.Forms.Button btn_ScoreOpt;
        private System.Windows.Forms.ToolStripButton toolStripButton_About;
        private System.Windows.Forms.Panel panel_Bottom;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer_Datetime;
        //private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel6;
        private MyTabControl tabControl2;
        private System.Windows.Forms.Panel panel_Left2;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ScoreTotalChart;
        private System.Windows.Forms.Button btn_ScoreInput;
        private System.Windows.Forms.Button btn_ScoreTotal;
    }
}


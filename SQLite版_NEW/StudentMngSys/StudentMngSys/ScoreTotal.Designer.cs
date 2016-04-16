namespace TJWForms
{
    partial class ScoreTotal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreTotal));
            this.panel_Full = new System.Windows.Forms.Panel();
            this.panel_Grid = new System.Windows.Forms.Panel();
            this.gridView_Score = new System.Windows.Forms.DataGridView();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_CourName = new System.Windows.Forms.ComboBox();
            this.radioButton_AllDisplay = new System.Windows.Forms.RadioButton();
            this.radioButton_Pass = new System.Windows.Forms.RadioButton();
            this.comboBox_Course = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_ClassName = new System.Windows.Forms.TextBox();
            this.comboBox_Class = new System.Windows.Forms.ComboBox();
            this.tb_StuName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_StuID = new System.Windows.Forms.TextBox();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Close = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Search = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Excel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Clear = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ScoreTotalChart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Refresh = new System.Windows.Forms.ToolStripButton();
            this.timer_Time = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel_Full.SuspendLayout();
            this.panel_Grid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Score)).BeginInit();
            this.panel_Top.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel_Bottom.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Full
            // 
            this.panel_Full.BackColor = System.Drawing.Color.Lavender;
            this.panel_Full.Controls.Add(this.panel_Grid);
            this.panel_Full.Controls.Add(this.panel_Top);
            this.panel_Full.Controls.Add(this.panel_Bottom);
            this.panel_Full.Controls.Add(this.toolStrip1);
            this.panel_Full.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Full.Location = new System.Drawing.Point(0, 0);
            this.panel_Full.Name = "panel_Full";
            this.panel_Full.Size = new System.Drawing.Size(834, 561);
            this.panel_Full.TabIndex = 0;
            // 
            // panel_Grid
            // 
            this.panel_Grid.Controls.Add(this.gridView_Score);
            this.panel_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Grid.Location = new System.Drawing.Point(0, 149);
            this.panel_Grid.Name = "panel_Grid";
            this.panel_Grid.Size = new System.Drawing.Size(834, 386);
            this.panel_Grid.TabIndex = 10;
            // 
            // gridView_Score
            // 
            this.gridView_Score.AllowUserToAddRows = false;
            this.gridView_Score.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridView_Score.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.gridView_Score.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView_Score.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView_Score.EnableHeadersVisualStyles = false;
            this.gridView_Score.Location = new System.Drawing.Point(0, 0);
            this.gridView_Score.MultiSelect = false;
            this.gridView_Score.Name = "gridView_Score";
            this.gridView_Score.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.DarkOrange;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridView_Score.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.DarkOrange;
            this.gridView_Score.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.gridView_Score.RowTemplate.Height = 23;
            this.gridView_Score.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.gridView_Score.Size = new System.Drawing.Size(834, 386);
            this.gridView_Score.TabIndex = 10;
            this.gridView_Score.CellMouseEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_Score_CellMouseEnter);
            this.gridView_Score.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gridView_Score_RowPostPaint);
            this.gridView_Score.Sorted += new System.EventHandler(this.gridView_Score_Sorted);
            this.gridView_Score.Leave += new System.EventHandler(this.gridView_Score_Leave);
            // 
            // panel_Top
            // 
            this.panel_Top.Controls.Add(this.groupBox1);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 25);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(834, 124);
            this.panel_Top.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_CourName);
            this.groupBox1.Controls.Add(this.radioButton_AllDisplay);
            this.groupBox1.Controls.Add(this.radioButton_Pass);
            this.groupBox1.Controls.Add(this.comboBox_Course);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tb_ClassName);
            this.groupBox1.Controls.Add(this.comboBox_Class);
            this.groupBox1.Controls.Add(this.tb_StuName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_StuID);
            this.groupBox1.Location = new System.Drawing.Point(12, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(810, 112);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条件";
            // 
            // comboBox_CourName
            // 
            this.comboBox_CourName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CourName.FormattingEnabled = true;
            this.comboBox_CourName.Location = new System.Drawing.Point(534, 23);
            this.comboBox_CourName.Name = "comboBox_CourName";
            this.comboBox_CourName.Size = new System.Drawing.Size(104, 23);
            this.comboBox_CourName.TabIndex = 5;
            this.comboBox_CourName.SelectedIndexChanged += new System.EventHandler(this.comboBox_CourName_SelectedIndexChanged);
            // 
            // radioButton_AllDisplay
            // 
            this.radioButton_AllDisplay.AutoSize = true;
            this.radioButton_AllDisplay.Checked = true;
            this.radioButton_AllDisplay.Location = new System.Drawing.Point(720, 88);
            this.radioButton_AllDisplay.Name = "radioButton_AllDisplay";
            this.radioButton_AllDisplay.Size = new System.Drawing.Size(85, 19);
            this.radioButton_AllDisplay.TabIndex = 9;
            this.radioButton_AllDisplay.TabStop = true;
            this.radioButton_AllDisplay.Text = "全部显示";
            this.radioButton_AllDisplay.UseVisualStyleBackColor = true;
            this.radioButton_AllDisplay.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // radioButton_Pass
            // 
            this.radioButton_Pass.AutoSize = true;
            this.radioButton_Pass.Location = new System.Drawing.Point(636, 88);
            this.radioButton_Pass.Name = "radioButton_Pass";
            this.radioButton_Pass.Size = new System.Drawing.Size(70, 19);
            this.radioButton_Pass.TabIndex = 7;
            this.radioButton_Pass.Text = "不及格";
            this.radioButton_Pass.UseVisualStyleBackColor = true;
            this.radioButton_Pass.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // comboBox_Course
            // 
            this.comboBox_Course.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Course.FormattingEnabled = true;
            this.comboBox_Course.Location = new System.Drawing.Point(534, 56);
            this.comboBox_Course.Name = "comboBox_Course";
            this.comboBox_Course.Size = new System.Drawing.Size(175, 23);
            this.comboBox_Course.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(474, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "科目";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "班级";
            // 
            // tb_ClassName
            // 
            this.tb_ClassName.Enabled = false;
            this.tb_ClassName.Location = new System.Drawing.Point(302, 55);
            this.tb_ClassName.Name = "tb_ClassName";
            this.tb_ClassName.Size = new System.Drawing.Size(119, 24);
            this.tb_ClassName.TabIndex = 3;
            // 
            // comboBox_Class
            // 
            this.comboBox_Class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Class.FormattingEnabled = true;
            this.comboBox_Class.Location = new System.Drawing.Point(88, 23);
            this.comboBox_Class.Name = "comboBox_Class";
            this.comboBox_Class.Size = new System.Drawing.Size(175, 23);
            this.comboBox_Class.TabIndex = 0;
            // 
            // tb_StuName
            // 
            this.tb_StuName.Enabled = false;
            this.tb_StuName.Location = new System.Drawing.Point(190, 55);
            this.tb_StuName.Name = "tb_StuName";
            this.tb_StuName.Size = new System.Drawing.Size(106, 24);
            this.tb_StuName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "学号";
            // 
            // tb_StuID
            // 
            this.tb_StuID.Location = new System.Drawing.Point(88, 55);
            this.tb_StuID.Name = "tb_StuID";
            this.tb_StuID.Size = new System.Drawing.Size(96, 24);
            this.tb_StuID.TabIndex = 1;
            this.tb_StuID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_StuID_KeyPress);
            this.tb_StuID.Leave += new System.EventHandler(this.tb_StuID_Leave);
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.Controls.Add(this.statusStrip1);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Bottom.Location = new System.Drawing.Point(0, 535);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(834, 26);
            this.panel_Bottom.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(834, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabel3.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(48, 21);
            this.toolStripStatusLabel3.Text = "不及格";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(301, 21);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(301, 21);
            this.toolStripStatusLabel2.Spring = true;
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Close,
            this.toolStripButton_Search,
            this.toolStripButton_Excel,
            this.toolStripButton_Clear,
            this.toolStripButton_ScoreTotalChart,
            this.toolStripButton_Refresh});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(834, 25);
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
            // toolStripButton_Search
            // 
            this.toolStripButton_Search.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Search.Image")));
            this.toolStripButton_Search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Search.Name = "toolStripButton_Search";
            this.toolStripButton_Search.Size = new System.Drawing.Size(91, 22);
            this.toolStripButton_Search.Text = "成绩查询(&S)";
            this.toolStripButton_Search.Click += new System.EventHandler(this.toolStripButton_Search_Click);
            // 
            // toolStripButton_Excel
            // 
            this.toolStripButton_Excel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Excel.Image")));
            this.toolStripButton_Excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Excel.Name = "toolStripButton_Excel";
            this.toolStripButton_Excel.Size = new System.Drawing.Size(96, 22);
            this.toolStripButton_Excel.Text = "导出Excel(&E)";
            this.toolStripButton_Excel.Click += new System.EventHandler(this.toolStripButton_Excel_Click);
            // 
            // toolStripButton_Clear
            // 
            this.toolStripButton_Clear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Clear.Image")));
            this.toolStripButton_Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Clear.Name = "toolStripButton_Clear";
            this.toolStripButton_Clear.Size = new System.Drawing.Size(68, 22);
            this.toolStripButton_Clear.Text = "清空(&C)";
            this.toolStripButton_Clear.Click += new System.EventHandler(this.toolStripButton_Clear_Click);
            // 
            // toolStripButton_ScoreTotalChart
            // 
            this.toolStripButton_ScoreTotalChart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_ScoreTotalChart.Image")));
            this.toolStripButton_ScoreTotalChart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ScoreTotalChart.Name = "toolStripButton_ScoreTotalChart";
            this.toolStripButton_ScoreTotalChart.Size = new System.Drawing.Size(91, 22);
            this.toolStripButton_ScoreTotalChart.Text = "成绩统计(&T)";
            this.toolStripButton_ScoreTotalChart.Click += new System.EventHandler(this.toolStripButton_ScoreTotalChart_Click);
            // 
            // toolStripButton_Refresh
            // 
            this.toolStripButton_Refresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_Refresh.Image")));
            this.toolStripButton_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Refresh.Name = "toolStripButton_Refresh";
            this.toolStripButton_Refresh.Size = new System.Drawing.Size(68, 22);
            this.toolStripButton_Refresh.Text = "刷新(&R)";
            this.toolStripButton_Refresh.Click += new System.EventHandler(this.toolStripButton_Refresh_Click);
            // 
            // timer_Time
            // 
            this.timer_Time.Enabled = true;
            this.timer_Time.Interval = 1000;
            this.timer_Time.Tick += new System.EventHandler(this.timer_Time_Tick);
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            // 
            // ScoreTotal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 561);
            this.Controls.Add(this.panel_Full);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScoreTotal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成绩统计";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScoreTotal_FormClosed);
            this.Load += new System.EventHandler(this.ScoreTotal_Load);
            this.panel_Full.ResumeLayout(false);
            this.panel_Full.PerformLayout();
            this.panel_Grid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView_Score)).EndInit();
            this.panel_Top.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel_Bottom.ResumeLayout(false);
            this.panel_Bottom.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Full;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Close;
        private System.Windows.Forms.Panel panel_Grid;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Panel panel_Bottom;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Search;
        private System.Windows.Forms.ToolStripButton toolStripButton_Excel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Class;
        private System.Windows.Forms.TextBox tb_ClassName;
        private System.Windows.Forms.TextBox tb_StuName;
        private System.Windows.Forms.TextBox tb_StuID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_Course;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView gridView_Score;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.Timer timer_Time;
        private System.Windows.Forms.ToolStripButton toolStripButton_Clear;
        private System.Windows.Forms.ToolStripButton toolStripButton_Refresh;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.RadioButton radioButton_AllDisplay;
        private System.Windows.Forms.RadioButton radioButton_Pass;
        private System.Windows.Forms.ToolStripButton toolStripButton_ScoreTotalChart;
        private System.Windows.Forms.ComboBox comboBox_CourName;
    }
}
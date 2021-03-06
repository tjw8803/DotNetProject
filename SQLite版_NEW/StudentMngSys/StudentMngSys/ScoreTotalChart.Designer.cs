﻿namespace TJWForms
{
    partial class ScoreTotalChart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreTotalChart));
            this.panel_Full = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabControl_AvgTotal1 = new TJWForms.MyTabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl_AvgTotal2 = new TJWForms.MyTabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl_AvgTotal3 = new TJWForms.MyTabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl_TermTotal = new TJWForms.MyTabControl();
            this.panel_Left = new System.Windows.Forms.Panel();
            this.panel_Year = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox_Term = new System.Windows.Forms.ComboBox();
            this.comboBox_AcademicYear = new System.Windows.Forms.ComboBox();
            this.panel_Group = new System.Windows.Forms.Panel();
            this.groupBox_Student = new System.Windows.Forms.GroupBox();
            this.comboBox_Student = new System.Windows.Forms.ComboBox();
            this.groupBox_Course = new System.Windows.Forms.GroupBox();
            this.comboBox_Course = new System.Windows.Forms.ComboBox();
            this.panel_Course = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox_CourseName = new System.Windows.Forms.ComboBox();
            this.groupBox_TotalType = new System.Windows.Forms.GroupBox();
            this.comboBox_TotalType = new System.Windows.Forms.ComboBox();
            this.btn_Total = new System.Windows.Forms.Button();
            this.groupBox_Class = new System.Windows.Forms.GroupBox();
            this.comboBox_Class = new System.Windows.Forms.ComboBox();
            this.panel_Full.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel_Left.SuspendLayout();
            this.panel_Year.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel_Group.SuspendLayout();
            this.groupBox_Student.SuspendLayout();
            this.groupBox_Course.SuspendLayout();
            this.panel_Course.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox_TotalType.SuspendLayout();
            this.groupBox_Class.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Full
            // 
            this.panel_Full.BackColor = System.Drawing.Color.Lavender;
            this.panel_Full.Controls.Add(this.tabControl1);
            this.panel_Full.Controls.Add(this.panel_Left);
            this.panel_Full.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Full.Location = new System.Drawing.Point(0, 0);
            this.panel_Full.Name = "panel_Full";
            this.panel_Full.Size = new System.Drawing.Size(784, 561);
            this.panel_Full.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(200, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 561);
            this.tabControl1.TabIndex = 2;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Lavender;
            this.tabPage1.Controls.Add(this.tabControl_AvgTotal1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(576, 535);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "分数段人数统计图";
            // 
            // tabControl_AvgTotal1
            // 
            this.tabControl_AvgTotal1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_AvgTotal1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl_AvgTotal1.ItemSize = new System.Drawing.Size(150, 25);
            this.tabControl_AvgTotal1.Location = new System.Drawing.Point(3, 3);
            this.tabControl_AvgTotal1.Name = "tabControl_AvgTotal1";
            this.tabControl_AvgTotal1.SelectedIndex = 0;
            this.tabControl_AvgTotal1.Size = new System.Drawing.Size(570, 529);
            this.tabControl_AvgTotal1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_AvgTotal1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Lavender;
            this.tabPage2.Controls.Add(this.tabControl_AvgTotal2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(576, 535);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "考试批次平均分统计图";
            // 
            // tabControl_AvgTotal2
            // 
            this.tabControl_AvgTotal2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_AvgTotal2.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl_AvgTotal2.ItemSize = new System.Drawing.Size(150, 25);
            this.tabControl_AvgTotal2.Location = new System.Drawing.Point(3, 3);
            this.tabControl_AvgTotal2.Name = "tabControl_AvgTotal2";
            this.tabControl_AvgTotal2.SelectedIndex = 0;
            this.tabControl_AvgTotal2.Size = new System.Drawing.Size(570, 529);
            this.tabControl_AvgTotal2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_AvgTotal2.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Lavender;
            this.tabPage3.Controls.Add(this.tabControl_AvgTotal3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(576, 535);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "个人成绩统计图";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabControl_AvgTotal3
            // 
            this.tabControl_AvgTotal3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_AvgTotal3.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl_AvgTotal3.ItemSize = new System.Drawing.Size(150, 25);
            this.tabControl_AvgTotal3.Location = new System.Drawing.Point(3, 3);
            this.tabControl_AvgTotal3.Name = "tabControl_AvgTotal3";
            this.tabControl_AvgTotal3.SelectedIndex = 0;
            this.tabControl_AvgTotal3.Size = new System.Drawing.Size(570, 529);
            this.tabControl_AvgTotal3.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_AvgTotal3.TabIndex = 3;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tabControl_TermTotal);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(576, 535);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "学年度成绩统计图";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabControl_TermTotal
            // 
            this.tabControl_TermTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_TermTotal.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl_TermTotal.ItemSize = new System.Drawing.Size(150, 25);
            this.tabControl_TermTotal.Location = new System.Drawing.Point(0, 0);
            this.tabControl_TermTotal.Name = "tabControl_TermTotal";
            this.tabControl_TermTotal.SelectedIndex = 0;
            this.tabControl_TermTotal.Size = new System.Drawing.Size(576, 535);
            this.tabControl_TermTotal.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl_TermTotal.TabIndex = 4;
            // 
            // panel_Left
            // 
            this.panel_Left.Controls.Add(this.panel_Year);
            this.panel_Left.Controls.Add(this.panel_Group);
            this.panel_Left.Controls.Add(this.panel_Course);
            this.panel_Left.Controls.Add(this.groupBox_TotalType);
            this.panel_Left.Controls.Add(this.btn_Total);
            this.panel_Left.Controls.Add(this.groupBox_Class);
            this.panel_Left.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel_Left.Location = new System.Drawing.Point(0, 0);
            this.panel_Left.Name = "panel_Left";
            this.panel_Left.Size = new System.Drawing.Size(200, 561);
            this.panel_Left.TabIndex = 0;
            // 
            // panel_Year
            // 
            this.panel_Year.Controls.Add(this.groupBox2);
            this.panel_Year.Location = new System.Drawing.Point(0, 212);
            this.panel_Year.Name = "panel_Year";
            this.panel_Year.Size = new System.Drawing.Size(200, 93);
            this.panel_Year.TabIndex = 7;
            this.panel_Year.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox_Term);
            this.groupBox2.Controls.Add(this.comboBox_AcademicYear);
            this.groupBox2.Location = new System.Drawing.Point(9, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(182, 86);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "学年度";
            // 
            // comboBox_Term
            // 
            this.comboBox_Term.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Term.FormattingEnabled = true;
            this.comboBox_Term.Items.AddRange(new object[] {
            "第一学期",
            "第二学期"});
            this.comboBox_Term.Location = new System.Drawing.Point(4, 58);
            this.comboBox_Term.Name = "comboBox_Term";
            this.comboBox_Term.Size = new System.Drawing.Size(175, 20);
            this.comboBox_Term.TabIndex = 5;
            // 
            // comboBox_AcademicYear
            // 
            this.comboBox_AcademicYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AcademicYear.FormattingEnabled = true;
            this.comboBox_AcademicYear.Items.AddRange(new object[] {
            "2010-2011学年",
            "2011-2012学年",
            "2012-2013学年",
            "2013-2014学年",
            "2014-2015学年",
            "2015-2016学年",
            "2016-2017学年",
            "2017-2018学年",
            "2018-2019学年",
            "2019-2020学年",
            "2020-2021学年",
            "2021-2022学年",
            "2022-2023学年",
            "2023-2024学年",
            "2024-2025学年",
            "2025-2026学年",
            "2026-2027学年",
            "2027-2028学年",
            "2028-2029学年",
            "2029-2030学年"});
            this.comboBox_AcademicYear.Location = new System.Drawing.Point(4, 23);
            this.comboBox_AcademicYear.Name = "comboBox_AcademicYear";
            this.comboBox_AcademicYear.Size = new System.Drawing.Size(175, 20);
            this.comboBox_AcademicYear.TabIndex = 3;
            // 
            // panel_Group
            // 
            this.panel_Group.Controls.Add(this.groupBox_Student);
            this.panel_Group.Controls.Add(this.groupBox_Course);
            this.panel_Group.Location = new System.Drawing.Point(0, 212);
            this.panel_Group.Name = "panel_Group";
            this.panel_Group.Size = new System.Drawing.Size(200, 69);
            this.panel_Group.TabIndex = 6;
            // 
            // groupBox_Student
            // 
            this.groupBox_Student.Controls.Add(this.comboBox_Student);
            this.groupBox_Student.Location = new System.Drawing.Point(9, 3);
            this.groupBox_Student.Name = "groupBox_Student";
            this.groupBox_Student.Size = new System.Drawing.Size(182, 60);
            this.groupBox_Student.TabIndex = 4;
            this.groupBox_Student.TabStop = false;
            this.groupBox_Student.Text = "学生";
            this.groupBox_Student.Visible = false;
            // 
            // comboBox_Student
            // 
            this.comboBox_Student.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Student.FormattingEnabled = true;
            this.comboBox_Student.Location = new System.Drawing.Point(4, 23);
            this.comboBox_Student.Name = "comboBox_Student";
            this.comboBox_Student.Size = new System.Drawing.Size(175, 20);
            this.comboBox_Student.TabIndex = 4;
            // 
            // groupBox_Course
            // 
            this.groupBox_Course.Controls.Add(this.comboBox_Course);
            this.groupBox_Course.Location = new System.Drawing.Point(9, 3);
            this.groupBox_Course.Name = "groupBox_Course";
            this.groupBox_Course.Size = new System.Drawing.Size(182, 60);
            this.groupBox_Course.TabIndex = 3;
            this.groupBox_Course.TabStop = false;
            this.groupBox_Course.Text = "考试批次";
            // 
            // comboBox_Course
            // 
            this.comboBox_Course.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Course.FormattingEnabled = true;
            this.comboBox_Course.Location = new System.Drawing.Point(4, 23);
            this.comboBox_Course.Name = "comboBox_Course";
            this.comboBox_Course.Size = new System.Drawing.Size(175, 20);
            this.comboBox_Course.TabIndex = 4;
            // 
            // panel_Course
            // 
            this.panel_Course.Controls.Add(this.groupBox1);
            this.panel_Course.Location = new System.Drawing.Point(0, 144);
            this.panel_Course.Name = "panel_Course";
            this.panel_Course.Size = new System.Drawing.Size(200, 69);
            this.panel_Course.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBox_CourseName);
            this.groupBox1.Location = new System.Drawing.Point(9, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(182, 60);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "科目";
            // 
            // comboBox_CourseName
            // 
            this.comboBox_CourseName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CourseName.FormattingEnabled = true;
            this.comboBox_CourseName.Location = new System.Drawing.Point(4, 23);
            this.comboBox_CourseName.Name = "comboBox_CourseName";
            this.comboBox_CourseName.Size = new System.Drawing.Size(175, 20);
            this.comboBox_CourseName.TabIndex = 3;
            this.comboBox_CourseName.SelectedIndexChanged += new System.EventHandler(this.comboBox_CourseName_SelectedIndexChanged);
            // 
            // groupBox_TotalType
            // 
            this.groupBox_TotalType.Controls.Add(this.comboBox_TotalType);
            this.groupBox_TotalType.Location = new System.Drawing.Point(9, 9);
            this.groupBox_TotalType.Name = "groupBox_TotalType";
            this.groupBox_TotalType.Size = new System.Drawing.Size(182, 60);
            this.groupBox_TotalType.TabIndex = 0;
            this.groupBox_TotalType.TabStop = false;
            this.groupBox_TotalType.Text = "统计类型";
            // 
            // comboBox_TotalType
            // 
            this.comboBox_TotalType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TotalType.FormattingEnabled = true;
            this.comboBox_TotalType.Items.AddRange(new object[] {
            "分数段人数统计图",
            "考试批次平均分统计图",
            "个人成绩统计图",
            "学年度成绩统计图"});
            this.comboBox_TotalType.Location = new System.Drawing.Point(4, 23);
            this.comboBox_TotalType.Name = "comboBox_TotalType";
            this.comboBox_TotalType.Size = new System.Drawing.Size(175, 20);
            this.comboBox_TotalType.TabIndex = 0;
            this.comboBox_TotalType.SelectedIndexChanged += new System.EventHandler(this.comboBox_TotalType_SelectedIndexChanged);
            // 
            // btn_Total
            // 
            this.btn_Total.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Total.Location = new System.Drawing.Point(93, 371);
            this.btn_Total.Name = "btn_Total";
            this.btn_Total.Size = new System.Drawing.Size(94, 46);
            this.btn_Total.TabIndex = 3;
            this.btn_Total.Text = "统计图表示(&T)";
            this.btn_Total.UseVisualStyleBackColor = true;
            this.btn_Total.Click += new System.EventHandler(this.btn_Total_Click);
            // 
            // groupBox_Class
            // 
            this.groupBox_Class.Controls.Add(this.comboBox_Class);
            this.groupBox_Class.Location = new System.Drawing.Point(9, 75);
            this.groupBox_Class.Name = "groupBox_Class";
            this.groupBox_Class.Size = new System.Drawing.Size(182, 60);
            this.groupBox_Class.TabIndex = 1;
            this.groupBox_Class.TabStop = false;
            this.groupBox_Class.Text = "班级";
            // 
            // comboBox_Class
            // 
            this.comboBox_Class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Class.FormattingEnabled = true;
            this.comboBox_Class.Location = new System.Drawing.Point(4, 23);
            this.comboBox_Class.Name = "comboBox_Class";
            this.comboBox_Class.Size = new System.Drawing.Size(175, 20);
            this.comboBox_Class.TabIndex = 1;
            this.comboBox_Class.SelectedIndexChanged += new System.EventHandler(this.comboBox_Class_SelectedIndexChanged);
            // 
            // ScoreTotalChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel_Full);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScoreTotalChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成绩统计表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ScoreTotalChart_Load);
            this.panel_Full.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.panel_Left.ResumeLayout(false);
            this.panel_Year.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel_Group.ResumeLayout(false);
            this.groupBox_Student.ResumeLayout(false);
            this.groupBox_Course.ResumeLayout(false);
            this.panel_Course.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox_TotalType.ResumeLayout(false);
            this.groupBox_Class.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Full;
        private System.Windows.Forms.Panel panel_Left;
        //private System.Windows.Forms.TabControl tabControl1;
        private MyTabControl tabControl_AvgTotal1;
        private System.Windows.Forms.GroupBox groupBox_Course;
        private System.Windows.Forms.ComboBox comboBox_Course;
        private System.Windows.Forms.GroupBox groupBox_Class;
        private System.Windows.Forms.ComboBox comboBox_Class;
        private System.Windows.Forms.Button btn_Total;
        private System.Windows.Forms.GroupBox groupBox_TotalType;
        private System.Windows.Forms.ComboBox comboBox_TotalType;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private MyTabControl tabControl_AvgTotal2;
        private System.Windows.Forms.TabPage tabPage3;
        private MyTabControl tabControl_AvgTotal3;
        private System.Windows.Forms.GroupBox groupBox_Student;
        private System.Windows.Forms.ComboBox comboBox_Student;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_CourseName;
        private System.Windows.Forms.Panel panel_Group;
        private System.Windows.Forms.Panel panel_Course;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel_Year;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_AcademicYear;
        private System.Windows.Forms.ComboBox comboBox_Term;
        private MyTabControl tabControl_TermTotal;
    }
}
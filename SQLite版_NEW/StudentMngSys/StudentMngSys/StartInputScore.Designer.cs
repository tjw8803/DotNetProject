namespace TJWForms
{
    partial class StartInputScore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartInputScore));
            this.panel_Full = new System.Windows.Forms.Panel();
            this.panel_ReTest = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tb_Score2 = new System.Windows.Forms.TextBox();
            this.tb_ClassName = new System.Windows.Forms.TextBox();
            this.tb_StuName = new System.Windows.Forms.TextBox();
            this.tb_StuID = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Score = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Buttom = new System.Windows.Forms.Panel();
            this.btn_Cancle = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_CourseName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel_Full.SuspendLayout();
            this.panel_ReTest.SuspendLayout();
            this.panel_Buttom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Full
            // 
            this.panel_Full.BackColor = System.Drawing.Color.Lavender;
            this.panel_Full.Controls.Add(this.label7);
            this.panel_Full.Controls.Add(this.label6);
            this.panel_Full.Controls.Add(this.label5);
            this.panel_Full.Controls.Add(this.panel_ReTest);
            this.panel_Full.Controls.Add(this.tb_CourseName);
            this.panel_Full.Controls.Add(this.tb_ClassName);
            this.panel_Full.Controls.Add(this.tb_StuName);
            this.panel_Full.Controls.Add(this.tb_StuID);
            this.panel_Full.Controls.Add(this.dateTimePicker1);
            this.panel_Full.Controls.Add(this.label3);
            this.panel_Full.Controls.Add(this.tb_Score);
            this.panel_Full.Controls.Add(this.label2);
            this.panel_Full.Controls.Add(this.label1);
            this.panel_Full.Controls.Add(this.panel_Buttom);
            this.panel_Full.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Full.Location = new System.Drawing.Point(0, 0);
            this.panel_Full.Name = "panel_Full";
            this.panel_Full.Size = new System.Drawing.Size(482, 258);
            this.panel_Full.TabIndex = 0;
            // 
            // panel_ReTest
            // 
            this.panel_ReTest.Controls.Add(this.label4);
            this.panel_ReTest.Controls.Add(this.checkBox1);
            this.panel_ReTest.Controls.Add(this.tb_Score2);
            this.panel_ReTest.Enabled = false;
            this.panel_ReTest.Location = new System.Drawing.Point(25, 165);
            this.panel_ReTest.Name = "panel_ReTest";
            this.panel_ReTest.Size = new System.Drawing.Size(314, 30);
            this.panel_ReTest.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "成绩2";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(92, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(71, 19);
            this.checkBox1.TabIndex = 5;
            this.checkBox1.Text = "已补考";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tb_Score2
            // 
            this.tb_Score2.Location = new System.Drawing.Point(169, 3);
            this.tb_Score2.MaxLength = 4;
            this.tb_Score2.Name = "tb_Score2";
            this.tb_Score2.Size = new System.Drawing.Size(96, 24);
            this.tb_Score2.TabIndex = 6;
            this.tb_Score2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // tb_ClassName
            // 
            this.tb_ClassName.Enabled = false;
            this.tb_ClassName.Location = new System.Drawing.Point(117, 11);
            this.tb_ClassName.Name = "tb_ClassName";
            this.tb_ClassName.Size = new System.Drawing.Size(119, 24);
            this.tb_ClassName.TabIndex = 3;
            // 
            // tb_StuName
            // 
            this.tb_StuName.Enabled = false;
            this.tb_StuName.Location = new System.Drawing.Point(219, 98);
            this.tb_StuName.Name = "tb_StuName";
            this.tb_StuName.Size = new System.Drawing.Size(106, 24);
            this.tb_StuName.TabIndex = 2;
            // 
            // tb_StuID
            // 
            this.tb_StuID.Location = new System.Drawing.Point(117, 98);
            this.tb_StuID.Name = "tb_StuID";
            this.tb_StuID.Size = new System.Drawing.Size(96, 24);
            this.tb_StuID.TabIndex = 1;
            this.tb_StuID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.tb_StuID.Leave += new System.EventHandler(this.textBox1_Leave);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(117, 61);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(175, 24);
            this.dateTimePicker1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "日期";
            // 
            // tb_Score
            // 
            this.tb_Score.Location = new System.Drawing.Point(117, 135);
            this.tb_Score.MaxLength = 4;
            this.tb_Score.Name = "tb_Score";
            this.tb_Score.Size = new System.Drawing.Size(96, 24);
            this.tb_Score.TabIndex = 4;
            this.tb_Score.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "成绩";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "学号";
            // 
            // panel_Buttom
            // 
            this.panel_Buttom.Controls.Add(this.btn_Cancle);
            this.panel_Buttom.Controls.Add(this.btn_OK);
            this.panel_Buttom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Buttom.Location = new System.Drawing.Point(0, 217);
            this.panel_Buttom.Name = "panel_Buttom";
            this.panel_Buttom.Size = new System.Drawing.Size(482, 41);
            this.panel_Buttom.TabIndex = 9;
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.Location = new System.Drawing.Point(383, 8);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancle.TabIndex = 10;
            this.btn_Cancle.Text = "关闭(&C)";
            this.btn_Cancle.UseVisualStyleBackColor = true;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(288, 8);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 9;
            this.btn_OK.Text = "保存(&S)";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Location = new System.Drawing.Point(0, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(482, 1);
            this.label5.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 14);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 11;
            this.label6.Text = "班级";
            // 
            // tb_CourseName
            // 
            this.tb_CourseName.Enabled = false;
            this.tb_CourseName.Location = new System.Drawing.Point(339, 11);
            this.tb_CourseName.Name = "tb_CourseName";
            this.tb_CourseName.Size = new System.Drawing.Size(119, 24);
            this.tb_CourseName.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(250, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "科目";
            // 
            // StartInputScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 258);
            this.Controls.Add(this.panel_Full);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StartInputScore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成绩录入";
            this.Load += new System.EventHandler(this.StartInputScore_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StartInputScore_KeyDown);
            this.panel_Full.ResumeLayout(false);
            this.panel_Full.PerformLayout();
            this.panel_ReTest.ResumeLayout(false);
            this.panel_ReTest.PerformLayout();
            this.panel_Buttom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Full;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Score;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Buttom;
        private System.Windows.Forms.Button btn_Cancle;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.TextBox tb_ClassName;
        private System.Windows.Forms.TextBox tb_StuName;
        private System.Windows.Forms.TextBox tb_StuID;
        private System.Windows.Forms.TextBox tb_Score2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel_ReTest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_CourseName;
    }
}
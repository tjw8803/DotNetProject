namespace TJWForms
{
    partial class ScoreInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScoreInput));
            this.panel_Full = new System.Windows.Forms.Panel();
            this.comboBox_CourName = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Class = new System.Windows.Forms.ComboBox();
            this.comboBox_Course = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Buttom = new System.Windows.Forms.Panel();
            this.btn_Cancle = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.panel_Full.SuspendLayout();
            this.panel_Buttom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Full
            // 
            this.panel_Full.BackColor = System.Drawing.Color.Lavender;
            this.panel_Full.Controls.Add(this.comboBox_CourName);
            this.panel_Full.Controls.Add(this.dateTimePicker1);
            this.panel_Full.Controls.Add(this.label4);
            this.panel_Full.Controls.Add(this.label3);
            this.panel_Full.Controls.Add(this.comboBox_Class);
            this.panel_Full.Controls.Add(this.comboBox_Course);
            this.panel_Full.Controls.Add(this.label1);
            this.panel_Full.Controls.Add(this.panel_Buttom);
            this.panel_Full.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Full.Location = new System.Drawing.Point(0, 0);
            this.panel_Full.Name = "panel_Full";
            this.panel_Full.Size = new System.Drawing.Size(379, 268);
            this.panel_Full.TabIndex = 0;
            // 
            // comboBox_CourName
            // 
            this.comboBox_CourName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_CourName.FormattingEnabled = true;
            this.comboBox_CourName.Location = new System.Drawing.Point(117, 40);
            this.comboBox_CourName.Name = "comboBox_CourName";
            this.comboBox_CourName.Size = new System.Drawing.Size(104, 23);
            this.comboBox_CourName.TabIndex = 1;
            this.comboBox_CourName.SelectedIndexChanged += new System.EventHandler(this.comboBox_CourName_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(117, 128);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(175, 24);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "班级";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "日期";
            // 
            // comboBox_Class
            // 
            this.comboBox_Class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Class.FormattingEnabled = true;
            this.comboBox_Class.Location = new System.Drawing.Point(117, 173);
            this.comboBox_Class.Name = "comboBox_Class";
            this.comboBox_Class.Size = new System.Drawing.Size(175, 23);
            this.comboBox_Class.TabIndex = 4;
            // 
            // comboBox_Course
            // 
            this.comboBox_Course.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Course.FormattingEnabled = true;
            this.comboBox_Course.Location = new System.Drawing.Point(117, 85);
            this.comboBox_Course.Name = "comboBox_Course";
            this.comboBox_Course.Size = new System.Drawing.Size(175, 23);
            this.comboBox_Course.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "科目";
            // 
            // panel_Buttom
            // 
            this.panel_Buttom.Controls.Add(this.btn_Cancle);
            this.panel_Buttom.Controls.Add(this.btn_OK);
            this.panel_Buttom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Buttom.Location = new System.Drawing.Point(0, 223);
            this.panel_Buttom.Name = "panel_Buttom";
            this.panel_Buttom.Size = new System.Drawing.Size(379, 45);
            this.panel_Buttom.TabIndex = 5;
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.Location = new System.Drawing.Point(286, 11);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancle.TabIndex = 6;
            this.btn_Cancle.Text = "关闭(&C)";
            this.btn_Cancle.UseVisualStyleBackColor = true;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(178, 11);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(100, 23);
            this.btn_OK.TabIndex = 5;
            this.btn_OK.Text = "开始录入(&I)";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // ScoreInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 268);
            this.Controls.Add(this.panel_Full);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ScoreInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "成绩录入";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ScoreInput_FormClosed);
            this.Load += new System.EventHandler(this.ScoreInput_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ScoreInput_KeyDown);
            this.panel_Full.ResumeLayout(false);
            this.panel_Full.PerformLayout();
            this.panel_Buttom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Full;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Buttom;
        private System.Windows.Forms.Button btn_Cancle;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Class;
        private System.Windows.Forms.ComboBox comboBox_Course;
        private System.Windows.Forms.ComboBox comboBox_CourName;
    }
}
namespace TJWForms
{
    partial class ExamOpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExamOpt));
            this.panel_Full = new System.Windows.Forms.Panel();
            this.comboBox_Type = new System.Windows.Forms.ComboBox();
            this.tb_Course = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Buttom = new System.Windows.Forms.Panel();
            this.btn_Cancle = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.comboBox_Course = new System.Windows.Forms.ComboBox();
            this.label_Mark = new System.Windows.Forms.Label();
            this.panel_Full.SuspendLayout();
            this.panel_Buttom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Full
            // 
            this.panel_Full.BackColor = System.Drawing.Color.Lavender;
            this.panel_Full.Controls.Add(this.label_Mark);
            this.panel_Full.Controls.Add(this.comboBox_Course);
            this.panel_Full.Controls.Add(this.comboBox_Type);
            this.panel_Full.Controls.Add(this.tb_Course);
            this.panel_Full.Controls.Add(this.label2);
            this.panel_Full.Controls.Add(this.label1);
            this.panel_Full.Controls.Add(this.panel_Buttom);
            this.panel_Full.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Full.Location = new System.Drawing.Point(0, 0);
            this.panel_Full.Name = "panel_Full";
            this.panel_Full.Size = new System.Drawing.Size(379, 182);
            this.panel_Full.TabIndex = 0;
            // 
            // comboBox_Type
            // 
            this.comboBox_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Type.FormattingEnabled = true;
            this.comboBox_Type.Location = new System.Drawing.Point(117, 39);
            this.comboBox_Type.Name = "comboBox_Type";
            this.comboBox_Type.Size = new System.Drawing.Size(104, 23);
            this.comboBox_Type.TabIndex = 0;
            this.comboBox_Type.SelectedIndexChanged += new System.EventHandler(this.comboBox_Type_SelectedIndexChanged);
            // 
            // tb_Course
            // 
            this.tb_Course.Location = new System.Drawing.Point(117, 82);
            this.tb_Course.Name = "tb_Course";
            this.tb_Course.Size = new System.Drawing.Size(175, 24);
            this.tb_Course.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "章节";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "类型";
            // 
            // panel_Buttom
            // 
            this.panel_Buttom.Controls.Add(this.btn_Cancle);
            this.panel_Buttom.Controls.Add(this.btn_OK);
            this.panel_Buttom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Buttom.Location = new System.Drawing.Point(0, 133);
            this.panel_Buttom.Name = "panel_Buttom";
            this.panel_Buttom.Size = new System.Drawing.Size(379, 49);
            this.panel_Buttom.TabIndex = 4;
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.Location = new System.Drawing.Point(288, 12);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancle.TabIndex = 5;
            this.btn_Cancle.Text = "关闭(&C)";
            this.btn_Cancle.UseVisualStyleBackColor = true;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(193, 12);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "保存(&S)";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // comboBox_Course
            // 
            this.comboBox_Course.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Course.FormattingEnabled = true;
            this.comboBox_Course.Location = new System.Drawing.Point(255, 39);
            this.comboBox_Course.Name = "comboBox_Course";
            this.comboBox_Course.Size = new System.Drawing.Size(104, 23);
            this.comboBox_Course.TabIndex = 1;
            this.comboBox_Course.Visible = false;
            this.comboBox_Course.SelectedIndexChanged += new System.EventHandler(this.comboBox_Type_SelectedIndexChanged);
            // 
            // label_Mark
            // 
            this.label_Mark.AutoSize = true;
            this.label_Mark.Location = new System.Drawing.Point(228, 43);
            this.label_Mark.Name = "label_Mark";
            this.label_Mark.Size = new System.Drawing.Size(23, 15);
            this.label_Mark.TabIndex = 5;
            this.label_Mark.Text = "=>";
            this.label_Mark.Visible = false;
            // 
            // ExamOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 182);
            this.Controls.Add(this.panel_Full);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ExamOpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "考试类型设定";
            this.Load += new System.EventHandler(this.ExamOpt_Load);
            this.panel_Full.ResumeLayout(false);
            this.panel_Full.PerformLayout();
            this.panel_Buttom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Full;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Buttom;
        private System.Windows.Forms.Button btn_Cancle;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.ComboBox comboBox_Type;
        private System.Windows.Forms.TextBox tb_Course;
        private System.Windows.Forms.ComboBox comboBox_Course;
        private System.Windows.Forms.Label label_Mark;
    }
}
namespace TJWForms
{
    partial class StuOpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StuOpt));
            this.panel_Full = new System.Windows.Forms.Panel();
            this.tb_StuName = new System.Windows.Forms.TextBox();
            this.tb_StuID = new System.Windows.Forms.TextBox();
            this.comboBox_Class = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Buttom = new System.Windows.Forms.Panel();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.btn_Cancle = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.panel_Full.SuspendLayout();
            this.panel_Buttom.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Full
            // 
            this.panel_Full.BackColor = System.Drawing.Color.Lavender;
            this.panel_Full.Controls.Add(this.tb_StuName);
            this.panel_Full.Controls.Add(this.tb_StuID);
            this.panel_Full.Controls.Add(this.comboBox_Class);
            this.panel_Full.Controls.Add(this.label3);
            this.panel_Full.Controls.Add(this.label2);
            this.panel_Full.Controls.Add(this.label1);
            this.panel_Full.Controls.Add(this.panel_Buttom);
            this.panel_Full.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Full.Location = new System.Drawing.Point(0, 0);
            this.panel_Full.Name = "panel_Full";
            this.panel_Full.Size = new System.Drawing.Size(379, 211);
            this.panel_Full.TabIndex = 0;
            // 
            // tb_StuName
            // 
            this.tb_StuName.Location = new System.Drawing.Point(117, 126);
            this.tb_StuName.Name = "tb_StuName";
            this.tb_StuName.Size = new System.Drawing.Size(175, 24);
            this.tb_StuName.TabIndex = 2;
            // 
            // tb_StuID
            // 
            this.tb_StuID.Location = new System.Drawing.Point(117, 78);
            this.tb_StuID.Name = "tb_StuID";
            this.tb_StuID.Size = new System.Drawing.Size(175, 24);
            this.tb_StuID.TabIndex = 1;
            this.tb_StuID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_StuID_KeyPress);
            this.tb_StuID.Leave += new System.EventHandler(this.tb_StuID_Leave);
            // 
            // comboBox_Class
            // 
            this.comboBox_Class.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Class.FormattingEnabled = true;
            this.comboBox_Class.Location = new System.Drawing.Point(117, 31);
            this.comboBox_Class.Name = "comboBox_Class";
            this.comboBox_Class.Size = new System.Drawing.Size(175, 23);
            this.comboBox_Class.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "班级";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "姓名";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "学号";
            // 
            // panel_Buttom
            // 
            this.panel_Buttom.Controls.Add(this.btn_Refresh);
            this.panel_Buttom.Controls.Add(this.btn_Cancle);
            this.panel_Buttom.Controls.Add(this.btn_OK);
            this.panel_Buttom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Buttom.Location = new System.Drawing.Point(0, 170);
            this.panel_Buttom.Name = "panel_Buttom";
            this.panel_Buttom.Size = new System.Drawing.Size(379, 41);
            this.panel_Buttom.TabIndex = 3;
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Location = new System.Drawing.Point(112, 9);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(75, 23);
            this.btn_Refresh.TabIndex = 3;
            this.btn_Refresh.Text = "更新(&R)";
            this.btn_Refresh.UseVisualStyleBackColor = true;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.Location = new System.Drawing.Point(288, 9);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancle.TabIndex = 5;
            this.btn_Cancle.Text = "关闭(&C)";
            this.btn_Cancle.UseVisualStyleBackColor = true;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(200, 9);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 4;
            this.btn_OK.Text = "保存(&S)";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // StuOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 211);
            this.Controls.Add(this.panel_Full);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "StuOpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "学生信息设定";
            this.Load += new System.EventHandler(this.StuOpt_Load);
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
        private System.Windows.Forms.ComboBox comboBox_Class;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_StuName;
        private System.Windows.Forms.TextBox tb_StuID;
        private System.Windows.Forms.Button btn_Refresh;
    }
}
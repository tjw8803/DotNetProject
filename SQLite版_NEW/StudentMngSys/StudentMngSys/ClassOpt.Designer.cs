namespace TJWForms
{
    partial class ClassOpt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClassOpt));
            this.panel_Full = new System.Windows.Forms.Panel();
            this.tb_ClassName = new System.Windows.Forms.TextBox();
            this.tb_ClassID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
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
            this.panel_Full.Controls.Add(this.tb_ClassName);
            this.panel_Full.Controls.Add(this.tb_ClassID);
            this.panel_Full.Controls.Add(this.label2);
            this.panel_Full.Controls.Add(this.label1);
            this.panel_Full.Controls.Add(this.panel_Buttom);
            this.panel_Full.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Full.Location = new System.Drawing.Point(0, 0);
            this.panel_Full.Name = "panel_Full";
            this.panel_Full.Size = new System.Drawing.Size(363, 179);
            this.panel_Full.TabIndex = 0;
            // 
            // tb_ClassName
            // 
            this.tb_ClassName.Location = new System.Drawing.Point(117, 83);
            this.tb_ClassName.Name = "tb_ClassName";
            this.tb_ClassName.Size = new System.Drawing.Size(175, 24);
            this.tb_ClassName.TabIndex = 1;
            // 
            // tb_ClassID
            // 
            this.tb_ClassID.Location = new System.Drawing.Point(117, 37);
            this.tb_ClassID.Name = "tb_ClassID";
            this.tb_ClassID.Size = new System.Drawing.Size(175, 24);
            this.tb_ClassID.TabIndex = 0;
            this.tb_ClassID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_ClassID_KeyPress);
            this.tb_ClassID.Leave += new System.EventHandler(this.tb_ClassID_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "班级名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "班级编号";
            // 
            // panel_Buttom
            // 
            this.panel_Buttom.Controls.Add(this.btn_Cancle);
            this.panel_Buttom.Controls.Add(this.btn_OK);
            this.panel_Buttom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Buttom.Location = new System.Drawing.Point(0, 138);
            this.panel_Buttom.Name = "panel_Buttom";
            this.panel_Buttom.Size = new System.Drawing.Size(363, 41);
            this.panel_Buttom.TabIndex = 1;
            // 
            // btn_Cancle
            // 
            this.btn_Cancle.Location = new System.Drawing.Point(268, 9);
            this.btn_Cancle.Name = "btn_Cancle";
            this.btn_Cancle.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancle.TabIndex = 3;
            this.btn_Cancle.Text = "关闭(&C)";
            this.btn_Cancle.UseVisualStyleBackColor = true;
            this.btn_Cancle.Click += new System.EventHandler(this.btn_Cancle_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(173, 9);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 2;
            this.btn_OK.Text = "保存(&S)";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // ClassOpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 179);
            this.Controls.Add(this.panel_Full);
            this.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ClassOpt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "班级设定";
            this.Load += new System.EventHandler(this.ClassOpt_Load);
            this.panel_Full.ResumeLayout(false);
            this.panel_Full.PerformLayout();
            this.panel_Buttom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Full;
        private System.Windows.Forms.TextBox tb_ClassName;
        private System.Windows.Forms.TextBox tb_ClassID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel_Buttom;
        private System.Windows.Forms.Button btn_Cancle;
        private System.Windows.Forms.Button btn_OK;
    }
}
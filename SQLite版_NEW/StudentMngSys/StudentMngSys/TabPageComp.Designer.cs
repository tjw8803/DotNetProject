namespace TJWForms
{
    partial class TabPageComp
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel_Full = new System.Windows.Forms.Panel();
            this.panel_Grid = new System.Windows.Forms.Panel();
            this.gridView = new System.Windows.Forms.DataGridView();
            this.panel_Bottom = new System.Windows.Forms.Panel();
            this.tb_DataCount = new System.Windows.Forms.TextBox();
            this.panel_Top = new System.Windows.Forms.Panel();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.panel_Full.SuspendLayout();
            this.panel_Grid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.panel_Bottom.SuspendLayout();
            this.panel_Top.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_Full
            // 
            this.panel_Full.Controls.Add(this.panel_Grid);
            this.panel_Full.Controls.Add(this.panel_Bottom);
            this.panel_Full.Controls.Add(this.panel_Top);
            this.panel_Full.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Full.Location = new System.Drawing.Point(0, 0);
            this.panel_Full.Name = "panel_Full";
            this.panel_Full.Size = new System.Drawing.Size(570, 360);
            this.panel_Full.TabIndex = 0;
            // 
            // panel_Grid
            // 
            this.panel_Grid.Controls.Add(this.gridView);
            this.panel_Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Grid.Location = new System.Drawing.Point(0, 35);
            this.panel_Grid.Name = "panel_Grid";
            this.panel_Grid.Size = new System.Drawing.Size(570, 295);
            this.panel_Grid.TabIndex = 2;
            // 
            // gridView
            // 
            this.gridView.AllowUserToAddRows = false;
            this.gridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridView.EnableHeadersVisualStyles = false;
            this.gridView.Location = new System.Drawing.Point(0, 0);
            this.gridView.MultiSelect = false;
            this.gridView.Name = "gridView";
            this.gridView.ReadOnly = true;
            this.gridView.RowTemplate.Height = 23;
            this.gridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridView.Size = new System.Drawing.Size(570, 295);
            this.gridView.TabIndex = 1;
            this.gridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_CellDoubleClick);
            this.gridView.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridView_CellEnter);
            this.gridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.gridView_RowPostPaint);
            // 
            // panel_Bottom
            // 
            this.panel_Bottom.Controls.Add(this.tb_DataCount);
            this.panel_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_Bottom.Location = new System.Drawing.Point(0, 330);
            this.panel_Bottom.Name = "panel_Bottom";
            this.panel_Bottom.Size = new System.Drawing.Size(570, 30);
            this.panel_Bottom.TabIndex = 1;
            // 
            // tb_DataCount
            // 
            this.tb_DataCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_DataCount.Enabled = false;
            this.tb_DataCount.ForeColor = System.Drawing.Color.Blue;
            this.tb_DataCount.Location = new System.Drawing.Point(9, 8);
            this.tb_DataCount.Name = "tb_DataCount";
            this.tb_DataCount.Size = new System.Drawing.Size(200, 14);
            this.tb_DataCount.TabIndex = 0;
            this.tb_DataCount.TextChanged += new System.EventHandler(this.tb_DataCount_TextChanged);
            // 
            // panel_Top
            // 
            this.panel_Top.Controls.Add(this.btn_Delete);
            this.panel_Top.Controls.Add(this.btn_Modify);
            this.panel_Top.Controls.Add(this.btn_Add);
            this.panel_Top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_Top.Location = new System.Drawing.Point(0, 0);
            this.panel_Top.Name = "panel_Top";
            this.panel_Top.Size = new System.Drawing.Size(570, 35);
            this.panel_Top.TabIndex = 0;
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.btn_Delete.Enabled = false;
            this.btn_Delete.Location = new System.Drawing.Point(171, 6);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 23);
            this.btn_Delete.TabIndex = 3;
            this.btn_Delete.Text = "删除(&D)";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Modify
            // 
            this.btn_Modify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.btn_Modify.Enabled = false;
            this.btn_Modify.Location = new System.Drawing.Point(90, 6);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(75, 23);
            this.btn_Modify.TabIndex = 2;
            this.btn_Modify.Text = "修改(&M)";
            this.btn_Modify.UseVisualStyleBackColor = false;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.btn_Add.Location = new System.Drawing.Point(9, 6);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 23);
            this.btn_Add.TabIndex = 1;
            this.btn_Add.Text = "新建(&A)";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // TabPageComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(570, 360);
            this.Controls.Add(this.panel_Full);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TabPageComp";
            this.Text = "TabPageComp";
            this.Load += new System.EventHandler(this.TabPageComp_Load);
            this.panel_Full.ResumeLayout(false);
            this.panel_Grid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.panel_Bottom.ResumeLayout(false);
            this.panel_Bottom.PerformLayout();
            this.panel_Top.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_Full;
        private System.Windows.Forms.Panel panel_Grid;
        private System.Windows.Forms.Panel panel_Bottom;
        private System.Windows.Forms.Panel panel_Top;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Modify;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.DataGridView gridView;
        private System.Windows.Forms.TextBox tb_DataCount;
    }
}
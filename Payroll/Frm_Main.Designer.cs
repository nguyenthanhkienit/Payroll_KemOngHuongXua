namespace Payroll
{
    partial class Frm_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Main));
            this.btncapnhatnhanvien = new System.Windows.Forms.Button();
            this.btntinhluongnhanvien = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btncapnhatnhanvien
            // 
            this.btncapnhatnhanvien.Location = new System.Drawing.Point(96, 71);
            this.btncapnhatnhanvien.Name = "btncapnhatnhanvien";
            this.btncapnhatnhanvien.Size = new System.Drawing.Size(120, 23);
            this.btncapnhatnhanvien.TabIndex = 9;
            this.btncapnhatnhanvien.Text = "Cập nhật nhân viên";
            this.btncapnhatnhanvien.UseVisualStyleBackColor = true;
            this.btncapnhatnhanvien.Click += new System.EventHandler(this.btncapnhatnhanvien_Click);
            // 
            // btntinhluongnhanvien
            // 
            this.btntinhluongnhanvien.Location = new System.Drawing.Point(96, 100);
            this.btntinhluongnhanvien.Name = "btntinhluongnhanvien";
            this.btntinhluongnhanvien.Size = new System.Drawing.Size(120, 23);
            this.btntinhluongnhanvien.TabIndex = 10;
            this.btntinhluongnhanvien.Text = "Tính lương nhân viên";
            this.btntinhluongnhanvien.UseVisualStyleBackColor = true;
            this.btntinhluongnhanvien.Click += new System.EventHandler(this.btntinhluongnhanvien_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(54, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(207, 23);
            this.label6.TabIndex = 27;
            this.label6.Text = "KEM ỐNG HƯƠNG XƯA";
            // 
            // Frm_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 215);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btntinhluongnhanvien);
            this.Controls.Add(this.btncapnhatnhanvien);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KEM ỐNG HƯƠNG XƯA";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btncapnhatnhanvien;
        private System.Windows.Forms.Button btntinhluongnhanvien;
        private System.Windows.Forms.Label label6;
    }
}
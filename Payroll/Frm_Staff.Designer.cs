namespace Payroll
{
    partial class Frm_Staff
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Staff));
            this.btnsua = new System.Windows.Forms.Button();
            this.txthoten = new System.Windows.Forms.TextBox();
            this.txtnoilam = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewS = new System.Windows.Forms.DataGridView();
            this.hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noilam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnluu = new System.Windows.Forms.Button();
            this.btlxoa = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewS)).BeginInit();
            this.SuspendLayout();
            // 
            // btnsua
            // 
            this.btnsua.Location = new System.Drawing.Point(323, 91);
            this.btnsua.Name = "btnsua";
            this.btnsua.Size = new System.Drawing.Size(71, 23);
            this.btnsua.TabIndex = 11;
            this.btnsua.Text = "Sửa";
            this.btnsua.UseVisualStyleBackColor = true;
            this.btnsua.Click += new System.EventHandler(this.btnsua_Click);
            // 
            // txthoten
            // 
            this.txthoten.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txthoten.Location = new System.Drawing.Point(68, 56);
            this.txthoten.Name = "txthoten";
            this.txthoten.Size = new System.Drawing.Size(118, 23);
            this.txthoten.TabIndex = 9;
            // 
            // txtnoilam
            // 
            this.txtnoilam.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtnoilam.Location = new System.Drawing.Point(276, 56);
            this.txtnoilam.Name = "txtnoilam";
            this.txtnoilam.Size = new System.Drawing.Size(118, 23);
            this.txtnoilam.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Họ tên:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(214, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "Nơi làm:";
            // 
            // dataGridViewS
            // 
            this.dataGridViewS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hoten,
            this.noilam});
            this.dataGridViewS.Location = new System.Drawing.Point(12, 134);
            this.dataGridViewS.Name = "dataGridViewS";
            this.dataGridViewS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewS.Size = new System.Drawing.Size(382, 176);
            this.dataGridViewS.TabIndex = 22;
            // 
            // hoten
            // 
            this.hoten.HeaderText = "Họ tên";
            this.hoten.Name = "hoten";
            this.hoten.Width = 161;
            // 
            // noilam
            // 
            this.noilam.HeaderText = "Nơi làm";
            this.noilam.Name = "noilam";
            this.noilam.Width = 161;
            // 
            // btnluu
            // 
            this.btnluu.Location = new System.Drawing.Point(169, 91);
            this.btnluu.Name = "btnluu";
            this.btnluu.Size = new System.Drawing.Size(71, 23);
            this.btnluu.TabIndex = 23;
            this.btnluu.Text = "Lưu";
            this.btnluu.UseVisualStyleBackColor = true;
            this.btnluu.Click += new System.EventHandler(this.btnluu_Click);
            // 
            // btlxoa
            // 
            this.btlxoa.Location = new System.Drawing.Point(246, 91);
            this.btlxoa.Name = "btlxoa";
            this.btlxoa.Size = new System.Drawing.Size(71, 23);
            this.btlxoa.TabIndex = 24;
            this.btlxoa.Text = "Xóa";
            this.btlxoa.UseVisualStyleBackColor = true;
            this.btlxoa.Click += new System.EventHandler(this.btlxoa_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(103, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 23);
            this.label2.TabIndex = 25;
            this.label2.Text = "THÔNG TIN NHÂN VIÊN";
            // 
            // Frm_Staff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(406, 324);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btlxoa);
            this.Controls.Add(this.btnluu);
            this.Controls.Add(this.dataGridViewS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnsua);
            this.Controls.Add(this.txthoten);
            this.Controls.Add(this.txtnoilam);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Frm_Staff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NHÂN VIÊN";
            this.Load += new System.EventHandler(this.Frm_Staff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewS)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnsua;
        private System.Windows.Forms.TextBox txthoten;
        private System.Windows.Forms.TextBox txtnoilam;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewS;
        private System.Windows.Forms.Button btnluu;
        private System.Windows.Forms.Button btlxoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn noilam;
    }
}
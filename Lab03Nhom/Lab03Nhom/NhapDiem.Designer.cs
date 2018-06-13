namespace Lab03Nhom
{
    partial class NhapDiem
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
            this.buttonNhapDiem = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxMaLop = new System.Windows.Forms.TextBox();
            this.textBoxHoTen = new System.Windows.Forms.TextBox();
            this.textBoxMaSinhVien = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxDSHocPhan = new System.Windows.Forms.ComboBox();
            this.textBoxDiem = new System.Windows.Forms.TextBox();
            this.dataGridViewDiemThi = new System.Windows.Forms.DataGridView();
            this.textBoxMatKhau = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonXemDiem = new System.Windows.Forms.Button();
            this.buttonXoaDiem = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiemThi)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNhapDiem
            // 
            this.buttonNhapDiem.Location = new System.Drawing.Point(12, 159);
            this.buttonNhapDiem.Name = "buttonNhapDiem";
            this.buttonNhapDiem.Size = new System.Drawing.Size(272, 37);
            this.buttonNhapDiem.TabIndex = 4;
            this.buttonNhapDiem.Text = "Nhập điểm";
            this.buttonNhapDiem.UseVisualStyleBackColor = true;
            this.buttonNhapDiem.Click += new System.EventHandler(this.buttonNhapDiem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxMaLop);
            this.groupBox1.Controls.Add(this.textBoxHoTen);
            this.groupBox1.Controls.Add(this.textBoxMaSinhVien);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(305, 126);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sinh viên";
            // 
            // textBoxMaLop
            // 
            this.textBoxMaLop.Location = new System.Drawing.Point(79, 87);
            this.textBoxMaLop.Name = "textBoxMaLop";
            this.textBoxMaLop.Size = new System.Drawing.Size(206, 20);
            this.textBoxMaLop.TabIndex = 5;
            // 
            // textBoxHoTen
            // 
            this.textBoxHoTen.Location = new System.Drawing.Point(79, 56);
            this.textBoxHoTen.Name = "textBoxHoTen";
            this.textBoxHoTen.Size = new System.Drawing.Size(206, 20);
            this.textBoxHoTen.TabIndex = 4;
            // 
            // textBoxMaSinhVien
            // 
            this.textBoxMaSinhVien.Location = new System.Drawing.Point(79, 23);
            this.textBoxMaSinhVien.Name = "textBoxMaSinhVien";
            this.textBoxMaSinhVien.Size = new System.Drawing.Size(206, 20);
            this.textBoxMaSinhVien.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Mã lớp";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Họ tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Mã sinh viên";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonXemDiem);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBoxMatKhau);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.comboBoxDSHocPhan);
            this.groupBox2.Controls.Add(this.textBoxDiem);
            this.groupBox2.Controls.Add(this.buttonNhapDiem);
            this.groupBox2.Location = new System.Drawing.Point(323, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(304, 206);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Điểm";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Điểm";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Danh sách học phần";
            // 
            // comboBoxDSHocPhan
            // 
            this.comboBoxDSHocPhan.FormattingEnabled = true;
            this.comboBoxDSHocPhan.Location = new System.Drawing.Point(118, 24);
            this.comboBoxDSHocPhan.Name = "comboBoxDSHocPhan";
            this.comboBoxDSHocPhan.Size = new System.Drawing.Size(166, 21);
            this.comboBoxDSHocPhan.TabIndex = 1;
            // 
            // textBoxDiem
            // 
            this.textBoxDiem.Location = new System.Drawing.Point(118, 58);
            this.textBoxDiem.Name = "textBoxDiem";
            this.textBoxDiem.Size = new System.Drawing.Size(166, 20);
            this.textBoxDiem.TabIndex = 0;
            // 
            // dataGridViewDiemThi
            // 
            this.dataGridViewDiemThi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDiemThi.Location = new System.Drawing.Point(10, 238);
            this.dataGridViewDiemThi.Name = "dataGridViewDiemThi";
            this.dataGridViewDiemThi.Size = new System.Drawing.Size(614, 99);
            this.dataGridViewDiemThi.TabIndex = 7;
            // 
            // textBoxMatKhau
            // 
            this.textBoxMatKhau.Location = new System.Drawing.Point(118, 87);
            this.textBoxMatKhau.Name = "textBoxMatKhau";
            this.textBoxMatKhau.Size = new System.Drawing.Size(166, 20);
            this.textBoxMatKhau.TabIndex = 0;
            this.textBoxMatKhau.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Mật khẩu";
            // 
            // buttonXemDiem
            // 
            this.buttonXemDiem.Location = new System.Drawing.Point(12, 113);
            this.buttonXemDiem.Name = "buttonXemDiem";
            this.buttonXemDiem.Size = new System.Drawing.Size(272, 40);
            this.buttonXemDiem.TabIndex = 2;
            this.buttonXemDiem.Text = "Xem điểm";
            this.buttonXemDiem.UseVisualStyleBackColor = true;
            this.buttonXemDiem.Click += new System.EventHandler(this.buttonXemDiem_Click);
            // 
            // buttonXoaDiem
            // 
            this.buttonXoaDiem.Location = new System.Drawing.Point(10, 141);
            this.buttonXoaDiem.Name = "buttonXoaDiem";
            this.buttonXoaDiem.Size = new System.Drawing.Size(307, 39);
            this.buttonXoaDiem.TabIndex = 8;
            this.buttonXoaDiem.Text = "Xóa điểm";
            this.buttonXoaDiem.UseVisualStyleBackColor = true;
            this.buttonXoaDiem.Click += new System.EventHandler(this.buttonXoaDiem_Click);
            // 
            // NhapDiem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 352);
            this.Controls.Add(this.buttonXoaDiem);
            this.Controls.Add(this.dataGridViewDiemThi);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "NhapDiem";
            this.Text = "Nhập điểm sinh viên";
            this.Load += new System.EventHandler(this.NhapDiem_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDiemThi)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNhapDiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxMaLop;
        private System.Windows.Forms.TextBox textBoxHoTen;
        private System.Windows.Forms.TextBox textBoxMaSinhVien;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxDSHocPhan;
        private System.Windows.Forms.TextBox textBoxDiem;
        private System.Windows.Forms.DataGridView dataGridViewDiemThi;
        private System.Windows.Forms.Button buttonXemDiem;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxMatKhau;
        private System.Windows.Forms.Button buttonXoaDiem;
    }
}
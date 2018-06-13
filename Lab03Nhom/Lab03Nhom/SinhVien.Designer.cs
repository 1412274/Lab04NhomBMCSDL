namespace Lab03Nhom
{
    partial class SinhVien
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
            this.dg_DSSV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_MatKhau = new System.Windows.Forms.TextBox();
            this.tb_TenDN = new System.Windows.Forms.TextBox();
            this.tb_NgaySinh = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_DiaChi = new System.Windows.Forms.TextBox();
            this.tb_HoTen = new System.Windows.Forms.TextBox();
            this.tb_MaSV = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ThemLuu = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_MaLop = new System.Windows.Forms.TextBox();
            this.btn_NhapDIem = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_MaNV = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dg_DSSV)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dg_DSSV
            // 
            this.dg_DSSV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_DSSV.Location = new System.Drawing.Point(12, 121);
            this.dg_DSSV.Name = "dg_DSSV";
            this.dg_DSSV.Size = new System.Drawing.Size(659, 164);
            this.dg_DSSV.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(258, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh sách sinh viên";
            // 
            // btn_Luu
            // 
            this.btn_Luu.Location = new System.Drawing.Point(485, 305);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(75, 23);
            this.btn_Luu.TabIndex = 2;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Location = new System.Drawing.Point(596, 305);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(75, 23);
            this.btn_Thoat.TabIndex = 3;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Location = new System.Drawing.Point(372, 305);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(75, 23);
            this.btn_Xoa.TabIndex = 4;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tb_MatKhau);
            this.groupBox1.Controls.Add(this.tb_TenDN);
            this.groupBox1.Controls.Add(this.tb_NgaySinh);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_DiaChi);
            this.groupBox1.Controls.Add(this.tb_HoTen);
            this.groupBox1.Controls.Add(this.tb_MaSV);
            this.groupBox1.Location = new System.Drawing.Point(13, 374);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(658, 157);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin sinh viên";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(326, 123);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Mật khẩu";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(326, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Tên đăng nhập";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(326, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Địa chỉ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Ngày sinh";
            // 
            // tb_MatKhau
            // 
            this.tb_MatKhau.Location = new System.Drawing.Point(422, 120);
            this.tb_MatKhau.Name = "tb_MatKhau";
            this.tb_MatKhau.Size = new System.Drawing.Size(215, 20);
            this.tb_MatKhau.TabIndex = 7;
            this.tb_MatKhau.UseSystemPasswordChar = true;
            // 
            // tb_TenDN
            // 
            this.tb_TenDN.Location = new System.Drawing.Point(422, 75);
            this.tb_TenDN.Name = "tb_TenDN";
            this.tb_TenDN.Size = new System.Drawing.Size(215, 20);
            this.tb_TenDN.TabIndex = 6;
            // 
            // tb_NgaySinh
            // 
            this.tb_NgaySinh.Location = new System.Drawing.Point(97, 120);
            this.tb_NgaySinh.Name = "tb_NgaySinh";
            this.tb_NgaySinh.Size = new System.Drawing.Size(215, 20);
            this.tb_NgaySinh.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Họ tên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Mã sinh viên";
            // 
            // tb_DiaChi
            // 
            this.tb_DiaChi.Location = new System.Drawing.Point(422, 35);
            this.tb_DiaChi.Name = "tb_DiaChi";
            this.tb_DiaChi.Size = new System.Drawing.Size(215, 20);
            this.tb_DiaChi.TabIndex = 2;
            // 
            // tb_HoTen
            // 
            this.tb_HoTen.Location = new System.Drawing.Point(97, 75);
            this.tb_HoTen.Name = "tb_HoTen";
            this.tb_HoTen.Size = new System.Drawing.Size(215, 20);
            this.tb_HoTen.TabIndex = 1;
            // 
            // tb_MaSV
            // 
            this.tb_MaSV.Location = new System.Drawing.Point(97, 35);
            this.tb_MaSV.Name = "tb_MaSV";
            this.tb_MaSV.Size = new System.Drawing.Size(215, 20);
            this.tb_MaSV.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(280, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Thêm sinh viên";
            // 
            // btn_ThemLuu
            // 
            this.btn_ThemLuu.Location = new System.Drawing.Point(596, 537);
            this.btn_ThemLuu.Name = "btn_ThemLuu";
            this.btn_ThemLuu.Size = new System.Drawing.Size(75, 23);
            this.btn_ThemLuu.TabIndex = 7;
            this.btn_ThemLuu.Text = "Lưu";
            this.btn_ThemLuu.UseVisualStyleBackColor = true;
            this.btn_ThemLuu.Click += new System.EventHandler(this.btn_ThemLuu_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Location = new System.Drawing.Point(485, 537);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(75, 23);
            this.btn_Them.TabIndex = 8;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 13);
            this.label9.TabIndex = 9;
            this.label9.Text = "Mã lớp";
            // 
            // tb_MaLop
            // 
            this.tb_MaLop.Location = new System.Drawing.Point(106, 14);
            this.tb_MaLop.Name = "tb_MaLop";
            this.tb_MaLop.Size = new System.Drawing.Size(100, 20);
            this.tb_MaLop.TabIndex = 10;
            // 
            // btn_NhapDIem
            // 
            this.btn_NhapDIem.Location = new System.Drawing.Point(262, 305);
            this.btn_NhapDIem.Name = "btn_NhapDIem";
            this.btn_NhapDIem.Size = new System.Drawing.Size(75, 23);
            this.btn_NhapDIem.TabIndex = 11;
            this.btn_NhapDIem.Text = "Nhập điểm";
            this.btn_NhapDIem.UseVisualStyleBackColor = true;
            this.btn_NhapDIem.Click += new System.EventHandler(this.btn_NhapDIem_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "Mã nhân viên";
            // 
            // tb_MaNV
            // 
            this.tb_MaNV.Location = new System.Drawing.Point(106, 53);
            this.tb_MaNV.Name = "tb_MaNV";
            this.tb_MaNV.Size = new System.Drawing.Size(100, 20);
            this.tb_MaNV.TabIndex = 13;
            // 
            // SinhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 572);
            this.Controls.Add(this.tb_MaNV);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_NhapDIem);
            this.Controls.Add(this.tb_MaLop);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.btn_ThemLuu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Thoat);
            this.Controls.Add(this.btn_Luu);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dg_DSSV);
            this.Name = "SinhVien";
            this.Text = "SinhVien";
            this.Load += new System.EventHandler(this.SinhVien_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dg_DSSV)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dg_DSSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_MatKhau;
        private System.Windows.Forms.TextBox tb_TenDN;
        private System.Windows.Forms.TextBox tb_NgaySinh;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_DiaChi;
        private System.Windows.Forms.TextBox tb_HoTen;
        private System.Windows.Forms.TextBox tb_MaSV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_ThemLuu;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_MaLop;
        private System.Windows.Forms.Button btn_NhapDIem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_MaNV;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;

namespace Lab03Nhom
{
    public partial class SinhVien : Form
    {
        SqlConnection connection = null;
        SqlCommand command = null;
        String connectionstring = @"Data Source=KIM;Initial Catalog=QLSVNhom;Integrated Security=True";
        string MaLop = null;
        string MaNVDN = null;

        public SinhVien()
        {
            InitializeComponent();
        }

        public SinhVien(string _Malop, string _MaNVDN)
        {
            InitializeComponent();
            this.MaLop = _Malop;
            this.MaNVDN = _MaNVDN;
        }

        private void LoadData()
        {
            connection = new SqlConnection(connectionstring);
            connection.Open();

            //command.Parameters.Clear();

            String procname = "SP_DSSV";
            command = new SqlCommand(procname);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            command.Parameters.Add("@MALOP", SqlDbType.VarChar, 20);
            command.Parameters["@MALOP"].Value = MaLop;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dg_DSSV.DataSource = table;

            connection.Close();
        }

        private void DisableThem()
        {
            tb_MaSV.Enabled = false;
            tb_HoTen.Enabled = false;
            tb_DiaChi.Enabled = false;
            tb_NgaySinh.Enabled = false;
            tb_TenDN.Enabled = false;
            tb_MatKhau.Enabled = false;
        }

        private void EnableThem()
        {
            tb_MaSV.Enabled = true;
            tb_HoTen.Enabled = true;
            tb_DiaChi.Enabled = true;
            tb_NgaySinh.Enabled = true;
            tb_TenDN.Enabled = true;
            tb_MatKhau.Enabled = true;
        }

        private void ResetThem()
        {
            tb_MaSV.ResetText();
            tb_HoTen.ResetText();
            tb_DiaChi.ResetText();
            tb_NgaySinh.ResetText();
            tb_TenDN.ResetText();
            tb_MatKhau.ResetText();
        }

        private void SinhVien_Load(object sender, EventArgs e)
        {
            tb_MaLop.Text = MaLop;
            tb_MaNV.Text = MaNVDN;
            LoadData();
            DisableThem();
        }

        public string TaoMaSV()
        {
            string chuoi = null;

            connection = new SqlConnection(connectionstring);
            connection.Open();

            String procname = "SP_MAX_MASV";
            command = new SqlCommand(procname);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            command.Parameters.Add("@MASV", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
            int n = command.ExecuteNonQuery();

            string str = (string)command.Parameters["@MASV"].Value;

            str = str.Remove(0, 2);
            int kq = Int32.Parse(str) + 1;

            if (kq > 0 && kq < 10)
            {
                chuoi = "SV0" + kq.ToString();
            }
            if (kq >= 10 && kq < 100)
            {
                chuoi = "SV" + kq.ToString();
            }
            return chuoi;
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionstring);
                connection.Open();

                //command.Parameters.Clear();
                SqlCommand command1 = null;

                String procname = "SP_UPDATE_SV";
                command = new SqlCommand(procname);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                String procname1 = "SP_GET_MK";
                command1 = new SqlCommand(procname1);
                command1.CommandType = CommandType.StoredProcedure;
                command1.Connection = connection;

                command1.Parameters.Add("@MASV", SqlDbType.VarChar, 20);
                command1.Parameters.Add("@MATKHAU", SqlDbType.VarChar, 2048).Direction = ParameterDirection.Output;

                int CurrentIndex = dg_DSSV.CurrentCell.RowIndex;
                string MASV = Convert.ToString(dg_DSSV.Rows[CurrentIndex].Cells[0].Value.ToString());
                string HOTEN = Convert.ToString(dg_DSSV.Rows[CurrentIndex].Cells[1].Value.ToString());
                string NGAYSINH = Convert.ToString(dg_DSSV.Rows[CurrentIndex].Cells[2].Value.ToString());
                string DIACHI = Convert.ToString(dg_DSSV.Rows[CurrentIndex].Cells[3].Value.ToString());
                string TENDN = Convert.ToString(dg_DSSV.Rows[CurrentIndex].Cells[5].Value.ToString());
                string MATKHAU = Convert.ToString(dg_DSSV.Rows[CurrentIndex].Cells[6].Value.ToString());

                command1.Parameters["@MASV"].Value = MASV;
                int n1 = command1.ExecuteNonQuery();
                string matkhautemp = (string)command1.Parameters["@MATKHAU"].Value;

                command.Parameters.Add("@MASV", SqlDbType.VarChar, 20);
                command.Parameters.Add("@HOTEN", SqlDbType.NVarChar, 100);
                command.Parameters.Add("@NGAYSINH", SqlDbType.DateTime);
                command.Parameters.Add("@DIACHI", SqlDbType.NVarChar, 200);
                command.Parameters.Add("@TENDN", SqlDbType.NVarChar, 100);
                command.Parameters.Add("@MATKHAU", SqlDbType.VarChar, 100);

                command.Parameters["@MASV"].Value = MASV;
                command.Parameters["@HOTEN"].Value = HOTEN;
                command.Parameters["@NGAYSINH"].Value = NGAYSINH;
                command.Parameters["@DIACHI"].Value = DIACHI;
                command.Parameters["@TENDN"].Value = TENDN;

                if (matkhautemp == MATKHAU)
                {
                    command.Parameters["@MATKHAU"].Value = MATKHAU;
                }
                else
                {
                    command.Parameters["@MATKHAU"].Value = MD5Hash.Hash(MATKHAU);
                }

                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Sửa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Sử thông tin thất bại!", "Thông báo", MessageBoxButtons.OK);
                }

                connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionstring);
                connection.Open();

                //command.Parameters.Clear();

                String procname = "SP_DELETE_SV";
                command = new SqlCommand(procname);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                int CurrentIndex = dg_DSSV.CurrentCell.RowIndex;
                string MASV = Convert.ToString(dg_DSSV.Rows[CurrentIndex].Cells[0].Value.ToString());

                command.Parameters.Add("@MASV", SqlDbType.VarChar, 20);

                command.Parameters["@MASV"].Value = MASV;

                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK);
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Xóa sinh viên thất bại!", "Thông báo", MessageBoxButtons.OK);
                }

                connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            EnableThem();
            string masv = TaoMaSV();
            tb_MaSV.Text = masv;
        }

        private void btn_ThemLuu_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionstring);
                connection.Open();

                //command.Parameters.Clear();

                String procname = "SP_INS_SINHVIEN";
                command = new SqlCommand(procname);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                command.Parameters.Add("@MASV", SqlDbType.VarChar, 20);
                command.Parameters.Add("@HOTEN", SqlDbType.NVarChar, 100);
                command.Parameters.Add("@NGAYSINH", SqlDbType.DateTime);
                command.Parameters.Add("@DIACHI", SqlDbType.NVarChar, 200);
                command.Parameters.Add("@MALOP", SqlDbType.NVarChar, 20);
                command.Parameters.Add("@TENDN", SqlDbType.NVarChar, 100);
                command.Parameters.Add("@MATKHAU", SqlDbType.VarChar, 100);

                command.Parameters["@MASV"].Value = tb_MaSV.Text;
                command.Parameters["@HOTEN"].Value = tb_HoTen.Text;
                command.Parameters["@NGAYSINH"].Value = tb_NgaySinh.Text;
                command.Parameters["@DIACHI"].Value = tb_DiaChi.Text;
                command.Parameters["@MALOP"].Value = MaLop;
                command.Parameters["@TENDN"].Value = tb_TenDN.Text;
                command.Parameters["@MATKHAU"].Value = MD5Hash.Hash(tb_MatKhau.Text);

                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK);
                    LoadData();
                    ResetThem();
                    DisableThem();
                }
                else
                {
                    MessageBox.Show("Thêm sinh viên thất bại!", "Thông báo", MessageBoxButtons.OK);
                }

                connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_NhapDIem_Click(object sender, EventArgs e)
        {
            int CurrentIndex = dg_DSSV.CurrentCell.RowIndex;
            string MASV = Convert.ToString(dg_DSSV.Rows[CurrentIndex].Cells[0].Value.ToString());
            string HOTEN = Convert.ToString(dg_DSSV.Rows[CurrentIndex].Cells[1].Value.ToString());
            //string MALOP = Convert.ToString(dg_DSSV.Rows[CurrentIndex].Cells[4].Value.ToString());

            NhapDiem formnd = new NhapDiem(MASV, HOTEN, MaLop, MaNVDN);
            //this.Hide();
            formnd.ShowDialog();

        }
    }
}

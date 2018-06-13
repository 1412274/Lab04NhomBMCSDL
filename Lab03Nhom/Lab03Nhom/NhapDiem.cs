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

namespace Lab03Nhom
{
    public partial class NhapDiem : Form
    {
        String connectionString = @"Data Source=KIM;Initial Catalog=QLSVN;Integrated Security=True";
        String MaSV = null;
        String HoTen = null;
        String MaLop = null;
        String MaNVDN = null;

        public NhapDiem()
        {
            InitializeComponent();
        }

        public NhapDiem(String _MaSV, String _HoTen, String _MaLop, String _MaNVDN)
        {
            InitializeComponent();
            this.MaSV = _MaSV;
            this.HoTen = _HoTen;
            this.MaLop = _MaLop;
            this.MaNVDN = _MaNVDN;
        }

        private void NhapDiem_Load(object sender, EventArgs e)
        {
            this.textBoxMaSinhVien.Text = MaSV;
            this.textBoxHoTen.Text = HoTen;
            this.textBoxMaLop.Text = MaLop;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_SEL_HOCPHAN ", connection);
                command.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader;
                DataTable table = new DataTable();

                reader = command.ExecuteReader();

                table.Load(reader);

                this.comboBoxDSHocPhan.DisplayMember = "TENHP";
                this.comboBoxDSHocPhan.ValueMember = "MAHP";
                this.comboBoxDSHocPhan.DataSource = table;

                connection.Close();
            }
            
        }

        private void buttonXemDiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_SEL_BANGDIEM ", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Clear();
                command.Parameters.Add("@MASV", SqlDbType.VarChar, 20);
                command.Parameters.Add("@MK", SqlDbType.NVarChar, 100);
                command.Parameters.Add("@PUBKEY", SqlDbType.VarChar, 20);

                command.Parameters["@MASV"].Value = this.textBoxMaSinhVien.Text;
                command.Parameters["@MK"].Value = this.textBoxMatKhau.Text;
                command.Parameters["@PUBKEY"].Value = MaNVDN;

                SqlDataReader reader;
                DataTable table = new DataTable();

                reader = command.ExecuteReader();
                table.Load(reader);

                this.dataGridViewDiemThi.DataSource = table;

                command.CommandText = "SP_SEL_HOCPHAN";
                command.Parameters.Clear();


                connection.Close();
            }
        }

        private void buttonNhapDiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("SP_INS_BANGDIEM  ", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Clear();
                command.Parameters.Add("@MASV", SqlDbType.VarChar, 20);
                command.Parameters.Add("@MAHP", SqlDbType.VarChar, 20);
                command.Parameters.Add("@PUBKEY", SqlDbType.VarChar, 20);
                command.Parameters.Add("@DIEMTHI", SqlDbType.Float);
                command.Parameters.Add("@KQ", SqlDbType.Int).Direction = ParameterDirection.Output;

                command.Parameters["@MASV"].Value = this.textBoxMaSinhVien.Text;
                command.Parameters["@MAHP"].Value = this.comboBoxDSHocPhan.SelectedValue;
                command.Parameters["@PUBKEY"].Value = MaNVDN;
                command.Parameters["@DIEMTHI"].Value = this.textBoxDiem.Text;
                command.Parameters["@KQ"].Value = 0;

                command.ExecuteNonQuery();
                
                if (command.Parameters["@KQ"].Value.ToString() == "1")
                {
                    MessageBox.Show("Có lỗi xảy ra");
                } else
                {
                    MessageBox.Show("Thêm điểm thành công");
                }

                connection.Close();
            }
        }

        private void buttonXoaDiem_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridViewDiemThi.SelectedRows)
            {
                String maSV = item.Cells["MASV"].Value.ToString();
                String maHP = item.Cells["MAHP"].Value.ToString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    String query = "delete from bangdiem where masv = '" + maSV + "' and mahp = '" + maHP + "'";
                  
                    SqlCommand command = new SqlCommand(query, connection);
                    command.CommandType = CommandType.Text;

                    int kq = command.ExecuteNonQuery();

                    if (kq != 1)
                    {
                        MessageBox.Show("Xóa thất bại");
                    } else
                    {
                        this.dataGridViewDiemThi.Rows.RemoveAt(item.Index);
                        MessageBox.Show("Xóa thành công");
                    }

                    connection.Close();
                }
            }
        }
    }
}

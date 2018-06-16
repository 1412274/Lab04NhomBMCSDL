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
        String connectionString = ConnectString.GetConnection();
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

                SqlCommand command = new SqlCommand("select * from hocphan ", connection);

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

                SqlCommand command = new SqlCommand("select masv, mahp, diemthi from bangdiem where masv = '" + this.textBoxMaSinhVien.Text + "'", connection);

                SqlDataReader reader;

                reader = command.ExecuteReader();

                DataTable table = new DataTable();
                table.Columns.Add(new DataColumn("masv"));
                table.Columns.Add(new DataColumn("mahp"));
                table.Columns.Add(new DataColumn("diemthi"));

                while (reader.Read())
                {
                    byte[] byteDiemThi = (Byte[])reader.GetValue(2);
                    table.Rows.Add(reader.GetValue(0), reader.GetValue(1), RSACryptography.RSAdecrypt(byteDiemThi, this.textBoxMatKhau.Text));
                }

                this.dataGridViewDiemThi.DataSource = table;

                connection.Close();
            }
        }

        private void buttonNhapDiem_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                String pubKey = RSACryptography.createKeyPair(this.textBoxMatKhau.Text);
                byte[] encryptedDiem = RSACryptography.RSAencrypt(this.textBoxDiem.Text, pubKey);

                String commandText = "insert into bangdiem values('"
                    + this.textBoxMaSinhVien.Text + "', '"
                    + this.comboBoxDSHocPhan.SelectedValue + "', @encryptedDiem)";

                SqlCommand command = new SqlCommand(commandText, connection);
                command.Parameters.Add("@encryptedDiem", SqlDbType.VarBinary);
                command.Parameters["@encryptedDiem"].Value = encryptedDiem;

                int result = command.ExecuteNonQuery();

                if (result != 1)
                {
                    MessageBox.Show("Có lỗi xảy ra");
                }
                else
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
                    }
                    else
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

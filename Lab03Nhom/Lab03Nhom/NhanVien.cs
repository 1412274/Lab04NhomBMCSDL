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
using System.Security.Cryptography;
using System.Threading;

namespace Lab03Nhom
{
    public partial class NhanVien : Form
    {
        SqlConnection connection = null;
        SqlCommand command;
        String connectionstring = ConnectString.GetConnection();

        //Mã truyền
        public string manvdn = null;

        public NhanVien()
        {
            InitializeComponent();
        }

        public NhanVien(string manv)
        {
            InitializeComponent();
            this.manvdn = manv;
        }

        private void ShowDanhSachLop()
        {
            DanhSachLop dsl = new DanhSachLop(manvdn);
            dsl.ShowDialog();
        }

        private void EnableTextBox()
        {
            tb_MaNV.Enabled = true;
            tb_Email.Enabled = true;
            tb_HoTen.Enabled = true;
            tb_Luong.Enabled = true;
            tb_MatKhau.Enabled = true;
            tb_TenDN.Enabled = true;
        }

        private void DisableTextBox()
        {
            tb_MaNV.Enabled = false;
            tb_Email.Enabled = false;
            tb_HoTen.Enabled = false;
            tb_Luong.Enabled = false;
            tb_MatKhau.Enabled = false;
            tb_TenDN.Enabled = false;
        }

        private void ClearTextBox()
        {
            tb_MaNV.ResetText();
            tb_Email.ResetText();
            tb_HoTen.ResetText();
            tb_Luong.ResetText();
            tb_MatKhau.ResetText();
            tb_TenDN.ResetText();
        }

        public string TaoMaNV()
        {
            string chuoi = null;

            connection = new SqlConnection(connectionstring);
            connection.Open();

            String procname = "SP_MAX_MANV";
            command = new SqlCommand(procname);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            command.Parameters.Add("@MANV", SqlDbType.VarChar, 20).Direction = ParameterDirection.Output;
            int n = command.ExecuteNonQuery();

            string str = (string)command.Parameters["@MANV"].Value;

            str = str.Remove(0, 2);
            int kq = Int32.Parse(str) + 1;

            if (kq > 0 && kq < 10)
            {
                chuoi = "NV0" + kq.ToString();
            }
            if (kq >= 10)
            {
                chuoi = "NV" + kq.ToString();
            }
            return chuoi;
        }

        private void DanhSachNhanVien_Load(object sender, EventArgs e)
        {
            DisableTextBox();
            tb_MaNVDN.Text = manvdn;
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            EnableTextBox();
            string MANV = TaoMaNV();
            tb_MaNV.Text = MANV;
        }

        private void btn_LuuThem_Click(object sender, EventArgs e)
        {
            try
            {
                connection = new SqlConnection(connectionstring);
                connection.Open();

                //command.Parameters.Clear();

                String procname = "SP_INS_PUBLIC_ENCRYPT_NHANVIEN";
                command = new SqlCommand(procname);
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;

                command.Parameters.Add("@MANV", SqlDbType.VarChar, 20);
                command.Parameters.Add("@HOTEN", SqlDbType.NVarChar, 100);
                command.Parameters.Add("@EMAIL", SqlDbType.VarChar, 20);
                command.Parameters.Add("@LUONG", SqlDbType.VarChar, 2048);
                command.Parameters.Add("@TENDN", SqlDbType.NVarChar, 100);
                command.Parameters.Add("@MATKHAU", SqlDbType.VarChar, 2048);
                command.Parameters.Add("@PUB", SqlDbType.VarChar, 2048);


                command.Parameters["@MANV"].Value = tb_MaNV.Text;
                command.Parameters["@HOTEN"].Value = tb_HoTen.Text;
                command.Parameters["@EMAIL"].Value = tb_Email.Text;
                command.Parameters["@TENDN"].Value = tb_TenDN.Text;

                String privatekey = SHA1Hash.Hash(tb_MatKhau.Text);
                String publickey = RSACryptography.createKeyPair(privatekey);

                //Mã hóa lương
                byte[] LuongMaHoa = RSACryptography.RSAencrypt(tb_Luong.Text, publickey);

                command.Parameters["@LUONG"].Value = Encoding.Default.GetString(LuongMaHoa);
                command.Parameters["@MATKHAU"].Value = privatekey;
                command.Parameters["@PUB"].Value = publickey;

                int n = command.ExecuteNonQuery();
                if (n > 0)
                {
                    MessageBox.Show("Thêm nhân viên thành công!", "Thông báo", MessageBoxButtons.OK);
                    //LoadData();
                    ClearTextBox();
                    DisableTextBox();
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thất bại!", "Thông báo", MessageBoxButtons.OK);
                }

                connection.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btn_GiaiMa_Click(object sender, EventArgs e)
        {
            connection = new SqlConnection(connectionstring);
            connection.Open();

            //command.Parameters.Clear();

            String procname = "SP_SEL_PUBLIC_ENCRYPT_NHANVIEN";
            command = new SqlCommand(procname);
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            command.Parameters.Add("@MANV", SqlDbType.VarChar, 20);
            command.Parameters.Add("@MATKHAU", SqlDbType.VarChar, 2048);

            command.Parameters["@MANV"].Value = manvdn;
            command.Parameters["@MATKHAU"].Value = SHA1Hash.Hash(tb_MatKhauGM.Text);

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            adapter.SelectCommand = command;
            adapter.Fill(table);

            byte[] LuongMaHoa = Encoding.Default.GetBytes(table.Rows[0]["LUONG"].ToString());
            String privatekey = SHA1Hash.Hash(tb_MatKhauGM.Text);

            //Giả mã lương
            String LuongGiaiMa = RSACryptography.RSAdecrypt(LuongMaHoa, privatekey);

            table.Rows[0].SetField("LUONG", LuongGiaiMa);

            dg_GiaiMa.DataSource = table;

        }

        private void btn_DanhSachLop_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ShowDanhSachLop));
            thread.Start();
            this.Close();

        }
    }
}

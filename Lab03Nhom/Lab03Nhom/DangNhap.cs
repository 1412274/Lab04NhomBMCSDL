using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace Lab03Nhom
{
    public partial class DangNhap : Form
    {
        public string name;
        public string password;
        public DangNhap()
        {
            InitializeComponent();
        }

        private void ShowDanhSachLop()
        {
            DanhSachLop dsl = new DanhSachLop(name);
            dsl.ShowDialog();
        }

        string connectstring = "Data Source=KIM;Initial Catalog=QLSVN;Integrated Security=True";
        private void btnlogin_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectstring);
            name = txtname.Text;
            password = txtpass.Text;
            string query = "select * from NHANVIEN where MANV = '"+name+"' and hashbytes('sha1','"+password+"') = MATKHAU";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            connection.Close();

            int check = ds.Tables[0].Rows.Count;
            if (check > 0)
            {
                
                if(DialogResult.OK == MessageBox.Show("Đăng nhập thành công!!!"))
                {
                    Thread thread = new Thread(new ThreadStart(ShowDanhSachLop));
                    thread.Start();
                    this.Close();


                    DanhSachLop dslop = new DanhSachLop();
                    this.Hide();
                    dslop.ShowDialog();
                    //this.Close();
                }
                
            }
            else
                MessageBox.Show("Đăng nhập thất bại!!! Sai tên đăng nhập hoặc mật khẩu");
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}

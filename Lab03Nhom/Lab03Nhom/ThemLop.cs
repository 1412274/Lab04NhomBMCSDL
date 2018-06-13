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
    public partial class ThemLop : Form
    {
        public string manv = null;
        public ThemLop()
        {
            InitializeComponent();
        }

        public ThemLop(string _manv)
        {
            InitializeComponent();
            this.manv = _manv;
        }

        string connectstring = "Data Source=KIM;Initial Catalog=QLSVN;Integrated Security=True";
        private void ThemLop_Load(object sender, EventArgs e)
        {
            //string manv = DangNhap.name;
            SqlConnection conn = new SqlConnection(connectstring);
            conn.Open();
            string query = "select MANV from NHANVIEN where MANV != '"+manv+"'";//nhan vien khong duoc phan cong lop cho chinh minh

            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            cbmanv.DataSource = dt;
            cbmanv.DisplayMember = "MANV";
            //cbmanv.ValueMember = "MANV";
            conn.Close();
        }

        private void btnthem_Click(object sender, EventArgs e)
        {
            //ComboBox cb = sender as cbmanv;
            SqlConnection conn = new SqlConnection(connectstring);
            conn.Open();
            string query = "select *from LOP where MALOP = '" + txtmalop.Text + "'";
            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            conn.Close();

            int count = ds.Tables[0].Rows.Count;
            if(count > 0)
            {
                MessageBox.Show("Mã lớp học đã tồn tại!!!");
            }
            else
            {
                DataRowView dr = cbmanv.SelectedItem as DataRowView;
                if (dr != null)
                {
                    //MessageBox.Show(dr["MANV"].ToString());
                    string cbchoice = dr["MANV"].ToString();
                    InsertData(cbchoice);
                }
            }
            void InsertData(string cb)
            {
                conn.Open();
                string insert = "insert into LOP values('" + txtmalop.Text + "', N'" + txttenlop.Text + "', '" + cb + "')";
                command = new SqlCommand(insert, conn);
                //adapter = new SqlDataAdapter(command);
                SqlDataReader reader = command.ExecuteReader();
                conn.Close();
                if (DialogResult.OK == MessageBox.Show("Thêm dữ liệu thành công!!!"))
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.DataSource = GetLopHoc().Tables[0];
                }
              
            }
            DataSet GetLopHoc()
            {
                conn.Open();
                string getlop = "select *from LOP";
                command = new SqlCommand(getlop, conn);
                adapter = new SqlDataAdapter(command);
                DataSet data = new DataSet();
                adapter.Fill(data);
                conn.Close();
                return data;
            }

        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

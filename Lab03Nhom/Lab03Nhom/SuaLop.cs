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

namespace Lab03Nhom
{
    public partial class SuaLop : Form
    {
        public string manv = null;
        public SuaLop()
        {
            InitializeComponent();
        }
        public SuaLop(string _manv)
        {
            InitializeComponent();
            this.manv = _manv;
        }
        string connectstring = ConnectString.GetConnection();

        private void SuaLop_Load(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectstring);
            conn.Open();
            string query = "select MANV from NHANVIEN";

            SqlCommand command = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            cbmanv.DataSource = dt;
            cbmanv.DisplayMember = "MANV";
            //cbmanv.ValueMember = "MANV";
            cbmanv.Enabled = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.DataSource = GetLopHoc().Tables[0];
            conn.Close();
        }
        DataSet GetLopHoc()
        {
            //string manv = DangNhap.name;
            DataSet data = new DataSet();
            string query = "select l.MALOP, l.TENLOP from NHANVIEN nv, LOP l where l.MANV = nv.MANV and nv.MANV = '" + manv + "'";
            SqlConnection conn = new SqlConnection(connectstring);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(data);
            conn.Close();
            return data;
        }
        string selectedclass()
        {
            DataSet data = GetLopHoc();
            int i = dataGridView1.CurrentCell.RowIndex;
            string index = data.Tables[0].Rows[i]["MALOP"].ToString();
            return index;
        }
        private void btnsua_Click(object sender, EventArgs e)
        {
            DataSet data = GetLopHoc();
            cbmanv.Enabled = true;
            int i = dataGridView1.CurrentCell.RowIndex;
            string index = data.Tables[0].Rows[i]["MALOP"].ToString(); 
            //MessageBox.Show(index);
            txtmalop.Text = index;
            txtmalop.Enabled = false;
            txttenlop.Text = data.Tables[0].Rows[i]["TENLOP"].ToString();
            cbmanv.Text = manv;


        }
        void UpdateLop(string cb)
        {
            string malop = selectedclass();
            SqlConnection conn = new SqlConnection(connectstring);
            conn.Open();
            string update = "update LOP set TENLOP = N'"+txttenlop.Text+"', MANV = '"+cb+"' where MALOP = '"+malop+"'";
            SqlCommand command = new SqlCommand(update, conn);
            SqlDataReader r = command.ExecuteReader();
            conn.Close();
            if (DialogResult.OK == MessageBox.Show("Sửa dữ liệu thành công!!!"))
            {
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridView1.DataSource = GetLopHoc().Tables[0];
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            DataRowView dr = cbmanv.SelectedItem as DataRowView;
            if (dr != null)
            {
                //MessageBox.Show(dr["MANV"].ToString());
                string cbchoice = dr["MANV"].ToString();
                UpdateLop(cbchoice);
            }
        }
    }
}

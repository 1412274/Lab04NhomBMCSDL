﻿using System;
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
    public partial class DanhSachLop : Form
    {
        public string manv = null;
        public string malop = null;

        public DanhSachLop()
        {
            InitializeComponent();
            
        }
        public DanhSachLop(string name)
        {
            InitializeComponent();
            this.manv = name;
        }

        private void ShowThemLop()
        {
            ThemLop tl = new ThemLop(manv);
            tl.ShowDialog();
        }

        private void ShowSuaLop()
        {
            SuaLop sl = new SuaLop(manv);
            sl.ShowDialog();
        }

        private void ShowSinhVien()
        {
            SinhVien sv = new SinhVien(malop, manv);
            sv.ShowDialog();
        }

        string connectstring = "Data Source=DESKTOP-BD4IRUN\\SQLSERVER2017;Initial Catalog=QLSVNhom;Integrated Security=True";

        private void DanhSachLop_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectstring);
           
            //string name = DangNhap.name;
        
            string query = "select * from NHANVIEN where MANV = '" + manv + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            //SqlDataAdapter adapter = new SqlDataAdapter(command);
            SqlDataReader r = command.ExecuteReader();
            if (r.Read())
            {
                txtmanv.Text = r.GetValue(0).ToString();
                txthoten.Text = r.GetValue(1).ToString();
                txtemail.Text = r.GetValue(2).ToString();
            }
            connection.Close();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; 
            dataGridView1.DataSource = GetLopHoc().Tables[0];
        }

        DataSet GetLopHoc()
        {
            //string manv = DangNhap.name;
            DataSet data = new DataSet();
            string query = "select l.MALOP, l.TENLOP from NHANVIEN nv, LOP l where l.MANV = nv.MANV and nv.MANV = '"+manv+"'";
            SqlConnection conn = new SqlConnection(connectstring);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            adapter.Fill(data);
            conn.Close();
            return data;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ShowThemLop));
            thread.Start();
            this.Close();

            //ThemLop lop = new ThemLop();
            //this.Hide();
            //lop.Show();

        }

        private void btn_DSSV_Click(object sender, EventArgs e)
        {
            int CurrentIndex = dataGridView1.CurrentCell.RowIndex;
            malop = Convert.ToString(dataGridView1.Rows[CurrentIndex].Cells[0].Value.ToString());

            Thread thread = new Thread(new ThreadStart(ShowSinhVien));
            thread.Start();
            this.Close();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(ShowSuaLop));
            thread.Start();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataSet data = GetLopHoc();
            int i = dataGridView1.CurrentCell.RowIndex;
            string index = data.Tables[0].Rows[i]["MALOP"].ToString();
            SqlConnection conn = new SqlConnection(connectstring);
            conn.Open();
            string delete = "delete from LOP where MALOP = '"+index+"'";
            SqlCommand command = new SqlCommand(delete, conn);

            string MessageBoxTitle = "Thông báo!!!";
            string MessageBoxContent = "Bạn có thực sự muốn xóa lớp không?";

            DialogResult result = MessageBox.Show(MessageBoxContent, MessageBoxTitle, MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes)
            {
                SqlDataReader r = command.ExecuteReader();
                if (DialogResult.OK == MessageBox.Show("Xóa dữ liệu thành công!!!"))
                {
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dataGridView1.DataSource = GetLopHoc().Tables[0];
                }
            }
            if(result == DialogResult.No)
            {
                //
            }


        }
    }
}

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

namespace PBL_3
{
    public partial class List : Form
    {
        
        public List()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        public SqlCommand cmd;
        SqlDataAdapter ad = new SqlDataAdapter();
        DataTable dt = new DataTable();
 
        //load dữ liệu lên bảng
        void loadData()
        {
            cmd = conn.CreateCommand();
            cmd.CommandText = "select ID,US,Name,Birthday,PhoneNumber,Position,Email from Inf_user";
            ad.SelectCommand = cmd;
            dt.Clear();
            ad.Fill(dt);
            dgv1.DataSource = dt;
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }
        Modify modify = new Modify();
        Login login = new Login();
        private void guna2Button1_Click(object sender, EventArgs e) //Button Back
        {
            MainForm mf2 = new MainForm();
            ////this.Hide();
            //string rs = login.roleLogin + " / " + modify.role;
            //mf2.mName(rs);
            mf2.ShowDialog();

            //this.Close();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e) //Show
        {
            conn = Connection.getSqlConnection();
            conn.Open();
            loadData();
        }

    }
}

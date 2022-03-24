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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void butRegister_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-K9NDIH8;Initial Catalog=Information;Integrated Security=True");
            try
            {

                string user = txtUsername.Text;
                string password = txtPassword.Text;
                string sql = "select * from Infor_user where US= '" + user + "'and PW ='" +password+ "'";
                cn.Open();
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader data = cmd.ExecuteReader();
                if(data.Read()==true)
                {
                   // MessageBox.Show("Login successed!");
                    MainForm mf = new MainForm();
                    mf.Show();
                } else
                {
                    MessageBox.Show("Login failed!");
                }
            //cn.Close();
        }
            catch (Exception ex)
            {
                MessageBox.Show("Connection failed!");
            }
}

        //private void guna2PictureBox1_Click(object sender, EventArgs e)
        //{
        //    txtPassword.UseSystemPasswordChar = false;
        //}

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb1.Checked) txtPassword.UseSystemPasswordChar = false;
            else txtPassword.UseSystemPasswordChar = true;
            txtPassword.PasswordChar = '\0';
        }
    }
}

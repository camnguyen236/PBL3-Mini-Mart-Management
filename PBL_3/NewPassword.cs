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
    public partial class NewPassword : Form
    {
        public NewPassword()
        {
            InitializeComponent();
        }

        SqlConnection conn;
        public SqlCommand cmd;
        SqlDataAdapter ad = new SqlDataAdapter();

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(tbNewPass.Text.Trim() == "" || tbConfirmNewPass.Text.Trim() == "")
            {
                MessageBox.Show("Please fill in the required information");
            }
            else
            {
                if(tbNewPass.Text != tbConfirmNewPass.Text)
                {
                    MessageBox.Show("Password and confirm password does not match");
                }
                else
                {
                    conn = Connection.getSqlConnection();
                    conn.Open();
                    cmd = conn.CreateCommand();
                    cmd.CommandText = "update Inf_user set PW = '" + tbConfirmNewPass.Text +"'"; //vì mã nhân viên là khóa chính
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Reset Successful!");
                }
            }
        }
    }
}

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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
       // public string roleLogin;
        private void butRegister_Click(object sender, EventArgs e)
        {
            Register r = new Register();
            r.Show();
        }
        Modify modify = new Modify();
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string user = txtUsername.Text;
            string password = txtPassword.Text;
            if(user.Trim() == "") MessageBox.Show("Please fill in username information!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (password.Trim() == "") MessageBox.Show("Please fill in password information!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                string sql = "select * from Inf_user where US= '" + user + "'and PW ='" + password + "'";
                if(modify.Accounts(sql).Count() !=0)
                {
                    MainForm mf = new MainForm();
                    //mf.load_data(txtUsername.Text);
                    //roleLogin = txtUsername.Text;
                    string rs = txtUsername.Text + " / " + modify.role; 
                    mf.mName(rs);
                    //f1.Close();
                    this.Hide();
                    mf.ShowDialog();
                    this.Close();
                    
                    
                }
                else
                {
                    MessageBox.Show("Login failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //    Sql_connect sQL_Connect = new Sql_connect();
            //    SqlConnection cn = sQL_Connect.connect();
            //    try
            //    {

            //        string user = txtUsername.Text;
            //        string password = txtPassword.Text;
            //        string sql = "select * from Inf_user where US= '" + user + "'and PW ='" +password+ "'";
            //        cn.Open();
            //        SqlCommand cmd = new SqlCommand(sql, cn);
            //        SqlDataReader data = cmd.ExecuteReader();
            //        if(data.Read()==true)
            //        {
            //           // MessageBox.Show("Login successed!");
            //            MainForm mf = new MainForm();
            //            //mf.load_data(txtUsername.Text);
            //            mf.mName(txtUsername.Text);
            //            mf.Show();
            //        } else
            //        {
            //            MessageBox.Show("Login failed!", "Warning",MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            //        cn.Close();
            //}
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("Connection failed!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb1.Checked) txtPassword.UseSystemPasswordChar = false;
            else txtPassword.UseSystemPasswordChar = true;
            txtPassword.PasswordChar = '\0';
        }

        private void label2_Click(object sender, EventArgs e)
        {
            ResetPassword rs = new ResetPassword();
            rs.ShowDialog();
        }
        //public string showName()
        //{
        //    return txtUsername.Text;
        //}
    }
}

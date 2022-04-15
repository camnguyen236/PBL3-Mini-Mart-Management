using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class Login : Form
    {
        Account account = new Account();
       
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            account.US = txtUsername.Text;
            account.PW = txtPassword.Text;
            switch(AccountBLL.Instance.checkLogin(account))
            {
                case "Please fill in username information!":
                    MessageBox.Show("Please fill in username information!");
                    break;
                case "Please fill in password information!":
                    MessageBox.Show("Please fill in password information!");
                    break;
                case "Login Failed!":
                    MessageBox.Show("Login Failed!");
                    break;
                default:
                    //MessageBox.Show("Login Successed!");
                    MainForm mf = new MainForm();
                    //mf.load_data(txtUsername.Text);
                    string rs = txtUsername.Text + " / " + AccountBLL.Instance.getRole();
                    mf.mName(rs);
                    this.Hide();
                    mf.ShowDialog();
                    this.Close();
                    break;
            }
            
        }

        private void cb1_CheckedChanged(object sender, EventArgs e)
        {
            if (cb1.Checked) txtPassword.UseSystemPasswordChar = false;
            else txtPassword.UseSystemPasswordChar = true;
            txtPassword.PasswordChar = '\0';
        }

        private void label2_Click(object sender, EventArgs e) //forgot password
        {
            ResetPassword rs = new ResetPassword();
            rs.ShowDialog();
        }
    }
}

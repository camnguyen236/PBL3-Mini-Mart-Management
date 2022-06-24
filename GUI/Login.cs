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
                    account = AccountBLL.Instance.getAccountByUS(txtUsername.Text);
                    MainForm mf = new MainForm(account);
                    this.Close();
                    mf.ShowDialog();
                    //this.Close();
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

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.GetNextControl(ActiveControl, true) != null)
                {
                    e.Handled = true;
                    this.GetNextControl(ActiveControl, true).Focus();
                }
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}

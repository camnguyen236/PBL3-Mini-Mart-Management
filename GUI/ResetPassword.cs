using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;


namespace GUI
{
    public partial class ResetPassword:Form
    {
        private static Random rnd = new Random();
        private int rd = rnd.Next(100000, 999999);
        private bool flag = false;
        public ResetPassword()
        {
            InitializeComponent();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "" || tbEmail.Text.Trim() == "")
            {
                MessageBox.Show("Please fill in the required information");
                return;
            }
            //if (!listUS.checkUserName(txtUserName.Text)) MessageBox.Show("Username does not exist");
            //else
            //{
            if (sendMail.Instance.checkMail(tbEmail.Text) != "OK") MessageBox.Show(sendMail.Instance.checkMail(tbEmail.Text) + "\nPlease re-enter your email");
            else
            {
                MessageBox.Show(sendMail.Instance.Send(tbEmail.Text, "Verification code", "Code: " + rd.ToString()));
                flag = true;
            }
            //}
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!flag)
            {
                MessageBox.Show("Please fill in the required information");
                return;
            }
            if (tbCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the verification code");
                return;
            }
            if (tbCode.Text != rd.ToString())
            {
                MessageBox.Show("Confirmation code is incorrect");
            }
            else
            {
                NewPassword np = new NewPassword();
                this.Hide();
                np.ShowDialog();
                this.Close();
            }
        }

        private void btnOK_Click_1(object sender, EventArgs e)
        {
            if (!flag)
            {
                MessageBox.Show("Please fill in the required information");
                return;
            }
            if (tbCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter the verification code");
                return;
            }
            if (tbCode.Text != rd.ToString())
            {
                MessageBox.Show("Confirmation code is incorrect");
            }
            else
            {
                NewPassword np = new NewPassword();
                this.Hide();
                np.ShowDialog();
                this.Close();
            }
        }

      
    }
}

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
using BLL;

namespace GUI
{
    public partial class NewPassword : Form
    {
        string US;
        public NewPassword(string name)
        {
            InitializeComponent();
            US = name;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (tbNewPass.Text.Trim() == "" || tbConfirmNewPass.Text.Trim() == "")
            {
                MessageBox.Show("Please fill in the required information");
            }
            else
            {
                if (tbNewPass.Text != tbConfirmNewPass.Text)
                {
                    MessageBox.Show("Password and confirm password does not match");
                }
                else
                {
                    AccountBLL.Instance.updatePassword(HashCode.Instance.hashCode(tbConfirmNewPass.Text), US);
                    MessageBox.Show("Reset Successful!");
                    this.Close();
                }
            }
        }
    }
}

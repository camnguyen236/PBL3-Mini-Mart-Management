using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class AddAccount : Form
    {
        
        public AddAccount()
        {
            InitializeComponent();
        }
        public delegate void Mydel();
        public Mydel d { get; set; }
       
        private void btnOK_Click(object sender, EventArgs e)
        {
            // thíu : ktra username, email, phonemunber có trùng k
            if (tbName.Text.Trim() == "" || tbEmail.Text.Trim() == "" || tbAddress.Text.Trim() == ""
                || tbUS.Text.Trim() == "" || tbPhoneNumber.Text.Trim() == "")
                MessageBox.Show("Please fill in the required information!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (!AccountBLL.Instance.checkUS(tbUS.Text))
            {
                MessageBox.Show("Your username:\n Must be between six and 24 characters long.\n Can contain any letters from a to z and any numbers from 0 through 9.");
            }
            else if (!AccountBLL.Instance.IsValidEmail(tbEmail.Text))
            {
                MessageBox.Show("Invalid email format");
            }
            else if (!AccountBLL.Instance.checkPhoneNumber(tbPhoneNumber.Text))
            {
                MessageBox.Show("Phone number must have exactly 10 digits");
            }
            else
            {
                Account account = new Account
                {
                    //ID = Convert.ToInt32(txtID.Text),
                    US = tbUS.Text,
                    PW = null,
                    Name = tbName.Text,
                    Gender = Convert.ToString(rbtnMale.Checked),
                    Birthday = Convert.ToDateTime(DTPBirthday.Text),
                    Adress = DTPBirthday.Text,
                    PhoneNumber = tbPhoneNumber.Text,
                    Position = null,
                    Email = tbEmail.Text
                };
                AccountBLL.Instance.ExcuteDB(account);
                //show
                
                MessageBox.Show("Added successfully");
                d();
                this.Close();
            }
        }

     
    }
}

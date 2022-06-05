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

        private static Random rnd = new Random();
        private int rd = rnd.Next(100000, 999999);
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
            else if (AccountBLL.Instance.checkField("US", tbUS.Text))
            {
                MessageBox.Show("This username already exists. Please re-enter your username");
            }
            else if (!AccountBLL.Instance.IsValidEmail(tbEmail.Text))
            {
                MessageBox.Show("Invalid email format");
            }
            else if (AccountBLL.Instance.checkField("Email", tbEmail.Text))
            {
                MessageBox.Show("This email already exists. Please re-enter your email");
            }
            else if (!AccountBLL.Instance.checkPhoneNumber(tbPhoneNumber.Text))
            {
                MessageBox.Show("Phone number must have exactly 10 digits");
            }
            else if (AccountBLL.Instance.checkField("PhoneNumber", tbPhoneNumber.Text))
            {
                MessageBox.Show("This phone number already exists. Please re-enter your phone number");
            }
            else
            {
                if (sendMail.Instance.checkMail(tbEmail.Text) != "OK") MessageBox.Show(sendMail.Instance.checkMail(tbEmail.Text) + "\nPlease re-enter your email");
                else
                {
                    string mess = sendMail.Instance.Send(tbEmail.Text, "DCD Supermarkets", "Hello " + tbName.Text
                        + ",<br>You have been created a new account by the administrator, your password is: " + rd.ToString() +
                        ". You should change your password the first time you log in. Do not share your password with anyone for any reason.<br>The DCD team.");
                    if (mess.Equals("Sent Successfully"))
                    {
                        Account account = new Account
                        {
                            US = tbUS.Text,
                            PW = HashCode.Instance.hashCode(rd.ToString()),
                            Name = tbName.Text,
                            Gender = rbtnFemale.Checked ? "Nữ" : "Nam",
                            Birthday = Convert.ToDateTime(DTPBirthday.Text),
                            Adress = tbAddress.Text,
                            PhoneNumber = tbPhoneNumber.Text,
                            Position = null,
                            Email = tbEmail.Text,
                            Status = true
                        };
                        AccountBLL.Instance.ExcuteDB(account, "Add");
                        //show

                        MessageBox.Show("Added successfully");
                        d();
                        this.Close();
                    }
                    else MessageBox.Show(mess);

                }

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbEmail.Text = "";
            tbAddress.Text = "";
            tbPhoneNumber.Text = "";
            tbUS.Text = "";
            DTPBirthday.Value = DateTime.Now;
            rbtnMale.Checked = true;
        }
    }
}

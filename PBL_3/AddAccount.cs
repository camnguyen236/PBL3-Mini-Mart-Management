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

namespace PBL_3
{
    public partial class AddAccount : Form
    {
        SqlConnection conn;
        public SqlCommand cmd;
        SqlDataAdapter ad = new SqlDataAdapter();
        private string gender;
        public AddAccount()
        {
            InitializeComponent();
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public bool checkPhoneNumber(string pn)
        {
            return Regex.IsMatch(pn, "^[0-9]{10}$");
        }

        public bool checkUS(string name)
        {
            return Regex.IsMatch(name, "^[a-zA-Z0-9]{6,24}$");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // thíu : ktra username, email, phonemunber có trùng k
            if (tbName.Text.Trim() == "" || tbEmail.Text.Trim() == "" || tbAddress.Text.Trim() == ""
                || tbUS.Text.Trim() == "" || tbPass.Text.Trim() == "" || tbConfirmPass.Text.Trim() == ""
                || tbPhoneNumber.Text.Trim() == "")
                MessageBox.Show("Please fill in the required information!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (!checkUS(tbUS.Text))
            {
                MessageBox.Show("Your username:\n Must be between six and 24 characters long.\n Can contain any letters from a to z and any numbers from 0 through 9.");
            }
            else if (tbPass.Text.Length < 6)
            {
                MessageBox.Show("Your password must be at least 6 characters");
            }
            else if (tbPass.Text != tbConfirmPass.Text)
            {
                MessageBox.Show("Password and confirm password does not match");
            }
            else if (!IsValidEmail(tbEmail.Text))
            {
                MessageBox.Show("Invalid email format");
            }
            else if (!checkPhoneNumber(tbPhoneNumber.Text))
            {
                MessageBox.Show("Phone number must have exactly 10 digits");
            }
            else
            {
                if (rbtnFemale.Checked) gender = "Nữ";
                else gender = "Nam";
                conn = Connection.getSqlConnection();
                conn.Open();
                cmd = conn.CreateCommand();
                cmd.CommandText = "insert into Inf_user(US,PW,Name,Gender,Birthday,Adress,PhoneNumber,Email) " +
                    "values ('" + tbUS.Text + "','" + tbPass.Text + "','" + tbName.Text + "','" + gender + "','" +
                    DTPBirthday.Text + "','" + tbAddress.Text + "','" + tbPhoneNumber.Text + "','" + tbEmail.Text + "')";
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Added successfully");
                this.Close();
            }
        }
    }
}

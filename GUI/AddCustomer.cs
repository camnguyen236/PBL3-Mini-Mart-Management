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
using DTO;

namespace GUI
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }
        public delegate void Mydel();
        public Mydel d { get; set; }

        private void btnOK_Customer_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "" )
                MessageBox.Show("Please enter customer name!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (tbPhoneNumber.Text != "" && !AccountBLL.Instance.checkPhoneNumber(tbPhoneNumber.Text))
            {
                MessageBox.Show("Phone number must have exactly 10 digits");
            }
            else
            {
                Customer customer = new Customer
                {
                    Name_Customer = tbName.Text,
                    Gender_Customer = rbtnFemale.Checked ? "Nữ" : "Nam",
                    Address_Customer = tbAddress.Text,
                    PhoneNumber_Customer = tbPhoneNumber.Text,
                    AccountNumber = tbAccountNumber.Text,
                    Email_Customer = txtEmail.Text,
                    TaxCode = txtTaxCode.Text,
                    Discount = 0,
                    Status = true
                };
                Customer_BLL.Instance.ExcuteDB(customer,"Add");
                //show

                MessageBox.Show("Added successfully");
                d();
                this.Close();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbAddress.Text = "";
            tbPhoneNumber.Text = "";
            tbAccountNumber.Text = "";
            txtEmail.Text = "";
            txtTaxCode.Text = "";
            rbtnMale.Checked = true;
        }
    }
}

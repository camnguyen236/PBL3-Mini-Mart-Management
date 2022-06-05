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
    public partial class AddSupply : Form
    {
        public AddSupply()
        {
            InitializeComponent();
        }
        public delegate void Mydel(bool b = true);
        public Mydel d { get; set; }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            tbName.Text = "";
            tbTaxCode.Text = "";
            tbAccountNumber.Text = "";
            tbPhoneNumber.Text = "";
            tbAddress.Text = "";
        }

        private void btnOK_Supply_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "" || tbAccountNumber.Text.Trim() == "" || tbTaxCode.Text.Trim() == ""
                || tbPhoneNumber.Text.Trim() == "" || tbAddress.Text.Trim() == "")
                MessageBox.Show("Please fill in the required information!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (!AccountBLL.Instance.checkPhoneNumber(tbPhoneNumber.Text))
            {
                MessageBox.Show("Phone number must have exactly 10 digits");
            }
            else
            {
                Supply supply = new Supply
                {
                    Name_Supply = tbName.Text,
                    Address_Supply = tbAddress.Text,
                    PhoneNumber_Supply = tbPhoneNumber.Text,
                    BankAccount = tbAccountNumber.Text,
                    TaxCode = tbTaxCode.Text,
                    Status = true
                };
                Supply_BLL.Instance.ExcuteDB(supply, "Add");
                //show

                MessageBox.Show("Added successfully");
                d();
                this.Close();
            }
        }
    }
}

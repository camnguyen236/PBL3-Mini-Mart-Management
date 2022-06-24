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
    public partial class AddSupplier : Form
    {
        public AddSupplier()
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

        private void btnOK_Supplier_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "" || tbPhoneNumber.Text.Trim() == "")
                MessageBox.Show("Please fill in the required information!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else if (!AccountBLL.Instance.checkPhoneNumber(tbPhoneNumber.Text))
            {
                MessageBox.Show("Phone number must have exactly 10 digits");
            }
            else
            {
                Supplier Supplier = new Supplier
                {
                    Name_Supplier = tbName.Text,
                    Address_Supplier = tbAddress.Text,
                    PhoneNumber_Supplier = tbPhoneNumber.Text,
                    BankAccount = tbAccountNumber.Text,
                    TaxCode = tbTaxCode.Text,
                    Status = true
                };
                Supplier_BLL.Instance.ExcuteDB(Supplier, "Add");
                //show

                MessageBox.Show("Added successfully");
                d();
                this.Close();
            }
        }
    }
}

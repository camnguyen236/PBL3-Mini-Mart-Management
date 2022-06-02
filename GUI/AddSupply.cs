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
        public delegate void Mydel();
        public Mydel d { get; set; }

        private void btnOK_Customer_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() == "" || tbAccountNumber.Text.Trim() == "" || tbAddress.Text.Trim() == "" || tbPhoneNumber.Text.Trim() == "")
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
                    //ID_Customer = Convert.ToInt32(txtID_Customer.Text),
                    Name_Supply = tbName.Text,
                    Address_Supply = tbAddress.Text,
                    PhoneNumber_Supply = tbPhoneNumber.Text,
                    BankAccount = tbAccountNumber.Text,
                    Status = rbTrue.Checked
                };
                Supply_BLL.Instance.ExcuteDB(supply, "Add");
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
            tbAccountNumber.Text = "";
            tbPhoneNumber.Text = "";
            rbTrue.Checked = true;
        }
    }
}

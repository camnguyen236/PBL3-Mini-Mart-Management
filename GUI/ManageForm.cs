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
    public partial class ManageForm : Form
    {
        public string rs;
        public ManageForm()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtID.Text = "";
            txtUsername.Text = "";
            txtName.Text = "";
            txtBirthday.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtRole.Text = "";
            txtEmail.Text = "";
        }
        private void Show()
        {
            dgv1.DataSource = AccountBLL.Instance.getAccount();
            dgv1.Columns[6].Visible = false;
        }
        private void Show_Customer()
        {
            dgv3.DataSource = Customer_BLL.Instance.getCustomer();
        }
        private void btnShow_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mf2 = new MainForm();
            this.Hide();
            mf2.mName(rs);
            mf2.ShowDialog();

            this.Close();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.ReadOnly = true;
            int i = dgv1.CurrentRow.Index;
            txtID.Text = dgv1.Rows[i].Cells[0].Value.ToString();
            txtUsername.Text = dgv1.Rows[i].Cells[1].Value.ToString();
            txtName.Text = dgv1.Rows[i].Cells[2].Value.ToString();
            txtBirthday.Text = dgv1.Rows[i].Cells[3].Value.ToString();
            txtAddress.Text = dgv1.Rows[i].Cells[4].Value.ToString();
            txtPhone.Text = dgv1.Rows[i].Cells[5].Value.ToString();
            txtRole.Text = dgv1.Rows[i].Cells[6].Value.ToString();
            txtEmail.Text = dgv1.Rows[i].Cells[7].Value.ToString();
        }
        Account account;
        Customer customer;
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            account = new Account
            {
                ID = Convert.ToInt32(txtID.Text),
                US = txtUsername.Text,
                PW = "null",
                Name = txtName.Text,
                Gender = "nữ",
                Birthday = Convert.ToDateTime(txtBirthday.Text),
                Adress = txtAddress.Text,
                PhoneNumber = txtPhone.Text,
                Position = txtRole.Text,
                Email = txtEmail.Text
            };
            AccountBLL.Instance.ExcuteDB(account);
            Show();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        { 
             //vì mã nhân viên là khóa chính
            DialogResult dl = MessageBox.Show("Are you sure to delete this row?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                AccountBLL.Instance.ExcuteDB(account, txtID.Text);
                Show();
                Reset();
            }
            else if (dl == DialogResult.Cancel)
            {
                //sthis.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAccount ad = new AddAccount();
            ad.d = new AddAccount.Mydel(Show);
            ad.ShowDialog();
        }

        //Tap Manage customer
        private void btnShow_Customer_Click(object sender, EventArgs e)
        {
            Show_Customer();
        }
        private void dgv3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID_Customer.ReadOnly = true;
            int i = dgv3.CurrentRow.Index;
            txtID_Customer.Text = dgv3.Rows[i].Cells[0].Value.ToString();
            txtName_Customer.Text = dgv3.Rows[i].Cells[1].Value.ToString();
            if (dgv3.Rows[i].Cells[2].Value.ToString() == "Nữ") rbtnFemale.Checked = true;
            else rbtnMale.Checked = true;
            txtAddress_Customer.Text = dgv3.Rows[i].Cells[3].Value.ToString();
            txtPhoneNumber_Customer.Text = dgv3.Rows[i].Cells[4].Value.ToString();
            txtAccountNumber.Text = dgv3.Rows[i].Cells[5].Value.ToString();
        }

        private void btnDelete_Customer_Click(object sender, EventArgs e)
        {
            //vì mã nhân viên là khóa chính
            DialogResult dl = MessageBox.Show("Are you sure to delete this row?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                Customer_BLL.Instance.ExcuteDB(customer, txtID_Customer.Text);
                Show_Customer();
                Reset();
            }
            else if (dl == DialogResult.Cancel)
            {
                //sthis.Close();
            }
        }

        private void btnUpdate_Customer_Click(object sender, EventArgs e)
        {
            customer = new Customer
            {
                ID_Customer = Convert.ToInt32(txtID_Customer.Text),
                Name_Customer = txtName_Customer.Text,
                Gender_Customer = rbtnFemale.Checked ? "Nữ" : "Nam",
                Address_Customer = txtAddress_Customer.Text,
                PhoneNumber_Customer = txtPhoneNumber_Customer.Text,
                AccountNumber = txtAccountNumber.Text
            };
            Customer_BLL.Instance.ExcuteDB(customer);
            Show_Customer();
            //MessageBox.Show("Update")
        }

        private void btnAdd_Customer_Click(object sender, EventArgs e)
        {
            AddCustomer ad = new AddCustomer();
            ad.d = new AddCustomer.Mydel(Show_Customer);
            ad.ShowDialog();
        }

        private void cbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

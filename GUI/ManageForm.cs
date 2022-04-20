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
            //account
            addCbSearch();
            //catalories
            setCBProductsGroups();
            addCbSearchProduct();
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
        private void Show_Supply()
        {
            dgv4.DataSource = Supply_BLL.Instance.getSupply();
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
        Supply supply;
        Product product;
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
            searchUser(cbSearch.Text);
        }
        public void addCbSearch()
        {
            cbSearch.Items.Add("Name");
            cbSearch.Items.Add("Username");
            cbSearch.Items.Add("Address");
            cbSearch.Items.Add("Phone number");
            cbSearch.Items.Add("Mail");
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchUser(cbSearch.Text);
        }
        private void searchUser(string option)
        {
            switch (option)
            {
                case "Name":
                    option = "Name";
                    break;
                case "Username":
                    option = "US";
                    break;
                case "Address":
                    option = "Adress";
                    break;
                case "Phone number":
                    option = "PhoneNumber";
                    break;
                case "Mail":
                    option = "Email";
                    break;
                default:
                    break;
            }
            dgv1.DataSource = AccountBLL.Instance.getAccountByOption(txtSearch.Text, option);
            dgv1.Columns[6].Visible = false;
        }

        //Tab Manage Supply
        private void btnShow_Supply_Click(object sender, EventArgs e)
        {
            Show_Supply();
        }

        private void btnAdd_Supply_Click(object sender, EventArgs e)
        {
            AddSupply ad = new AddSupply();
            ad.d = new AddSupply.Mydel(Show_Supply);
            ad.ShowDialog();
        }

        private void btnUpdate_Supply_Click(object sender, EventArgs e)
        {
            supply = new Supply
            {
                ID_Supply = Convert.ToInt32(txtID_Supply.Text),
                Name_Supply = txtName_Supply.Text,
                Address_Supply = txtAddress_Supply.Text,
                PhoneNumber_Supply = txtPhoneNumber_Supply.Text,
                BankAccount = txtBankAccount.Text
            };
            Supply_BLL.Instance.ExcuteDB(supply);
            Show_Supply();
        }


        
        private void btnDelete_Supply_Click(object sender, EventArgs e)
        {
            //vì mã nhân viên là khóa chính
            DialogResult dl = MessageBox.Show("Are you sure to delete this row?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                Supply_BLL.Instance.ExcuteDB(supply, txtID_Supply.Text);
                Show_Supply();
                Reset();
            }
            else if (dl == DialogResult.Cancel)
            {
                //sthis.Close();
            }
        }

        private void dgv4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID_Supply.ReadOnly = true;
            int i = dgv4.CurrentRow.Index;
            txtID_Supply.Text = dgv4.Rows[i].Cells[0].Value.ToString();
            txtName_Supply.Text = dgv4.Rows[i].Cells[1].Value.ToString();
            txtAddress_Supply.Text = dgv4.Rows[i].Cells[2].Value.ToString();
            txtPhoneNumber_Supply.Text = dgv4.Rows[i].Cells[3].Value.ToString();
            txtBankAccount.Text = dgv4.Rows[i].Cells[4].Value.ToString();
        }


        //manage product
        private string selectIDProduct;
        private string getCurrenGroupName()
        {
            string groupName = cbProductsGroups.Text;
            if (groupName == "")
            {
                MessageBox.Show("Choose product group!");
            }
            else
            {
                return groupName = cbProductsGroups.SelectedItem.ToString();
            }
            return groupName;
        }
        private void setCBProductsGroups()
        {
            cbProductsGroups.Items.Add("All");
            List<string> listProductsGroups = ProductGroups_BLL.Instance.getProductGroups().Rows.OfType<DataRow>().Select(dr => dr.Field<string>("Name_PG")).ToList();
            foreach (string i in listProductsGroups)
            {
                cbProductsGroups.Items.Add(i);
            }
        }

        private void Show_Product(string groupName)
        {
            if (groupName == "All")
            {
                dgv2.DataSource = Product_BLL.Instance.getProducts();
            }
            else
            {
                dgv2.DataSource = Product_BLL.Instance.getProductsByGroupName(groupName);
            }
        }
        private void btnShowProduct_Click(object sender, EventArgs e)
        {

            Show_Product(getCurrenGroupName());
        }

        private void btnDelteProduct_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Are you sure to delete this row?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                Product_BLL.Instance.ExcuteDB(product, selectIDProduct);
                Show_Product(getCurrenGroupName());
            }
            else if (dl == DialogResult.Cancel)
            {
                //sthis.Close();
            }
        }
        private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv2.CurrentRow.Index;
            selectIDProduct = dgv2.Rows[i].Cells[0].Value.ToString();
        }

        private void cbProductsGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show_Product(getCurrenGroupName());
        }


        //search
        public void addCbSearchProduct()
        {
            cbSearchProduct.Items.Add("ID");
            cbSearchProduct.Items.Add("Name product");
        }
        private void searchProduct(string option)
        {
            switch (option)
            {
                case "ID":
                    option = "ID_P";
                    break;
                case "Name product":
                    option = "Name_P";
                    break;
                default:
                    break;
            }
            dgv2.DataSource = Product_BLL.Instance.getProductsByOption(getCurrenGroupName(), txtSearchProduct.Text, option);
        }

        private void txtSearchProduct_TextChanged(object sender, EventArgs e)
        {
            searchProduct(cbSearchProduct.Text);
        }
    }
}

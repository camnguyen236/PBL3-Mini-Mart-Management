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
            //ImportProduct
            //setCBBID_IP();
            setCBBName_Supply();
            setCBBID_Products();
            setCBBDiscount();
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
        DetailImportProducts detailImportProducts, detailImportProducts2;
        ImportProducts importProducts;
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
                MessageBox.Show("Choose Catalories!");
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
        private void ShowAllProduct()
        {
                dgv2.DataSource = Product_BLL.Instance.getProducts();
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

        private void dgv2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgv2.CurrentRow.Index;
            string id = dgv2.Rows[i].Cells["ID_P"].Value.ToString();
            ProductDetails pd = new ProductDetails(id);
            //deleget
            pd.d = new ProductDetails.MyDel(ShowAllProduct);
            pd.Show();
        }

        private void btnAdd_PG_Click(object sender, EventArgs e)
        {
            
            ProductDetails pd = new ProductDetails();
            //deleget
            pd.d = new ProductDetails.MyDel(ShowAllProduct);
            pd.Show();
        }

        private void btnUpdate_PG_Click(object sender, EventArgs e)
        {
            int i = dgv2.CurrentRow.Index;
            string id = dgv2.Rows[i].Cells["ID_P"].Value.ToString();
            ProductDetails pd = new ProductDetails(id);
            //deleget
            pd.d = new ProductDetails.MyDel(ShowAllProduct);
            pd.Show();
        }

        private void btnBackProduct_Click(object sender, EventArgs e)
        {
            MainForm mf2 = new MainForm();
            this.Hide();
            mf2.mName(rs);
            mf2.ShowDialog();

            this.Close();
        }

        //Tab Import Product
        public void showInformationOfBill(int i)
        {
            dtDate_Import.Text = ImportProductsBLL.Instance.getRecords().Rows[i]["Date_Import"].ToString();
            cbbName_Supply.SelectedItem = ImportProductsBLL.Instance.getRecords().Rows[i]["Name_Supply"].ToString();
            txtAddress_InfOfBill.Text = ImportProductsBLL.Instance.getRecords().Rows[i]["Address_Supply"].ToString();
            txtBankAccountInfOfBill.Text = ImportProductsBLL.Instance.getRecords().Rows[i]["BankAccount"].ToString();
            txtPhoneNumberSupply.Text = ImportProductsBLL.Instance.getRecords().Rows[i]["PhoneNumber_Supply"].ToString();
            txtID_Tax.Text = ImportProductsBLL.Instance.getRecords().Rows[i]["TaxCode"].ToString();
            txtSymbol.Text = ImportProductsBLL.Instance.getRecords().Rows[i]["Symbol"].ToString();
        }
        public void showInformationNew()
        {
            cbbName_Supply.SelectedItem = ImportProductsBLL.Instance.getRecordsNewID_IP().Rows[0]["Name_Supply"].ToString();
            txtAddress_InfOfBill.Text = ImportProductsBLL.Instance.getRecordsNewID_IP().Rows[0]["Address_Supply"].ToString();
            txtBankAccountInfOfBill.Text = ImportProductsBLL.Instance.getRecordsNewID_IP().Rows[0]["BankAccount"].ToString();
            txtPhoneNumberSupply.Text = ImportProductsBLL.Instance.getRecordsNewID_IP().Rows[0]["PhoneNumber_Supply"].ToString();
            txtID_Tax.Text = ImportProductsBLL.Instance.getRecordsNewID_IP().Rows[0]["TaxCode"].ToString();
        }
        public int countRowsImportProduct()
        {
            return ImportProductsBLL.Instance.getAllImport_Product().Rows.Count;
        }
        //public void setCBBID_IP() //cbb mã phiếu nhập
        //{
        //    cbbID_IP.Items.AddRange(ImportProductsBLL.Instance.getAllID_IP().Distinct().ToArray());
        //}
        public void setCBBName_Supply() //cbb tên ncc
        {
            cbbName_Supply.Items.AddRange(ImportProductsBLL.Instance.getAllName_Supply().Distinct().ToArray());
        }
        public void setCBBID_Products() //cbb mã sp
        {
            cbbID_Product.Items.AddRange(ImportProductsBLL.Instance.getAllIP_Product().ToArray());
        }
        public void setCBBDiscount() //cbb mã sp
        {
            cbbDiscount.Items.AddRange(ImportProductsBLL.Instance.getAllDiscount().Distinct().ToArray());
        }
        private void showProducts()
        {
            //showInformationOfBill(cbbID_IP.SelectedIndex);
            int ID_IP = Convert.ToInt32(ImportProductsBLL.Instance.getAllImport_Product().Rows[countRowsImportProduct()-1]["ID_IP"].ToString()); //láy id phiếu cuối
            MessageBox.Show(Convert.ToString(ID_IP));
            dtgvImportProduct.DataSource = ImportProductsBLL.Instance.getDetailsImportProduct(ID_IP);
        }
        //private void cbbID_IP_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    showProducts();
        //}
        int amount;
        double total;
        //private void nmrQuantity_ValueChanged(object sender, EventArgs e)
        //{
        //    amount = (Convert.ToInt32(nmrQuantity.Value)) * (Convert.ToInt32(txtImport_Price.Text));
        //    txtPrice.Text = Convert.ToString(amount);

        //}
        //private void cbbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    total = amount + amount * Convert.ToInt32(cbbDiscount.Text) / 100;5tg
        //    txtTotal.Text = Convert.ToString(total);
        //}
        private void btnAdd_InfOfProduct_Click(object sender, EventArgs e)
        {
            detailImportProducts = new DetailImportProducts
            {
                ID_IP = Convert.ToInt32(ImportProductsBLL.Instance.getAllImport_Product().Rows[countRowsImportProduct()-1]["ID_IP"].ToString()),
                ID_P = Convert.ToInt32(cbbID_Product.SelectedItem.ToString()),
                IP_Price = Convert.ToInt32(txtImport_Price.Text),
                Amount_IP = Convert.ToInt32(nmrQuantity.Value),
                Amount_Price = amount,
                Discount = Convert.ToInt32(cbbDiscount.Text),
                Total = total,
            };
            DetailImportProductBLL.Instance.ExcuteDB(detailImportProducts, "Add");
            lbAdd.ForeColor = Color.Green;
            
            showProducts();
        }
        

        private void dtgvImportProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbID_Product.Enabled = false;
            int i = dtgvImportProduct.CurrentRow.Index;
            cbbID_Product.Text = dtgvImportProduct.Rows[i].Cells[0].Value.ToString();
            txtImport_Price.Text = dtgvImportProduct.Rows[i].Cells[2].Value.ToString();
            nmrQuantity.Value = Convert.ToInt32(dtgvImportProduct.Rows[i].Cells[3].Value.ToString());
            amount = (Convert.ToInt32(dtgvImportProduct.Rows[i].Cells[3].Value) * Convert.ToInt32(dtgvImportProduct.Rows[i].Cells[2].Value));
            txtPrice.Text = Convert.ToString(amount);
            cbbDiscount.Text = dtgvImportProduct.Rows[i].Cells[5].Value.ToString();
            total = amount + amount * Convert.ToInt32(cbbDiscount.Text) / 100;
            txtTotal.Text = Convert.ToString(total);

        }

        private void btnDeleteImportProduct_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Are you sure to delete this row?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                DetailImportProductBLL.Instance.ExcuteDB(detailImportProducts,cbbID_Product.Text);
                showProducts();
            }
            else if (dl == DialogResult.Cancel)
            {
                //sthis.Close();
            }
        }

        private void btnNewInfOfProduct_Click(object sender, EventArgs e)
        {
            cbbID_Product.Enabled = true;
            cbbID_Product.Text = "";
            txtImport_Price.Text = "";
            nmrQuantity.Value = 0;
            txtPrice.Text = "";
            cbbDiscount.Text = "";
            txtTotal.Text = "";
            lbAdd.ForeColor = Color.White;
            lbUpdate.ForeColor = Color.White;
            //dtgvImportProduct.DataSource = empty;
        }
        //Form inf ở trên
        List<ImportProducts> empty = new List<ImportProducts>();
        private void txtNew_Click(object sender, EventArgs e)
        {
            //cbbID_IP.Text = "";
            cbbName_Supply.Text = "";
            txtAddress_InfOfBill.Text = "";
            txtBankAccountInfOfBill.Text = "";
            txtPhoneNumberSupply.Text = "";
            txtID_Tax.Text = "";
            txtSymbol.Text = "";
            dtgvImportProduct.DataSource = empty;
            lbSaveInfOfBill.ForeColor = Color.White;
        }

        private void cbbName_Supply_SelectedIndexChanged(object sender, EventArgs e)
        {
            showInformationNew();
        }

        private void btnSave_InfOfBill_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Convert.ToString(AccountBLL.Instance.getID()));
            importProducts = new ImportProducts
            {

                ID_IP = 0,
                ID = AccountBLL.Instance.getID(),
                Date_Import = Convert.ToDateTime(dtDate_Import.Text),
                //Name_Supply = Convert.ToInt32(txtImport_Price.Text),
                ID_Supply = ImportProductsBLL.Instance.getID_Supply(cbbName_Supply.SelectedItem.ToString()),
                Symbol = txtSymbol.Text,
            };
            
            ImportProductsBLL.Instance.ExcuteDB(importProducts, "Add");
            //lbAdd.ForeColor = Color.Green;
            lbSaveInfOfBill.ForeColor = Color.Green;
            txtID_IP.Text = ImportProductsBLL.Instance.getAllImport_Product().Rows[countRowsImportProduct()-1]["ID_IP"].ToString();
            //setCBBID_IP();
        }
        //nút update bill
        //private void btnUpdateInfOfBill_Click(object sender, EventArgs e)
        //{
        //    importProducts = new ImportProducts
        //    {

        //        ID_IP = Convert.ToInt32(cbbID_IP.Text),
        //        ID = AccountBLL.Instance.getID(),
        //        Date_Import = Convert.ToDateTime(dtDate_Import.Text),
        //        //Name_Supply = Convert.ToInt32(txtImport_Price.Text),
        //        ID_Supply = ImportProductsBLL.Instance.getID_Supply(cbbName_Supply.SelectedItem.ToString()),
        //        Symbol = txtSymbol.Text,
        //    };

        //    ImportProductsBLL.Instance.ExcuteDB(importProducts);
        //    //lbAdd.ForeColor = Color.Green;
        //    //lbSaveInfOfBill.ForeColor = Color.Green;
        //}

        private void btnDetailImportBill_Click(object sender, EventArgs e)
        {
            DetailPaymentBill detailPaymentBill = new DetailPaymentBill();
            detailPaymentBill.ShowDialog();
        }

        //cần sửa chữa
        private void btnSaveImport_Click(object sender, EventArgs e)
        {
            DataTable data = new DataTable();
            data = ImportProductsBLL.Instance.getDetailsImportProduct(Convert.ToInt32(txtID_IP.Text));
            MessageBox.Show(Convert.ToString(data.Rows.Count));
            for (int i = 0; i < data.Rows.Count; i++)
            {
                TableImportSql tableImportSql = new TableImportSql
                {
                    ID_IP2 = Convert.ToInt32(txtID_IP.Text),//Convert.ToInt32(cbbID_IP.SelectedItem.ToString()),
                    Date_Import2 = Convert.ToDateTime(dtDate_Import.Text), //OK
                    Symbol2 = txtSymbol.Text, //OK
                    Name_Supply2 = cbbName_Supply.SelectedItem.ToString(), //OK
                    Address_Supply2 = txtAddress_InfOfBill.Text, //OK
                    TaxCode2 = txtID_Tax.Text, //OK
                    PhoneNumber_Supply2 = txtPhoneNumberSupply.Text, //OK
                    BankAccount2 = txtBankAccountInfOfBill.Text, //OK
                    Name_Product2 = data.Rows[i]["Name_P"].ToString(),
                    Amount_IP2 = Convert.ToInt32(data.Rows[i]["Amount_IP"].ToString()),
                    Price2 = Convert.ToInt32(data.Rows[i]["IP_Price"].ToString()),
                    Amount_Price2 = Convert.ToInt32(data.Rows[i]["Amount_Price"].ToString()),
                    Discount2 = Convert.ToInt32(data.Rows[i]["Discount"].ToString()),
                    Total2 = Convert.ToDouble(data.Rows[i]["Total"].ToString()),
                };
                TableImportSqlBLL.Instance.ExcuteDB(tableImportSql, "Add");
                lbAdd.ForeColor = Color.Red;
            }
            TableImportSqlBLL.Instance.get(txtID_IP.Text);
        }

        private void btnUpdateImportProduct_Click(object sender, EventArgs e)
        {
            //amount = (Convert.ToInt32(nmrQuantity.Value)) * (Convert.ToInt32(txtImport_Price.Text));
            total = amount + amount * Convert.ToInt32(cbbDiscount.Text) / 100;
            detailImportProducts = new DetailImportProducts
            {
                ID_IP = 0,//Convert.ToInt32(cbbID_IP.SelectedItem.ToString()),
                ID_P = Convert.ToInt32(cbbID_Product.SelectedItem.ToString()),
                IP_Price = Convert.ToInt32(txtImport_Price.Text),
                Amount_IP = Convert.ToInt32(nmrQuantity.Value),
                Amount_Price = amount,
                Discount = Convert.ToInt32(cbbDiscount.SelectedItem.ToString()),
                Total = total,
            };
            DetailImportProductBLL.Instance.ExcuteDB(detailImportProducts);
            lbUpdate.ForeColor = Color.Green;

            showProducts();
        }
        //Nút ok total
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            txtTotalAll.Text = Convert.ToString(totalAll());
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            ImportHistory importHistory = new ImportHistory();
            importHistory.ShowDialog();
        }

        public double totalAll()
        {
            double totalall = 0;
            int ID_IP = Convert.ToInt32(ImportProductsBLL.Instance.getAllImport_Product().Rows[countRowsImportProduct()-1]["ID_IP"].ToString());
            int count = ImportProductsBLL.Instance.getDetailsImportProduct(ID_IP).Rows.Count;
            for(int i=0; i<count; i++)
            {
                totalall += Convert.ToInt32(ImportProductsBLL.Instance.getDetailsImportProduct(ID_IP).Rows[i]["Total"].ToString());

            }
            return totalall;
        }
    }
}

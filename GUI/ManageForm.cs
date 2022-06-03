using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
using Product_Library;

namespace GUI
{
    public partial class ManageForm : Form
    {
        public string rs;
        Account acc;
        public ManageForm(Account acc)
        {
            InitializeComponent();
            this.acc = acc;
            if (!AccountBLL.Instance.checkRole("Admin"))
            {
                TabControlManage.TabPages.Remove(tpUS);
                TabControlManage.TabPages.Remove(tpProduct);
                TabControlManage.TabPages.Remove(tpSupply);
                TabControlMain.TabPages.Remove(tpImport);
            }

            addCbSearch();
            setCBProductsGroups();
            addCbSearchProduct();
            addCbSearchCustomer();
            addCbSearchSupply();
            setCBBName_Supply();
            setCBBID_Products();
            cbbID_Product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbbID_Product.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbbID_Product.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            setCBBDiscount();

            addTab();
            ViewCart();
            showDgvSH();
        }
        private void Reset()
        {
            txtID.Text = "";
            txtUsername.Text = "";
            txtName.Text = "";
            dpBirthday.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtRole.Text = "";
            txtEmail.Text = "";
            rbTrue_us.Checked = true;
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
            MainForm mf2 = new MainForm(acc);
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
            dpBirthday.Text = dgv1.Rows[i].Cells[3].Value.ToString();
            txtAddress.Text = dgv1.Rows[i].Cells[4].Value.ToString();
            txtPhone.Text = dgv1.Rows[i].Cells[5].Value.ToString();
            txtRole.Text = dgv1.Rows[i].Cells[6].Value.ToString();
            txtEmail.Text = dgv1.Rows[i].Cells[7].Value.ToString();
        }
        Account account;
        Customer customer;
        Supply supply;
        Product product;
        DetailImportProducts detailImportProducts;
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
                Birthday = Convert.ToDateTime(dpBirthday.Text),
                Adress = txtAddress.Text,
                PhoneNumber = txtPhone.Text,
                Position = txtRole.Text,
                Email = txtEmail.Text,
                Status = rbTrue_us.Checked
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
            if (dgv3.Rows[i].Cells[2].Value.ToString() == "Nữ") rbtnFemale_cus.Checked = true;
            else rbtnMale_cus.Checked = true;
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
                Gender_Customer = rbtnFemale_cus.Checked ? "Nữ" : "Nam",
                Address_Customer = txtAddress_Customer.Text,
                PhoneNumber_Customer = txtPhoneNumber_Customer.Text,
                AccountNumber = txtAccountNumber.Text,
                Email_Customer = txtEmail_cus.Text,
                Discount = Convert.ToInt32(txtDiscountCustomer.Text),
                TaxCode = txtTaxCode_cus.Text,
                Status = rbTrue_cus.Checked
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
                BankAccount = txtBankAccount.Text,
                Status = rbTrue_su.Checked
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
            cbProductsGroups.Items.Clear();
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
            DataGridView dgv = (DataGridView)sender;
            int i = dgv.CurrentRow.Index;
            selectIDProduct = dgv.Rows[i].Cells[0].Value.ToString();
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
            if (cbSearchProduct.Text != null)
            {
                searchProduct(cbSearchProduct.Text);
            }
        }

        private void dgv2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            int i = dgv.CurrentRow.Index;
            string id = dgv.Rows[i].Cells["ID_P"].Value.ToString();
            ProductDetails pd = new ProductDetails(id);
            //delegate
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

        //Tab Import Product
        public void showInformationOfBill(int i)
        {
            dtDate_Import.Text = ImportProductsBLL.Instance.getRecords().Rows[i]["Date_Import"].ToString();
            cbbName_Supply.SelectedItem = ImportProductsBLL.Instance.getRecords().Rows[i]["Name_Supply"].ToString();
            txtAddress_InfOfBill.Text = ImportProductsBLL.Instance.getRecords().Rows[i]["Address_Supply"].ToString();
            txtBankAccountInfOfBill.Text = ImportProductsBLL.Instance.getRecords().Rows[i]["BankAccount"].ToString();
            txtPhoneNumberSupply.Text = ImportProductsBLL.Instance.getRecords().Rows[i]["PhoneNumber_Supply"].ToString();
            txtID_Tax.Text = ImportProductsBLL.Instance.getRecords().Rows[i]["TaxCode"].ToString();
            //txtSymbol.Text = ImportProductsBLL.Instance.getRecords().Rows[i]["Symbol"].ToString();
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
            //cbbID_Product.SelectedIndex = 0;
            cbbID_Product.Items.AddRange(ImportProductsBLL.Instance.getAllIP_Product().ToArray());
            //cbbID_Product.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //cbbID_Product.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
        public void setCBBDiscount() //cbb mã sp
        {
            cbbDiscount.Items.AddRange(ImportProductsBLL.Instance.getAllDiscount().Distinct().ToArray());
        }
        private void showProducts()
        {
            //showInformationOfBill(cbbID_IP.SelectedIndex);
            int ID_IP = Convert.ToInt32(ImportProductsBLL.Instance.getAllImport_Product().Rows[countRowsImportProduct()-1]["ID_IP"].ToString()); //láy id phiếu cuối
            //MessageBox.Show(Convert.ToString(ID_IP));
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
            //MessageBox.Show(ImportProductsBLL.Instance.getID_Product(cbbID_Product.SelectedItem.ToString()));
            detailImportProducts = new DetailImportProducts
            {
                ID_IP = Convert.ToInt32(ImportProductsBLL.Instance.getAllImport_Product().Rows[countRowsImportProduct()-1]["ID_IP"].ToString()),
                ID_P = Convert.ToInt32(ImportProductsBLL.Instance.getID_Product(cbbID_Product.SelectedItem.ToString())),
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
            cbbID_Product.Text = dtgvImportProduct.Rows[i].Cells[1].Value.ToString();
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
            //txtSymbol.Text = "";
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
                //Symbol = txtSymbol.Text,
            };
            
            ImportProductsBLL.Instance.ExcuteDB(importProducts, "Add");
            //lbAdd.ForeColor = Color.Green;
            lbSaveInfOfBill.ForeColor = Color.Green;
            txtID_IP.Text = ImportProductsBLL.Instance.getAllImport_Product().Rows[countRowsImportProduct()-1]["ID_IP"].ToString();
            DetailImportProductBLL.Instance.get(txtID_IP.Text);
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
            ImportProductsBill importProductsBill = new ImportProductsBill();
            importProductsBill.ShowDialog();
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
                    //Symbol2 = txtSymbol.Text, //OK
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

        //selling product 
        List<Tuple<int, int>> productArray;
        UserControl1 products;
        double Total;
        private UserControl1 populateItems(UserControl1 uc, string groupName, int i)
        {
            DataRow dc;
            if (!groupName.Equals("All products")) dc = Product_BLL.Instance.getAllProductsByGroupName(groupName).Rows[i];
            else dc = Product_BLL.Instance.getAllProducts().Rows[i];

            uc = new UserControl1(Convert.ToInt32(dc["ID_P"].ToString()));
            uc.AddToCard_Click += new UserControl1.AddToCard_ClickHandler(addToCard_Click);

            Byte[] data = new Byte[0];
            data = (Byte[])(dc["IMG_P"]);
            MemoryStream mem = new MemoryStream(data);
            uc.Picture = Image.FromStream(mem);

            uc.Name = dc["Name_P"].ToString();
            uc.Price = "Price: " + dc["Price_P"].ToString();
            uc.Unit = "Unit: " + dc["Unit_P"].ToString();
            uc.Number = 0;
            return uc;
        }

        void addToCard_Click(object sender, EventArgs e)
        {
            txtTotal.Text = "";
            UserControl1 us = (UserControl1)sender;
            if (us.Number <= 0)
            {
                MessageBox.Show("Please enter the quantity");
                return;
            }
            MessageBox.Show("Add successful");
            productArray.Add(new Tuple<int, int>(us.Id_p, us.Number));
            viewCart();
            us.Number = 0;
        }

        private void addItems(FlowLayoutPanel fl, string groupName)
        {
            productArray = new List<Tuple<int, int>>();
            int numOfProduct;
            if (groupName.Equals("All products")) numOfProduct = Product_BLL.Instance.getAllProducts().Rows.Count;
            else numOfProduct = Product_BLL.Instance.getAllProductsByGroupName(groupName).Rows.Count;
            fl.Controls.Clear();
            for (int i = 0; i < numOfProduct; i++)
            {
                products = populateItems(products, groupName, i);
                fl.Controls.Add(products);
            }
        }

        private void createTab(TabPage myTabPage, string product)
        {
            tabControlSellP.TabPages.Add(myTabPage);
            myTabPage.Text = product;

            FlowLayoutPanel fl_panel = new FlowLayoutPanel();
            myTabPage.Controls.Add(fl_panel);
            fl_panel.AutoScroll = true;
            fl_panel.BackgroundImage = global::GUI.Properties.Resources._277293806_1451411541982748_8799551172936554219_n__1_;
            fl_panel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            fl_panel.Location = new System.Drawing.Point(0, 0);
            fl_panel.Name = "flowLayoutPanel";
            fl_panel.Size = new System.Drawing.Size(908, 508);
            addItems(fl_panel, product);
        }

        private void addTab()
        {
            TabPage myTabPage = new TabPage("tpAllProducts");
            createTab(myTabPage, "All products");
            List<string> listProductsGroups = ProductGroups_BLL.Instance.getProductGroups().Rows.OfType<DataRow>().Select(dr => dr.Field<string>("Name_PG")).ToList();
            for (int i = 0; i < listProductsGroups.Count; i++)
            {
                myTabPage = new TabPage("tp" + listProductsGroups[i]);
                createTab(myTabPage, listProductsGroups[i]);
            }
        }

        private void updateTP(TabPage tp, string productGroup)
        {
            if (tp.Name.Equals("tpAllProducts") || tp.Name.Equals("tp" + productGroup))
            {
                while (tp.Controls.Count > 0) tp.Controls[0].Dispose();
                createTab(tp, productGroup);
            }
        }

        private void viewCart()
        {
            Total = 0;
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn(columnName: "ID_P", dataType: typeof (int)),
                new DataColumn(columnName: "Name_PG", dataType: typeof (string)),
                new DataColumn(columnName: "Name_P", dataType: typeof(string)),
                new DataColumn(columnName: "Unit_P", dataType: typeof(string)),
                new DataColumn(columnName: "Price_P", dataType: typeof(string)),
                new DataColumn(columnName: "VAT", dataType: typeof(string)),
                new DataColumn(columnName: "VAT_Inclusive_P", dataType: typeof(int)),
                new DataColumn(columnName: "Number", dataType: typeof(int))
            });
            for (int i = 0; i < productArray.Count; i++)
            {
                DataRow dr = Product_BLL.Instance.getProductByID(productArray[i].Item1);
                DataRow row1 = dt.NewRow();
                row1["ID_P"] = dr["ID_P"];
                row1["Name_PG"] = dr["Name_PG"];
                row1["Name_P"] = dr["Name_P"];
                row1["Unit_P"] = dr["Unit_P"];
                row1["Price_P"] = dr["Price_P"];
                row1["VAT"] = dr["VAT"];
                row1["VAT_Inclusive_P"] = dr["VAT_Inclusive_P"];
                row1["number"] = productArray[i].Item2;
                dt.Rows.Add(row1);
                Total += Convert.ToInt32(dr["VAT_Inclusive_P"]) * productArray[i].Item2;
            }
            dgvCart.DataSource = dt;
            dgvCart.Columns[0].HeaderText = "ID Product";
            dgvCart.Columns[1].HeaderText = "Product Categories";
            dgvCart.Columns[2].HeaderText = "Product's name";
            dgvCart.Columns[3].HeaderText = "Unit";
            dgvCart.Columns[4].HeaderText = "Price";
            dgvCart.Columns[5].HeaderText = "VAT(%)";
            dgvCart.Columns[6].HeaderText = "Amount";
            dgvCart.Columns[7].HeaderText = "Number";
            txtTotalProduct.Text = Total.ToString();
        }
        private void ViewCart()
        {


            //DataTable dt = new DataTable();
            //dt.Columns.AddRange(new DataColumn[]
            //{
            //    new DataColumn(columnName: "ID_P", dataType: typeof (string)),
            //    new DataColumn(columnName: "Name_PG", dataType: typeof (string)),
            //    new DataColumn(columnName: "Name_P", dataType: typeof(string)),
            //    new DataColumn(columnName: "Unit_P", dataType: typeof(string)),
            //    new DataColumn(columnName: "Price_P", dataType: typeof(string)),
            //    new DataColumn(columnName: "VAT", dataType: typeof(string)),
            //    new DataColumn(columnName: "VAT_Inclusive_P", dataType: typeof(string)),
            //    new DataColumn(columnName: "Number", dataType: typeof(int))
            //});
            //dgvCart.DataSource = dt;
        }

        private void btnDelProduct_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Are you sure to delete this row?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                var it = productArray.Single(productArray => productArray.Item1 == Convert.ToInt32(selectIDProduct));
                productArray.Remove(it);
                viewCart();
            }
            else if (dl == DialogResult.Cancel)
            {
                //sthis.Close();
            }

        }
        

        private void btnPay_Click(object sender, EventArgs e)
        {
            //if (txtSearchCustomer.Text.Equals(""))
            //{
            //    MessageBox.Show("Please enter customer information");
            //    return;
            //}
            Invoice inv = new Invoice
            {
                ID = acc.ID,
                //ID_Customer = Customer_BLL.Instance.getCustomerByPhoneNum(txtCustomerPhoneNum.Text).ID_Customer,
                Invoice_Date = DateTime.Now
            };
            Invoice_BLL.Instance.ExcuteDB(inv, "Add");
            int id = Convert.ToInt32(Invoice_BLL.Instance.getInvoice().Rows[Invoice_BLL.Instance.getInvoice().Rows.Count - 1]["ID_Invoice"].ToString());
            MessageBox.Show(id.ToString());
            InvoiceDetail_BLL.Instance.get(id.ToString());
            for (int i = 0; i < productArray.Count; i++)
            {
                InvoiceDetail ind = new InvoiceDetail
                {
                    ID_Invoice = id,
                    ID_P = productArray[i].Item1,
                    Unit_Price = Convert.ToInt32(Product_BLL.Instance.getProductByID(productArray[i].Item1)["VAT_Inclusive_P"].ToString()),
                    Quantity = productArray[i].Item2
                };
                InvoiceDetail_BLL.Instance.ExcuteDB(ind, "Add");
            }
            
            showDgvSH();
            DialogResult dl = MessageBox.Show("Are you want to print this bill?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dl == DialogResult.OK)
            {
                InvoiceReport invoiceReport = new InvoiceReport();
                invoiceReport.ShowDialog();
            }
            else if (dl == DialogResult.Cancel)
            {
                //sthis.Close();
            }
            //MessageBox.Show("Payment successful");
            btnRefresh.PerformClick();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer ad = new AddCustomer();
            ad.d = new AddCustomer.Mydel(Show_Customer);
            ad.ShowDialog();
        }

        private void txtCustomerPhoneNum_TextChanged(object sender, EventArgs e)
        {
            //if (AccountBLL.Instance.checkPhoneNumber(txtCustomerPhoneNum.Text))
            //{
            //    if (Customer_BLL.Instance.getCustomerByPhoneNum(txtCustomerPhoneNum.Text) != null)
            //    {
            //        txtNameCustomer.Text = Customer_BLL.Instance.getCustomerByPhoneNum(txtCustomerPhoneNum.Text).Name_Customer;
            //    }
            //    else
            //    {
            //        MessageBox.Show("This account does not exist, please re-enter");
            //    }
            //}
        }
        private void showDgvSH()
        {
            dgvInvoice.DataSource = Invoice_BLL.Instance.getInvoiceView();
            dgvInvoice.Columns[0].HeaderText = "ID Invoice";
            dgvInvoice.Columns[1].HeaderText = "Staff's name";
            dgvInvoice.Columns[2].HeaderText = "Customer name";
            dgvInvoice.Columns[3].HeaderText = "Date";
        }

        private void dgvInvoice_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dgvInvoice.CurrentRow.Index;
            string id = dgvInvoice.Rows[i].Cells["ID_Invoice"].Value.ToString();
            dgvDetailInvoice.DataSource = InvoiceDetail_BLL.Instance.getInvoiceDetailView(Convert.ToInt32(id));
            txtTotalDI.Text = InvoiceDetail_BLL.Instance.getTotal(Convert.ToInt32(id)).ToString();

            dgvDetailInvoice.Columns[0].HeaderText = "Product's name";
            dgvDetailInvoice.Columns[1].HeaderText = "Product Category";
            dgvDetailInvoice.Columns[2].HeaderText = "Unit";
            dgvDetailInvoice.Columns[3].HeaderText = "Unit Price";
            dgvDetailInvoice.Columns[4].HeaderText = "Quantity";
            dgvDetailInvoice.Columns[5].HeaderText = "Amount";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            List<int> ls = new List<int>();
            dgvCart.DataSource = ls;
            //txtCustomerPhoneNum.Text = "";
            txtTotalProduct.Text = "";
            //txtSearchCustomer.Text = "";
        }

        private void rbDaily_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDaily.Checked)
            {
                dtDaily.Enabled = rbDaily.Checked;
                rbAnnual.Checked = false;
                rbQuarterly.Checked = false;
            }
            dtQuarterly.Enabled = rbQuarterly.Checked;
            dtAnnual.Enabled = rbAnnual.Checked;
        }

        private void rbQuarterly_CheckedChanged(object sender, EventArgs e)
        {
            if (rbQuarterly.Checked)
            {
                dtQuarterly.Enabled = rbQuarterly.Checked;
                rbAnnual.Checked = rbAnnual.Checked;
                rbDaily.Checked = false;
            }
            dtAnnual.Enabled = rbAnnual.Checked;
            dtDaily.Enabled = rbDaily.Checked;
        }

        private void rbAnnual_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAnnual.Checked)
            {
                dtAnnual.Enabled = rbAnnual.Checked;
                rbQuarterly.Checked = false;
                rbDaily.Checked = false;
            }
            dtQuarterly.Enabled = rbQuarterly.Checked;
            dtDaily.Enabled = rbDaily.Checked;
        }

        private void btnBack_TR_Click(object sender, EventArgs e)
        {
            MainForm mf2 = new MainForm(acc);
            this.Hide();
            mf2.mName(rs);
            mf2.ShowDialog();
        }

        private void cbbResultSearchCustomer_MouseClick(object sender, MouseEventArgs e)
        {
            cbbResultSearchCustomer.Items.Clear();
            if (Customer_BLL.Instance.getListCustomer(cbbSearchCustomer.SelectedItem.ToString(), txtSearchCustomer.Text) != null)
            {
                foreach (var i in Customer_BLL.Instance.getListCustomer(cbbSearchCustomer.SelectedItem.ToString(), txtSearchCustomer.Text))
                {

                    cbbResultSearchCustomer.Items.Add((i.Name_Customer == null ? "" : i.Name_Customer + "-")
                        + (i.PhoneNumber_Customer == null ? "" : i.PhoneNumber_Customer + "-")
                        + (i.Email_Customer == null ? "" : i.Email_Customer));
                }
            }
        }

        private void btnCatalogManagement_Click(object sender, EventArgs e)
        {
            CatalogManagement cm = new CatalogManagement();
            cm.d = new CatalogManagement.Mydel(setCBProductsGroups);
            cm.ShowDialog();
        }

        //private void btnPrintInvoice_Click(object sender, EventArgs e)
        //{
        //    InvoiceReport invoiceReport = new InvoiceReport();
        //    invoiceReport.ShowDialog();
        //}

        private void txtSearchSH_TextChanged(object sender, EventArgs e)
        {
            dgvInvoice.DataSource = Invoice_BLL.Instance.GetInvoiceByDate(txtSearchSH.Text);
        }

        private void pbRefresh_Cus_Click(object sender, EventArgs e)
        {
            txtID_Customer.Text = "";
            txtName_Customer.Text = "";
            txtPhoneNumber_Customer.Text = "";
            txtAccountNumber.Text = "";
            txtAddress_Customer.Text = "";
            txtDiscountCustomer.Text = "";
            txtTaxCode_cus.Text = "";
            txtEmail_cus.Text = "";
            rbtnMale_cus.Checked = true;
            rbTrue_cus.Checked = true;
        }

        private void pbRefresh_US_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtUsername.Text = "";
            txtRole.Text = "";
            dpBirthday.Value = DateTime.Now;
            rbMale_us.Checked = true;
            rbTrue_us.Checked = true;
        }

        private void pbRefresh_Supply_Click(object sender, EventArgs e)
        {
            txtID_Supply.Text = "";
            txtName_Supply.Text = "";
            txtTaxCode_su.Text = "";
            txtAddress_Supply.Text = "";
            txtPhoneNumber_Supply.Text = "";
            txtBankAccount.Text = "";
            rbTrue_su.Checked = true;
        }

        private void cbSearchProduct_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtSearchCustomer_MI_TextChanged(object sender, EventArgs e)
        {
            if (cbbSearchCustomer_MI.Text!=null)
            {
                searchCustomer(cbbSearchCustomer_MI.Text);
            }
        }
        public void addCbSearchCustomer()
        {
            cbbSearchCustomer_MI.Items.Add("ID");
            cbbSearchCustomer_MI.Items.Add("Name Customer");
            cbbSearchCustomer_MI.Items.Add("Gender");
            cbbSearchCustomer_MI.Items.Add("Address");
            cbbSearchCustomer_MI.Items.Add("Phone number");
            cbbSearchCustomer_MI.Items.Add("Email");
            cbbSearchCustomer_MI.Items.Add("Account Number");
            cbbSearchCustomer_MI.Items.Add("Tax code");
    
        }
        private void searchCustomer(string option)
        {
            switch (option)
            {
                case "ID":
                    option = "ID_Customer";
                    break;
                case "Name Customer":
                    option = "Name_Customer";
                    break;
                case "Gender":
                    option = "Gender_Customer";
                    break;
                case "Address":
                    option = "Address_Customer";
                    break;
                case "Phone number":
                    option = "PhoneNumber_Customer";
                    break;
                case "Email":
                    option = "Email_Customer";
                    break;
                case "Account Number":
                    option = "AccountNumber";
                    break;
                case "Tax code":
                    option = "TaxCode";
                    break;
                default:
                    break;
            }
            dgv3.DataSource = Customer_BLL.Instance.getCustomersByOption(txtSearchCustomer_MI.Text, option);
        }

        private void txtSearchSupply_MI_TextChanged(object sender, EventArgs e)
        {
            if (cbbSearchSupply_MI.Text != null)
            {
                searchSupply(cbbSearchSupply_MI.Text);
            }
        }
        public void addCbSearchSupply()
        {
            cbbSearchSupply_MI.Items.Add("ID");
            cbbSearchSupply_MI.Items.Add("Name Supply");
            cbbSearchSupply_MI.Items.Add("Address");
            cbbSearchSupply_MI.Items.Add("Phone number");
            cbbSearchSupply_MI.Items.Add("Bank Account");
            cbbSearchSupply_MI.Items.Add("Tax code");

        }
        private void searchSupply(string option)
        {
            switch (option)
            {

                case "ID":
                    option = "ID_Supply";
                    break;
                case "Name Supply":
                    option = "Name_Supply";
                    break;
                case "Address":
                    option = "Address_Supply";
                    break;
                case "Phone number":
                    option = "PhoneNumber_Supply";
                    break;
                case "Bank Account":
                    option = "BankAccount";
                    break;
                case "Tax code":
                    option = "TaxCode";
                    break;
                default:
                    break;
            }
            dgv4.DataSource = Supply_BLL.Instance.getSupplysByOption(txtSearchSupply_MI.Text, option);
        }
        //report

    }
}

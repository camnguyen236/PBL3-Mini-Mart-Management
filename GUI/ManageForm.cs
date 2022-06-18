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
                TabControlManage.TabPages.Remove(tpSupplier);
                TabControlMain.TabPages.Remove(tpImport);
            }
            
            addCbSearch();
            setCBProductsGroups();
            addCbSearchProduct();
            addCbSearchCustomer();
            addCbSearchSupplier();
            setCBBName_Supplier();
            setCBBID_Products();
            cbbName_Product.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbbName_Product.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbbName_Product.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //setCBBDiscount();

            addTab();
            Show_Customer();
            Show();
            cbProductsGroups.SelectedIndex = 0;
            Show_Product(getCurrenGroupName());
            Show_Supplier();
            showDgvSH();
            cb_point.Hide();
        }
        private void Reset()
        {
            txtID.Text = "";
            txtUsername.Text = "";
            txtName.Text = "";
            dpBirthday.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            txtEmail.Text = "";
        }
        private void Show(bool b = true)
        {
            dgv1.DataSource = b ? AccountBLL.Instance.getAccount() : AccountBLL.Instance.getTFAccount();
        }

        private void Show_Customer()
        {
            dgv3.DataSource = Customer_BLL.Instance.getCustomer();
        }
        private void Show_Supplier(bool b = true)
        {
            dgv4.DataSource = b ? Supplier_BLL.Instance.getSupplier() : Supplier_BLL.Instance.getTFSupplier();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MainForm mf2 = new MainForm(acc);
            this.Hide();
            mf2.mName(rs);
            mf2.ShowDialog();

            this.Close();
        }
        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.ReadOnly = true;
            txtID.Text = AccountBLL.Instance.getAccountByID(dgv1.SelectedRows[0].Cells["ID"].Value.ToString()).ID.ToString();
            txtUsername.Text = AccountBLL.Instance.getAccountByID(dgv1.SelectedRows[0].Cells["ID"].Value.ToString()).US.ToString();
            txtName.Text = AccountBLL.Instance.getAccountByID(dgv1.SelectedRows[0].Cells["ID"].Value.ToString()).Name.ToString();
            dpBirthday.Value = AccountBLL.Instance.getAccountByID(dgv1.SelectedRows[0].Cells["ID"].Value.ToString()).Birthday;
            txtAddress.Text = AccountBLL.Instance.getAccountByID(dgv1.SelectedRows[0].Cells["ID"].Value.ToString()).Adress.ToString();
            txtPhone.Text = AccountBLL.Instance.getAccountByID(dgv1.SelectedRows[0].Cells["ID"].Value.ToString()).PhoneNumber.ToString();
            txtEmail.Text = AccountBLL.Instance.getAccountByID(dgv1.SelectedRows[0].Cells["ID"].Value.ToString()).Email.ToString();
            rbMale_us.Checked = AccountBLL.Instance.getAccountByID(dgv1.SelectedRows[0].Cells["ID"].Value.ToString()).Gender.ToString().Contains("Nam") ? true : false;
            rbFemale_us.Checked = AccountBLL.Instance.getAccountByID(dgv1.SelectedRows[0].Cells["ID"].Value.ToString()).Gender.ToString().Contains("Nam") ? false : true;
            rbTrue_us.Checked = AccountBLL.Instance.getAccountByID(dgv1.SelectedRows[0].Cells["ID"].Value.ToString()).Status;
            rbFalse_us.Checked = !AccountBLL.Instance.getAccountByID(dgv1.SelectedRows[0].Cells["ID"].Value.ToString()).Status;
        }
        Account account;
        Customer customer;
        Supplier Supplier;
        Product product;
        DetailImportProducts detailImportProducts;
        ImportProducts importProducts;
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv1.SelectedRows.Count == 1)
            {
                AccountBLL.Instance.ExcuteDB(new Account
                {
                    ID = Convert.ToInt32(txtID.Text),
                    US = txtUsername.Text,
                    PW = AccountBLL.Instance.getAccountByID(txtID.Text).PW,
                    Name = txtName.Text,
                    Gender = rbMale_us.Checked ? "Nam" : "Nữ",
                    Birthday = Convert.ToDateTime(dpBirthday.Text),
                    Adress = txtAddress.Text,
                    PhoneNumber = txtPhone.Text,
                    Position = AccountBLL.Instance.getAccountByID(txtID.Text).Position.ToString(),
                    Email = txtEmail.Text,
                    Status = rbTrue_us.Checked
                });
                Show(!cb_us.Checked);
            }       

        }

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    if (dgv1.SelectedRows.Count > 0)
        //    {
        //        DialogResult dl = MessageBox.Show("Are you sure to delete this row?", ""
        //            , MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        //        if (dl == DialogResult.OK)
        //        {
        //            AccountBLL.Instance.ExcuteDB(account, txtID.Text);
        //            Show(!cb_us.Checked);
        //            Reset();
        //        }
        //        else if (dl == DialogResult.Cancel)
        //        {
        //            //sthis.Close();
        //        }
        //    }            
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddAccount ad = new AddAccount();
            ad.d = new AddAccount.Mydel(Show);
            ad.ShowDialog();
        }

        //Tap Manage customer
        private void dgv3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID_Customer.ReadOnly = true;
            txtID_Customer.Text = Customer_BLL.Instance.getCustomerByID(dgv3.SelectedRows[0].Cells["ID_Customer"].Value.ToString()).ID_Customer.ToString();
            txtName_Customer.Text = Customer_BLL.Instance.getCustomerByID(dgv3.SelectedRows[0].Cells["ID_Customer"].Value.ToString()).Name_Customer.ToString();
            rbtnMale_cus.Checked = Customer_BLL.Instance.getCustomerByID(dgv3.SelectedRows[0].Cells["ID_Customer"].Value.ToString()).Gender_Customer.ToString().Equals("Nam") ? true : false;
            rbtnFemale_cus.Checked = Customer_BLL.Instance.getCustomerByID(dgv3.SelectedRows[0].Cells["ID_Customer"].Value.ToString()).Gender_Customer.ToString().Equals("Nam") ? false : true;
            txtAddress_Customer.Text = Customer_BLL.Instance.getCustomerByID(dgv3.SelectedRows[0].Cells["ID_Customer"].Value.ToString()).Address_Customer.ToString();
            txtPhoneNumber_Customer.Text = Customer_BLL.Instance.getCustomerByID(dgv3.SelectedRows[0].Cells["ID_Customer"].Value.ToString()).PhoneNumber_Customer.ToString();
            txtAccountNumber.Text = Customer_BLL.Instance.getCustomerByID(dgv3.SelectedRows[0].Cells["ID_Customer"].Value.ToString()).AccountNumber.ToString();
            txtTaxCode_cus.Text = Customer_BLL.Instance.getCustomerByID(dgv3.SelectedRows[0].Cells["ID_Customer"].Value.ToString()).TaxCode.ToString();
            txtEmail_cus.Text = Customer_BLL.Instance.getCustomerByID(dgv3.SelectedRows[0].Cells["ID_Customer"].Value.ToString()).Email_Customer.ToString();
        }

        //private void btnDelete_Customer_Click(object sender, EventArgs e)
        //{
        //    if(dgv3.SelectedRows.Count > 0)
        //    {
        //        DialogResult dl = MessageBox.Show("Are you sure to delete this row?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        //        if (dl == DialogResult.OK)
        //        {
        //            Customer_BLL.Instance.ExcuteDB(customer, txtID_Customer.Text);
        //            Show_Customer();
        //            Reset();
        //        }
        //        else if (dl == DialogResult.Cancel)
        //        {
        //            //sthis.Close();
        //        }
        //    }            
        //}

        private void btnUpdate_Customer_Click(object sender, EventArgs e)
        {
            if(dgv3.SelectedRows.Count == 1)
            {
                Customer_BLL.Instance.ExcuteDB(new Customer
                {
                    ID_Customer = Convert.ToInt32(txtID_Customer.Text),
                    Name_Customer = txtName_Customer.Text,
                    Gender_Customer = rbtnFemale_cus.Checked ? "Nữ" : "Nam",
                    Address_Customer = txtAddress_Customer.Text,
                    PhoneNumber_Customer = txtPhoneNumber_Customer.Text,
                    AccountNumber = txtAccountNumber.Text,
                    Email_Customer = txtEmail_cus.Text,
                    TaxCode = txtTaxCode_cus.Text,
                    Status = true
                });
                Show_Customer();
            }            
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

        //Tab Manage Supplier

        private void btnAdd_Supplier_Click(object sender, EventArgs e)
        {
            AddSupplier ad = new AddSupplier();
            ad.d = new AddSupplier.Mydel(Show_Supplier);
            ad.ShowDialog();
        }

        private void btnUpdate_Supplier_Click(object sender, EventArgs e)
        {
            if(dgv4.SelectedRows.Count == 1)
            {
                Supplier_BLL.Instance.ExcuteDB(new Supplier
                {
                    ID_Supplier = Convert.ToInt32(txtID_Supplier.Text),
                    Name_Supplier = txtName_Supplier.Text,
                    Address_Supplier = txtAddress_Supplier.Text,
                    PhoneNumber_Supplier = txtPhoneNumber_Supplier.Text,
                    BankAccount = txtBankAccount.Text,
                    TaxCode = txtTaxCode_su.Text,
                    Status = rbTrue_sup.Checked
                });
                Show_Supplier(!cb_supplier.Checked);
            }            
        }
        
        //private void btnDelete_Supplier_Click(object sender, EventArgs e)
        //{
        //    if(dgv4.SelectedRows.Count > 0)
        //    {
        //        DialogResult dl = MessageBox.Show("Are you sure to delete this row?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        //        if (dl == DialogResult.OK)
        //        {
        //            Supplier_BLL.Instance.ExcuteDB(Supplier, txtID_Supplier.Text);
        //            Show_Supplier();
        //            Reset();
        //        }
        //        else if (dl == DialogResult.Cancel)
        //        {
        //            //sthis.Close();
        //        }
        //    }            
        //}
        private void dgv4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID_Supplier.ReadOnly = true;
            txtID_Supplier.Text = Supplier_BLL.Instance.getSupplierByID(dgv4.SelectedRows[0].Cells["ID_Supplier"].Value.ToString()).ID_Supplier.ToString();
            txtName_Supplier.Text = Supplier_BLL.Instance.getSupplierByID(dgv4.SelectedRows[0].Cells["ID_Supplier"].Value.ToString()).Name_Supplier.ToString();
            txtAddress_Supplier.Text = Supplier_BLL.Instance.getSupplierByID(dgv4.SelectedRows[0].Cells["ID_Supplier"].Value.ToString()).Address_Supplier.ToString();
            txtPhoneNumber_Supplier.Text = Supplier_BLL.Instance.getSupplierByID(dgv4.SelectedRows[0].Cells["ID_Supplier"].Value.ToString()).PhoneNumber_Supplier.ToString();
            txtBankAccount.Text = Supplier_BLL.Instance.getSupplierByID(dgv4.SelectedRows[0].Cells["ID_Supplier"].Value.ToString()).BankAccount.ToString();
            txtTaxCode_su.Text = Supplier_BLL.Instance.getSupplierByID(dgv4.SelectedRows[0].Cells["ID_Supplier"].Value.ToString()).TaxCode.ToString();
            rbTrue_sup.Checked = Supplier_BLL.Instance.getSupplierByID(dgv4.SelectedRows[0].Cells["ID_Supplier"].Value.ToString()).Status;
            rbFalse_sup.Checked = !Supplier_BLL.Instance.getSupplierByID(dgv4.SelectedRows[0].Cells["ID_Supplier"].Value.ToString()).Status;
        }


        //manage product
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

        private void Show_Product(string groupName, bool b = true)
        {
            if (groupName == "All")
            {
                dgv2.DataSource = b ? Product_BLL.Instance.getProducts() : Product_BLL.Instance.getTFProducts();
            }
            else
            {
                dgv2.DataSource = b ? Product_BLL.Instance.getProductsByGroupName(groupName) : Product_BLL.Instance.getTFProductsByGroupName(groupName);
            }
        }

        //private void btnDelteProduct_Click(object sender, EventArgs e)
        //{
        //    if(dgv2.SelectedRows.Count > 0)
        //    {
        //        DialogResult dl = MessageBox.Show("Are you sure to delete this row?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        //        if (dl == DialogResult.OK)
        //        {
        //            Product_BLL.Instance.ExcuteDB(product, dgv2.SelectedRows[0].Cells["ID_P"].Value.ToString());
        //            Show_Product(getCurrenGroupName());
        //        }
        //        else if (dl == DialogResult.Cancel)
        //        {
        //            //sthis.Close();
        //        }
        //    }            
        //}

        private void cbProductsGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            Show_Product(getCurrenGroupName(), !cb_Product.Checked);
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
            ProductDetails pd = new ProductDetails(dgv.SelectedRows[0].Cells["ID_P"].Value.ToString());
            cb_Product.Checked = false;
            pd.d = new ProductDetails.MyDel(Show_Product);
            pd.Show();
        }

        private void btnAdd_PG_Click(object sender, EventArgs e)
        {            
            ProductDetails pd = new ProductDetails();
            cb_Product.Checked = false;
            pd.d = new ProductDetails.MyDel(Show_Product);
            pd.Show();
        }

        private void btnUpdate_PG_Click(object sender, EventArgs e)
        {
            if(dgv2.SelectedRows.Count == 1)
            {
                ProductDetails pd = new ProductDetails(dgv2.SelectedRows[0].Cells["ID_P"].Value.ToString());
                cb_Product.Checked = false;
                pd.d = new ProductDetails.MyDel(Show_Product);
                pd.Show();
            }
        }
        public void showInformationNew(int i)
        {
            cbbName_Supplier.SelectedItem = ImportProductsBLL.Instance.getRecordsNewID_IP().Rows[i]["Name_Supplier"].ToString();
            txtAddress_InfOfBill.Text = ImportProductsBLL.Instance.getRecordsNewID_IP().Rows[i]["Address_Supplier"].ToString();
            txtBankAccountInfOfBill.Text = ImportProductsBLL.Instance.getRecordsNewID_IP().Rows[i]["BankAccount"].ToString();
            txtPhoneNumberSupplier.Text = ImportProductsBLL.Instance.getRecordsNewID_IP().Rows[i]["PhoneNumber_Supplier"].ToString();
            txtID_Tax.Text = ImportProductsBLL.Instance.getRecordsNewID_IP().Rows[i]["TaxCode"].ToString();
        }
        public int countRowsImportProduct()
        {
            return ImportProductsBLL.Instance.getAllImport_Product().Rows.Count;
        }
        public void setCBBName_Supplier() //cbb tên ncc
        {
            cbbName_Supplier.Items.AddRange(ImportProductsBLL.Instance.getAllName_Supplier().Distinct().ToArray());
        }
        public void setCBBID_Products() //cbb mã sp
        {
            //cbbID_Product.Items.AddRange(ImportProductsBLL.Instance.getAllIP_Product().ToArray());
            foreach(var i in Product_BLL.Instance.getAllProductTrue())
            {
                cbbName_Product.Items.Add(new CBBGroups
                {
                    Value = i.ID_P,
                    Text = i.Name_P
                });
            }
        }
        //public void setCBBDiscount() //cbb mã sp
        //{
        //    txtDiscount.Items.AddRange(ImportProductsBLL.Instance.getAllDiscount().Distinct().ToArray());
        //}
        private void showProducts()
        {
            int ID_IP = Convert.ToInt32(ImportProductsBLL.Instance.getAllImport_Product().Rows[countRowsImportProduct()-1]["ID"].ToString()); //láy id phiếu cuối
            dtgvImportProduct.DataSource = ImportProductsBLL.Instance.getDetailsImportProduct(ID_IP);
        }
        int amount;
        double total;
        private void btnAdd_InfOfProduct_Click(object sender, EventArgs e)
        {
            detailImportProducts = new DetailImportProducts
            {
                ID_IP = Convert.ToInt32(ImportProductsBLL.Instance.getAllImport_Product().Rows[countRowsImportProduct()-1]["ID"].ToString()),
                ID_P = ((CBBGroups)cbbName_Product.SelectedItem).Value,
                IP_Price = Convert.ToDouble(txtImport_Price.Text),
                Amount_IP = Convert.ToInt32(nmrQuantity.Value),
                Amount_Price = amount,
                Discount = Convert.ToDouble(txtDiscount.Text),
                Total = total,
            };
            DetailImportProductBLL.Instance.ExcuteDB(detailImportProducts, "Add");
            lbAdd.ForeColor = Color.Green;
            
            showProducts();
            txtTotalAll.Text = Convert.ToString(totalAll());
        }
        
        private void dtgvImportProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbName_Product.Enabled = false;
            int i = dtgvImportProduct.CurrentRow.Index;
            //cbbID_Product.Text = ImportProductsBLL.Instance.getImportProductsByID(dtgvImportProduct.SelectedRows[0].Cells["ID_P"].Value.ToString()).ID_IP.ToString();
            cbbName_Product.Text = dtgvImportProduct.Rows[i].Cells[1].Value.ToString();
            //txtImport_Price.Text = ImportProductsBLL.Instance.getImportProductsByID(dtgvImportProduct.SelectedRows[0].Cells["ID_P"].Value.ToString()).ip
            txtImport_Price.Text = dtgvImportProduct.Rows[i].Cells[2].Value.ToString();
            nmrQuantity.Value = Convert.ToInt32(dtgvImportProduct.Rows[i].Cells[3].Value.ToString());
            amount = (Convert.ToInt32(dtgvImportProduct.Rows[i].Cells[3].Value) * Convert.ToInt32(dtgvImportProduct.Rows[i].Cells[2].Value));
            txtPrice.Text = Convert.ToString(amount);
            txtDiscount.Text = dtgvImportProduct.Rows[i].Cells[5].Value.ToString();
            total = amount + amount * Convert.ToInt32(txtDiscount.Text) / 100;
            txtTotal.Text = Convert.ToString(total);
        }

        private void btnDeleteImportProduct_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Are you sure to delete this row?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                DetailImportProductBLL.Instance.ExcuteDB(detailImportProducts,cbbName_Product.Text);
                showProducts();
            }
            else if (dl == DialogResult.Cancel)
            {
                //sthis.Close();
            }
        }

        private void btnNewInfOfProduct_Click(object sender, EventArgs e)
        {
            cbbName_Product.Enabled = true;
            cbbName_Product.Text = "";
            txtImport_Price.Text = "";
            nmrQuantity.Value = 0;
            txtPrice.Text = "";
            txtDiscount.Text = "";
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
            cbbName_Supplier.Text = "";
            txtAddress_InfOfBill.Text = "";
            txtBankAccountInfOfBill.Text = "";
            txtPhoneNumberSupplier.Text = "";
            txtID_Tax.Text = "";
            dtgvImportProduct.DataSource = empty;
            lbSaveInfOfBill.ForeColor = Color.White;
        }

        private void cbbName_Supplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            showInformationNew(cbbName_Supplier.SelectedIndex);
        }

        private void btnSave_InfOfBill_Click(object sender, EventArgs e)
        {
            importProducts = new ImportProducts
            {
                ID_IP = 0,
                ID = AccountBLL.Instance.getID(),
                Date_Import = DateTime.Now,
                ID_Supplier = Supplier_BLL.Instance.getSupplierByName(cbbName_Supplier.SelectedItem.ToString()).ID_Supplier
            };
            
            ImportProductsBLL.Instance.ExcuteDB(importProducts, "Add");
            //lbAdd.ForeColor = Color.Green;
            lbSaveInfOfBill.ForeColor = Color.Green;
            txtID_IP.Text = ImportProductsBLL.Instance.getAllImport_Product().Rows[countRowsImportProduct()-1]["ID"].ToString();
            DetailImportProductBLL.Instance.get(txtID_IP.Text);
            //setCBBID_IP();
        }

        private void btnDetailImportBill_Click(object sender, EventArgs e)
        {
            ImportProductsBill importProductsBill = new ImportProductsBill();
            importProductsBill.ShowDialog();
        }

        private void btnUpdateImportProduct_Click(object sender, EventArgs e)
        {
            total = amount - amount * Convert.ToInt32(txtDiscount.Text) / 100;
            detailImportProducts = new DetailImportProducts
            {
                ID_IP = 0,
                ID_P = ((CBBGroups)cbbName_Product.SelectedItem).Value,
                IP_Price = Convert.ToDouble(txtImport_Price.Text),
                Amount_IP = Convert.ToInt32(nmrQuantity.Value),
                Amount_Price = amount,
                Discount = Convert.ToDouble(txtDiscount.Text),
                Total = total,
            };
            DetailImportProductBLL.Instance.ExcuteDB(detailImportProducts);
            lbUpdate.ForeColor = Color.Green;

            showProducts();
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
            int ID_IP = Convert.ToInt32(ImportProductsBLL.Instance.getAllImport_Product().Rows[countRowsImportProduct()-1]["ID"].ToString());
            int count = ImportProductsBLL.Instance.getDetailsImportProduct(ID_IP).Rows.Count;
            for(int i=0; i<count; i++)
            {
                totalall += Convert.ToDouble(ImportProductsBLL.Instance.getDetailsImportProduct(ID_IP).Rows[i]["Total"].ToString());
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

        private bool checkID_P(int id, int num)
        {
            for(int i = 0; i < productArray.Count; i++)
            {
                if(productArray[i].Item1 == id)
                {
                    productArray[i] = new Tuple<int, int>(productArray[i].Item1, productArray[i].Item2 + num);
                    return true;
                }
            }
            return false;
        }

        private void addToCard_Click(object sender, EventArgs e)
        {
            txtTotal.Text = "";
            UserControl1 us = (UserControl1)sender;
            if (us.Number <= 0)
            {
                MessageBox.Show("Please enter the quantity");
                return;
            }
            MessageBox.Show("Add successful");
            if (!checkID_P(us.Id_p, us.Number)) productArray.Add(new Tuple<int, int>(us.Id_p, us.Number));
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

        private void btnDelProduct_Click(object sender, EventArgs e)
        {
            if(dgvCart.SelectedRows.Count > 0) { 
                DialogResult dl = MessageBox.Show("Are you sure to delete this row?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dl == DialogResult.OK)
                {
                    var it = productArray.Single(productArray => productArray.Item1 == Convert.ToInt32(dgvCart.SelectedRows[0].Cells["ID_P"].Value.ToString()));
                    productArray.Remove(it);
                    viewCart();
                }
                else if (dl == DialogResult.Cancel)
                {
                    //sthis.Close();
                }
            }
        }
        

        private void btnPay_Click(object sender, EventArgs e)
        {
            Invoice inv = new Invoice
            {
                ID = acc.ID,
                ID_Customer = ((CBBGroups)cbbResultSearchCustomer.SelectedItem).Value,
                Invoice_Date = DateTime.Now,
                Name_Customer = ((CBBGroups)cbbResultSearchCustomer.SelectedItem).Text,
                Name_staff = AccountBLL.Instance.getAccountByID(acc.ID.ToString()).Name
            };
            Invoice_BLL.Instance.ExcuteDB(inv, "Add");
            int id = Convert.ToInt32(Invoice_BLL.Instance.getInvoice().Rows[Invoice_BLL.Instance.getInvoice().Rows.Count - 1]["ID_Invoice"].ToString());
            InvoiceDetail_BLL.Instance.get(id.ToString());
            for (int i = 0; i < productArray.Count; i++)
            {
                InvoiceDetail ind = new InvoiceDetail
                {
                    ID_Invoice = id,
                    ID_P = productArray[i].Item1,
                    Unit_Price = Convert.ToInt32(Product_BLL.Instance.getProductByID(productArray[i].Item1.ToString()).VATInclusive_P),
                    Quantity = productArray[i].Item2,
                    Name_product = Product_BLL.Instance.getProductByID(productArray[i].Item1.ToString()).Name_P,
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
            btnRefresh.PerformClick();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer ad = new AddCustomer();
            ad.d = new AddCustomer.Mydel(Show_Customer);
            ad.ShowDialog();
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
            txtTotalProduct.Text = "";
            txtSearchCustomer.Text = "";
            cbbResultSearchCustomer.Items.Clear();
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

        private void btnCatalogManagement_Click(object sender, EventArgs e)
        {
            CatalogManagement cm = new CatalogManagement();
            cm.d = new CatalogManagement.Mydel(setCBProductsGroups);
            cm.ShowDialog();
        }

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
            txtTaxCode_cus.Text = "";
            txtEmail_cus.Text = "";
            rbtnMale_cus.Checked = true;
        }

        private void pbRefresh_US_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            txtAddress.Text = "";
            txtUsername.Text = "";
            dpBirthday.Value = DateTime.Now;
            rbMale_us.Checked = true;
        }

        private void pbRefresh_Supplier_Click(object sender, EventArgs e)
        {
            txtID_Supplier.Text = "";
            txtName_Supplier.Text = "";
            txtTaxCode_su.Text = "";
            txtAddress_Supplier.Text = "";
            txtPhoneNumber_Supplier.Text = "";
            txtBankAccount.Text = "";
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

        private void txtSearchSupplier_MI_TextChanged(object sender, EventArgs e)
        {
            if (cbbSearchSupplier_MI.Text != null)
            {
                searchSupplier(cbbSearchSupplier_MI.Text);
            }
        }
        public void addCbSearchSupplier()
        {
            cbbSearchSupplier_MI.Items.Add("ID");
            cbbSearchSupplier_MI.Items.Add("Name Supplier");
            cbbSearchSupplier_MI.Items.Add("Address");
            cbbSearchSupplier_MI.Items.Add("Phone number");
            cbbSearchSupplier_MI.Items.Add("Bank Account");
            cbbSearchSupplier_MI.Items.Add("Tax code");

        }
        private void searchSupplier(string option)
        {
            switch (option)
            {

                case "ID":
                    option = "ID_Supplier";
                    break;
                case "Name Supplier":
                    option = "Name_Supplier";
                    break;
                case "Address":
                    option = "Address_Supplier";
                    break;
                case "Phone number":
                    option = "PhoneNumber_Supplier";
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
            dgv4.DataSource = Supplier_BLL.Instance.getSuppliersByOption(txtSearchSupplier_MI.Text, option);
        }

        private void cbbResultSearchCustomer_MouseClick(object sender, MouseEventArgs e)
        {
            cbbResultSearchCustomer.Items.Clear();
            if (txtSearchCustomer.Text != "" && Customer_BLL.Instance.getListCustomer(cbbSearchCustomer.SelectedItem.ToString(), txtSearchCustomer.Text) != null)
            {
                foreach (var i in Customer_BLL.Instance.getListCustomer(cbbSearchCustomer.SelectedItem.ToString(), txtSearchCustomer.Text))
                {
                    cbbResultSearchCustomer.Items.Add(new CBBGroups
                    {
                        Value = i.ID_Customer,
                        Text = (i.Name_Customer == null ? "" : i.Name_Customer + "-")
                        + (i.PhoneNumber_Customer == null ? "" : i.PhoneNumber_Customer + "-")
                        + (i.Email_Customer == null ? "" : i.Email_Customer)
                    });
                }
            }
        }

        private void cb_us_CheckedChanged(object sender, EventArgs e)
        {
            Show(cb_us.Checked ? false : true);
        }

        private void cb_Product_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cb_Supplier_CheckedChanged(object sender, EventArgs e)
        {
            Show_Supplier(cb_supplier.Checked ? false : true);
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if(cb_point.Checked) 
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }


        //report

    }
}

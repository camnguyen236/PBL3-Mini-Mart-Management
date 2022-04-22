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
using System.IO;
namespace GUI
{
    public partial class ProductDetails : Form
    {
        public delegate void MyDel();
        public MyDel d { get; set; }
        public string id_p { get; set; }
        public ProductDetails(string id = null)
        {
            InitializeComponent();
            id_p = id;
            loadData(id_p);
            setCBcbCatagories_PD();
            setCBCatagoriesSelectItem_PDByID(id);
        }

        
        //
        //variable
        public bool btnEditEnabled = true;
        private string imgLocation = "";
        //

        private void setCBcbCatagories_PD()
        {
            List<string> listProductsGroups = ProductGroups_BLL.Instance.getProductGroups().Rows.OfType<DataRow>().Select(dr => dr.Field<string>("Name_PG")).ToList();
            foreach (string i in listProductsGroups)
            {
                cbCatagories_PD.Items.Add(i);
            }
        }
        private string getNameGroupByID(string id)
        {
            DataTable db = ProductGroups_BLL.Instance.getNameGroupByID(id_p);
            DataRow dr = db.Rows[0];
            return dr["Name_PG"].ToString();
        }
        private string getIDByGroupName(string name)
        {
            try
            {
                DataTable db = ProductGroups_BLL.Instance.getIDByGroupName(name);
                DataRow dr = db.Rows[0];
                return dr["ID_PG"].ToString();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            return "";
        }
        private void setCBCatagoriesSelectItem_PDByID(string id)
        {
            int index = 0;
            if(id!=null){
                foreach (var item in cbCatagories_PD.Items)
                {
                    if (item.ToString() == getNameGroupByID(id))
                    {
                        cbCatagories_PD.SelectedIndex = index;
                    }
                    index++;
                }
            }
            
        }
        private void loadData(string id)
        {
            if (id!=null)
            {
                DataTable db = Product_BLL.Instance.GetProductByID(id_p);
                DataRow dr = db.Rows[0];
                lbNameProduct_PD.Text = dr["Name_P"].ToString();

                txtID_PD.Text = dr["ID_P"].ToString();
                cbCatagories_PD.Text = getNameGroupByID(dr["ID_PG"].ToString());
                txtName_PD.Text = dr["Name_P"].ToString();
                txtUnit_PD.Text = dr["Unit_P"].ToString();
                txtPrice_PD.Text = dr["Price_P"].ToString();
                txtVAT_PD.Text = dr["VAT"].ToString();
                txtVATInclusive_PD.Text = dr["VAT_Inclusive_P"].ToString();
                txtID_PD.Enabled = false;
                cbCatagories_PD.Enabled = false;
                txtQuantity_PD.Enabled = false;
                txtName_PD.Enabled = false;
                txtUnit_PD.Enabled = false;
                txtVATInclusive_PD.Enabled = false;
                txtPrice_PD.Enabled = false;
                txtVAT_PD.Enabled = false;
                byte[] img = (byte[])dr["IMG_P"];
                MemoryStream ms = new MemoryStream(img);
                img_PD.Image = Image.FromStream(ms);
                btnCancel_PD.Hide();
                btnAdd_PD.Hide();
            }
            else
            {
                txtID_PD.Enabled = false;
                txtQuantity_PD.Enabled = false;
                txtVATInclusive_PD.Enabled=false;
            }
        }
            

        private void ProductDetails_Load(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_PD_Click(object sender, EventArgs e)
        {
            cbCatagories_PD.Enabled = true;
            txtName_PD.Enabled = true;
            txtUnit_PD.Enabled = true;
            txtPrice_PD.Enabled = true;
            txtVAT_PD.Enabled = true;
            if (btnEditEnabled == true)
            {
                btnEdit_PD.Text = "Save";
                lbSave.Text = "Changing...";
                lbSave.ForeColor = Color.FromArgb(220, 3, 49);
                btnEditEnabled = false;
                btnChangeImg_PD.Show();
            }
            else
            {
                txtID_PD.Enabled = false;
                cbCatagories_PD.Enabled = false;
                txtQuantity_PD.Enabled = false;
                txtName_PD.Enabled = false;
                txtUnit_PD.Enabled = false;
                txtVATInclusive_PD.Enabled = false;
                txtPrice_PD.Enabled = false;
                txtVAT_PD.Enabled = false;
                lbSave.Text = "Saved✓";
                lbSave.ForeColor = Color.FromArgb(39, 216, 102);
                btnEditEnabled = true;
                btnEdit_PD.Text = "Edit";
                btnChangeImg_PD.Hide();
                saveBtn();
            }
        }

        private void saveBtn()
        {
            //check
            if (cbCatagories_PD.Text.Trim() == "" || txtName_PD.Text.Trim() == "" || txtUnit_PD.Text.Trim() == "" || txtPrice_PD.Text.Trim() == "" || txtVAT_PD.Text.Trim() == ""|| cbCatagories_PD.Text == "")
                MessageBox.Show("Please fill in the required information!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                Product product = new Product
                {
                    Name_P = txtName_PD.Text,
                    Unit_P = txtUnit_PD.Text,
                    Price_P = txtPrice_PD.Text,
                    VAT = txtVAT_PD.Text,
                    ID_PG = getIDByGroupName(cbCatagories_PD.Text),
                };

                //save to database
                if (txtID_PD.Text=="")
                {
                    Product_BLL.Instance.ExcuteDB(product,"Add");
                    //save img to database
                    /*Product_BLL.Instance.updateProductImg(imgLocation);*/
                }
                else
                {
                    product.ID_P = Convert.ToInt32(txtID_PD.Text);
                    Product_BLL.Instance.ExcuteDB(product);
                    //save img to database
                    Product_BLL.Instance.updateProductImg(imgLocation, Convert.ToInt32(txtID_PD.Text));
                }

                
                //ok
                /*MessageBox.Show("update successfully");*/

            }

        }

        private void btnOK_PD_Click(object sender, EventArgs e)
        {
            d();
            this.Close();
        }

        private void btnChangeImg_PD_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "png files(*png)|*.png|jpg file (*jpg)|*.jpg|All file(*.*)|*.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                img_PD.ImageLocation = imgLocation;
            }
        }

        private void btnCancel_PD_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_PD_Click(object sender, EventArgs e)
        {
            saveBtn();
        }

        private void txtName_PD_TextChanged(object sender, EventArgs e)
        {
            lbNameProduct_PD.Text=txtName_PD.Text;
        }

        private void txtPrice_PD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int price = Convert.ToInt32(txtPrice_PD.Text);
                int vat = Convert.ToInt32(txtVAT_PD.Text);
                txtVATInclusive_PD.Text = (price * (1 + (vat / 100))).ToString();
            }
            catch (Exception)
            {
            }
        }

        private void txtVAT_PD_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double price = Convert.ToInt32(txtPrice_PD.Text);
                double vat = Convert.ToInt32(txtVAT_PD.Text);
                txtVATInclusive_PD.Text = (price * (1 + (vat / 100))).ToString();
            }
            catch (Exception)
            {
            }
        }

    }
}

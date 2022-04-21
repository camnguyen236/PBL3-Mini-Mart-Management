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
        public ProductDetails(string id)
        {
            InitializeComponent();
            id_p = id;
            loadData();
        }

        //variable
        public bool btnEditEnabled = true;
        private string getNameGroupByID(string id)
        {
            DataTable db = ProductGroups_BLL.Instance.getNameGroupByID(id_p);
            DataRow dr = db.Rows[0];
            return dr["Name_PG"].ToString();
        }
        private void loadData()
        {
            DataTable db = Product_BLL.Instance.GetProductByID(id_p);
            DataRow dr = db.Rows[0];
            lbNameProduct_PD.Text = dr["Name_P"].ToString();

            txtID_PD.Text = dr["ID_P"].ToString();
            txtCatagories_PD.Text = getNameGroupByID(dr["ID_PG"].ToString());
            txtName_PD.Text = dr["Name_P"].ToString();
            txtUnit_PD.Text = dr["Unit_P"].ToString();
            txtCost_PD.Text = dr["Cost_P"].ToString();
            txtPrice_PD.Text = dr["Price_P"].ToString();
            txtVAT_PD.Text = dr["VAT"].ToString();
            txtID_PD.Enabled = false;
            txtCatagories_PD.Enabled = false;
            txtQuantity_PD.Enabled = false ;
            txtName_PD.Enabled = false;
            txtUnit_PD.Enabled = false;
            txtCost_PD.Enabled = false;
            txtPrice_PD.Enabled = false;
            txtVAT_PD.Enabled = false;
            /* byte[] ms = new dr["IMG_P"]);
             img_PD.Image = new Bitmap(ms);*/
        }
            

        private void ProductDetails_Load(object sender, EventArgs e)
        {

        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnEdit_PD_Click(object sender, EventArgs e)
        {
            txtCatagories_PD.Enabled = true;
            txtName_PD.Enabled = true;
            txtUnit_PD.Enabled = true;
            txtCost_PD.Enabled = true;
            txtPrice_PD.Enabled = true;
            txtVAT_PD.Enabled = true;
            if (btnEditEnabled == true)
            {
                btnEdit_PD.Text = "Save";
                lbSave.Text = "Changing...";
                lbSave.ForeColor = Color.FromArgb(220, 3, 49);
                btnEditEnabled = false;
            }
            else
            {
                txtID_PD.Enabled = false;
                txtCatagories_PD.Enabled = false;
                txtQuantity_PD.Enabled = false;
                txtName_PD.Enabled = false;
                txtUnit_PD.Enabled = false;
                txtCost_PD.Enabled = false;
                txtPrice_PD.Enabled = false;
                txtVAT_PD.Enabled = false;
                lbSave.Text = "Saved✓";
                lbSave.ForeColor = Color.FromArgb(39, 216, 102);
                btnEditEnabled = true;
            }
        }

        private void btnOK_PD_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class CatalogManagement : Form
    {
        public CatalogManagement()
        {
            InitializeComponent();
            showDGV();
        }
        public delegate void Mydel();
        public Mydel d { get; set; }
        public delegate void CreateTP(TabPage myTabPage, CBBGroups PG);
        public CreateTP tp { get; set; }
        public delegate void updateTP(CBBGroups PG, CBBGroups PGNew);
        public updateTP up { get; set; }
        public delegate void removeTP(CBBGroups PG);
        public removeTP remove { get; set; }
        CBBGroups cbb { get; set; }
        bool status;
        public void showDGV(bool b = true)
        {
            dgvCM.DataSource = b ? ProductGroups_BLL.Instance.getProductGroups() : ProductGroups_BLL.Instance.getTFProductGroups();            
        }
        private void createTP(CBBGroups cbb)
        {
            TabPage myTabPage = new TabPage("tp" + cbb.Text);
            myTabPage.Name = "tp" + cbb.Text;
            tp(myTabPage, cbb);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
                MessageBox.Show("Please fill in the required information!", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
            {
                ProductGroups pg = new ProductGroups
                {
                    Name_PG = txtName.Text,
                    Status = rbTrue.Checked
                };
                ProductGroups_BLL.Instance.ExcuteDB(pg, "Add");

                MessageBox.Show("Added successfully");
                d();
                showDGV(!cb_PG.Checked);
                createTP(new CBBGroups 
                            { Value = Convert.ToInt32((ProductGroups_BLL.Instance.getAllProductGroups()[ProductGroups_BLL.Instance.getAllProductGroups().Count - 1]).ID_PG)
                            , Text = txtName.Text
                        });
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCM.SelectedRows.Count == 1)
            {
                if (!rbTrue.Checked && status)
                {
                    if (ProductGroups_BLL.Instance.checkNumOfProduct(txtID.Text))
                    {
                        MessageBox.Show("You cannot delete this product category because there are still products in that product category");
                        return;
                    }
                    else
                    {
                        ProductGroups_BLL.Instance.ExcuteDB(new ProductGroups
                        {
                            ID_PG = txtID.Text,
                            Name_PG = txtName.Text,
                            Status = rbTrue.Checked,
                        }, txtID.Text);
                        remove(cbb);
                    }
                }
                ProductGroups_BLL.Instance.ExcuteDB(new ProductGroups
                {
                    ID_PG = txtID.Text,
                    Name_PG = txtName.Text,
                    Status = rbTrue.Checked,
                });

                MessageBox.Show("Updated successfully");
                d();
                showDGV(!cb_PG.Checked);
                if(!status && rbTrue.Checked) 
                    createTP(new CBBGroups
                                {
                                    Value = Convert.ToInt32(txtID.Text),
                                    Text = txtName.Text
                                });
                else if(rbTrue.Checked)
                    up(cbb, new CBBGroups
                    {
                        Value = Convert.ToInt32(ProductGroups_BLL.Instance.getAllProductGroups()[ProductGroups_BLL.Instance.getAllProductGroups().Count - 1].ID_PG),
                        Text = txtName.Text
                    });
            }            
        }

        //private void btnDel_Click(object sender, EventArgs e)
        //{
        //    ProductGroups pg = new ProductGroups
        //    {
        //        ID_PG = txtID.Text,
        //        Name_PG = txtName.Text,
        //        Status = rbTrue.Checked,
        //    };
        //    DialogResult dl = MessageBox.Show("Are you sure to delete this row?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
        //    if (dl == DialogResult.OK)
        //    {
        //        ProductGroups_BLL.Instance.ExcuteDB(pg, txtID.Text);
        //        d();
        //        showDGV(!cb_PG.Checked);
        //        txtID.Text = "";
        //    }
        //}

        private void dgvCM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCM.SelectedRows.Count == 1)
            { 
                txtID.Text = ProductGroups_BLL.Instance.getPGByID(dgvCM.SelectedRows[0].Cells["ID_PG"].Value.ToString()).ID_PG;
                txtName.Text = ProductGroups_BLL.Instance.getPGByID(dgvCM.SelectedRows[0].Cells["ID_PG"].Value.ToString()).Name_PG;
                rbTrue.Checked = ProductGroups_BLL.Instance.getPGByID(dgvCM.SelectedRows[0].Cells["ID_PG"].Value.ToString()).Status;
                rbFalse.Checked = !ProductGroups_BLL.Instance.getPGByID(dgvCM.SelectedRows[0].Cells["ID_PG"].Value.ToString()).Status;
                cbb = new CBBGroups
                {
                    Value = Convert.ToInt32(ProductGroups_BLL.Instance.getPGByID(dgvCM.SelectedRows[0].Cells["ID_PG"].Value.ToString()).ID_PG),
                    Text = ProductGroups_BLL.Instance.getPGByID(dgvCM.SelectedRows[0].Cells["ID_PG"].Value.ToString()).Name_PG
                };
                status = rbTrue.Checked;
            }
            
        }

        private void pbRefresh_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtName.Text = "";
        }

        private void cb_PG_CheckedChanged(object sender, EventArgs e)
        {
            showDGV(!cb_PG.Checked);
        }
    }
}

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
        public void showDGV(bool b = true)
        {
            dgvCM.DataSource = b ? ProductGroups_BLL.Instance.getProductGroups() : ProductGroups_BLL.Instance.getTFProductGroups();
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
                    Status = true
                };
                ProductGroups_BLL.Instance.ExcuteDB(pg, "Add");

                MessageBox.Show("Added successfully");
                d();
                showDGV(!cb_PG.Checked);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCM.SelectedRows.Count == 1)
            {
                ProductGroups pg = new ProductGroups
                {
                    ID_PG = txtID.Text,
                    Name_PG = txtName.Text,
                    Status = true
                };
                ProductGroups_BLL.Instance.ExcuteDB(pg);

                MessageBox.Show("Updated successfully");
                d();
                showDGV(!cb_PG.Checked);
            }            
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            ProductGroups pg = new ProductGroups
            {
                ID_PG = txtID.Text,
                Name_PG = txtName.Text,
                Status = true
            };
            DialogResult dl = MessageBox.Show("Are you sure to delete this row?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (dl == DialogResult.OK)
            {
                ProductGroups_BLL.Instance.ExcuteDB(pg, txtID.Text);
                d();
                showDGV(!cb_PG.Checked);
                txtID.Text = "";
            }
        }

        private void dgvCM_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCM.SelectedRows.Count == 1)
            { 
                txtID.Text = ProductGroups_BLL.Instance.getPGByID(dgvCM.SelectedRows[0].Cells["ID_PG"].Value.ToString()).ID_PG;
                txtName.Text = ProductGroups_BLL.Instance.getPGByID(dgvCM.SelectedRows[0].Cells["ID_PG"].Value.ToString()).Name_PG;
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

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
    public partial class Systems : Form
    {
        Account acc;
        public Systems(Account acc)
        {
            this.acc = acc; 
            InitializeComponent();
            setCBBAccount();
        }
        public void setCBBAccount()
        {
            cbbAccount.Items.AddRange(AccountBLL.Instance.getAllUsername().ToArray());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newRole;
            if (rbAdmin.Checked) newRole = "Admin";
            else newRole = "Staff";
            AccountBLL.Instance.updateRole(cbbAccount.Text, newRole);
            MessageBox.Show("Successfully!");
            this.Close();
        }

        private void cbbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            MainForm mf2 = new MainForm(acc);
            this.Hide();
            mf2.ShowDialog();
            this.Close();
        }
    }
}

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

namespace GUI
{
    public partial class Systems : Form
    {
        public Systems()
        {
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
    }
}

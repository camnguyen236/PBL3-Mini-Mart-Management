using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBL_3
{
    public partial class List : Form
    {
        public List()
        {
            InitializeComponent();
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }
        Modify modify = new Modify();
        Login login = new Login();
        private void guna2Button1_Click(object sender, EventArgs e) //Button Back
        {
            MainForm mf2 = new MainForm();
            ////this.Hide();
            //string rs = login.roleLogin + " / " + modify.role;
            //mf2.mName(rs);
            mf2.ShowDialog();

            //this.Close();

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
    }
}

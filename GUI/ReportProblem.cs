using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ReportProblem : Form
    {
        public ReportProblem()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (true)
            {
                MessageBox.Show("Thank you for reporting the bug. It's very helpful for us!");
                txtEmail.Text = "";
                txtDesc.Text = "";
                txtTitle.Text = "";
            }
        }
    }
}

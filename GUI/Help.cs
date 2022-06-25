﻿using System;
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
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {

        }

        private void btnHow_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://dcd-help.netlify.app/");
        }

        

        private void btnProblem_Click(object sender, EventArgs e)
        {
            ReportProblem rp = new ReportProblem();
            rp.ShowDialog();
        }

        
    }
}

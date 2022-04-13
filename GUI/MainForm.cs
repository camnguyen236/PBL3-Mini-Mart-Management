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
    public partial class MainForm : Form
    {
        public delegate void MyDelName(string s);
        public MyDelName mName;
        public MainForm()
        {
            InitializeComponent();
            mName = new MyDelName(show);
        }
        public void load_data(string str)
        {
            txtNameNV.Text = str;
        }
        public void show(string s)
        {
            txtNameNV.Text = s;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ManageForm l = new ManageForm();
            this.Hide();
            l.rs = txtNameNV.Text;
            l.ShowDialog();
        }
    }
}

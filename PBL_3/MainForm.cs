﻿using System;
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
    public partial class MainForm : Form
    {
        public delegate void MyDelName(string s);
        public MyDelName mName;
        public MainForm()
        {
            //txtNameNV.Text = mName();
            InitializeComponent();
            mName = new MyDelName(show);
            //show();
        }
        //public void load_data(string str)
        //{
        //    txtNameNV.Text = str;
        //}
        public void show(string s)
        {
            txtNameNV.Text = s;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            List l = new List();
            l.Show();
        }
    }
}

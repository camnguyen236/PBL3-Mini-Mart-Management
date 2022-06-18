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
    public partial class MainForm : Form
    {
        public Login cur_login;
        public delegate void MyDelName(string s);
        public MyDelName mName;
        Account mAccount;

        public MainForm(Account acc)
        {
            InitializeComponent();
            
            mName = new MyDelName(show);
            btnSystem.Enabled = AccountBLL.Instance.checkRole("Admin");
            btnAnalyze.Enabled = AccountBLL.Instance.checkRole("Admin");
            mAccount = acc;
            pnAccountDropDown.Hide();
            pnAccountDropDown.Size = pnAccountDropDown.MinimumSize;
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
            ManageForm l = new ManageForm(mAccount);
            this.Hide();
            l.rs = txtNameNV.Text;
            l.ShowDialog();
        }

        private void btnSystem_Click(object sender, EventArgs e)
        {
            Systems s = new Systems();
            s.ShowDialog();
        }


        private bool isCollapsed=true;//check collap
        //bấm zô cái avatar
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                pnAccountDropDown.Show();
                pnAccountDropDown.Height += 50;
                if (pnAccountDropDown.Size == pnAccountDropDown.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                
                pnAccountDropDown.Height -= 50;
                if (pnAccountDropDown.Size == pnAccountDropDown.MinimumSize)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
                pnAccountDropDown.Hide();
            }
        }

        private void ptAvatar_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }
        private void btnSignout_MouseHover(object sender, EventArgs e)
        {
            btnSignout.BackColor = Color.FromArgb(192, 0, 0);
        }
        private void btnSignout_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSignout_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            Analyze l = new Analyze();
            l.ShowDialog();
        }

        private void btnChangePw_Click(object sender, EventArgs e)
        {

        }
    }
}

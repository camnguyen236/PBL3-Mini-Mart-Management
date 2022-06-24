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
        public delegate void MyDelName(string s);
        public MyDelName mName;
        Account mAccount;

        public MainForm(Account acc)
        {
            InitializeComponent();
            btnSystem.Enabled = AccountBLL.Instance.checkRole("Admin");
            btnAnalyze.Enabled = AccountBLL.Instance.checkRole("Admin");
            mAccount = acc;
            pnAccountDropDown.Hide();
            pnAccountDropDown.Size = pnAccountDropDown.MinimumSize;
            txtNameNV.Text = acc.US + "/" + acc.Position;
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            ManageForm l = new ManageForm(mAccount);
            this.Close();
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
                pnAccountDropDown.Height += 200;
                if (pnAccountDropDown.Size == pnAccountDropDown.MaximumSize)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {                
                pnAccountDropDown.Height -= 200;
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

        private void btnSignout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Login login = new Login();
            login.ShowDialog();
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            Analyze l = new Analyze(mAccount);
            this.Close();
            l.ShowDialog();
        }

        private void btnChangePw_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword(mAccount);
            cp.ShowDialog();
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Help f_help = new Help();
            f_help.ShowDialog();
        }

        private void btnChangeProfile_Click(object sender, EventArgs e)
        {
            ChangeProfile cp = new ChangeProfile(mAccount);
            cp.ShowDialog();
        }
    }
}

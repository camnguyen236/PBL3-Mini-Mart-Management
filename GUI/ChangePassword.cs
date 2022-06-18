using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
namespace GUI
{
    public partial class ChangePassword : Form
    {
        Account account;
        public ChangePassword(Account acc)
        {
            InitializeComponent();
            account = acc;
        }
        
        private void btnUpdatePw_Click(object sender, EventArgs e)
        {
            string curPw= HashCode.Instance.hashCode(txtCurrentw.Text);
            if (AccountBLL.Instance.perfectPassword(txtNewPw.Text))
            {
                if (txtNewPw.Text == txtConfirmNewPw.Text)
                {
                    if (curPw == account.PW)
                    {
                        account.PW = HashCode.Instance.hashCode(txtNewPw.Text);
                        AccountBLL.Instance.ExcuteDB(account);
                        MessageBox.Show("đồi mk rùi!");
                    }
                    else
                    {
                        MessageBox.Show("mk sai rùi!");
                    }
                }
                else
                {
                    MessageBox.Show("Nhập lại mk mới đi ko giống!");
                }
            }
            else
            {
                MessageBox.Show("Sai định dạng gòi:)))!");
            }
            
        }

        
        private void txtCurrentw_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNewPw_TextChanged(object sender, EventArgs e)
        {

            string pw = txtNewPw.Text;
            lbUpper.ForeColor = Color.FromArgb(255, 128, 128);
            lbSpecial.ForeColor = Color.FromArgb(255, 128, 128);
            lbLength.ForeColor = Color.FromArgb(255, 128, 128);
            for (int i = 0; i < pw.Length; i++)
            {
                if (pw[i] >= 'A' && pw[i] <= 'Z')
                {
                    lbUpper.ForeColor = Color.Green;
                }

                if (pw[i] >= '0' && pw[i] <= '9')
                {
                    lbSpecial.ForeColor = Color.Green;
                }

                if (pw.Length > 8)
                {
                    lbLength.ForeColor = Color.Green;
                }
            }
        }
    }
}

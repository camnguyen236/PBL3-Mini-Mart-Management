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
            if (txtNewPw.Text==txtConfirmNewPw.Text)
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

        private bool perfectPassword(string pw)
        {
            return true;
        }
        private void txtCurrentw_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNewPw_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}

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
    public partial class DetailPaymentBill : Form
    {
        public DetailPaymentBill()
        {
            InitializeComponent();
        }

        private void DetailPaymentBill_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}

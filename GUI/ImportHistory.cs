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

namespace GUI
{
    public partial class ImportHistory : Form
    {
        public ImportHistory()
        {
            InitializeComponent();
            dtgvHistoryIP1.DataSource = ImportProductsBLL.Instance.getAllImport_Product();
        }
        int ID_IP;
        private void dtgvHistoryIP1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dtgvHistoryIP1.CurrentRow.Index;
            ID_IP = Convert.ToInt32(dtgvHistoryIP1.Rows[i].Cells[0].Value.ToString());
            dtgvHistoryIP2.DataSource = ImportProductsBLL.Instance.getDetailsImportProduct(ID_IP);
        }

        private void txtSearchDateImport_TextChanged(object sender, EventArgs e)
        {
            dtgvHistoryIP1.DataSource = ImportProductsBLL.Instance.getBillImportProductByDate(txtSearchDateImport.Text);
        }

        private void ImportHistory_Load(object sender, EventArgs e)
        {

        }
    }
}

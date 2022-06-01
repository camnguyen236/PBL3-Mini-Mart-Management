using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace GUI
{
    public partial class ImportProductsBill : Form
    {
        public ImportProductsBill()
        {
            InitializeComponent();
        }

        private void ImportProductsBill_Load(object sender, EventArgs e)
        {

            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "GUI.ImportProductsBill.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "ImportProductsBill";
                reportDataSource.Value = DetailImportProductBLL.Instance.getDetailImportProductByID(Convert.ToInt32(DetailImportProductBLL.Instance.getID_IP()));
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

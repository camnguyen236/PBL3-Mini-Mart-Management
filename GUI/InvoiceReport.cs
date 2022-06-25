using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using BLL;

namespace GUI
{
    public partial class InvoiceReport : Form
    {
        //private int ID_Invoice;
        public InvoiceReport()
        {
            InitializeComponent();
           // ID_Invoice = i;
        }

        private void InvoiceReport_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "GUI.Invoice.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "InvoiceDS";
                reportDataSource.Value = InvoiceDetail_BLL.Instance.getInvoiceDetailByID(Convert.ToInt32(InvoiceDetail_BLL.Instance.getID_Invoice())); //InvoiceDetail_BLL.Instance.getID_Invoice()
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

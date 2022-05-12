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
    public partial class DetailPaymentBill : Form
    {
        public DetailPaymentBill()
        {
            InitializeComponent();
        }

        private void DetailPaymentBill_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.LocalReport.ReportEmbeddedResource = "GUI.DetailPaymentBill.rdlc";
                ReportDataSource reportDataSource = new ReportDataSource();
                reportDataSource.Name = "DataSet1";
                reportDataSource.Value = TableImportSqlBLL.Instance.getTableImportByID(Convert.ToInt32(TableImportSqlBLL.Instance.getID_IP()));
                reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.RefreshReport();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

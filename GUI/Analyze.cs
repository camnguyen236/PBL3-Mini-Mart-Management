using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class Analyze : Form
    {
        public Analyze()
        {
            InitializeComponent();
        }

        private void btnShow_Sales_A_Click(object sender, EventArgs e)
        {
            showSalesReport();
        }
        public void showSalesReport()
        {
            if (rbDaily_Sales.Checked || rbAnnual_Sales.Checked || rbQuarterly_Sales.Checked)
            {
                if (rbDaily_Sales.Checked)
                {
                    dvgSales_A.DataSource = Report_BLL.Instance.GetSalesReportByDate(dtpDaily_Sales_A.Value);
                    lbTotalRevenue.Text = totalRevenue(Report_BLL.Instance.GetSalesReportByDate(dtpDaily_Sales_A.Value)).ToString()+" VND";
                }
                if (rbAnnual_Sales.Checked)
                {
                    dvgSales_A.DataSource = Report_BLL.Instance.GetSalesReportByYear(dtpSales_Year_A.Value);
                    lbTotalRevenue.Text = totalRevenue(Report_BLL.Instance.GetSalesReportByYear(dtpSales_Year_A.Value)).ToString()+" VND";

                }
                if (rbQuarterly_Sales.Checked)
                {

                }
            }
            else
            {
                MessageBox.Show("Chọn cách thống kê", "",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            


        }
        public int totalRevenue(DataTable dt)
        {
            int s = 0;
            int n = 0;
            foreach (DataRow i in dt.Rows)
            {
                s += Convert.ToInt32(dt.Rows[n]["Amount"]);
                n++;
            }
            return s;
        }

        private void dtpShow_Import_A_Click(object sender, EventArgs e)
        {
            showImportReport();
        }
        public void showImportReport()
        {
            if (rbDaily_Import_A.Checked || rbAnnual_Import_A.Checked || rbQuarterly_Sales.Checked)
            {
                if (rbDaily_Import_A.Checked)
                {
                    dvgImport_A.DataSource = Report_BLL.Instance.GetImportReportByYear(dtpDaily_Import_A.Value);
                    lbTotalCost_Import_A.Text = totalCost(Report_BLL.Instance.GetImportReportByYear(dtpDaily_Import_A.Value)).ToString() + " VND";
                }
                if (rbAnnual_Import_A.Checked)
                {
                    dvgImport_A.DataSource = Report_BLL.Instance.GetImportReportByYear(dtpAnnualy_Import_A.Value);
                    lbTotalCost_Import_A.Text = totalCost(Report_BLL.Instance.GetImportReportByYear(dtpAnnualy_Import_A.Value)).ToString() + " VND";
                    
                }
                if (rbQuarterly_Sales.Checked)
                {

                }
            }
            else
            {
                MessageBox.Show("Chọn cách thống kê", "",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        public int totalCost(DataTable dt)
        {
            int s = 0;
            int n = 0;
            foreach (DataRow i in dt.Rows)
            {
                s += Convert.ToInt32(dt.Rows[n]["Total"]);
                n++;
            }
            return s;
        }
    }
}

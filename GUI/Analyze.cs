using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
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
            GetProductsBestSale();
        }
        public void GetProductsBestSale()
        {
            DataTable dt = Report_BLL.Instance.GetProductsBestSale(dtpSales_Year_A.Value, dtpSales_Year_A.Value);
            //Get the names of Cities.
            string[] x = (from p in dt.AsEnumerable()
                          orderby p.Field<string>("Name_P") ascending
                          select p.Field<string>("Name_P")).ToArray();

            //Get the Total of Orders for each City.
            int[] y = (from p in dt.AsEnumerable()
                       orderby p.Field<string>("Name_P") ascending
                       select p.Field<int>("Quantity")).ToArray();
            chart3.Series[0].Points.DataBindXY(x, y);
        }
        public void showSalesReport()
        {
            if (rbDaily_Sales.Checked || rbAnnual_Sales.Checked || rbCustom_Sales.Checked)
            {
                if (rbDaily_Sales.Checked)
                {
                    MessageBox.Show("Daily");
                    dvgSales_A.DataSource = Report_BLL.Instance.GetSalesReportByDate(dtpDaily_Sales_A.Value, dtpDaily_Sales_A.Value);
                    lbTotalRevenue.Text = totalRevenue(Report_BLL.Instance.GetSalesReportByDate(dtpDaily_Sales_A.Value, dtpDaily_Sales_A.Value)).ToString()+" VND";
                }
                if (rbAnnual_Sales.Checked)
                {
                    MessageBox.Show("Annual");
                    dvgSales_A.DataSource = Report_BLL.Instance.GetSalesReportByYear(dtpSales_Year_A.Value, dtpSales_Year_A.Value);
                    lbTotalRevenue.Text = totalRevenue(Report_BLL.Instance.GetSalesReportByYear(dtpSales_Year_A.Value, dtpSales_Year_A.Value)).ToString()+" VND";

                }
                if (rbCustom_Sales.Checked)
                {
                    dvgSales_A.DataSource = Report_BLL.Instance.GetSalesReportByDate(dtpCustomA_Sales_A.Value, dtpCustomB_Sales_A.Value);
                    lbTotalRevenue.Text = totalRevenue(Report_BLL.Instance.GetSalesReportByDate(dtpCustomA_Sales_A.Value, dtpCustomB_Sales_A.Value)).ToString() + " VND";
                }
            }
            else
            {
                MessageBox.Show("Chọn cách thống kê", "",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void GrafCategories()
        {

        }
        public int totalRevenue(DataTable dt)
        {
            int s = 0;
            int n = 0;
            int numberOfRecords = dt.Rows.Count;
            MessageBox.Show(numberOfRecords.ToString());
            foreach (DataRow i in dt.Rows)
            {
                if (numberOfRecords!=0)
                {
                    s += Convert.ToInt32(dt.Rows[n]["Amount"]);
                    n++;
                }
            }
            return s;
        }

        private void dtpShow_Import_A_Click(object sender, EventArgs e)
        {
            showImportReport();
        }
        public void showImportReport()
        {
            if (rbDaily_Import_A.Checked || rbAnnual_Import_A.Checked || rbCustom_Import_A.Checked)
            {
                if (rbDaily_Import_A.Checked)
                {
                    dvgImport_A.DataSource = Report_BLL.Instance.GetImportReportByDate(dtpDaily_Import_A.Value, dtpDaily_Import_A.Value);
                    lbTotalCost_Import_A.Text = totalCost(Report_BLL.Instance.GetImportReportByDate(dtpDaily_Import_A.Value, dtpDaily_Import_A.Value)).ToString() + " VND";
                }
                if (rbAnnual_Import_A.Checked)
                {
                    dvgImport_A.DataSource = Report_BLL.Instance.GetImportReportByYear(dtpAnnualy_Import_A.Value, dtpAnnualy_Import_A.Value);
                    lbTotalCost_Import_A.Text = totalCost(Report_BLL.Instance.GetImportReportByYear(dtpAnnualy_Import_A.Value, dtpAnnualy_Import_A.Value)).ToString() + " VND";
                    
                }
                if (rbCustom_Import_A.Checked)
                {
                    dvgImport_A.DataSource = Report_BLL.Instance.GetImportReportByDate(dtpCustomA_Sales_A.Value, dtpCustomB_Sales_A.Value);
                    lbTotalCost_Import_A.Text = totalCost(Report_BLL.Instance.GetImportReportByDate(dtpCustomA_Sales_A.Value, dtpCustomB_Sales_A.Value)).ToString() + " VND";
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

        private void guna2PictureBox2_Click(object sender, EventArgs e)
        {

        }

        //profit
        private void btnShow_Profit_A_Click(object sender, EventArgs e)
        {
            showProfitReport();
        }

        public void showProfitReport()
        {



                    //dvgImport_Profit_A.DataSource = Report_BLL.Instance.GetImportReportByYear(dtpAnnualy_Profit_A.Value);
                    lbTotalCost_Profit_A.Text = totalCost(Report_BLL.Instance.GetImportReportByYear(dtpAnnualy_Profit_A.Value, dtpAnnualy_Profit_A.Value)).ToString() + " VND";


                    //dvgSales_Profit_A.DataSource = Report_BLL.Instance.GetSalesReportByYear(dtpAnnualy_Profit_A.Value);
                    lbRevenue_Profit_A.Text = totalRevenue(Report_BLL.Instance.GetSalesReportByYear(dtpAnnualy_Profit_A.Value, dtpAnnualy_Profit_A.Value)).ToString() + " VND";

                    lbProfit_A.Text = (totalRevenue(Report_BLL.Instance.GetSalesReportByYear(dtpAnnualy_Profit_A.Value, dtpAnnualy_Profit_A.Value))-totalCost(Report_BLL.Instance.GetImportReportByYear(dtpAnnualy_Profit_A.Value, dtpAnnualy_Profit_A.Value))).ToString()+"VND";

        }

        private void dvgImport_Profit_A_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLast30Days_Click(object sender, EventArgs e)
        {

        }
    }
}

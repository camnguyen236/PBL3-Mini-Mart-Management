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
using System.Windows.Forms.DataVisualization.Charting;

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
        public void GetProductsBestSale(DataTable dt)
        {
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
                    GetProductsBestSale(Report_BLL.Instance.GetProductsBestSaleDate(dtpDaily_Sales_A.Value, dtpDaily_Sales_A.Value));
                    dvgSales_A.DataSource = Report_BLL.Instance.GetSalesReportByDate(dtpDaily_Sales_A.Value, dtpDaily_Sales_A.Value);
                    lbTotalRevenue.Text = totalRevenue(Report_BLL.Instance.GetSalesReportByDate(dtpDaily_Sales_A.Value, dtpDaily_Sales_A.Value)).ToString()+" VND";
                }
                if (rbAnnual_Sales.Checked)
                {
                    MessageBox.Show("Annual");
                    GetProductsBestSale(Report_BLL.Instance.GetProductsBestSaleYear(dtpSales_Year_A.Value, dtpSales_Year_A.Value));
                    dvgSales_A.DataSource = Report_BLL.Instance.GetSalesReportByYear(dtpSales_Year_A.Value, dtpSales_Year_A.Value);
                    lbTotalRevenue.Text = totalRevenue(Report_BLL.Instance.GetSalesReportByYear(dtpSales_Year_A.Value, dtpSales_Year_A.Value)).ToString()+" VND";
                }
                if (rbCustom_Sales.Checked)
                {
                    GetProductsBestSale(Report_BLL.Instance.GetProductsBestSaleDate(dtpCustomA_Sales_A.Value, dtpCustomB_Sales_A.Value));
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

        //profit/////////////////////////////////////////////////////
        public void GUI_Profit()
        {
            btnProfit_Custom.BackColor = Color.FromArgb(50, 100, 115);
        }
        private void btnShow_Profit_A_Click(object sender, EventArgs e)
        {
            showProfitReport();
        }

        public void showProfitReport()
        {



                    //dvgImport_Profit_A.DataSource = Report_BLL.Instance.GetImportReportByYear(dtpAnnualy_Profit_A.Value);
                    lbTotalCost_Profit_A.Text = totalCost(Report_BLL.Instance.GetImportReportByYear(dtp_Profit_Date_A.Value, dtp_Profit_Date_B.Value)).ToString() + " VND";


                    //dvgSales_Profit_A.DataSource = Report_BLL.Instance.GetSalesReportByYear(dtpAnnualy_Profit_A.Value);
                    lbRevenue_Profit_A.Text = totalRevenue(Report_BLL.Instance.GetSalesReportByYear(dtp_Profit_Date_A.Value, dtp_Profit_Date_B.Value)).ToString() + " VND";

                    lbProfit_A.Text = (totalRevenue(Report_BLL.Instance.GetSalesReportByYear(dtp_Profit_Date_A.Value, dtp_Profit_Date_B.Value))-totalCost(Report_BLL.Instance.GetImportReportByYear(dtp_Profit_Date_A.Value, dtp_Profit_Date_B.Value))).ToString()+"VND";

        }

        private void btnProfit_Year_Click(object sender, EventArgs e)
        {
            lbDate.Text = "Choose Year:";

            dtp_Profit_Date_A.Enabled = true;
            dtp_Profit_Date_B.Enabled = true;
            dtp_Profit_Date_A.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtp_Profit_Date_B.Value = new DateTime(DateTime.Now.Year, 12, 31);
            dtp_Profit_Date_B.Hide();
      
            dtp_Profit_Date_A.CustomFormat = "yyyy";
            dtp_Profit_Date_A.ShowUpDown = true;

            dtp_Profit_Date_A.Enabled = false;

            lbTo.Hide();

            btnProfit_Day.FillColor = Color.FromArgb(203, 228, 236);
            btnProfit_Week.FillColor = Color.FromArgb(203, 228, 236);
            btnProfit_Month.FillColor = Color.FromArgb(203, 228, 236);
            btnProfit_Year.FillColor = Color.FromArgb(50, 100, 115);
            btnProfit_Custom.FillColor = Color.FromArgb(203, 228, 236);

            btnProfit_Day.BorderThickness = 0;
            btnProfit_Week.BorderThickness = 0;
            btnProfit_Month.BorderThickness = 0;
            btnProfit_Year.BorderThickness = 1;
            btnProfit_Custom.BorderThickness = 0;
            btnProfit_Year.BringToFront();

            dtp_Profit_Date_A.Enabled = true;
            dtp_Profit_Date_A.CustomFormat = "";
            ShowRevenue();
            ShowCost();
            dtp_Profit_Date_A.CustomFormat = "yyyy";
            dtp_Profit_Date_A.Enabled = false;
        }

        private void btnProfit_Day_Click(object sender, EventArgs e)
        {

            lbDate.Text = "This Day: ";

            dtp_Profit_Date_A.Enabled = true;
            dtp_Profit_Date_B.Hide();

            dtp_Profit_Date_A.CustomFormat = "";
            dtp_Profit_Date_A.ShowUpDown = false;

            dtp_Profit_Date_A.Value = DateTime.Now;

            dtp_Profit_Date_A.Enabled = false;
            lbTo.Hide();

            btnProfit_Day.FillColor = Color.FromArgb(50, 100, 115);
            btnProfit_Week.FillColor = Color.FromArgb(203, 228, 236);
            btnProfit_Month.FillColor = Color.FromArgb(203, 228, 236);
            btnProfit_Year.FillColor = Color.FromArgb(203, 228, 236);
            btnProfit_Custom.FillColor = Color.FromArgb(203, 228, 236);

            btnProfit_Day.BorderThickness = 1;
            btnProfit_Week.BorderThickness = 0;
            btnProfit_Month.BorderThickness = 0;
            btnProfit_Year.BorderThickness = 0;
            btnProfit_Custom.BorderThickness = 0;

            btnProfit_Day.BringToFront();

            ShowRevenue();
            ShowCost();
        }

        private void btnProfit_Week_Click(object sender, EventArgs e)
        {
            lbDate.Text = "7Days: ";

            dtp_Profit_Date_A.Enabled = true;
            dtp_Profit_Date_B.Enabled = true;
           
            dtp_Profit_Date_A.CustomFormat = "";
            dtp_Profit_Date_A.ShowUpDown = false;
            dtp_Profit_Date_B.Show();
            dtp_Profit_Date_B.CustomFormat = "";

            dtp_Profit_Date_A.Value = DateTime.Today.AddDays(-7);
            dtp_Profit_Date_B.Value = DateTime.Now;

            dtp_Profit_Date_A.Enabled = false;
            dtp_Profit_Date_B.Enabled = false;

            lbTo.Show();
            
            btnProfit_Day.FillColor = Color.FromArgb(203, 228, 236);
            btnProfit_Week.FillColor = Color.FromArgb(50, 100, 115);
            btnProfit_Month.FillColor = Color.FromArgb(203, 228, 236);
            btnProfit_Year.FillColor = Color.FromArgb(203, 228, 236);
            btnProfit_Custom.FillColor = Color.FromArgb(203, 228, 236);

            btnProfit_Day.BorderThickness = 0;
            btnProfit_Week.BorderThickness = 1;
            btnProfit_Month.BorderThickness = 0;
            btnProfit_Year.BorderThickness = 0;
            btnProfit_Custom.BorderThickness = 0;
            btnProfit_Week.BringToFront();

            ShowRevenue();
            ShowCost();
        }

        private void btnProfit_Month_Click(object sender, EventArgs e)
        {
            lbDate.Text = "30Days ";

            dtp_Profit_Date_A.Enabled = true;
            dtp_Profit_Date_B.Enabled = true;

            dtp_Profit_Date_A.CustomFormat = "";
            dtp_Profit_Date_A.ShowUpDown = false;
            dtp_Profit_Date_B.Show();
            dtp_Profit_Date_B.CustomFormat = "";

            dtp_Profit_Date_A.Value = DateTime.Today.AddDays(-30);
            dtp_Profit_Date_B.Value = DateTime.Now;

            dtp_Profit_Date_A.Enabled = false;
            dtp_Profit_Date_B.Enabled = false;

            lbTo.Show();

            btnProfit_Day.FillColor = Color.FromArgb(203, 228, 236);
            btnProfit_Week.FillColor = Color.FromArgb(203, 228, 236);
            btnProfit_Month.FillColor = Color.FromArgb(50, 100, 115);
            btnProfit_Year.FillColor = Color.FromArgb(203, 228, 236);
            btnProfit_Custom.FillColor = Color.FromArgb(203, 228, 236);

            btnProfit_Day.BorderThickness = 0;
            btnProfit_Week.BorderThickness = 0;
            btnProfit_Month.BorderThickness = 1;
            btnProfit_Year.BorderThickness = 0;
            btnProfit_Custom.BorderThickness = 0;
            btnProfit_Month.BringToFront();

            ShowRevenue();
            ShowCost();
        }

        private void btnProfit_Custom_Click(object sender, EventArgs e)
        {

        }

        private void ShowRevenue()
        {
            DataTable dt = Report_BLL.Instance.GetRevenueByDate(dtp_Profit_Date_A.Value, dtp_Profit_Date_B.Value);
            dgv_Profit_Revenue.DataSource = dt;
            SetRevenueChart(dt);
        }


        public void SetRevenueChart(DataTable dt)
        {

           
        }

        private void ShowCost()
        {
            MessageBox.Show(dtp_Profit_Date_A.Value.ToString("yyy-MM-dd") + "  " + dtp_Profit_Date_B.Value.ToString("yyy-MM-dd"));
            DataTable dt = Report_BLL.Instance.GetCostByDate(dtp_Profit_Date_A.Value, dtp_Profit_Date_B.Value);
            dgv_Profit_Cost.DataSource = dt;
          
        }




        private void guna2TabControl1_Click(object sender, EventArgs e)
        {

        }
    }
}

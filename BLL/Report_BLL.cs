using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using DAL;
namespace BLL
{
    public class Report_BLL
    {
        private static Report_BLL _Instance;
        public static Report_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Report_BLL();
                }
                return _Instance;
            }
            private set { } 
        }
        private Report_BLL() { }
        public DataTable getCustomer()
        {
            return Customer_DAL.Instance.GetRecords();
            //return accounts;
        }

        public DataTable GetSalesReportByYear(DateTime date1, DateTime date2)
        {
            return Report_DAL.Instance.GetSalesReportByYear(date1, date2);
        }

        public DataTable GetSalesReportByDate(DateTime date1, DateTime date2)
        {
            return Report_DAL.Instance.GetSalesReportByDate(date1, date2);
        }

        //import
        public DataTable GetImportReportByYear(DateTime date1, DateTime date2)
        {
            return Report_DAL.Instance.GetImportReportByYear(date1, date2);
        }

        public DataTable GetImportReportByDate(DateTime date1, DateTime date2)
        {
            return Report_DAL.Instance.GetImportReportByDate(date1, date2);
        }

        //best sale
        public DataTable GetProductsBestSaleDate(DateTime date1, DateTime date2)
        {
            return Report_DAL.Instance.GetProductsBestSaleDate(date1, date2);
        }
        public DataTable GetProductsBestSaleYear(DateTime date1, DateTime date2)
        {
            return Report_DAL.Instance.GetProductsBestSaleYear(date1, date2);
        }

        //Profit
        public DataTable GetRevenueByDate(DateTime date1, DateTime date2)
        {
            return Report_DAL.Instance.GetRevenueByDate(date1,date2);
        }
        public DataTable GetCostByDate(DateTime date1, DateTime date2)
        {
            return Report_DAL.Instance.GetCostByDate(date1, date2);
        }
    }
}

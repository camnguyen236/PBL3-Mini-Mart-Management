﻿using System;
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

        //
        public DataTable GetInventoryByGroupID(int ID)
        {
            return Report_DAL.Instance.GetInventoryByGroupID(ID);
        }
        public int getQuantityImport(string id)
        {
            int quantity = 0;
            foreach(var i in DetailImportProductBLL.Instance.getDetailImportProductsByID_P(id))
            {
                quantity += i.Amount_IP;
            }
            return quantity;
        }
        public int getQuantitySell(string id)
        {
            int quantity = 0;
            foreach (var i in InvoiceDetail_BLL.Instance.getInvoiceDetailByID_P(id))
            {
                quantity += i.Quantity;
            }
            return quantity;
        }
        public int getInventoryByID_P(string id)
        {
            //return getQuantityImport(id) - getQuantitySell(id);
            try
            {
                return Convert.ToInt32(Report_DAL.Instance.GetInventoryByID(Convert.ToInt32(id)).Rows[0][0]);

            }
            catch (Exception)
            {

                return 0;
            }
        }
    }
}

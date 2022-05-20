using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
namespace DAL
{
    public class Report_DAL
    {
        private static Report_DAL _Instance;
        public static Report_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Report_DAL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private Report_DAL() { }
        DataTable report = new DataTable();

        public DataTable GetSalesReportByYear(DateTime date)
        {
            string query = "select Products.Name_P, Products.Unit_P,  InvoiceDetail.Quantity, InvoiceDetail.Unit_Price, InvoiceDetail.Amount from(( Invoice " +
                "inner join InvoiceDetail " +
                $"on Invoice.ID_Invoice = InvoiceDetail.ID_Invoice and year(Invoice.Invoice_Date) = '{date.Year}')" +
                "inner join Products " +
                "on InvoiceDetail.ID_P = Products.ID_P)";
                report = DataProvider.Instance.GetRecords(query);
            return report;
        }

        public DataTable GetSalesReportByDate(DateTime date)
        {
            string query = "select Products.Name_P, Products.Unit_P,  InvoiceDetail.Quantity, InvoiceDetail.Unit_Price, InvoiceDetail.Amount from(( Invoice " +
                "inner join InvoiceDetail " +
                $"on Invoice.ID_Invoice = InvoiceDetail.ID_Invoice and Invoice.Invoice_Date = '{date.ToString("yyyy-MM-dd")}')" +
                "inner join Products " +
                "on InvoiceDetail.ID_P = Products.ID_P)";
            report = DataProvider.Instance.GetRecords(query);
            return report;
        }

        //import
        public DataTable GetImportReportByYear(DateTime date)
        {
            string query = "select Products.Name_P, Products.Unit_P,  DetailImportProduct.Amount_IP, DetailImportProduct.Amount_Price, DetailImportProduct.Total from(( ImportProduct" +
                " inner join DetailImportProduct" +
                $" on ImportProduct.ID_IP= ImportProduct.ID_IP and year(ImportProduct.Date_Import)='{date.Year}') " +
                "inner join Products on DetailImportProduct.ID_P=Products.ID_P)";
            report = DataProvider.Instance.GetRecords(query);
            return report;
        }

        public DataTable GetImportReportByDate(DateTime date)
        {
            string query = "select Products.Name_P, Products.Unit_P,  DetailImportProduct.Amount_IP, DetailImportProduct.Amount_Price, DetailImportProduct.Total from(( ImportProduct" +
                " inner join DetailImportProduct" +
                $" on ImportProduct.ID_IP= ImportProduct.ID_IP and ImportProduct.Date_Import='{date.ToString("yyyy-MM-dd")}') " +
                "inner join Products on DetailImportProduct.ID_P=Products.ID_P)";
            report = DataProvider.Instance.GetRecords(query);
            return report;
        }
    }
}

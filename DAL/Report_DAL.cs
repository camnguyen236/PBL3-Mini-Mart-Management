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

        public DataTable GetSalesReportByYear(DateTime date1, DateTime date2)
        {
            
            string query = "select Products.Name_P as \"Name Product\", Products.Unit_P as Unit,InvoiceDetail.Unit_Price as Price,  sum(InvoiceDetail.Quantity) as Quantity,  sum(InvoiceDetail.Amount) as Amount " +
                "from((InvoiceDetail " +
                $"inner join(select * from Invoice where year(Invoice.Invoice_Date) BETWEEN '{date1.Year}' and '{date2.Year}') as Invoice " +
                "on InvoiceDetail.ID_Invoice = Invoice.ID_Invoice) " +
                "left join Products " +
                "on Products.ID_P = InvoiceDetail.ID_P) " +
                "group by Products.Name_P , Products.Unit_P, InvoiceDetail.Unit_Price";
            report = DataProvider.Instance.GetRecords(query);
            return report;
        }

        public DataTable GetSalesReportByDate(DateTime date1, DateTime date2)
        {

            
            string query = "select Products.Name_P as \"Name Product\", Products.Unit_P as Unit,InvoiceDetail.Unit_Price as Price,  sum(InvoiceDetail.Quantity) as Quantity,  sum(InvoiceDetail.Amount) as Amount " +
                "from((InvoiceDetail " +
                $"inner join(select * from Invoice where Invoice.Invoice_Date between '{date1.ToString("yyyy - MM - dd")}' and '{date2.ToString("yyyy - MM - dd")}') as Invoice " +
                "on InvoiceDetail.ID_Invoice = Invoice.ID_Invoice) " +
                "left join Products " +
                "on Products.ID_P = InvoiceDetail.ID_P) " +
                "group by Products.Name_P , Products.Unit_P, InvoiceDetail.Unit_Price";
            report = DataProvider.Instance.GetRecords(query);
            return report;
        }

        //bestsale
        public DataTable GetProductsBestSaleDate(DateTime date1, DateTime date2)
        {

            string query = "select top(5) Products.Name_P, sum(InvoiceDetail.Quantity) as Quantity " +
                "from((InvoiceDetail " +
                $"inner join(select * from Invoice where Invoice.Invoice_Date BETWEEN '{date1.ToString("yyyy - MM - dd")}' and '{date2.ToString("yyyy - MM - dd")}') as Invoice " +
                "on InvoiceDetail.ID_Invoice = Invoice.ID_Invoice) " +
                "left join Products " +
                "on Products.ID_P = InvoiceDetail.ID_P) " +
                "group by Products.Name_P " +
                "order by sum(InvoiceDetail.Quantity) desc";
            report = DataProvider.Instance.GetRecords(query);
            return report;
        }
        public DataTable GetProductsBestSaleYear(DateTime date1, DateTime date2)
        {

            string query = "select top(5) Products.Name_P, sum(InvoiceDetail.Quantity) as Quantity " +
                "from((InvoiceDetail " +
                $"inner join(select * from Invoice where year(Invoice.Invoice_Date) BETWEEN '{date1.Year}' and '{date2.Year}') as Invoice " +
                "on InvoiceDetail.ID_Invoice = Invoice.ID_Invoice) " +
                "left join Products " +
                "on Products.ID_P = InvoiceDetail.ID_P) " +
                "group by Products.Name_P " +
                "order by sum(InvoiceDetail.Quantity) desc";
            report = DataProvider.Instance.GetRecords(query);
            return report;
        }


        //import
        public DataTable GetImportReportByYear(DateTime date1, DateTime date2)
        {
            
            string query = "select Products.Name_P, Products.Unit_P, sum(DetailImportProduct.Amount_IP) as Quantity, DetailImportProduct.IP_Price as Price, sum(DetailImportProduct.Total) as Total " +
                 "from((DetailImportProduct " +
                 $"inner join(select * from ImportProduct where Year(ImportProduct.Date_Import) between'{date1.Year}'and '{date2.Year}') as ImportProduct " +
                 "on DetailImportProduct.ID_IP = ImportProduct.ID_IP) " +
                 "left join Products " +
                 "on Products.ID_P = DetailImportProduct.ID_P) " +
                 "group by Products.Name_P , Products.Unit_P, DetailImportProduct.IP_Price";

            report = DataProvider.Instance.GetRecords(query);
            return report;
        }

        public DataTable GetImportReportByDate(DateTime date1, DateTime date2)
        {
            
            string query = "select Products.Name_P, Products.Unit_P, sum(DetailImportProduct.Amount_IP) as Quantity, DetailImportProduct.IP_Price as Price, sum(DetailImportProduct.Total) as Total " +
                 "from((DetailImportProduct " +
                 $"inner join(select * from ImportProduct where ImportProduct.Date_Import between '{date1.ToString("yyyy - MM - dd")}' and '{date2.ToString("yyyy - MM - dd")}') as ImportProduct " +
                 "on DetailImportProduct.ID_IP = ImportProduct.ID_IP) " +
                 "left join Products " +
                 "on Products.ID_P = DetailImportProduct.ID_P) " +
                 "group by Products.Name_P , Products.Unit_P, DetailImportProduct.IP_Price";
            report = DataProvider.Instance.GetRecords(query);
            return report;
        }


        //PROFIT//////////////////
        public DataTable GetRevenueByDate(DateTime date1, DateTime date2)
        {

            string query = "select ImportProduct.Date_Import as Date, sum(DetailImportProduct.Total) as Revenue " +
                $"from (select * from ImportProduct where Date_Import between '{date1.ToString("yyyy - MM - dd")}' and '{date2.ToString("yyyy - MM - dd")}') as ImportProduct " +
                "left join DetailImportProduct on ImportProduct.ID_IP = DetailImportProduct.ID_IP " +
                "group by ImportProduct.Date_Import";
            report = DataProvider.Instance.GetRecords(query);
            return report;
        }
        public DataTable GetCostByDate(DateTime date1, DateTime date2)
        {

            string query = "select Invoice.Invoice_Date as Date, sum(InvoiceDetail.Amount) as Cost " +
                $"from (select * from Invoice where Invoice_Date between '{date1.ToString("yyyy - MM - dd")}' and '{date2.ToString("yyyy - MM - dd")}') as Invoice " +
                "left join InvoiceDetail " +
                "on Invoice.ID_Invoice = InvoiceDetail.ID_Invoice " +
                "group by Invoice.Invoice_Date";
            report = DataProvider.Instance.GetRecords(query);
            return report;
        }
    }
}

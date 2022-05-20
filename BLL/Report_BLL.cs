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
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private Report_BLL() { }
        public DataTable getCustomer()
        {
            return Customer_DAL.Instance.GetRecords();
            //return accounts;
        }

        public DataTable GetSalesReportByYear(DateTime date)
        {
            return Report_DAL.Instance.GetSalesReportByYear(date);
        }

        public DataTable GetSalesReportByDate(DateTime date)
        {
            return Report_DAL.Instance.GetSalesReportByDate(date);
        }

        //import
        public DataTable GetImportReportByYear(DateTime date)
        {
            return Report_DAL.Instance.GetImportReportByYear(date);
        }

        public DataTable GetImportReportByDate(DateTime date)
        {
            return Report_DAL.Instance.GetImportReportByDate(date);
        }
    }
}

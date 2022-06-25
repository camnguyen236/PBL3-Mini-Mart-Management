using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class Invoice_DAL
    {
        private static Invoice_DAL _Instance;
        public static Invoice_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Invoice_DAL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private Invoice_DAL() { }
        DataTable invoice = new DataTable();
        public DataTable GetRecords()
        {
            string query = "select * from Invoice";
            invoice = DataProvider.Instance.GetRecords(query);
            return invoice;
        }
        public DataTable GetRecordsView()
        {
            string query = "select ID_Invoice, Name_staff, Name_Customer, Invoice_Date " +
                "from Invoice";// inner join Inf_user on Invoice.ID = Inf_user.ID inner join Customer " +
            //"on Customer.ID_Customer = Invoice.ID_Customer
            invoice = DataProvider.Instance.GetRecords(query);
            return invoice;
        }
        public List<Invoice> GetAllInvoice()
        {
            List<Invoice> list = new List<Invoice>();
            foreach (DataRow i in DataProvider.Instance.GetRecords("select * from Invoice").Rows)
            {
                list.Add(GetInvoiceByDataRow(i));
            }
            return list;
        }
        public Invoice GetInvoiceByDataRow(DataRow i)
        {
            return new Invoice
            {
                ID_Invoice = Convert.ToInt32(i["ID_Invoice"].ToString()),
                ID = Convert.ToInt32(i["ID"].ToString()),
                ID_Customer = Convert.ToInt32(i["ID_Customer"].ToString()),
                Invoice_Date = Convert.ToDateTime(i["Invoice_Date"].ToString()),
                Name_staff = i["Name_staff"].ToString(),
                Name_Customer = i["Name_Customer"].ToString()
            };
        }
        public void addInvoice(Invoice invoice)
        {
            string query = "insert into Invoice " + "values ('" + invoice.ID + "','"
                + invoice.ID_Customer + "','" + invoice.Invoice_Date + "',N'" + invoice.Name_staff +
                "',N'" + invoice.Name_Customer + "')";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updateInvoice(Invoice invoice)
        {
            string query = "update Invoice set ID = N'" + invoice.ID + "', ID_Customer = N'"
                + invoice.ID_Customer + "', Invoice_Date = '" + invoice.Invoice_Date 
                + "', Name_staff = '" + invoice.Name_staff + "', Name_Customer = '"
                + invoice.Name_Customer + "' where ID_Invoice = '" + invoice.ID_Invoice + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void deleteInvoice(int id_invoice)
        {
            DataProvider.Instance.ExcuteDB("delete from Invoice where ID_Invoice = '" + id_invoice + "'");
        }
    }
}

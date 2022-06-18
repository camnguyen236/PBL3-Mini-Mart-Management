using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class InvoiceDetail_DAL
    {
        private static InvoiceDetail_DAL _Instance;
        public static InvoiceDetail_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new InvoiceDetail_DAL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private InvoiceDetail_DAL() { }
        DataTable invoiceDetail = new DataTable();
        public DataTable GetRecords()
        {
            string query = "select * from InvoiceDetail";
            invoiceDetail = DataProvider.Instance.GetRecords(query);
            return invoiceDetail;
        }
        public DataTable GetRecordsView(int id)
        {
            string query = "select Products.Name_P,ProductGroups.Name_PG,Products.Unit_P, Unit_Price, Quantity, Amount from InvoiceDetail inner join Products on InvoiceDetail.ID_P = Products.ID_P inner join ProductGroups on Products.ID_PG = ProductGroups.ID_PG where ID_Invoice = " + id;
            invoiceDetail = DataProvider.Instance.GetRecords(query);
            return invoiceDetail;
        }
        public List<InvoiceDetail> GetAllInvoiceDetail()
        {
            List<InvoiceDetail> list = new List<InvoiceDetail>();
            foreach (DataRow i in DataProvider.Instance.GetRecords("select * from InvoiceDetail").Rows)
            {
                list.Add(GetInvoiceDetailByDataRow(i));
            }
            return list;
        }
        public InvoiceDetail GetInvoiceDetailByDataRow(DataRow i)
        {
            return new InvoiceDetail
            {
                ID_Invoice = Convert.ToInt32(i["ID_Invoice"].ToString()),
                ID_P = Convert.ToInt32(i["ID_P"].ToString()),
                Unit_Price = Convert.ToInt32(i["Unit_Price"].ToString()),
                Quantity = Convert.ToInt32(i["Quantity"].ToString()),
                Amount = Convert.ToInt32(i["Amount"].ToString()),
                Name_product = i["Name_product"].ToString()
            };
        }
        public void addInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            string query = "insert into InvoiceDetail " +
                    "values (N'" + invoiceDetail.ID_Invoice + "',N'" + invoiceDetail.ID_P
                    + "',N'" + invoiceDetail.Unit_Price + "','" + invoiceDetail.Quantity + "')";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updateInvoiceDetail(InvoiceDetail invoiceDetail)
        {
            string query = "update InvoiceDetail set ID_P = N'" + invoiceDetail.ID_P
                + "', Unit_Price = N'" + invoiceDetail.Unit_Price + "', Quantity = N'"
                + invoiceDetail.Quantity + "', Amount = '" + invoiceDetail.Amount
                + "' where ID_Invoice = '" + invoiceDetail.ID_Invoice + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void deleteInvoiceDetail(string id_invoiceDetail)
        {
            string query = "delete from InvoiceDetail where ID_Invoice = '" + id_invoiceDetail + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public int getTotal(int id)
        {
            int total = 0;
            foreach (InvoiceDetail i in GetAllInvoiceDetail())
            {
                if (i.ID_Invoice == id)
                {
                    total += i.Amount;
                }
            }
            return total;
        }
        public DataTable getInvoiceDetailByID(int ID_Invoice)
        {
            DataTable data = new DataTable();
            string query = "select Customer.Name_Customer, Customer.Address_Customer, Customer.PhoneNumber_Customer, Customer.AccountNumber, Inf_user.Name, Invoice.Invoice_Date, InvoiceDetail.Unit_Price, InvoiceDetail.Quantity,InvoiceDetail.ID_Invoice, InvoiceDetail.Amount, Products.Name_P from Customer LEFT OUTER JOIN Invoice ON Customer.ID_Customer = Invoice.ID_Customer LEFT OUTER JOIN Inf_user ON Invoice.ID = Inf_user.ID LEFT OUTER JOIN InvoiceDetail ON Invoice.ID_Invoice = InvoiceDetail.ID_Invoice LEFT OUTER JOIN Products ON InvoiceDetail.ID_P = Products.ID_P Where InvoiceDetail.ID_Invoice = " + ID_Invoice;
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
    }
}

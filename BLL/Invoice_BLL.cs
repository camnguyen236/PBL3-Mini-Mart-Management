using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class Invoice_BLL
    {
        private static Invoice_BLL _Instance;
        public static Invoice_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Invoice_BLL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private Invoice_BLL() { }
        public DataTable getInvoice()
        {
            return Invoice_DAL.Instance.GetRecords();
        }
        public DataTable getInvoiceView()
        {
            return Invoice_DAL.Instance.GetRecordsView();
        }
        public void ExcuteDB(Invoice invoice, string id_invoice = null) //update, delete
        {
            if (id_invoice == null)
            {
                Invoice_DAL.Instance.updateInvoice(invoice);
                return;
            }
            if (id_invoice != null && !id_invoice.Equals("Add"))
            {
                Invoice_DAL.Instance.deleteInvoice(invoice.ID_Invoice);
                return;
            }
            if (id_invoice == "Add")
            {
                Invoice_DAL.Instance.addInvoice(invoice);
                return;
            }
        }
        public List<Invoice> GetInvoices()
        {
            return Invoice_DAL.Instance.GetAllInvoice();
        }

        public List<Invoice> GetInvoiceByDate(string da)
        {
            List<Invoice> ls = new List<Invoice>();
            foreach (Invoice i in GetInvoices())
            {
                if (i.Invoice_Date.ToString().Contains(da)) ls.Add(i);
            }
            return ls;
        }
    }
}

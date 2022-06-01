using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class InvoiceDetail_BLL
    {
        private static InvoiceDetail_BLL _Instance;
        public static InvoiceDetail_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new InvoiceDetail_BLL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private InvoiceDetail_BLL() { }
        public DataTable getInvoiceDetail()
        {
            return InvoiceDetail_DAL.Instance.GetRecords();
        }
        public DataTable getInvoiceDetailView(int id)
        {
            return InvoiceDetail_DAL.Instance.GetRecordsView(id);
        }
        public void ExcuteDB(InvoiceDetail invoiceDetail, string id_invoiceDetail = null) //update, delete
        {
            if (id_invoiceDetail == null)
            {
                InvoiceDetail_DAL.Instance.updateInvoiceDetail(invoiceDetail);
                return;
            }
            if (id_invoiceDetail != null && !id_invoiceDetail.Equals("Add"))
            {
                InvoiceDetail_DAL.Instance.deleteInvoiceDetail(id_invoiceDetail);
                return;
            }
            if (id_invoiceDetail == "Add")
            {
                InvoiceDetail_DAL.Instance.addInvoiceDetail(invoiceDetail);
                return;
            }
        }
        public int getTotal(int id)
        {
            return InvoiceDetail_DAL.Instance.getTotal(id);
        }
        private string id_invoice;
        public void get(string ID_Invoice)
        {
            id_invoice = ID_Invoice;
            
        }
        public string getID_Invoice()
        {
            return id_invoice;
        }
        public DataTable getInvoiceDetailByID(int ID_Invoice)
        {
            return InvoiceDetail_DAL.Instance.getInvoiceDetailByID(ID_Invoice);
        }
    }
}

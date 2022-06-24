using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using System.Data;
using DTO;

namespace BLL
{
    public class ImportProductsBLL
    {
        private static ImportProductsBLL _Instance;
        public static ImportProductsBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ImportProductsBLL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private ImportProductsBLL() { }
        public DataTable getAllImport_Product()
        {
            return ImportProductsDAL.Instance.getAllImport_Product();
        }
        public DataTable getRecordsNewID_IP()
        {
            return ImportProductsDAL.Instance.GetRecordsNewID_IP();
        }
        public DataTable getDetailsImportProduct(int ID_IP)
        {
            return ImportProductsDAL.Instance.getDetailsImportProduct(ID_IP);
        }
        public DataTable getBillImportProductByDate(string datee)
        {
            return ImportProductsDAL.Instance.getBillImportProductByDate(datee);
        }
        public void ExcuteDB(ImportProducts importProducts,string s = null) //update, delete
        {
            if (s == null)
            {
                ImportProductsDAL.Instance.updateImportProduct(importProducts);
                return;
            }
            if (s == "Add")
            {
                ImportProductsDAL.Instance.addProducts(importProducts);
                return;
            }
        }
        public List<ImportProducts> getAllImportProducts()
        {
            return ImportProductsDAL.Instance.GetAllImportProducts();
        }
        public ImportProducts getImportProductsByID(string id)
        {
            foreach (ImportProducts i in getAllImportProducts())
            {
                if (i.ID_IP.ToString().Equals(id))
                {
                    return i;
                }
            }
            return null;
        }
    }
}

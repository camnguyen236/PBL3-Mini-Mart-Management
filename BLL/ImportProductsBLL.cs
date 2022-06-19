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
        public List<string> getAllID_IP() //max phieu nhap
        {
            return ImportProductsDAL.Instance.getAllID_IP();
        }
        public List<string> getAllName_Supplier() //nha cc
        {
            return ImportProductsDAL.Instance.getAllName_Supplier();
        }
        public List<string> getAllIP_Product() //nha cc
        {
            return ImportProductsDAL.Instance.getAllIP_Product();
        }
        public string getID_Product(string Name_P)
        {
            return ImportProductsDAL.Instance.getID_Product(Name_P);
        }
        public List<string> getAllDiscount() //nha cc
        {
            return ImportProductsDAL.Instance.getAllDiscount();
        }
        public DataTable getRecords()
        {
            return ImportProductsDAL.Instance.GetRecords();
        }
        public DataTable getAllImport_Product()
        {
            return ImportProductsDAL.Instance.getAllImport_Product();
        }
        public int getID_Supplier(string Name_Supplier)
        {
            return ImportProductsDAL.Instance.getID_Supplier(Name_Supplier);
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

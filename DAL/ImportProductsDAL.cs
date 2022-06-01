﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class ImportProductsDAL
    {
        private static ImportProductsDAL _Instance;
        public static ImportProductsDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ImportProductsDAL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private ImportProductsDAL() { }
        DataTable importproducts = new DataTable();
        public List<string> getAllID_IP()
        {
            List<string> data = new List<string>();
            string query = "select ID_IP from ImportProduct";
            foreach (DataRow i in DataProvider.Instance.GetRecords(query).Rows)
            {
                data.Add(i["ID_IP"].ToString());
            }
            return data;
        }
        public List<string> getAllName_Supply()
        {
            List<string> data = new List<string>();
            string query = "select Name_Supply from Supply";
            foreach (DataRow i in DataProvider.Instance.GetRecords(query).Rows)
            {
                data.Add(i["Name_Supply"].ToString());
            }
            return data;
        }
        public List<string> getAllIP_Product()
        {
            List<string> data = new List<string>();
            string query = "select Name_P from Products";
            foreach (DataRow i in DataProvider.Instance.GetRecords(query).Rows)
            {
                data.Add(i["Name_P"].ToString());
            }
            return data;
        }
        public String getID_Product(string Name_P)
        {
            string query = "select ID_P from Products where Name_P = N'" + Name_P + "'";
            return DataProvider.Instance.GetRecords(query).Rows[0]["ID_P"].ToString();

        }
        public List<string> getAllDiscount()
        {
            List<string> data = new List<string>();
            string query = "select Discount from DetailImportProduct";
            foreach (DataRow i in DataProvider.Instance.GetRecords(query).Rows)
            {
                data.Add(i["Discount"].ToString());
            }
            return data;
        }
        public DataTable GetRecords()
        {
            string query = "select Date_Import,Name_Supply,Address_Supply,BankAccount,PhoneNumber_Supply,TaxCode,Symbol from Supply inner join ImportProduct on Supply.ID_Supply = ImportProduct.ID_Supply";
            importproducts = DataProvider.Instance.GetRecords(query);
            return importproducts;
        }
        public DataTable getAllImport_Product()
        {
            string query = "select * from ImportProduct";
            importproducts = DataProvider.Instance.GetRecords(query);
            return importproducts;
        }
        public int getID_Supply(string Name_Supply)
        {
            string query = "select Supply.ID_Supply from Supply inner join ImportProduct on Supply.ID_Supply = ImportProduct.ID_Supply where Name_Supply = '" + Name_Supply + "'";
            return Convert.ToInt32(DataProvider.Instance.GetRecords(query).Rows[0]["ID_Supply"].ToString());
        }
        public DataTable GetRecordsNewID_IP()
        {
            string query = "select Name_Supply,Address_Supply,BankAccount,PhoneNumber_Supply,TaxCode from Supply ";
            importproducts = DataProvider.Instance.GetRecords(query);
            return importproducts;
        }
        public DataTable getDetailsImportProduct(int ID_IP)
        {
            string query = "select DetailImportProduct.ID_P,Name_P,IP_Price,Amount_IP,Amount_Price,Discount,Total from DetailImportProduct inner join Products on DetailImportProduct.ID_P = Products.ID_P  where ID_IP = " + ID_IP;
            importproducts = DataProvider.Instance.GetRecords(query);
            return importproducts;
        }
        public DataTable getBillImportProductByDate(string datee)
        {
            //DataTable accountsList = new DataTable();
            string query = $"select ID_IP,ID,ID_Supply,Symbol,Date_Import from ImportProduct where Date_Import like N'%{datee}%'";
            importproducts = DataProvider.Instance.GetRecords(query);
            return importproducts;
        }
        public void addProducts(ImportProducts importProducts)
        {
            string query = "insert into ImportProduct(ID,ID_Supply,Date_Import) " + "values ('"
                + importProducts.ID + "','" + importProducts.ID_Supply + "','" + importProducts.Date_Import + "')";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updateImportProduct(ImportProducts importProducts)
        {
            string query = $"update ImportProduct set Date_Import = '{importProducts.Date_Import}' where ID_IP = '{importProducts.ID_IP}'";
            DataProvider.Instance.ExcuteDB(query);
        }

    }
}

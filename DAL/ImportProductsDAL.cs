using System;
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
        public List<string> getAllName_Supplier()
        {
            List<string> data = new List<string>();
            string query = "select Name_Supplier from Supplier";
            foreach (DataRow i in DataProvider.Instance.GetRecords(query).Rows)
            {
                data.Add(i["Name_Supplier"].ToString());
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
            string query = "select Date_Import,Name_Supplier,Address_Supplier,BankAccount,PhoneNumber_Supplier,TaxCode,Symbol from Supplier inner join ImportProduct on Supplier.ID_Supplier = ImportProduct.ID_Supplier";
            importproducts = DataProvider.Instance.GetRecords(query);
            return importproducts;
        }
        public DataTable getAllImport_Product()
        {
            string query = "select ID_IP as ID, Inf_user.Name as \"Staff\'s name\", Supplier.Name_Supplier as \"Supplier\'s name\", Date_Import as 'Import date' from ImportProduct inner join Inf_user on ImportProduct.ID = Inf_user.ID inner join Supplier on ImportProduct.ID_Supplier = Supplier.ID_Supplier";
            importproducts = DataProvider.Instance.GetRecords(query);
            return importproducts;
        }
        public int getID_Supplier(string Name_Supplier)
        {
            string query = "select Supplier.ID_Supplier from Supplier inner join ImportProduct on Supplier.ID_Supplier = ImportProduct.ID_Supplier where Name_Supplier like '%" + Name_Supplier + "%'";
            return Convert.ToInt32(DataProvider.Instance.GetRecords(query).Rows[0][0].ToString());
        }
        public DataTable GetRecordsNewID_IP()
        {
            string query = "select Name_Supplier,Address_Supplier,BankAccount,PhoneNumber_Supplier,TaxCode from Supplier ";
            importproducts = DataProvider.Instance.GetRecords(query);
            return importproducts;
        }
        public DataTable getDetailsImportProduct(int ID_IP)
        {
            string query = "select DetailImportProduct.ID_P,Name_P,IP_Price,Amount_IP,Amount_Price,Discount" +
                ",Total from DetailImportProduct inner join Products " +
                "on DetailImportProduct.ID_P = Products.ID_P  where ID_IP = " + ID_IP;
            importproducts = DataProvider.Instance.GetRecords(query);
            return importproducts;
        }
        public DataTable getBillImportProductByDate(string datee)
        {
            //DataTable accountsList = new DataTable();
            string query = $"select ID_IP,ID,ID_Supplier,Symbol,Date_Import from ImportProduct where Date_Import like N'%{datee}%'";
            importproducts = DataProvider.Instance.GetRecords(query);
            return importproducts;
        }
        public void addProducts(ImportProducts importProducts)
        {
            string query = "insert into ImportProduct(ID,ID_Supplier,Date_Import) " + "values ('"
                + importProducts.ID + "','" + importProducts.ID_Supplier + "','" + importProducts.Date_Import + "')";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updateImportProduct(ImportProducts importProducts)
        {
            string query = $"update ImportProduct set Date_Import = '{importProducts.Date_Import}' where ID_IP = '{importProducts.ID_IP}'";
            DataProvider.Instance.ExcuteDB(query);
        }

        public List<ImportProducts> GetAllImportProducts()
        {
            List<ImportProducts> list = new List<ImportProducts>();
            foreach (DataRow i in DataProvider.Instance.GetRecords("select * from ImportProduct").Rows)
            {
                list.Add(GetImportProductsByDataRow(i));
            }
            return list;
        }
        public ImportProducts GetImportProductsByDataRow(DataRow i)
        {
            return new ImportProducts
            {
                ID_IP = Convert.ToInt32(i["ID_IP"].ToString()),
                ID = Convert.ToInt32(i["ID"].ToString()),
                ID_Supplier = Convert.ToInt32(i["ID_Supplier"].ToString()),
                Date_Import = Convert.ToDateTime(i["Date_Import"].ToString())
            };
        }
    }
}

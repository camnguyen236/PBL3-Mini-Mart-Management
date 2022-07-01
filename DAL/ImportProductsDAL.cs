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
        public DataTable getAllImport_Product()
        {
            string query = "select ID_IP as ID, Name_Staff as \"Staff\'s name\", " +
                "Name_Supplier as \"Supplier\'s name\", Date_Import as 'Import date' " +
                "from ImportProduct";
            //inner join Inf_user on ImportProduct.ID = Inf_user.ID inner join " +
            //    "Supplier on ImportProduct.ID_Supplier = Supplier.ID_Supplier
            importproducts = DataProvider.Instance.GetRecords(query);
            return importproducts;
        }
        public DataTable GetRecordsNewID_IP()
        {
            string query = "select Name_Supplier,Address_Supplier,BankAccount,PhoneNumber_Supplier,TaxCode from Supplier ";
            importproducts = DataProvider.Instance.GetRecords(query);
            return importproducts;
        }
        public DataTable getDetailsImportProduct(int ID_IP)
        {
            string query = "select DetailImportProduct.ID_P,Name_Product,IP_Price,Amount_IP,Amount_Price,Discount" +
                ",Total from DetailImportProduct where ID_IP = " + ID_IP;
            // inner join Products " +
            //"on DetailImportProduct.ID_P = Products.ID_P
            importproducts = DataProvider.Instance.GetRecords(query);
            return importproducts;
        }
        public DataTable getBillImportProductByDate(string datee)
        {
            //DataTable accountsList = new DataTable();
            string query = $"select ID_IP,ID,ID_Supplier,Date_Import from ImportProduct where Date_Import like N'%{datee}%'";
            importproducts = DataProvider.Instance.GetRecords(query);
            return importproducts;
        }
        public void addProducts(ImportProducts importProducts)
        {
            string query = "insert into ImportProduct(ID,ID_Supplier,Date_Import,Name_Staff,Name_Supplier) " + "values ('"
                + importProducts.ID + "','" + importProducts.ID_Supplier + "','" + importProducts.Date_Import
                + "',N'" + importProducts.Name_Staff + "',N'" + importProducts.Name_Supplier + "')";
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
                Date_Import = Convert.ToDateTime(i["Date_Import"].ToString()),
                Name_Staff = i["Name_Staff"].ToString(),
                Name_Supplier = i["Name_Supplier"].ToString()
            };
        }
    }
}

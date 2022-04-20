using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class Product_DAL
    {
        private static Product_DAL _Instance;
        public static Product_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Product_DAL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private Product_DAL() { }
        DataTable products = new DataTable();

        public DataTable GetRecords()
        {
            string query = "select ID_P,Name_P,Unit_P,Cost_P,Price_P,VAT from Products";
            products = DataProvider.Instance.GetRecords(query);
            return products;
        }

        

        public void addProduct(Product product)
        {
            string query = "insert into Product(Name_P,Unit_P,Cost_P,Price_P,VAT,IMG_P) " + "values (N'"
                + product.Name_P + "',N'" + product.Unit_P + "','" + product.Cost_P + "','" + product.Price_P + "','" + product.VAT + "','" + product.Img_P + "')";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updateProduct(Product product)
        {
            string query = "update Products set Name_P = N'" + product.Name_P + "', Unit_P = N'" + product.Unit_P
                + "', Cost_P = '" + product.Cost_P + "', Price_P = '" + product.Price_P
                + "', VAT = '" + product.VAT + "', IMG_P = '" + product.Img_P
                + "' where ID_P = '" + product.ID_P + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void deleteProduct(string id_product)
        {
            string query = "delete from Products where ID_P = '" + id_product + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
    }
}

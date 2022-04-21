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
        DataRow product;
        public DataTable GetRecords()
        {
            string query = "select ID_P,Name_P,Unit_P,Cost_P,Price_P,VAT from Products";
            products = DataProvider.Instance.GetRecords(query);
            return products;
        }

        public DataTable GetProductByID(string id)
        {
            string query = $"select ID_P,ID_PG,Name_P,Unit_P,Cost_P,Price_P,VAT,IMG_P from Products where ID_P={id}";
            products = DataProvider.Instance.GetRecords(query);
            return products;
        }
        public DataTable GetRecordsAllColumns()
        {
            string query = "select ID_P,Name_P,Unit_P,Cost_P,Price_P,VAT,IMG_P from Products";
            products = DataProvider.Instance.GetRecords(query);
            return products;
        }

        public DataTable getProductsByGroupName(string groupName)
        {
            string query = "SELECT ID_P,Name_P,Unit_P,Cost_P,Price_P,VAT FROM Products as p inner JOIN ProductGroups as g ON p.ID_PG = g.ID_PG and g.Name_PG = N'" + groupName + "'";
            products = DataProvider.Instance.GetRecords(query);
            return products;
        }

        public DataTable getProductsByOption(string groupName, string name, string option)
        {
            DataTable productList = new DataTable();
            string query;
            if (groupName == "All")
            {
                query = $"select ID_P,Name_P,Unit_P,Cost_P,Price_P,VAT FROM Products as p inner JOIN ProductGroups as g ON p.ID_PG = g.ID_PG where {option} like N'%{name}%'";
            }
            else
            {
                query = $"select ID_P,Name_P,Unit_P,Cost_P,Price_P,VAT FROM Products as p inner JOIN ProductGroups as g ON p.ID_PG = g.ID_PG and g.Name_PG = N'{groupName}'where {option} like N'%{name}%'";
            }
            productList = DataProvider.Instance.GetRecords(query);
            return productList;
        }

        public void addProduct(Product product)
        {
            string query = "insert into Products(Name_P,Unit_P,Cost_P,Price_P,VAT) " + "values (N'"
                + product.Name_P + "',N'" + product.Unit_P + "','" + product.Cost_P + "','" + product.Price_P + "','" + product.VAT + "')";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updateProduct(Product product)
        {
            /*string query = "update Products set Name_P = N'" + product.Name_P + "', Unit_P = N'" + product.Unit_P
                + "', Cost_P = '" + product.Cost_P + "', Price_P = '" + product.Price_P
                + "', VAT = '" + product.VAT + "', IMG_P = '" + product.Img_P+ "' where ID_P = '" + product.ID_P + "'";*/
            string query = "update Products set Name_P = N'" + product.Name_P + "', Unit_P = N'" + product.Unit_P
                 + "', Cost_P = '" + product.Cost_P + "', Price_P = '" + product.Price_P
                 + "', VAT = '" + product.VAT + "' where ID_P = '" + product.ID_P + "'";
            DataProvider.Instance.ExcuteDB(query);
        }

        public void updateProductImg(string src, int id)
        {
            string query = $"UPDATE Products SET IMG_P = BulkColumn FROM OPENROWSET(BULK N'{src}', SINGLE_BLOB) as img WHERE ID_P='{id}'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void deleteProduct(string id_product)
        {
            string query = "delete from Products where ID_P = '" + id_product + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
    }
}

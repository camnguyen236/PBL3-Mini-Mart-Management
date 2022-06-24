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
            string query = "select ID_P,Name_P,Unit_P,Price_P,VAT,VAT_Inclusive_P from Products";
            products = DataProvider.Instance.GetRecords(query);
            return products;
        }
        public DataTable GetTrueRecords()
        {
            string query = "select ID_P,Name_P,Unit_P,Price_P,VAT,VAT_Inclusive_P from Products where Status = 'true'";
            products = DataProvider.Instance.GetRecords(query);
            return products;
        }

        public DataTable GetProductByID(string id)
        {
            string query = $"select ID_P,ID_PG,Name_P,Unit_P,Price_P,VAT,VAT_Inclusive_P,IMG_P " +
                $"from Products where ID_P={id} and Status = 'true'";
            products = DataProvider.Instance.GetRecords(query);
            return products;
        }
        public DataTable getProductByID(string id)
        {
            string query = $"select ID_P,ProductGroups.Name_PG,Name_P,Unit_P,Price_P,VAT,VAT_Inclusive_P " +
                $"from Products inner JOIN ProductGroups ON ProductGroups.ID_PG = Products.ID_PG " +
                $"where ID_P={id} and Products.Status = 'true'";
            products = DataProvider.Instance.GetRecords(query);
            return products;
        }

        public DataTable getProductsByGroupName(string groupName)
        {
            string query = "SELECT ID_P,Name_P,Unit_P,Price_P,VAT,VAT_Inclusive_P " +
                "FROM Products as p inner JOIN ProductGroups as g ON p.ID_PG = g.ID_PG " +
                "and g.Name_PG = N'" + groupName;
            products = DataProvider.Instance.GetRecords(query);
            return products;
        }
        public DataTable getTrueProductsByGroupName(string groupName)
        {
            string query = "SELECT ID_P,Name_P,Unit_P,Price_P,VAT,VAT_Inclusive_P " +
                "FROM Products as p inner JOIN ProductGroups as g ON p.ID_PG = g.ID_PG " +
                "and g.Name_PG = N'" + groupName + "' where p.Status = 'true'";
            products = DataProvider.Instance.GetRecords(query);
            return products;
        }

        public DataTable getProductsByOption(string groupName, string name, string option)
        {
            DataTable productList = new DataTable();
            string query;
            if (groupName == "All")
            {
                query = $"select ID_P,Name_P,Unit_P,Price_P,VAT,VAT_Inclusive_P " +
                    $"FROM Products as p inner JOIN ProductGroups as g ON p.ID_PG = g.ID_PG " +
                    $"where {option} like N'%{name}%' and p.Status = 'true'";
            }
            else
            {
                query = $"select ID_P,Name_P,Unit_P,Price_P,VAT,VAT_Inclusive_P " +
                    $"FROM Products as p inner JOIN ProductGroups as g ON p.ID_PG = g.ID_PG " +
                    $"and g.Name_PG = N'{groupName}'where {option} like N'%{name}%' and p.Status = 'true'";
            }
            productList = DataProvider.Instance.GetRecords(query);
            return productList;
        }

        public void addProduct(Product product)
        {
            /*string query = "insert into Products(ID_PG,Name_P,Unit_P,Price_P,VAT) " + "values (" +
                "'" + product.ID_PG + "',N'" + product.Name_P + "',N'" + product.Unit_P + "','" + product.Price_P + "','" + product.VAT + "')";*/
            //string query = $"insert into Products(ID_PG,Name_P,Unit_P,Price_P,VAT,Img_P) values ('{ product.ID_PG}',N'{product.Name_P}',N'{product.Unit_P}','{product.Price_P}','{product.VAT}','{product.Img_P}')";

            string query = $"insert into Products(ID_PG,Name_P,Unit_P,Price_P,VAT,IMG_P,Status) values ('{ product.ID_PG}',N'{product.Name_P}',N'{product.Unit_P}','{product.Price_P}','{product.VAT}',@data,'{product.Status}')";

            DataProvider.Instance.ExcuteDB(query, product.IMG_P);
        }
        public void updateProduct(Product product)
        {
            /*string query = "update Products set Name_P = N'" + product.Name_P + "', Unit_P = N'" + product.Unit_P
                + "', Cost_P = '" + product.Cost_P + "', Price_P = '" + product.Price_P
                + "', VAT = '" + product.VAT + "', IMG_P = '" + product.Img_P+ "' where ID_P = '" + product.ID_P + "'";*/
            string query = $"update Products set ID_PG = '{product.ID_PG}',Name_P = N'{product.Name_P}'" +
                $", Unit_P = N'{product.Unit_P}',Price_P = '{product.Price_P}', VAT = '{product.VAT}'" +
                $", IMG_P = @data, Status = '{product.Status}' where ID_P = '{product.ID_P}'";
            DataProvider.Instance.ExcuteDB(query, product.IMG_P);
        }

        public void updateProductImg(string src, int id)
        {
            string query = $"UPDATE Products SET IMG_P = BulkColumn FROM OPENROWSET(BULK N'{src}', SINGLE_BLOB) as img WHERE ID_P='{id}'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void deleteProduct(string id_product)
        {
            string query = "update Products set Status = 'false' where ID_P = '" + id_product + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void deleteProductByPG(int id_PG)
        {
            string query = "update Products set Status = 'false' where ID_PG = '" + Convert.ToString(id_PG) + "'";
            DataProvider.Instance.ExcuteDB(query);
        }

        public DataTable getAllProductsByGroupName(string groupName)
        {
            string query = "SELECT ID_P,Name_P,Unit_P,Price_P,VAT,VAT_Inclusive_P,IMG_P " +
                "FROM Products as p inner JOIN ProductGroups as g ON p.ID_PG = g.ID_PG " +
                "and g.Name_PG = N'" + groupName + "' where p.Status = 'true'";
            products = DataProvider.Instance.GetRecords(query);
            return products;
        }

        public DataTable GetAllRecords()
        {
            string query = "select ID_P,Name_P,Unit_P,Price_P,VAT,VAT_Inclusive_P,IMG_P " +
                "from Products where Status = 'true'";
            products = DataProvider.Instance.GetRecords(query);
            return products;
        }
        public List<Product> GetAllProduct()
        {
            List<Product> list = new List<Product>();
            foreach (DataRow i in DataProvider.Instance.GetRecords("select * from Products where Status = 'true'").Rows)
            {
                list.Add(GetProductByDataRow(i));
            }
            return list;
        }
        public Product GetProductByDataRow(DataRow i)
        {
            return new Product
            {
                ID_P = Convert.ToInt32(i["ID_P"].ToString()),
                ID_PG = i["ID_PG"].ToString(),
                Name_P = i["Name_P"].ToString(),
                Unit_P = i["Unit_P"].ToString(),
                Price_P = i["Price_P"].ToString(),
                VAT = i["VAT"].ToString(),
                VATInclusive_P = Convert.ToInt32(i["VAT_Inclusive_P"].ToString()),
                IMG_P = (byte[])(i["IMG_P"]),
                Status = Convert.ToBoolean(i["Status"].ToString())
            };
        }
    }
}

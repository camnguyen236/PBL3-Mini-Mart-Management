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
    public class Product_BLL
    {
        private static Product_BLL _Instance;
        public static Product_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Product_BLL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private Product_BLL() { }
        public DataTable getProducts()
        {
            return Product_DAL.Instance.GetRecords();
        }

        public DataTable GetProductByID(string id)
        {
            return Product_DAL.Instance.GetProductByID(id);
        }
        public DataTable getProductsByGroupName(string groupName)
        {
            return Product_DAL.Instance.getProductsByGroupName(groupName);
        }

        public DataTable getProductsByOption(string groupName, string name, string option)
        {
            return Product_DAL.Instance.getProductsByOption(groupName, name, option);
        }

        public void ExcuteDB(Product product, string id_product = null) //update, delete, add
        {
            if (id_product == null)
            {

                Product_DAL.Instance.updateProduct(product);
                return;
            }
            if (id_product != null && !id_product.Equals("Add"))
            {
                Product_DAL.Instance.deleteProduct(id_product);
                return;
            }
            if (id_product == "Add")
            {
                Product_DAL.Instance.addProduct(product);
                return;
            }
        }

        public DataTable getAllProductsByGroupName(string groupName)
        {
            return Product_DAL.Instance.getAllProductsByGroupName(groupName);
        }

        public DataTable getAllProducts()
        {
            return Product_DAL.Instance.GetAllRecords();
        }

        public DataRow getProductByID(int id)
        {
            DataRow dr = Product_DAL.Instance.getProductByID(id.ToString()).Rows[0];
            return dr;
            //return new Product
            //{
            //    ID_P = Convert.ToInt32(dr["ID_P"].ToString()),
            //    ID_PG = dr["ID_PG"].ToString(),
            //    Name_P = dr["Name_P"].ToString(),
            //    Unit_P = dr["Unit_P"].ToString(),
            //    Price_P = dr["Price_P"].ToString(),
            //    VAT = dr["VAT"].ToString(),
            //    VATInclusive_P = Convert.ToInt32(dr["VAT_Inclusive_P"].ToString()),
            //    IMG_P = null
            //};
        }
    }
}

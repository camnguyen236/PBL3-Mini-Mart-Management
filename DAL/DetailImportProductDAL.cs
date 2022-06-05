using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DetailImportProductDAL
    {
        private static DetailImportProductDAL _Instance;
        public static DetailImportProductDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DetailImportProductDAL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private DetailImportProductDAL() { }
        public void addProducts(DetailImportProducts detailImportProducts)
        {
            string query = "insert into DetailImportProduct(ID_IP,ID_P,IP_Price,Amount_IP,Discount) " + "values ('"
                + detailImportProducts.ID_IP + "','" + detailImportProducts.ID_P + "','" + detailImportProducts.IP_Price  +"','" + detailImportProducts.Amount_IP+ "','" + detailImportProducts.Discount + "')";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updateImportProduct(DetailImportProducts detailImportProducts)
        {
            string query = $"update DetailImportProduct set IP_Price = '{detailImportProducts.IP_Price}',Amount_IP = N'{detailImportProducts.Amount_IP}', Discount = '{detailImportProducts.Discount}' where ID_P = '{detailImportProducts.ID_P}'";
            DataProvider.Instance.ExcuteDB(query);
        }
        //public void updateImportProduct2(int quantity, int ID_P)
        //{
        //    string query = $"update DetailImportProduct set Amount_IP = '{quantity}' where ID_P = '{ID_P}'";
        //    DataProvider.Instance.ExcuteDB(query);
        //}
        public void deleteImportProduct(DetailImportProducts detailImportProducts,string id_product)
        {
            string query = "select ID_P from Products where Name_P = N'" + id_product + "'";
            int ID_P = Convert.ToInt32(DataProvider.Instance.GetRecords(query).Rows[0]["ID_P"].ToString());
            
            DataProvider.Instance.ExcuteDB("delete from DetailImportProduct where ID_P = '" + ID_P + "'");
        }
        public DataTable getDetailImportProductByID(int ID_IP)
        {
            DataTable data = new DataTable();
            string query = "SELECT DetailImportProduct.ID_IP, DetailImportProduct.IP_Price, " +
                "DetailImportProduct.Amount_IP, DetailImportProduct.Amount_Price, " +
                "DetailImportProduct.Discount, DetailImportProduct.Total, ImportProduct.Date_Import" +
                ", Inf_user.Name, Products.Name_P, Supply.Name_Supply, Supply.PhoneNumber_Supply, " +
                "Supply.Address_Supply, Supply.BankAccount, Supply.TaxCode from DetailImportProduct " +
                "LEFT OUTER JOIN ImportProduct ON DetailImportProduct.ID_IP = ImportProduct.ID_IP LEFT " +
                "OUTER JOIN Inf_user ON ImportProduct.ID = Inf_user.ID LEFT OUTER JOIN Products ON " +
                "DetailImportProduct.ID_P = Products.ID_P LEFT OUTER JOIN Supply " +
                "ON ImportProduct.ID_Supply = Supply.ID_Supply Where ImportProduct.ID_IP = " + ID_IP;
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }

        public List<DetailImportProducts> GetAllDetailImportProducts()
        {
            List<DetailImportProducts> list = new List<DetailImportProducts>();
            foreach (DataRow i in DataProvider.Instance.GetRecords("select * from DetailImportProducts").Rows)
            {
                list.Add(GetDetailImportProductsByDataRow(i));
            }
            return list;
        }
        public DetailImportProducts GetDetailImportProductsByDataRow(DataRow i)
        {
            return new DetailImportProducts
            {
                ID_IP = Convert.ToInt32(i["ID_IP"].ToString()),
                ID_P = Convert.ToInt32(i["ID_P"].ToString()),
                IP_Price = Convert.ToDouble(i["IP_Price"].ToString()),
                Amount_IP = Convert.ToInt32(i["Amount_IP"].ToString()),
                Amount_Price = Convert.ToDouble(i["Amount_Price"].ToString()),
                Total = Convert.ToDouble(i["Total"].ToString()),
                Discount = Convert.ToDouble(i["Discount"].ToString())
            };
        }
    }
}

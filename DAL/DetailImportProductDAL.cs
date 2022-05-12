using System;
using System.Collections.Generic;
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
            string query = "delete from DetailImportProduct where ID_P = '" + id_product + "'";
            DataProvider.Instance.ExcuteDB(query);
        }

    }
}

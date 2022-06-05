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
    public class DetailImportProductBLL
    {
        private static DetailImportProductBLL _Instance;
        public static DetailImportProductBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DetailImportProductBLL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private DetailImportProductBLL() { }
        public void ExcuteDB(DetailImportProducts detailImportProducts, string s = null) //update, delete
        {
            if (s == null)
            {
                DetailImportProductDAL.Instance.updateImportProduct(detailImportProducts);
                return;
            }
            if (s != null && !s.Equals("Add"))
            {
                DetailImportProductDAL.Instance.deleteImportProduct(detailImportProducts, s);
                return;
            }
            if (s == "Add")
            {
                DetailImportProductDAL.Instance.addProducts(detailImportProducts);
                return;
            }
        }
        private string id_ip;
        public void get(string ID_IP)
        {
            id_ip = ID_IP;
        }
        public string getID_IP()
        {
            return id_ip;
        }
        public DataTable getDetailImportProductByID(int ID_IP)
        {
            return DetailImportProductDAL.Instance.getDetailImportProductByID(ID_IP);
        }
        //public void updateImportProduct()
        //{
        //    DetailImportProductDAL.Instance.updateImportProduct2()
        //}

        public List<DetailImportProducts> getAllDetailImportProducts()
        {
            return DetailImportProductDAL.Instance.GetAllDetailImportProducts();
        }
        public DetailImportProducts getDetailImportProductsByID_IP(string id)
        {
            foreach (DetailImportProducts i in getAllDetailImportProducts())
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

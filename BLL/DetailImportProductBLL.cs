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
        public List<DetailImportProducts> getAllDetailImportProducts()
        {
            return DetailImportProductDAL.Instance.GetAllDetailImportProducts();
        }
        public DetailImportProducts getDetailImportProductsByID_IPAndID_P(string id_ip, string id_p)
        {
            foreach (DetailImportProducts i in getAllDetailImportProducts())
            {
                if (i.ID_IP.ToString().Equals(id_ip) && i.ID_P.ToString().Equals(id_p))
                {
                    return i;
                }
            }
            return null;
        }
        public List<DetailImportProducts> getDetailImportProductsByID_P(string id_p)
        {
            List<DetailImportProducts> data = new List<DetailImportProducts>();
            foreach (DetailImportProducts i in getAllDetailImportProducts())
            {
                if (i.ID_P.ToString().Equals(id_p))
                {
                    data.Add(i);
                }
            }
            return data;
        }
        public bool checkID_PByIP_IP(int id_p, int id_ip)
        {
            foreach (var i in getAllProduct())
            {
                if (i.ID_P == id) return true;
            }
            return false;
        }
    }
}

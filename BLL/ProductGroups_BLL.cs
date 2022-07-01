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
    public class ProductGroups_BLL
    {
        private static ProductGroups_BLL _Instance;
        public static ProductGroups_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ProductGroups_BLL();
                }
                return _Instance;
            }
            private set { }
        }
        private ProductGroups_BLL() { }

        public DataTable getProductGroups()
        {
            return ProductGroups_DAL.Instance.GetTrueRecords();
        }
        public DataTable getTFProductGroups()
        {
            return ProductGroups_DAL.Instance.GetRecords();
        }
        public List<ProductGroups> getAllProductGroups()
        {
            return ProductGroups_DAL.Instance.GetAllProductGroups();
        }
        public ProductGroups getProductGroupsByID(string id)
        {
            foreach (ProductGroups i in getAllProductGroups())
            {
                if (i.ID_PG.Equals(id))
                {
                    return i;
                }
            }
            return null;
        }

        public List<CBBGroups> GetListCBB()
        {
            List<CBBGroups> data = new List<CBBGroups>();
            foreach (ProductGroups i in ProductGroups_DAL.Instance.GetAllGroups())
            {
                data.Add(new CBBGroups
                {
                    Text = i.Name_PG,
                    Value = Convert.ToInt32(i.ID_PG),
                });
            }
            return data;
        }
        public void ExcuteDB(ProductGroups pg, string id_pg = null) //update, delete
        {
            if (id_pg == null)
            {
                ProductGroups_DAL.Instance.updateProductGroups(pg);
                return;
            }
            if (id_pg != null && !id_pg.Equals("Add"))
            {
                ProductGroups_DAL.Instance.deleteProductGroups(Convert.ToInt32(id_pg));
                return;
            }
            if (id_pg == "Add")
            {
                ProductGroups_DAL.Instance.addProductGroups(pg);
                return;
            }
        }
        public ProductGroups getPGByID(string id)
        {
            foreach(var i in getAllProductGroups())
            {
                if (i.ID_PG.Equals(id)) return i;
            }
            return null;
        }
        public bool checkNumOfProduct(string id_pg)
        {
            foreach(var i in Product_BLL.Instance.getProductByID_PG(id_pg))
            {
                if(Report_BLL.Instance.getInventoryByID_P(i.ID_P.ToString()) > 0) return true;
            }
            return false;
        }
    }
}

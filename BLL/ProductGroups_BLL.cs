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
            return ProductGroups_DAL.Instance.GetRecords();
        }
        public DataTable getNameGroupByID(string id)
        {
            return ProductGroups_DAL.Instance.getNameGroupByID(id);
        }
        public DataTable getIDByGroupName(string groupName)
        {
            return ProductGroups_DAL.Instance.getIDByGroupName(groupName);
        }
    }
}

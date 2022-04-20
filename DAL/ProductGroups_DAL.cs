using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class ProductGroups_DAL
    {
        private static ProductGroups_DAL _Instance;
        public static ProductGroups_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ProductGroups_DAL();
                }
                return _Instance;
            }
            private set { }
        }
        private ProductGroups_DAL() { }
        DataTable productGroups = new DataTable();
        public DataTable GetRecords()
        {
            string query = "select ID_PG,Name_PG from ProductGroups";
            productGroups = DataProvider.Instance.GetRecords(query);
            return productGroups;
        }
    }
}

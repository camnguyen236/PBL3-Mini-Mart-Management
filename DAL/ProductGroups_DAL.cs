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
        public DataTable getIDByGroupName(string groupName)
        {
            string query = $"SELECT * FROM ProductGroups where Name_PG = N'{groupName}'";
            productGroups = DataProvider.Instance.GetRecords(query);
            return productGroups;
        }
        public DataTable getNameGroupByID(string id)
        {
            string query = $"SELECT g.ID_PG , Name_PG FROM ProductGroups as g inner JOIN Products as p ON p.ID_PG = g.ID_PG and p.ID_P = {id}";
            productGroups = DataProvider.Instance.GetRecords(query);
            return productGroups;
        }
    }
}

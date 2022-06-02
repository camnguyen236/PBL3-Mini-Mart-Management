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

        public List<ProductGroups> GetAllProductGroups()
        {
            List<ProductGroups> list = new List<ProductGroups>();
            foreach (DataRow i in DataProvider.Instance.GetRecords("select * from ProductGroups").Rows)
            {
                list.Add(GetProductGroupsByDataRow(i));
            }
            return list;
        }
        public ProductGroups GetProductGroupsByDataRow(DataRow i)
        {
            return new ProductGroups
            {
                ID_PG = i["ID_PG"].ToString(),
                Name_PG = i["Name_PG"].ToString(),
                Status = Convert.ToBoolean(i["Status"].ToString())
            };
        }
        public DataTable GetRecords()
        {
            string query = "select ID_PG,Name_PG from ProductGroups where Status = 'true'";
            productGroups = DataProvider.Instance.GetRecords(query);
            return productGroups;
        }
        public DataTable getIDByGroupName(string groupName)
        {
            string query = $"SELECT ID_PG,Name_PG FROM ProductGroups where Name_PG = N'{groupName}' and Status = 'true'";
            productGroups = DataProvider.Instance.GetRecords(query);
            return productGroups;
        }
        public DataTable getNameGroupByID(string id)
        {
            string query = $"SELECT g.ID_PG , Name_PG FROM ProductGroups as g inner JOIN Products as p ON p.ID_PG = g.ID_PG and p.ID_P = {id} where g.Status = 'true'";
            productGroups = DataProvider.Instance.GetRecords(query);
            return productGroups;
        }

        public ProductGroups GetGroup(DataRow i)
        {
            return new ProductGroups
            {
                ID_PG = i["ID_PG"].ToString(),
                Name_PG = i["Name_PG"].ToString(),
                Status = Convert.ToBoolean(i["Status"].ToString())
            };
        }
        public List<ProductGroups> GetAllGroups()
        {
            List<ProductGroups> data = new List<ProductGroups>();
            string query = "select * from ProductGroups where Status = 'true'";
            foreach (DataRow i in DataProvider.Instance.GetRecords(query).Rows)
            {
                data.Add(GetGroup(i));
            };
            return data;
        }
        public void addProductGroups(ProductGroups productGroups)
        {
            string query = "insert into ProductGroups(Name_PG,Status) " + "values (N'"
                + productGroups.Name_PG + "',N'" + productGroups.Status + "')";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updateProductGroups(ProductGroups productGroups)
        {
            string query = "update ProductGroups set Name_PG = N'" + productGroups.Name_PG 
                + "', Status = N'" + productGroups.Status
                + "' where ID_PG = '" + productGroups.ID_PG + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void deleteProductGroups(int id)
        {
            Product_DAL.Instance.deleteProductByPG(id);
            string query = "update ProductGroups set Status = 'false' where ID_PG = '" + id + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
    }
}

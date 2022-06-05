using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class Supply_DAL
    {
        private static Supply_DAL _Instance;
        public static Supply_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Supply_DAL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private Supply_DAL() { }
        DataTable supply = new DataTable();
        public DataTable GetRecords()
        {
            string query = "select ID_Supply,Name_Supply,Address_Supply,PhoneNumber_Supply,BankAccount,TaxCode from Supply";
            supply = DataProvider.Instance.GetRecords(query);
            return supply;
        }
        public DataTable GetTrueRecords()
        {
            string query = "select ID_Supply,Name_Supply,Address_Supply,PhoneNumber_Supply,BankAccount,TaxCode from Supply where Status = 'true'";
            supply = DataProvider.Instance.GetRecords(query);
            return supply;
        }
        public List<Supply> GetAllSupply()
        {
            List<Supply> list = new List<Supply>();
            foreach (DataRow i in DataProvider.Instance.GetRecords("select * from Supply").Rows)
            {
                list.Add(GetSupplyByDataRow(i));
            }
            return list;
        }
        public Supply GetSupplyByDataRow(DataRow i)
        {
            return new Supply
            {
                ID_Supply = Convert.ToInt32(i["ID_Supply"].ToString()),
                Name_Supply = i["Name_Supply"].ToString(),
                PhoneNumber_Supply = i["PhoneNumber_Supply"].ToString(),
                Address_Supply = i["Address_Supply"].ToString(),
                BankAccount = i["BankAccount"].ToString(),
                TaxCode = i["TaxCode"].ToString(),
                Status = Convert.ToBoolean(i["Status"].ToString())
            };
        }
        public void addSupply(Supply supply)
        {
            string query = "insert into Supply(Name_Supply,Address_Supply,PhoneNumber_Supply,BankAccount,TaxCode,Status) " + "values (N'"
                + supply.Name_Supply + "',N'" + supply.Address_Supply + "','" + supply.PhoneNumber_Supply 
                + "','" + supply.BankAccount + "','" + supply.TaxCode + "','" + supply.Status + "')";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updateSupply(Supply supply)
        {
            string query = "update Supply set Name_Supply = N'" + supply.Name_Supply + "', Address_Supply = N'" + supply.Address_Supply
                + "', PhoneNumber_Supply = '" + supply.PhoneNumber_Supply + "', BankAccount = '" + supply.BankAccount
                + "', TaxCode = '" + supply.TaxCode + "', Status = '" + supply.Status 
                + "' where ID_Supply = '" + supply.ID_Supply + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void deleteSupply(string id_supply)
        {
            string query = "update Supply set Status = 'false' where ID_Supply = '" + id_supply + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public DataTable getSupplysByOption(string name, string option)
        {
            DataTable customersList = new DataTable();
            string query;

            {
                query = "select ID_Supply,Name_Supply,Address_Supply,PhoneNumber_Supply,BankAccount,TaxCode " +
                    " FROM Supply " +
                    $"where {option} like N'%{name}%'";
            }
            customersList = DataProvider.Instance.GetRecords(query);
            return customersList;
        }
    }
}

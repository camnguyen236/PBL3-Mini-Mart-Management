using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class Supplier_DAL
    {
        private static Supplier_DAL _Instance;
        public static Supplier_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Supplier_DAL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private Supplier_DAL() { }
        DataTable supplier = new DataTable();
        public DataTable GetRecords()
        {
            string query = "select ID_Supplier,Name_Supplier,Address_Supplier,PhoneNumber_Supplier,BankAccount,TaxCode from Supplier";
            supplier = DataProvider.Instance.GetRecords(query);
            return supplier;
        }
        public DataTable GetTrueRecords()
        {
            string query = "select ID_Supplier,Name_Supplier,Address_Supplier,PhoneNumber_Supplier," +
                "BankAccount,TaxCode from Supplier where Status = 'true'";
            supplier = DataProvider.Instance.GetRecords(query);
            return supplier;
        }
        public List<Supplier> GetAllSupplier()
        {
            List<Supplier> list = new List<Supplier>();
            foreach (DataRow i in DataProvider.Instance.GetRecords("select * from Supplier").Rows)
            {
                list.Add(GetSupplierByDataRow(i));
            }
            return list;
        }
        public Supplier GetSupplierByDataRow(DataRow i)
        {
            return new Supplier
            {
                ID_Supplier = Convert.ToInt32(i["ID_Supplier"].ToString()),
                Name_Supplier = i["Name_Supplier"].ToString(),
                PhoneNumber_Supplier = i["PhoneNumber_Supplier"].ToString(),
                Address_Supplier = i["Address_Supplier"].ToString(),
                BankAccount = i["BankAccount"].ToString(),
                TaxCode = i["TaxCode"].ToString(),
                Status = Convert.ToBoolean(i["Status"].ToString())
            };
        }
        public void addSupplier(Supplier supplier)
        {
            string query = "insert into Supplier(Name_Supplier,Address_Supplier,PhoneNumber_Supplier,BankAccount,TaxCode,Status) " + "values (N'"
                + supplier.Name_Supplier + "',N'" + supplier.Address_Supplier + "','" + supplier.PhoneNumber_Supplier
                + "','" + supplier.BankAccount + "','" + supplier.TaxCode + "','" + supplier.Status + "')";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updateSupplier(Supplier Supplier)
        {
            string query = "update Supplier set Name_Supplier = N'" + Supplier.Name_Supplier + "', Address_Supplier = N'" + Supplier.Address_Supplier
                + "', PhoneNumber_Supplier = '" + Supplier.PhoneNumber_Supplier + "', BankAccount = '" + Supplier.BankAccount
                + "', TaxCode = '" + Supplier.TaxCode + "', Status = '" + Supplier.Status 
                + "' where ID_Supplier = '" + Supplier.ID_Supplier + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void deleteSupplier(string id_Supplier)
        {
            string query = "update Supplier set Status = 'false' where ID_Supplier = '" + id_Supplier + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public DataTable getSuppliersByOption(string name, string option)
        {
            DataTable customersList = new DataTable();
            string query;

            {
                query = "select ID_Supplier,Name_Supplier,Address_Supplier,PhoneNumber_Supplier,BankAccount,TaxCode " +
                    " FROM Supplier " +
                    $"where {option} like N'%{name}%'";
            }
            customersList = DataProvider.Instance.GetRecords(query);
            return customersList;
        }
    }
}

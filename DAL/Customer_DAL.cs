using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class Customer_DAL
    {
        private static Customer_DAL _Instance;
        public static Customer_DAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Customer_DAL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private Customer_DAL() { }
        DataTable customers = new DataTable();
        public DataTable GetRecords()
        {
            string query = "select ID_Customer,Name_Customer,Gender_Customer,Address_Customer," +
                "PhoneNumber_Customer,Email_Customer,AccountNumber,TaxCode,Discount from Customer " +
                "where Status = 'true'";
            customers = DataProvider.Instance.GetRecords(query);
            return customers;
        }
        public List<Customer> GetAllCustomer()
        {
            List<Customer> list = new List<Customer>();
            foreach (DataRow i in DataProvider.Instance.GetRecords("select * from Customer where Status = 'true'").Rows)
            {
                list.Add(GetCustomerByDataRow(i));
            }
            return list;
        }
        public Customer GetCustomerByDataRow(DataRow i)
        {
            return new Customer
            {
                ID_Customer = Convert.ToInt32(i["ID_Customer"].ToString()),
                Name_Customer = i["Name_Customer"].ToString(),
                Gender_Customer = i["Gender_Customer"].ToString(),
                PhoneNumber_Customer = i["PhoneNumber_Customer"].ToString(),
                Email_Customer = i["Email_Customer"].ToString(),
                AccountNumber = i["AccountNumber"].ToString(),
                Address_Customer = i["Address_Customer"].ToString(),
                TaxCode = i["TaxCode"].ToString(),
                Discount = Convert.ToInt32(i["Discount"].ToString()),
                Status = Convert.ToBoolean(i["Status"].ToString())
            };
        }
        public void addCustomer(Customer customer)
        {
            string query = "insert into Customer(Name_Customer,Gender_Customer,Address_Customer" +
                ",PhoneNumber_Customer,Email_Customer,AccountNumber,TaxCode,Discount,Status) " + "values (N'" 
                + customer.Name_Customer + "',N'" + customer.Gender_Customer  + "',N'" + customer.Address_Customer 
                + "','" + customer.PhoneNumber_Customer + "','" + customer.Email_Customer + "','" 
                + customer.AccountNumber + "','" + customer.TaxCode + "','" + customer.Discount 
                + "','" + customer.Status + "')";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updateCustomer(Customer customer)
        {
            string query = "update Customer set Name_Customer = N'" + customer.Name_Customer 
                + "', Gender_Customer = N'" + customer.Gender_Customer + "', Address_Customer = N'" 
                + customer.Address_Customer + "', PhoneNumber_Customer = '" + customer.PhoneNumber_Customer 
                + "', Email_Customer = '" + customer.Email_Customer + "', AccountNumber = '" 
                + customer.AccountNumber + "', TaxCode = '" + customer.TaxCode + "', Discount = '" 
                + customer.Discount + "', Status = '" + customer.Status
                + "' where ID_Customer = '" + customer.ID_Customer + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void deleteCustomer(string id_customer)
        {
            string query = "update Customer set Status = 'false' where ID_Customer = '" + id_customer + "'";
            DataProvider.Instance.ExcuteDB(query);
        }

        public DataTable getCustomersByOption(string name, string option)
        {
            DataTable customersList = new DataTable();
            string query;
            
            {
                query = "select ID_Customer,Name_Customer,Gender_Customer,Address_Customer,PhoneNumber_Customer,Email_Customer,AccountNumber,TaxCode " +
                    " FROM Customer " +
                    $"where {option} like N'%{name}%'";
            }
            customersList = DataProvider.Instance.GetRecords(query);
            return customersList;
        }
    }
}

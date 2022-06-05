using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAL;

namespace BLL
{
    public class Customer_BLL
    {
        private static Customer_BLL _Instance;
        public static Customer_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Customer_BLL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private Customer_BLL() { }
        enum Search
        {
            Name,
            Phonenumber,
            Email
        }
        public DataTable getCustomer()
        {
            return Customer_DAL.Instance.GetRecords();
            //return accounts;
        }
        public List<Customer> getAllCustomer()
        {
            return Customer_DAL.Instance.GetAllCustomer();
        }
        public void ExcuteDB(Customer customer, string id_customer = null) //update, delete
        {
            if (id_customer == null)
            {
                Customer_DAL.Instance.updateCustomer(customer);
                return;
            }
            if (id_customer != null && !id_customer.Equals("Add"))
            {
                Customer_DAL.Instance.deleteCustomer(id_customer);
                return;
            }
            if (id_customer == "Add")
            {
                Customer_DAL.Instance.addCustomer(customer);
                return;
            }
        }

        public List<Customer> getCustomerByName(string name)
        {
            List<Customer> list = new List<Customer> ();
            foreach (Customer i in getAllCustomer())
            {
                if (i.Name_Customer.Contains(name))
                {
                    list.Add(i);
                }
            }
            return list;
        }

        public Customer getCustomerByID(string id)
        {
            foreach (Customer i in getAllCustomer())
            {
                if (i.ID_Customer.ToString().Equals(id))
                {
                    return i;
                }
            }
            return null;
        }

        public List<Customer> getCustomerByPhoneNum(string phoneNum)
        {
            List<Customer> list = new List<Customer>();
            foreach (Customer i in getAllCustomer())
            {
                if (i.PhoneNumber_Customer.Contains(phoneNum))
                {
                    list.Add(i);
                }
            }
            return list;
        }

        public List<Customer> getCustomerByEmail(string email)
        {
            List<Customer> list = new List<Customer>();
            foreach (Customer i in getAllCustomer())
            {
                if (i.Email_Customer.Contains(email))
                {
                    list.Add(i);
                }
            }
            return list;
        }
        public List<Customer> getCustomerByNPM(string txt)
        {
            List<Customer> list = new List<Customer>();
            foreach (Customer i in getAllCustomer())
            {
                if (i.Name_Customer.Contains(txt) || i.Email_Customer.Contains(txt) 
                    || i.PhoneNumber_Customer.Contains(txt))
                {
                    list.Add(i);
                }
            }
            return list;
        }

        public List<Customer> getListCustomer(string cbb, string txt)
        {
            if(cbb.Equals(Search.Name.ToString())) return getCustomerByName(txt);
            else if (cbb.Equals(Search.Phonenumber.ToString())) return getCustomerByPhoneNum(txt);
            else return getCustomerByEmail(txt);
        }

        public DataTable getCustomersByOption(string name, string option)
        {
            return Customer_DAL.Instance.getCustomersByOption(name, option);
        }
    }
}

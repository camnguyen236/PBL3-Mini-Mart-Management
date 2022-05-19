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
        public DataTable getCustomer()
        {
            return Customer_DAL.Instance.GetRecords();
            //return accounts;
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
                Customer_DAL.Instance.deleteCustomer(customer, id_customer);
                return;
            }
            if (id_customer == "Add")
            {
                Customer_DAL.Instance.addCustomer(customer);
                return;
            }
        }

        public Customer getCustomerByPhoneNum(string phoneNum)
        {
            foreach (Customer i in Customer_DAL.Instance.GetAllCustomer())
            {
                if (phoneNum == i.PhoneNumber_Customer)
                {
                    return i;
                }
            }
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Customer
    {
        public int ID_Customer { get; set; }
        public string Name_Customer { get; set; }
        public string Gender_Customer { get; set; }
        public string Address_Customer { get; set; }
        public string PhoneNumber_Customer { get; set; }
        public string Email_Customer { get; set; }  
        public string AccountNumber { get; set; }
        public string TaxCode { get; set; }
        public int Discount { get; set; }
        public bool Status { get; set; }
    }
}

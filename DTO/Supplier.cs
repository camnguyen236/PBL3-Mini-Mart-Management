using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Supplier
    {
        public int ID_Supplier { get; set; }
        public string Name_Supplier { get; set; }
        public string Address_Supplier { get; set; }
        public string PhoneNumber_Supplier { get; set; }
        public string BankAccount { get; set; }
        public string TaxCode { get; set; }
        public bool Status { get; set; }
    }
}

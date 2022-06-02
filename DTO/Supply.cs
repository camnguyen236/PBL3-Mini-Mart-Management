using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Supply
    {
        public int ID_Supply { get; set; }
        public string Name_Supply { get; set; }
        public string Address_Supply { get; set; }
        public string PhoneNumber_Supply { get; set; }
        public string BankAccount { get; set; }
        public string TaxCode { get; set; }
        public bool Status { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class InvoiceDetail
    {
        public int ID_Invoice { get; set; }
        public int ID_P { get; set; }
        public int Unit_Price { get; set; }
        public int Quantity { get; set; }
        public int Amount { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Invoice
    {
        public int ID_Invoice { get; set; }
        public int ID { get; set; }
        public int ID_Customer { get; set; }
        public DateTime Invoice_Date { get; set; }
    }
}

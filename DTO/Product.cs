using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Product
    {
        public int ID_P { get; set; }
        public string ID_PG { get; set; }
        public string Name_P { get; set; }
        public string Unit_P { get; set; }
        public DateTime Birthday { get; set; }
        public string Price_P { get; set; }
        public string VAT { get; set; }
        public string Cost_P { get; set; }
    }
}

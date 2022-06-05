using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DetailImportProducts
    {
		public int ID_IP { get; set; }
		public int ID_P { get; set; }
		public double IP_Price { get; set; } // giá nhập
		public int Amount_IP { get; set; }
		public double Amount_Price { get; set; }
		public double Discount { get; set; }
		public double Total { get; set; }
	}
}

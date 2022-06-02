using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ImportProducts
    {
		public int ID_IP { get; set; }
		public int ID { get; set; } //mã nv
		public int ID_Supply { get; set; }
	    //public string Symbol { get; set; }
		public DateTime Date_Import { get; set; }


    }
}

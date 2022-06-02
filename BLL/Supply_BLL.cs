using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Data;

namespace BLL
{
    public class Supply_BLL
    {
        private static Supply_BLL _Instance;
        public static Supply_BLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Supply_BLL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private Supply_BLL() { }
        public DataTable getSupply()
        {
            return Supply_DAL.Instance.GetRecords();
        }
        public void ExcuteDB(Supply supply, string id_supply = null) //update, delete
        {
            if (id_supply == null)
            {
                Supply_DAL.Instance.updateSupply(supply);
                return;
            }
            if (id_supply != null && !id_supply.Equals("Add"))
            {
                Supply_DAL.Instance.deleteSupply(id_supply);
                return;
            }
            if (id_supply == "Add")
            {
                Supply_DAL.Instance.addSupply(supply);
                return;
            }
        }
    }
}

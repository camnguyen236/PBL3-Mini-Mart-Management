using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Threading.Tasks;
using DAL;
using System.Data;

namespace BLL
{
    public class TableImportSqlBLL
    {
        private static TableImportSqlBLL _Instance;
        public static TableImportSqlBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TableImportSqlBLL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private TableImportSqlBLL() { }
        public void ExcuteDB(TableImportSql tableImportSql, string s = null) //update, delete
        {
            if (s == "Add")
            {
                TableImportSqlDAL.Instance.addTableImportSql(tableImportSql);
                return;
            }
        }
        private string id_ip;
        public void get(string ID_IP)
        {
            id_ip = ID_IP;
        }
        public string getID_IP()
        {
            return id_ip;
        }
        public DataTable getTableImportByID(int ID_IP)
        {
            return TableImportSqlDAL.Instance.getTableImportByID(ID_IP);
        }
    }
}

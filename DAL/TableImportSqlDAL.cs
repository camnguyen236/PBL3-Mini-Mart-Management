using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;

namespace DAL
{
    public class TableImportSqlDAL
    {
        private static TableImportSqlDAL _Instance;
        public static TableImportSqlDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new TableImportSqlDAL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private TableImportSqlDAL() { }
        public void addTableImportSql (TableImportSql tableImportSql)
        {
            string query = "insert into TableImport(ID_IP2,Date_Import2,Symbol2,Name_Supply2,Address_Supply2,TaxCode2,PhoneNumber_Supply2,BankAccount2,Name_Product2,Amount_IP2,Price2, Amount_Price2,Discount2,Total2) " + "values ('"
                + tableImportSql.ID_IP2 + "','" + tableImportSql.Date_Import2 + "','" + tableImportSql.Symbol2 + "','" + tableImportSql.Name_Supply2 + "','"+ tableImportSql.Address_Supply2+ "','"+ tableImportSql.TaxCode2+ "','"+tableImportSql.PhoneNumber_Supply2+ "','"+ tableImportSql.BankAccount2+ "','"+tableImportSql.Name_Product2 + "','" + tableImportSql.Amount_IP2 + "','" + tableImportSql.Price2 + "','" + tableImportSql.Amount_Price2 + "','" + tableImportSql.Discount2 + "','" + tableImportSql.Total2+  "')";
            DataProvider.Instance.ExcuteDB(query);
        }
        public DataTable getTableImportByID(int ID_IP)
        {
            DataTable data = new DataTable();
            string query = "select ID_IP2,Date_Import2,Symbol2,Name_Supply2,Address_Supply2,TaxCode2,PhoneNumber_Supply2,BankAccount2,Name_Product2,Amount_IP2,Price2,Amount_Price2,Discount2,Total2 from TableImport where ID_IP2 = " + ID_IP;
            data = DataProvider.Instance.GetRecords(query);
            return data;
        }
    }
}

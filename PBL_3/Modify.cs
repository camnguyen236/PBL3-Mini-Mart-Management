using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PBL_3
{
    public class Modify
    {
        public string role;
        public Modify() { }
        public SqlCommand cmd; //truy vấn các câu lệnh insert, update,...
        public SqlDataReader reader;
        public List<Account> Accounts(string query)
        {
            List<Account> accounts = new List<Account>();
            using(SqlConnection cn = Connection.getSqlConnection()) //vì getSqlConnection là pt tĩnh
            {
                cn.Open();
                cmd =new SqlCommand(query,cn);
                reader = cmd.ExecuteReader(); //tiến hành đọc
                while (reader.Read()) //đọc từn dòng
                {
                    accounts.Add(new Account(reader.GetString(1), reader.GetString(2)));
                    role = reader.GetString(8);
                }

                cn.Close();
            }
            return accounts;
        } 
    }
}

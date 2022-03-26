using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PBL_3
{
    internal class List_user
    {
        List<Infor_user> list_user;
        SqlDataReader reader;
        public List<Infor_user> getDataUser()
        {
            List<Infor_user> ls = new List<Infor_user>();
            //Connection sQL_Connect = new Connection();
            using (SqlConnection cn = Connection.getSqlConnection())
            {
                //Sql_connect sQL_Connect = new Sql_connect();
                //SqlConnection cn = sQL_Connect.connect();
                cn.Open();
                string sql = "select * from Infor_user";
                SqlCommand cmd = new SqlCommand(sql, cn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list_user.Add(new Infor_user(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetString(5), reader.GetString(6), reader.GetString(7)));
                }
                cn.Close();
            }
            return ls;
        }

        public bool checkUserName(string USname)
        {
            for (int i = 0; i < list_user.Count; i++)
            {
                if (list_user[i].US == USname)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
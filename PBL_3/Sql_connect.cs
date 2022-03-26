using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PBL_3
{
    internal class Sql_connect
    {
        public SqlConnection connect()
        {
            SqlConnection cn = new SqlConnection(@"Data Source=DESKTOP-K9NDIH8;Initial Catalog=Information;Integrated Security=True");
            return cn;
        }
    }
}

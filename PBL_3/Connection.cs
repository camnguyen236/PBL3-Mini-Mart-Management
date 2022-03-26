using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PBL_3
{
    public class Connection
    {
        private static string stringConnection = @"Data Source=DESKTOP-K9NDIH8;Initial Catalog=Information;Integrated Security=True";
        public static SqlConnection getSqlConnection()
        {
            return new SqlConnection(stringConnection);
        }
    }
}

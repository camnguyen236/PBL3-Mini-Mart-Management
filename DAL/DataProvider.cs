using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAL
{
    
    public class DataProvider
    {
        private static DataProvider _Instance;
        public static DataProvider Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new DataProvider();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private DataProvider() { }
        //
        public DataTable GetRecords(string query) //để thực hiện lệnh select
        {
            DataTable dt = new DataTable();
            using (SqlConnection cnt = Connection.getSqlConnection()) //khi kết thúc khối lệnh, dữ liệu sẽ đc giải phóng
            {
                cnt.Open();
                SqlCommand cmd = new SqlCommand(query, cnt);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                cnt.Close();
            }
            return dt;
        }

        public string role;
        public string checkLoginDTO(Account account, string query = null)
        {
            
            string user = null;
            //connect tới CSDL
            SqlConnection cnt = Connection.getSqlConnection();
            cnt.Open();
            SqlCommand cmd = new SqlCommand(query, cnt); //"proc_loginn"
            //cmd.CommandType = CommandType.StoredProcedure; //query, procdure
            //cmd.Parameters.AddWithValue("@user", account.US); //của ng dùng nhập vào
            //cmd.Parameters.AddWithValue("@password", account.PW);
            //cmd.Parameters.AddWithValue("@role", account.Position); //kiểm tra phân quyền
            cmd.Connection = cnt;
            SqlDataReader reader = cmd.ExecuteReader(); //đọc từng row , dữ liệu còn tồn tại khi còn kết nối csdl
            if (reader.HasRows) //nếu có 
            {
                while(reader.Read()) //đọc từ row đầu tiên đến row cúi cùng
                {
                    user = reader.GetString(1);
                    role = reader.GetString(8);
                }
                reader.Close();
                cnt.Close();
            } else
            {
                return "Login Failed!";
            }
            return user;
        }
        public string getRole()
        {
            return role;
        }
        //để thực hiện update, delete
        public bool ExcuteDB(string query)
        {
            try
            {
                using(SqlConnection cnt = Connection.getSqlConnection())
                {
                    cnt.Open();
                    SqlCommand cmd = new SqlCommand(query, cnt);
                    cmd.ExecuteNonQuery();
                    cnt.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public String CheckAcc(string query) //để thực hiện lệnh select
        {
            string s;
            using (SqlConnection cnt = Connection.getSqlConnection()) //khi kết thúc khối lệnh, dữ liệu sẽ đc giải phóng
            {
                cnt.Open();
                SqlCommand cmd = new SqlCommand(query, cnt);
                s = (string)cmd.ExecuteScalar();
                cnt.Close();
            }
            return s;
        }
    }
}

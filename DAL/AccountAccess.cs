using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;


namespace DAL
{
    public class AccountAccess
    {
        private static AccountAccess _Instance;
        public static AccountAccess Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountAccess();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private AccountAccess() { }
        DataTable accounts = new DataTable();
        public string checkLogin(Account account)
        {
            string query = "select * from Inf_user where US= '" + account.US + "'and PW ='" + account.PW + "'";
            string inf = DataProvider.Instance.checkLoginDTO(account,query); 
            return inf;
        }
        public DataTable GetRecords()
        {
            string query = "select ID,US,Name,Birthday,Adress,PhoneNumber,Position,Email from Inf_user";
            accounts = DataProvider.Instance.GetRecords(query);
            return accounts;
        }

        public void updateAccount(Account account)
        {
            string query = "update Inf_user set US = '" + account.US + "', Name = N'" + account.Name + "', Birthday = '" + account.Birthday + "', Adress = N'" + account.Adress + "', PhoneNumber = '" + account.PhoneNumber + "', Email = '" + account.Email + "' where ID = '" + account.ID + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updatePassword(string password)
        {
            string query = "update Inf_user set PW = '" + password + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updateRole(string username, string role)
        {
            string query = "update Inf_user set Position = '" + role + "'" + " where US = '" + username + "'"; ;
            DataProvider.Instance.ExcuteDB(query);
        }
        public void deleteAccount(Account account, string id)
        {
            string query = "delete from Inf_user where ID = '" + id + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void addAccount(Account account)
        {
            string query = "insert into Inf_user(US,PW,Name,Gender,Birthday,Adress,PhoneNumber,Position,Email) " +
                    "values ('" + account.US + "','" + account.PW + "',N'" + account.Name + "','" + account.Gender + "','" +
                    account.Birthday+ "',N'" + account.Adress + "','" + account.PhoneNumber + "','" + account.Position + "','" + account.Email + "')";
            DataProvider.Instance.ExcuteDB(query);
        }
        public List<string> getAllUsername()
        {
            List<string> data = new List<string>();
            string query = "select US from Inf_user";
            foreach(DataRow i in DataProvider.Instance.GetRecords(query).Rows)
            {
                data.Add(i["US"].ToString());
            }
            return data;
        }

    }
}

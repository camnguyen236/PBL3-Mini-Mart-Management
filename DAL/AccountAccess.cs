using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Security.Cryptography;

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
            //begin hashing
            byte[] passByte = ASCIIEncoding.ASCII.GetBytes(account.PW); //convert s (string) to byte
            byte[] hashPassByte = new MD5CryptoServiceProvider().ComputeHash(passByte);//Hash: Returns is an array of numbers
            string hashPassStr = "";
            foreach (byte item in hashPassByte)
            {
                hashPassStr += item;
            }
            //end hashing: password after hash is hashPassStr
            string query = "select * from Inf_user where US= '" + account.US + "'and PW ='" + hashPassStr + "' and Status = 'true'";
            string inf = DataProvider.Instance.checkLoginDTO(account, query);
            return inf;
        }
        public DataTable GetRecords()
        {
            string query = "select ID,US,Name,Birthday,Adress,PhoneNumber,Position,Email from Inf_user";
            accounts = DataProvider.Instance.GetRecords(query);
            return accounts;
        }
        public DataTable GetTrueRecords()
        {
            string query = "select ID,US,Name,Birthday,Adress,PhoneNumber,Position,Email from Inf_user where Status = 'true'";
            accounts = DataProvider.Instance.GetRecords(query);
            return accounts;
        }

        public List<Account> GetAllAccount()
        {
            List<Account> list = new List<Account>();
            foreach (DataRow i in DataProvider.Instance.GetRecords("select * from Inf_user").Rows)
            {
                list.Add(GetAccountByDataRow(i));
            }
            return list;
        }
        public Account GetAccountByDataRow(DataRow i)
        {
            return new Account
            {
                ID = Convert.ToInt32(i["ID"].ToString()),
                US = i["US"].ToString(),
                PW = i["PW"].ToString(),
                Name = i["Name"].ToString(),
                Gender = i["Gender"].ToString(),
                Birthday = Convert.ToDateTime(i["Birthday"].ToString()),
                Adress = i["Adress"].ToString(),
                PhoneNumber = i["PhoneNumber"].ToString(),
                Position = i["Position"].ToString(),
                Email = i["Email"].ToString(),
                Status = Convert.ToBoolean(i["Status"].ToString())
            };
        }
        public DataTable GetAccountsByOption(string name, string option)
        {
            DataTable accountsList = new DataTable();
            string query = $"select ID,US,Name,Birthday,Adress,PhoneNumber,Position,Email from Inf_user where {option} like N'%{name}%' and Status = 'true'";
            accountsList = DataProvider.Instance.GetRecords(query);
            return accountsList;
        }
        public void updateAccount(Account account)
        {
            string query = $"update Inf_user set US = N'{account.US}', " +
                $"PW = N'{account.PW}', " +
                $"Name = N'{account.Name}', " +
                $"Gender = N'{account.Gender}', Birthday = '{account.Birthday.ToString("yyyy - MM - dd")}', " +
                $"Adress = N'{account.Adress}', PhoneNumber = '{account.PhoneNumber}', " +
                $"Email = '{account.Email}', Status = '{account.Status}' " +
                $"where ID = {account.ID}";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updatePassword(string password, string US)
        {
            string query = "update Inf_user set PW = '" + password + "' where US = '" + US + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void updateRole(string username, string role)
        {
            string query = "update Inf_user set Position = '" + role + "'" + " where US = '" + username + "'"; ;
            DataProvider.Instance.ExcuteDB(query);
        }
        public void deleteAccount(string id)
        {
            string query = "update Inf_user set Status = 'false' where ID = '" + id + "'";
            DataProvider.Instance.ExcuteDB(query);
        }
        public void addAccount(Account account)
        {
            string query = "insert into Inf_user(US,PW,Name,Gender,Birthday,Adress,PhoneNumber,Position,Email,Status) " +
                    "values ('" + account.US + "','" + account.PW + "',N'" + account.Name + "',N'" + account.Gender + "','" +
                    account.Birthday + "',N'" + account.Adress + "','" + account.PhoneNumber + "','" 
                    + account.Position + "','" + account.Email + "','" + account.Status + "')";
            DataProvider.Instance.ExcuteDB(query);
        }
        public List<string> getAllUsername()
        {
            List<string> data = new List<string>();
            string query = "select US from Inf_user where Status = 'true'";
            foreach (DataRow i in DataProvider.Instance.GetRecords(query).Rows)
            {
                data.Add(i["US"].ToString());
            }
            return data;
        }
        public string checkField(string field, string value)
        {
            string query = "select " + field + " from Inf_user where " + field + " = '" + value + "' and Status = 'true'";
            return DataProvider.Instance.CheckAcc(query);
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAL;

namespace BLL
{
    public class AccountBLL
    {
        private static AccountBLL _Instance;
        public static AccountBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountBLL();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private AccountBLL() { }
        DataTable accounts = new DataTable();
        public string checkLogin(Account account)
        {
            //kiểm tra nghiệp vụ
            if (account.US.Trim() == "") return "Please fill in username information!";
            if (account.PW.Trim() =="") return "Please fill in passwork information!";
            string inf = AccountAccess.Instance.checkLogin(account);
            return inf;
        }
        public string getRole()
        {
            return DataProvider.Instance.getRole();
        }
        public DataTable getAccount()
        {
            return AccountAccess.Instance.GetRecords();
            //return accounts;
        }
        public DataTable getAccountByOption(string name, string option)
        {
            return AccountAccess.Instance.GetAccountsByOption(name, option);
        }
        public void ExcuteDB(Account account, string id = null) //update, delete
        {
            if (id == null && (account.PW) != null)
            {
                AccountAccess.Instance.updateAccount(account);
                return;
            }
            if (id != null && !id.Equals("Add"))
            {
                AccountAccess.Instance.deleteAccount(account, id);
                return;
            }
            if (id.Equals("Add"))
            {
                AccountAccess.Instance.addAccount(account);
                return;
            }
        }
        public void updatePassword(string password, string US)
        {
            AccountAccess.Instance.updatePassword(password, US);
        }
        public void updateRole(string username, string role)
        {
            AccountAccess.Instance.updateRole(username, role);
        }
        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    // Use IdnMapping class to convert Unicode domain names.
                    var idn = new IdnMapping();

                    // Pull out and process domain name (throws ArgumentException on invalid)
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
        public bool checkPhoneNumber(string pn)
        {
            return Regex.IsMatch(pn, "^[0-9]{10}$");
        }

        public bool checkUS(string name)
        {
            return Regex.IsMatch(name, "^[a-zA-Z0-9]{6,24}$");
        }

        public List<string> getAllUsername()
        {
            return AccountAccess.Instance.getAllUsername();
        }
        public bool checkField(string field, string name)
        {
            string s = AccountAccess.Instance.checkField(field, name);
            if (s == null) return false;
            return true;
        }
        public bool checkRole(string s)
        {
            if(DataProvider.Instance.getRole().Equals(s))
            return true;
            return false;
        }
    }
}

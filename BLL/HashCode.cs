using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace BLL
{
    public class HashCode
    {
        private static HashCode _Instance;
        public static HashCode Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new HashCode();
                }
                return _Instance;
            }
            private set { } //chỉ nội bộ lớp này mới đc set dữ liệu vào
        }
        private HashCode() { }

        public string hashCode(string password)
        {
            //begin hashing
            byte[] passByte = ASCIIEncoding.ASCII.GetBytes(password); //convert s (string) to byte
            byte[] hashPassByte = new MD5CryptoServiceProvider().ComputeHash(passByte);//Hash: Returns is an array of numbers
            string hashPassStr = "";
            foreach (byte item in hashPassByte)
            {
                hashPassStr += item;
            }
            //end hashing: password after hash is hashPassStr
            return hashPassStr;
        }
    }
}

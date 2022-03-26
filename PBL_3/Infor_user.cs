using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_3
{
    internal class Infor_user
    {
        private int _id;
        public int ID { get { return _id; } set { _id = value; } }
        private string _US;
        public string US { get { return _US; } set { _US = value; } }
        private string _PW;
        public string PW { get { return _PW; } set { _PW = value; } }
        private string _phoneNumber;
        public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }
        private string _address;
        public string Address { get { return _address; } set { _address = value; } }
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }
        private string _position;
        public string Position { get { return _position; } set { _position = value; } }
        private DateTime _birthday;
        public DateTime Birthday { get { return _birthday; } set { _birthday = value; } }
        private string _email;
        public string Email { get { return _email; } set { _email = value; } }

        public Infor_user(int id, string us, string pw, string name, DateTime bd, string ad, string pn, string po)
        {
            ID = id;
            US = us;
            PW = pw;
            Name = name;
            Birthday = bd;
            Address = ad;
            PhoneNumber = pn;
            Position = po;
        }

        public Infor_user() { }
        public bool checkPass(string confirmPass)
        {
            return PW.Equals(confirmPass);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_3
{
    public class Account
    {
       
        private string _US;
        public string US { get { return _US; } set { _US = value; } }
        private string _PW;
        public string PW { get { return _PW; } set { _PW = value; } }
        private string _phoneNumber;
        //public string PhoneNumber { get { return _phoneNumber; } set { _phoneNumber = value; } }
        //private string _address;
        //public string Address { get { return _address; } set { _address = value; } }
        //private string _name;
        //public string Name { get { return _name; } set { _name = value; } }
        //private string _role;
        //public string Role { get { return _role; } set { _role = value; } }
        //private DateTime _birthday;
        //public DateTime Birthday { get { return _birthday; } set { _birthday = value; } }

        //private string _email;
        //public string Email { get { return _email; } set { _email = value; } }
        public Account()
        {

        }


        public Account(string us, string pw)
        {
            US = us;
            PW = pw;
            //Name = name;
            //Birthday = bd;
            //Address = ad;
            //PhoneNumber = pn;
            //Role = ro;
            //Email = em;
            //, string name, DateTime bd, string ad, string pn, string ro, string em)
        }

    }
}

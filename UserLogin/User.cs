using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public string Username
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }
        public string FacNum
        {
            get;
            set;
        }
        public UserRoles Role { get; set; }

        public DateTime Created
        {
            get;
            set;
        }

        public DateTime Valid
        {
            get;
            set;
        }

        public User()
        {

        }

        public User(string username, string password, string facNum, UserRoles role, DateTime created, DateTime valid)
        {
            Username = username;
            Password = password;
            FacNum = facNum;
            Role = role;
            Created = created;
            Valid = valid;
        }
    }
}

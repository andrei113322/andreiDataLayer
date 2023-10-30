using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User:BaseEntity
    {
        protected string userName;
        public string UserName { get { return userName; } set { userName = value; } }

        protected string firstName;
        public string FirstName { get { return firstName; } set { firstName = value; } }

        protected string secondName;
        public string SecondName { get { return secondName; } set { secondName = value; } }

        protected string password;
        public string Password { get { return password; } set { password = value; } }

        protected DateTime birthDate;
        public DateTime BirthDate { get { return birthDate; } set { birthDate = value; } }

        protected string email;
        public string Email { get { return email; } set { email = value; } }

        protected bool isAdmin;
        public bool IsAdmin { get { return isAdmin; } set { isAdmin = value; } }
    }

    public class UserList : List<User>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public UserList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public UserList(IEnumerable<User> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public UserList(IEnumerable<BaseEntity> list)
            : base(list.Cast<User>().ToList()) { }
    }

}
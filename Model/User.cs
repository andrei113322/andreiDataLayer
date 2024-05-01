using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class User : BaseEntity
    {

        public User (User user)
        {
            User newUser = new User();
            newUser.UserName = user.UserName;
            newUser.Password = user.Password;
            newUser.BirthDate = user.BirthDate;
            newUser.Email = user.Email;
            newUser.FirstName = user.FirstName;
            newUser.SecondName = user.SecondName;
            newUser.IsAdmin = user.IsAdmin;
            newUser.ID = user.ID;
        }

        public User()
        {
            
        }

        protected bool ban;
        [DataMember] public bool Ban { get { return ban; } set { ban = value; } }

        protected double volume;
        [DataMember] public double Volume { get { return volume; } set { volume = value; } }

        protected double pAndL;
        [DataMember] public double PAndL { get { return pAndL; } set { pAndL = value; } }

        protected string userName;

        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        protected string firstName;

        [DataMember]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        protected string secondName;

        [DataMember]
        public string SecondName
        {
            get { return secondName; }
            set { secondName = value; }
        }

        protected string password;

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        protected DateTime birthDate;

        [DataMember]
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }

        protected string email;

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        protected bool isAdmin;

        [DataMember]
        public bool IsAdmin
        {
            get { return isAdmin; }
            set { isAdmin = value; }
        }
    }

    [CollectionDataContract]
    public class UserList : List<User>
    {
        // Default constructor - an empty collection
        public UserList() { }

        // Conversion from a generic collection to a list of Users
        public UserList(IEnumerable<User> list)
            : base(list) { }

        // Conversion from a list of BaseEntity to UserList
        public UserList(IEnumerable<BaseEntity> list)
            : base(list.Cast<User>().ToList()) { }
    }
}
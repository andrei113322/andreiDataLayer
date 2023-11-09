using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UsersDB : BaseDB
    {
        protected override BaseEntity NewEntity()
        {
            return new User();
        }
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User user = entity as User;

            user.ID = int.Parse(reader["ID"].ToString());
            user.UserName = reader["USERNAME"].ToString();
            user.FirstName = reader["FIRSTNAME"].ToString();
            user.SecondName = reader["SECONDNAME"].ToString();
            user.Password = reader["PASSWORD"].ToString();
            user.BirthDate = DateTime.Parse(reader["BIRTHDATE"].ToString());
            user.Email = reader["EMAIL"].ToString() ;
            user.IsAdmin = Convert.ToBoolean(reader["ISADMIN"].ToString());

            return user;
        }

        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM USERS";
            UserList list = new UserList(ExecuteCommand());
            return list;
        }

        //public User SelectById(int id)
        //{
        //    command.CommandText = "SELECT * FROM USERS WHERE id=" + id;
        //    UserList list = new UserList(ExecuteCommand());
        //    if (list.Count == 0)
        //        return null;
        //    return list[0];
        //}

        public User SelectByEmail(string email)
        {
            command.CommandText = "SELECT * FROM USERS WHERE EMAIL = @Email";
            command.Parameters.AddWithValue("@Email", email);
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }

    }
}

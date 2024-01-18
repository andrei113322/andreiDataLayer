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
            user.Email = reader["EMAIL"].ToString();
            user.IsAdmin = Convert.ToBoolean(reader["ISADMIN"].ToString());

            return user;
        }

        public UserList SelectAll()
        {
            command.CommandText = "SELECT * FROM USERS";
            UserList list = new UserList(ExecuteCommand());
            return list;
        }

        public User SelectById(int id)
        {
            command.CommandText = "SELECT * FROM USERS WHERE id=" + id;
            UserList list = new UserList(ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }

        public User SelectByEmail(string email)
        {
            command.CommandText = $"SELECT * FROM USERS WHERE (EMAIL = '{email}');";
            //command.Parameters.AddWithValue("@Email", email);
            string cammand = command.CommandText;
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }

        public User SelectByUserName(string userName)
        {
            command.CommandText = $"SELECT * FROM USERS WHERE (USERNAME = '{userName}');";
            //command.Parameters.AddWithValue("@Email", email);
            string cammand = command.CommandText;
            UserList list = new UserList(base.ExecuteCommand());
            if (list.Count == 0)
                return null;
            return list[0];
        }

        public bool InsertUser(User newUser)
        {
            // Assuming you have appropriate database columns for each property
            command.CommandText = $"INSERT INTO USERS (USERNAME, FIRSTNAME, SECONDNAME, [PASSWORD], BIRTHDATE, EMAIL, ISADMIN) VALUES ('{newUser.UserName}', '{newUser.FirstName}', '{newUser.SecondName}', '{newUser.Password}', #{newUser.BirthDate}#, '{newUser.Email}', {newUser.IsAdmin})";
            string cammand = command.CommandText;

            // Execute the INSERT command
          return   base.ExecuteCRUD();
        }

        public bool UpdateUser(User updatedUser)
        {
            // Assuming you have an appropriate primary key column in your database
            command.CommandText = "UPDATE USERS SET USERNAME = @UserName, FIRSTNAME = @FirstName, SECONDNAME = @SecondName, PASSWORD = @Password, BIRTHDATE = @BirthDate, EMAIL = @Email, ISADMIN = @IsAdmin WHERE ID = @ID";

            // Add parameters to prevent SQL injection
            LoadParameters(updatedUser); 

            // Execute the UPDATE command
          return   base.ExecuteCRUD();
        }

        public bool DeleteUser(int userId)
        {
            // Assuming you have an appropriate primary key column in your database
            command.CommandText = "DELETE FROM USERS WHERE ID = @ID";

            // Add parameters to prevent SQL injection
            command.Parameters.AddWithValue("@ID", userId);

            // Execute the DELETE command
          return   base.ExecuteCRUD();
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            User user = entity as User;

            command.Parameters.AddWithValue("@UserName", user.UserName);
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@SecondName", user.SecondName);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.Parameters.AddWithValue("@BirthDate", user.BirthDate);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@IsAdmin", user.IsAdmin);
            command.Parameters.AddWithValue("@ID", user.ID);
        }
    }
}
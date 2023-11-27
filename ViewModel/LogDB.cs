using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class LogDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Log log = new Log();
            log.Time = DateTime.Parse(reader["TIME"].ToString());
            log.PAndl = float.Parse(reader["P&L"].ToString());
            log.Action = reader["ACTION"].ToString();
            log.UserId = int.Parse(reader["USERID"].ToString());
            return log;
        }

        protected override BaseEntity NewEntity()
        {
            return new Log() as BaseEntity;
        }

        public LogList SelectAll()
        {
            this.command.CommandText = "SELECT * FROM LOG";
            LogList list = new LogList(base.ExecuteCommand());
            return list;
        }

        public LogList SelectByUser(User user)
        {
            this.command.CommandText = String.Format("SELECT * FROM LOG WHERE (USERID = {0})", user.ID);
            LogList list = new LogList(base.ExecuteCommand());
            return list;
        }

        public void InsertLog(Log newLog)
        {
            // Assuming you have appropriate database columns for each property
            command.CommandText = "INSERT INTO LOG (TIME, [P&L], ACTION, USERID) VALUES (@Time, @PAndl, @Action, @UserID)";

            // Add parameters to prevent SQL injection
            command.Parameters.AddWithValue("@Time", newLog.Time);
            command.Parameters.AddWithValue("@PAndl", newLog.PAndl);
            command.Parameters.AddWithValue("@Action", newLog.Action);
            command.Parameters.AddWithValue("@UserID", newLog.UserId); // Assuming USERID is the column in your database for user ID
            // Execute the INSERT command
            base.ExecuteCRUD();
        }

        public void UpdateLog(Log updatedLog)
        {
            // Assuming you have an appropriate primary key column in your database
            command.CommandText = "UPDATE LOG SET TIME = @Time, [P&L] = @PAndl, ACTION = @Action, USERID = @UserID WHERE ID = @ID";

            // Add parameters to prevent SQL injection
            command.Parameters.AddWithValue("@Time", updatedLog.Time);
            command.Parameters.AddWithValue("@PAndl", updatedLog.PAndl);
            command.Parameters.AddWithValue("@Action", updatedLog.Action);
            command.Parameters.AddWithValue("@UserID", updatedLog.UserId);
            command.Parameters.AddWithValue("@ID", updatedLog.ID); // Assuming ID is the primary key column

            // Execute the UPDATE command
            base.ExecuteCRUD();
        }

        public void DeleteLog(int logId)
        {
            // Assuming you have an appropriate primary key column in your database
            command.CommandText = "DELETE FROM LOG WHERE ID = @ID";

            // Add parameters to prevent SQL injection
            command.Parameters.AddWithValue("@ID", logId);

            // Execute the DELETE command
            base.ExecuteCRUD();
        }
    }
}

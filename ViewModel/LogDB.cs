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
            LoadParameters(newLog);
            // Execute the INSERT command
            base.ExecuteCRUD();
        }

        public void UpdateLog(Log updatedLog)
        {
            // Assuming you have an appropriate primary key column in your database
            command.CommandText = "UPDATE LOG SET TIME = @Time, [P&L] = @PAndl, ACTION = @Action, USERID = @UserID WHERE ID = @ID";

            // Add parameters to prevent SQL injection
            LoadParameters(updatedLog);

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

        protected override void LoadParameters(BaseEntity entity)
        {
            Log log = entity as Log;

            command.Parameters.AddWithValue("@Time", log.Time);
            command.Parameters.AddWithValue("@PAndl", log.PAndl);
            command.Parameters.AddWithValue("@Action", log.Action);
            command.Parameters.AddWithValue("@UserID", log.UserId);
            command.Parameters.AddWithValue("@ID", log.ID);
        }
    }
}

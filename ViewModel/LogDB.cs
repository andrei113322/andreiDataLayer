using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    internal class LogDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Log log = new Log();
            log.Time = DateTime.Parse(reader["TIME"].ToString());
            log.PAndl = float.Parse(reader["P&L"].ToString());
            log.Action = reader["action"].ToString();
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
    }
}

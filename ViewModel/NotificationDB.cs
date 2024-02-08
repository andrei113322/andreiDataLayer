using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class NotificationDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Notification notification = new Notification();
            notification.Sender = reader["SENDER"].ToString();
            notification.Reciever = reader["RECIEVER"].ToString();
            notification.SentDate = DateTime.Parse(reader["SENTDATE"].ToString());
            notification.Data = reader["DATA"].ToString();
            throw new NotImplementedException();
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Notification notification = entity as Notification;
            command.Parameters.AddWithValue("@Sender", notification.Sender);
            command.Parameters.AddWithValue("@Reciever", notification.Reciever);
            command.Parameters.AddWithValue("@Data", notification.Data);
            command.Parameters.AddWithValue("@SentDate", notification.SentDate);
        }

        public NotificationList SelectBySender(User user)
        {
            this.command.CommandText = $"SELECT * FROM NOTIFICATIONS WHERE (SENDERID = {user.ID})";
            NotificationList list = new NotificationList(base.ExecuteCommand());
            return list;
        }


        public NotificationList SelectByReciever(User user)
        {
            this.command.CommandText = $"SELECT * FROM NOTIFICATIONS WHERE (RECIEVERID = {user.ID})";
            NotificationList list = new NotificationList(base.ExecuteCommand());
            return list;
        }

        protected override BaseEntity NewEntity()
        {
            return new Notification();
        }
    }
}

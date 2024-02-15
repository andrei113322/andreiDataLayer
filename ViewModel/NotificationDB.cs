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

            return notification;
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
            this.command.CommandText = String.Format("SELECT * FROM NOTIFICATIONS WHERE (RECIEVERID = {0})", user.ID);
            NotificationList list = new NotificationList(base.ExecuteCommand());
            return list;
        }

        protected override BaseEntity NewEntity()
        {
            return new Notification();
        }

        public bool InsertNotification(Notification notification)
        {
            command.CommandText = $"INSERT INTO NOTIFICATIONS (SENDER, RECIEVER, SENTDATE, DATA, [READ], SENDERID, RECIEVERID) VALUES ('{notification.Sender}', '{notification.Reciever}', #{notification.SentDate}#, '{notification.Data}',{true},{notification.SenderId}, {notification.RecieverId})";
            LoadParameters(notification);
            return base.ExecuteCRUD();
        }


    }
}

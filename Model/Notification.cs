using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Notification:BaseEntity
    {
        protected string sender;
        protected string reciever;
        protected DateTime sentDate;
        protected string data;
        protected int senderId;
        protected int recieverId;

        [DataMember] public string Sender { get { return sender; } set { sender = value; } }
        [DataMember] public string Reciever { get { return reciever; } set { reciever = value; } }
        [DataMember] public DateTime SentDate { get { return sentDate; } set { sentDate = value; } }
        [DataMember] public string Data { get { return data; } set { data = value; } }
        [DataMember] public int SenderId { get  {return senderId; } set { senderId = value; } }
        [DataMember] public int RecieverId { get {return recieverId; } set {recieverId = value; } }
    }

    [CollectionDataContract]
    public class NotificationList : List<Notification>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public NotificationList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public NotificationList(IEnumerable<Notification> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public NotificationList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Notification>().ToList()) { }
    }
}

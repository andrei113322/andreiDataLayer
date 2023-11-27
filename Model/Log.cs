using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Log:BaseEntity
    {
        protected DateTime time;
        [DataMember]
        public DateTime Time { get { return time; } set { time = value; } }

        protected float pAndl;
        [DataMember]
        public float PAndl { get { return pAndl; } set {pAndl = value; } }

        protected string action;
        [DataMember]
        public string Action { get { return action; } set { action = value; } }

        protected int userId;
        [DataMember]
        public int UserId { get { return userId; } set { userId = value; } }
    }

    [CollectionDataContract]
    public class LogList : List<Log>
    {
        public LogList() { } //בנאי ברירת מחדל
        public LogList(IEnumerable<Log> list) :
            base(list)
        { } //המרה של רשימת קורסים לאוסף של קורסים
        public LogList(IEnumerable<BaseEntity> list) :
            base(list.Cast<Log>().ToList())
        { } //המרה כלפי מטה מישות בסיס לרשימת קורסים

    }
}

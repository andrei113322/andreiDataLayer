using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Coin:BaseEntity
    {
        protected string name;
        [DataMember]
        public string Name { get { return name; } set { name = value; } }

        protected string symbol;
        [DataMember]
        public string Symbol { get { return symbol; } set { symbol = value; } }

        private UserList myUsers;
        [DataMember]
        public UserList Users { get { return myUsers; } set { myUsers = value; } }

    }

    [CollectionDataContract]
    public class CoinList : List<Coin>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public CoinList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public CoinList(IEnumerable<Coin> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public CoinList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Coin>().ToList()) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class MyCoin : BaseEntity
    {
        private Coin coin;
        private User user;
        public double value;

        [DataMember]
        public Coin Coin { get { return coin; } set { coin = value; } }
        [DataMember]
        public User User { get { return user; } set { user = value; } }
        [DataMember]
        public double Value{ get { return value; } set { this.value = value; } }
    }

    [CollectionDataContract]
    public class MyCoinList : List<MyCoin>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public MyCoinList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public MyCoinList(IEnumerable<MyCoin> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public MyCoinList(IEnumerable<BaseEntity> list)
            : base(list.Cast<MyCoin>().ToList()) { }
    }
}


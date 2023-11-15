using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Coin:BaseEntity
    {
        protected string name;
        public string Name { get { return name; } set { name = value; } }

        protected string symbol;
        public string Symbol { get { return symbol; } set { symbol = value; } }

        private UserList myUsers;
        public UserList Users { get { return myUsers; } set { myUsers = value; } }

    }

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Wallet:BaseEntity
    {
        protected float usdt;
        public float USDT { get { return usdt; } set { usdt = value; } }

        protected float btc;
        public float BTC { get { return btc; } set { btc = value; } }

        protected float eth;
        public float ETH { get { return eth; } set { eth = value; } }
    }

    public class WalletList : List<Wallet>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public WalletList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public WalletList(IEnumerable<Wallet> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public WalletList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Wallet>().ToList()) { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OrderHistory:BaseEntity
    {
        protected string symbol;
        public string Symbol { get { return symbol; } set { symbol = value; } }

        protected string side;
        public string Side { get { return side; } set { side = value; } }

        protected string type;
        public string Type { get { return type; } set { type = value; } }

        protected float qty;
        public float Qty { get { return qty; } set { qty = value; } }

        protected float price;
        public float Price { get { return price; } set { price = value; } }

        protected float fillPrice;
        public float FillPrice { get { return fillPrice; } set { fillPrice = value; } }

        protected string status;
        public string Status { get { return status; } set { status = value; } }

        protected DateTime placingtime;
        public DateTime Placingtime { get { return placingtime; } set { placingtime = value; } }

        protected DateTime closingTime;
        public DateTime ClosingTime { get { return closingTime; } set { closingTime = value; } }

    }

    public class OrderHistoryList : List<OrderHistory>
    {
        public OrderHistoryList() { } //בנאי ברירת מחדל
        public OrderHistoryList(IEnumerable<OrderHistory> list) :
            base(list)
        { } //המרה של רשימת קורסים לאוסף של קורסים
        public OrderHistoryList(IEnumerable<BaseEntity> list) :
            base(list.Cast<OrderHistory>().ToList())
        { } //המרה כלפי מטה מישות בסיס לרשימת קורסים

    }
}

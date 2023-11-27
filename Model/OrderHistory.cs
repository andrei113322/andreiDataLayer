using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class OrderHistory : BaseEntity
    {
        protected string symbol;

        [DataMember]
        public string Symbol
        {
            get { return symbol; }
            set { symbol = value; }
        }

        protected string side;

        [DataMember]
        public string Side
        {
            get { return side; }
            set { side = value; }
        }

        protected string type;

        [DataMember]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        protected float qty;

        [DataMember]
        public float Qty
        {
            get { return qty; }
            set { qty = value; }
        }

        protected float price;

        [DataMember]
        public float Price
        {
            get { return price; }
            set { price = value; }
        }

        protected float fillPrice;

        [DataMember]
        public float FillPrice
        {
            get { return fillPrice; }
            set { fillPrice = value; }
        }

        protected string status;

        [DataMember]
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        protected DateTime placingtime;

        [DataMember]
        public DateTime Placingtime
        {
            get { return placingtime; }
            set { placingtime = value; }
        }

        protected DateTime closingTime;

        [DataMember]
        public DateTime ClosingTime
        {
            get { return closingTime; }
            set { closingTime = value; }
        }

        protected int userId;
        [DataMember]
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }

    [CollectionDataContract]
    public class OrderHistoryList : List<OrderHistory>
    {
        public OrderHistoryList() { } // Default constructor

        public OrderHistoryList(IEnumerable<OrderHistory> list) :
            base(list)
        { } // Conversion from a list of OrderHistory to OrderHistoryList

        public OrderHistoryList(IEnumerable<BaseEntity> list) :
            base(list.Cast<OrderHistory>().ToList())
        { } // Conversion from a list of BaseEntity to OrderHistoryList
    }
}

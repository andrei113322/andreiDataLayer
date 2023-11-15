using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    internal class OrderHistoryDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            OrderHistory orderHistory = new OrderHistory();
            orderHistory.Symbol = reader["SYMBOL"].ToString();
            orderHistory.Side = reader["SIDE"].ToString();
            orderHistory.Type = reader["TYPE"].ToString();
            orderHistory.Qty = float.Parse(reader["QTY"].ToString());
            orderHistory.Price = float.Parse(reader["PRICE"].ToString());
            orderHistory.FillPrice = float.Parse(reader["FILLPRICE"].ToString());
            orderHistory.Status = reader["STATUS"].ToString();
            orderHistory.Placingtime = DateTime.Parse(reader["PLACINGTIME"].ToString());
            orderHistory.ClosingTime = DateTime.Parse(reader["CLOSINGTIME"].ToString());

            return orderHistory;
            throw new NotImplementedException();
        }

        protected override BaseEntity NewEntity()
        {
            return new OrderHistory();
        }

        public OrderHistoryList SelectAll()
        {
            this.command.CommandText = "SELECT * FROM ORDERHISTORY";
            OrderHistoryList list = new OrderHistoryList(base.ExecuteCommand());
            return list;
        }

        public OrderHistoryList SelectByUser(User user)
        {
            this.command.CommandText = String.Format("SELECT * FROM ORDERHISTORY WHERE (USERID = {0})", user.ID);
            OrderHistoryList list = new OrderHistoryList(base.ExecuteCommand());
            return list;
        }
    }
}

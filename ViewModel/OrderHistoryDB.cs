using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class OrderHistoryDB : BaseDB
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
            orderHistory.UserId = int.Parse(reader["USERID"].ToString());

            return orderHistory;
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

        public bool InsertOrderHistory(OrderHistory newOrderHistory)
        {
            // Assuming you have appropriate database columns for each property
            command.CommandText = "INSERT INTO ORDERHISTORY (SYMBOL, SIDE, TYPE, QTY, PRICE, FILLPRICE, STATUS, PLACINGTIME, CLOSINGTIME, USERID) VALUES (@Symbol, @Side, @Type, @Qty, @Price, @FillPrice, @Status, @PlacingTime, @ClosingTime, @UserID)";

            // Add parameters to prevent SQL injection
            LoadParameters(newOrderHistory);

            // Execute the INSERT command
          return   base.ExecuteCRUD();
        }

        public bool UpdateOrderHistory(OrderHistory updatedOrderHistory)
        {
            // Assuming you have an appropriate primary key column in your database
            command.CommandText = "UPDATE ORDERHISTORY SET SYMBOL = @Symbol, SIDE = @Side, TYPE = @Type, QTY = @Qty, PRICE = @Price, FILLPRICE = @FillPrice, STATUS = @Status, PLACINGTIME = @PlacingTime, CLOSINGTIME = @ClosingTime, USERID = @UserID WHERE ID = @ID";

            // Add parameters to prevent SQL injection
            LoadParameters(updatedOrderHistory);

            // Execute the UPDATE command
          return   base.ExecuteCRUD();
        }

        public bool DeleteOrderHistory(int orderHistoryId)
        {
            // Assuming you have an appropriate primary key column in your database
            command.CommandText = "DELETE FROM ORDERHISTORY WHERE ID = @ID";

            // Add parameters to prevent SQL injection
            command.Parameters.AddWithValue("@ID", orderHistoryId);

            // Execute the DELETE command
          return   base.ExecuteCRUD();
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            OrderHistory orderHistory = entity as OrderHistory;
            command.Parameters.AddWithValue("@Symbol", orderHistory.Symbol);
            command.Parameters.AddWithValue("@Side", orderHistory.Side);
            command.Parameters.AddWithValue("@Type", orderHistory.Type);
            command.Parameters.AddWithValue("@Qty", orderHistory.Qty);
            command.Parameters.AddWithValue("@Price", orderHistory.Price);
            command.Parameters.AddWithValue("@FillPrice", orderHistory.FillPrice);
            command.Parameters.AddWithValue("@Status", orderHistory.Status);
            command.Parameters.AddWithValue("@PlacingTime", orderHistory.Placingtime);
            command.Parameters.AddWithValue("@ClosingTime", orderHistory.ClosingTime);
            command.Parameters.AddWithValue("@UserID", orderHistory.UserId);
            command.Parameters.AddWithValue("@ID", orderHistory.ID);
        }
    }
}

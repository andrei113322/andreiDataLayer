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

        public void InsertOrderHistory(OrderHistory newOrderHistory)
        {
            // Assuming you have appropriate database columns for each property
            command.CommandText = "INSERT INTO ORDERHISTORY (SYMBOL, SIDE, TYPE, QTY, PRICE, FILLPRICE, STATUS, PLACINGTIME, CLOSINGTIME, USERID) VALUES (@Symbol, @Side, @Type, @Qty, @Price, @FillPrice, @Status, @PlacingTime, @ClosingTime, @UserID)";

            // Add parameters to prevent SQL injection
            command.Parameters.AddWithValue("@Symbol", newOrderHistory.Symbol);
            command.Parameters.AddWithValue("@Side", newOrderHistory.Side);
            command.Parameters.AddWithValue("@Type", newOrderHistory.Type);
            command.Parameters.AddWithValue("@Qty", newOrderHistory.Qty);
            command.Parameters.AddWithValue("@Price", newOrderHistory.Price);
            command.Parameters.AddWithValue("@FillPrice", newOrderHistory.FillPrice);
            command.Parameters.AddWithValue("@Status", newOrderHistory.Status);
            command.Parameters.AddWithValue("@PlacingTime", newOrderHistory.Placingtime);
            command.Parameters.AddWithValue("@ClosingTime", newOrderHistory.ClosingTime);
            command.Parameters.AddWithValue("@UserID", newOrderHistory.UserId);

            // Execute the INSERT command
            base.ExecuteCRUD();
        }

        public void UpdateOrderHistory(OrderHistory updatedOrderHistory)
        {
            // Assuming you have an appropriate primary key column in your database
            command.CommandText = "UPDATE ORDERHISTORY SET SYMBOL = @Symbol, SIDE = @Side, TYPE = @Type, QTY = @Qty, PRICE = @Price, FILLPRICE = @FillPrice, STATUS = @Status, PLACINGTIME = @PlacingTime, CLOSINGTIME = @ClosingTime, USERID = @UserID WHERE ID = @ID";

            // Add parameters to prevent SQL injection
            command.Parameters.AddWithValue("@Symbol", updatedOrderHistory.Symbol);
            command.Parameters.AddWithValue("@Side", updatedOrderHistory.Side);
            command.Parameters.AddWithValue("@Type", updatedOrderHistory.Type);
            command.Parameters.AddWithValue("@Qty", updatedOrderHistory.Qty);
            command.Parameters.AddWithValue("@Price", updatedOrderHistory.Price);
            command.Parameters.AddWithValue("@FillPrice", updatedOrderHistory.FillPrice);
            command.Parameters.AddWithValue("@Status", updatedOrderHistory.Status);
            command.Parameters.AddWithValue("@PlacingTime", updatedOrderHistory.Placingtime);
            command.Parameters.AddWithValue("@ClosingTime", updatedOrderHistory.ClosingTime);
            command.Parameters.AddWithValue("@UserID", updatedOrderHistory.UserId);
            command.Parameters.AddWithValue("@ID", updatedOrderHistory.ID); // Assuming ID is the primary key column

            // Execute the UPDATE command
            base.ExecuteCRUD();
        }

        public void DeleteOrderHistory(int orderHistoryId)
        {
            // Assuming you have an appropriate primary key column in your database
            command.CommandText = "DELETE FROM ORDERHISTORY WHERE ID = @ID";

            // Add parameters to prevent SQL injection
            command.Parameters.AddWithValue("@ID", orderHistoryId);

            // Execute the DELETE command
            base.ExecuteCRUD();
        }
    }
}

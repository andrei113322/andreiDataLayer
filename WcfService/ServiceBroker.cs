using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using BinanceConnector;

namespace WcfService
{
    public class ServiceBroker : IServiceBroker
    {
        public void DeleteCoin(Coin coin)
        {
            CoinDB db = new CoinDB();
            db.DeleteCoin(coin.ID);
        }

        public void DeleteLog(Log log)
        {
            LogDB db = new LogDB();
            db.DeleteLog(log.ID);
        }

        public void DeleteOrderHistory(OrderHistory orderHistory)
        {
            OrderHistoryDB db = new OrderHistoryDB();
            db.DeleteOrderHistory(orderHistory.ID);
        }

        public void DeleteUser(User user)
        {
            UsersDB db = new UsersDB();
            db.DeleteUser(user.ID);
        }

        public decimal GiveCoinValue(string Value)
        {
            Connections connections = new Connections();
            return connections.GetCriptoValue(Value);
        }

        public void InsertCoin(Coin coin)
        {
            CoinDB db = new CoinDB();
            db.InsertCoin(coin);
        }

        public void InsertLog(Log log)
        {
            LogDB db = new LogDB();
            db.InsertLog(log);
        }

        public void InsertOrderHistory(OrderHistory orderHistory)
        {
            OrderHistoryDB db = new OrderHistoryDB();
            db.InsertOrderHistory(orderHistory);
        }

        public void InsertUser(User user)
        {
            UsersDB db = new UsersDB();
            db.InsertUser(user);
        }

        public CoinList SelectAllCoins()
        {
            CoinDB db = new CoinDB();
            CoinList list = db.SelectAll();
            return list;
        }

        public LogList SelectAllLogs()
        {
            LogDB db = new LogDB();
            LogList list = db.SelectAll();
            return list;
        }

        public OrderHistoryList SelectAllOrderHistory()
        {
            OrderHistoryDB db = new OrderHistoryDB();
            OrderHistoryList list = db.SelectAll();
            return list;
        }

        public UserList SelectAllUsers()
        {
            UsersDB db = new UsersDB();
            UserList list = db.SelectAll();
            return list;
        }

        public Dictionary<Coin, double> SelectCoinByUser(User user)
        {
            CoinDB db = new CoinDB();
            Dictionary<Coin, double> list = db.SelectByUser(user);
            return list;
        }

        public LogList SelectLogByUser(User user)
        {
            LogDB db = new LogDB();
            LogList list = db.SelectByUser(user);
            return list;
        }

        public OrderHistoryList SelectOrderHistoryByUser(User user)
        {
            OrderHistoryDB db = new OrderHistoryDB();
            OrderHistoryList list = db.SelectByUser(user);
            return list;
        }

        public User SelectUserByEmail(string email)
        {
            UsersDB db = new UsersDB();
            User list = db.SelectByEmail(email);
            return list;
        }

        public User SelectUserByUserName(string userName)
        {
            UsersDB db = new UsersDB();
            User list = db.SelectByUserName(userName);
            return list;
        }

        public void UpdateCoin(Coin coin)
        {
            CoinDB db = new CoinDB();
            db.UpdateCoin(coin);
        }

        public void UpdateLog(Log log)
        {
            LogDB db = new LogDB();
            db.UpdateLog(log);
        }

        public void UpdateOrderHistory(OrderHistory orderHistory)
        {
            OrderHistoryDB db = new OrderHistoryDB();
            db.UpdateOrderHistory(orderHistory);
        }

        public void UpdateUser(User user)
        {
            UsersDB db = new UsersDB();
            db.UpdateUser(user);
        }
    }
}

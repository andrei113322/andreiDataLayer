using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using BinanceCCC;

namespace WcfService
{
    public class ServiceBroker : IServiceBroker
    {
        public bool DeleteCoin(Coin coin)
        {
            CoinDB db = new CoinDB();
            return db.DeleteCoin(coin.ID);
        }

        public bool DeleteLog(Log log)
        {
            LogDB db = new LogDB();
            return db.DeleteLog(log.ID);
        }

        public bool DeleteOrderHistory(OrderHistory orderHistory)
        {
            OrderHistoryDB db = new OrderHistoryDB();
            return db.DeleteOrderHistory(orderHistory.ID);
        }

        public bool DeleteUser(User user)
        {
            UsersDB db = new UsersDB();
            return db.DeleteUser(user.ID);
        }

        public Task<Dictionary<string, decimal>> GiveCoinValue(List<string> Value)
        {
            Connections connections = new Connections();
            return connections.GetCriptoValue(Value);
        }

        public Task<List<Decimal>> GetHistoricalClosingPrices(string symbol)
        {
            Connections connections = new Connections();
            return connections.GetHistoricalClosingPrices(symbol);
        }

        public bool InsertCoin(Coin coin)
        {
            CoinDB db = new CoinDB();
            return db.InsertCoin(coin);
        }

        public bool InsertLog(Log log)
        {
            LogDB db = new LogDB();
            return db.InsertLog(log);
        }

        public bool InsertOrderHistory(OrderHistory orderHistory)
        {
            OrderHistoryDB db = new OrderHistoryDB();
            return db.InsertOrderHistory(orderHistory);
        }

        public bool InsertUser(User user)
        {
            UsersDB db = new UsersDB();
            return db.InsertUser(user);
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

        public bool UpdateCoin(Coin coin)
        {
            CoinDB db = new CoinDB();
            return db.UpdateCoin(coin);
        }

        public bool UpdateLog(Log log)
        {
            LogDB db = new LogDB();
            return db.UpdateLog(log);
        }
        public bool UpdateOrderHistory(OrderHistory orderHistory)
        {
            OrderHistoryDB db = new OrderHistoryDB();
            return db.UpdateOrderHistory(orderHistory);
        }

        public bool UpdateUser(User user)
        {
            UsersDB db = new UsersDB();
            return db.UpdateUser(user);
        }
        public MyCoinList GetCoinsByUser(User user)
        {
            MyCoinDB myCoinDB = new MyCoinDB();
            return myCoinDB.SelectCoinsByUser(user);
        }
        public bool InsertMyCoin(MyCoin myCoin)
        {
            MyCoinDB db = new MyCoinDB();
            return db.InsertCoin(myCoin);
        }
        public bool UpdateMyCoin(MyCoin myCoin)
        {
            MyCoinDB db = new MyCoinDB();
            return db.UpdateCoin(myCoin);
        }
        public bool DeleteMyCoin(MyCoin myCoin)
        {
            MyCoinDB db = new MyCoinDB();
            return db.DeleteCoin(myCoin);
        }

        public NotificationList GetNotificationsBySender(User user)
        {
            NotificationDB notificationDB = new NotificationDB();
            return notificationDB.SelectBySender(user);
        }


        public NotificationList GetNotificationsByReciever(User user)
        {
            NotificationDB notificationDB = new NotificationDB();
            return notificationDB.SelectByReciever(user);
        }

        public bool InsertNotification(Notification notification)
        {
            NotificationDB db = new NotificationDB();
            return db.InsertNotification(notification);
        }

        public AdminList SelectAdminData()
        {
            AdminDB adminDB = new AdminDB();
            return adminDB.getAdmin();
        }

        public bool UpdateAdmin(Admin myAdmin)
        {
            AdminDB adminDB = new AdminDB();
            return adminDB.updateAdmin(myAdmin);
        }
    }
}

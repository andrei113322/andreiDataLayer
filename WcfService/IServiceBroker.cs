using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfService
{
    [ServiceContract]
    public interface IServiceBroker
    {
        [OperationContract] CoinList SelectAllCoins();
        [OperationContract] Dictionary<Coin, double> SelectCoinByUser(User user);
        [OperationContract] bool InsertCoin(Coin coin);
        [OperationContract] bool UpdateCoin(Coin coin);
        [OperationContract] bool DeleteCoin(Coin coin);

        [OperationContract] LogList SelectAllLogs();
        [OperationContract] LogList SelectLogByUser(User user);
        [OperationContract] bool InsertLog(Log log);
        [OperationContract] bool UpdateLog(Log log);
        [OperationContract] bool DeleteLog(Log log);

        [OperationContract] OrderHistoryList SelectAllOrderHistory();
        [OperationContract] OrderHistoryList SelectOrderHistoryByUser(User user);
        [OperationContract] bool InsertOrderHistory(OrderHistory orderHistory);
        [OperationContract] bool UpdateOrderHistory(OrderHistory orderHistory);
        [OperationContract] bool DeleteOrderHistory(OrderHistory orderHistory);

        [OperationContract] UserList SelectAllUsers();
        [OperationContract] User SelectUserByEmail(string email);
        [OperationContract] User SelectUserByUserName(string userName);
        [OperationContract] bool InsertUser(User user);
        [OperationContract] bool UpdateUser(User user);
        [OperationContract] bool DeleteUser(User user);


        [OperationContract] MyCoinList GetCoinsByUser(User user);
        [OperationContract] bool InsertMyCoin(MyCoin myCoin);
        [OperationContract] bool UpdateMyCoin(MyCoin myCoin);
        [OperationContract] bool DeleteMyCoin(MyCoin myCoin);
        [OperationContract] Task<Dictionary<string, decimal>> GiveCoinValue(List<string> Value);
        [OperationContract] Task<List<Decimal>> GetHistoricalClosingPrices(string symbol);
        [OperationContract] Task<Dictionary<string, decimal>> GetAllCryptos(string coinName);


        [OperationContract] NotificationList GetNotificationsBySender(User user);
        [OperationContract] NotificationList GetNotificationsByReciever(User user);
        [OperationContract] bool InsertNotification(Notification notification);

        [OperationContract] AdminList SelectAdminData();
        [OperationContract] bool UpdateAdmin(Admin myAdmin);

    }
}

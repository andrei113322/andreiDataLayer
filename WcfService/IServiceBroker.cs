﻿using Model;
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
        [OperationContract] CoinList SelectCoinByUser(User user);
        [OperationContract] void InsertCoin(Coin coin);
        [OperationContract] void UpdateCoin(Coin coin);
        [OperationContract] void DeleteCoin(Coin coin);

        [OperationContract] LogList SelectAllLogs();
        [OperationContract] LogList SelectLogByUser(User user);
        [OperationContract] void InsertLog(Log log);
        [OperationContract] void UpdateLog(Log log);
        [OperationContract] void DeleteLog(Log log);

        [OperationContract] OrderHistoryList SelectAllOrderHistory();
        [OperationContract] OrderHistoryList SelectOrderHistoryByUser(User user);
        [OperationContract] void InsertOrderHistory(OrderHistory orderHistory);
        [OperationContract] void UpdateOrderHistory(OrderHistory orderHistory);
        [OperationContract] void DeleteOrderHistory(OrderHistory orderHistory);

        [OperationContract] UserList SelectAllUsers();
        [OperationContract] User SelectUserByEmail(string email);
        [OperationContract] void InsertUser(User user);
        [OperationContract] void UpdateUser(User user);
        [OperationContract] void DeleteUser(User user);
    }
}
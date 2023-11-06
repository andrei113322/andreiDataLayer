using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class WalletDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Wallet wallet = new Wallet();

            wallet.USDT = float.Parse(reader["USDT"].ToString());
            wallet.BTC = float.Parse(reader["BTC"].ToString());
            wallet.ETH = float.Parse(reader["ETH"].ToString());

            return wallet;
        }

        protected override BaseEntity NewEntity()
        {
            return new Wallet();
        }


    }
}

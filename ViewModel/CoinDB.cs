using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    internal class CoinDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Coin coin = new Coin();
            coin.ID = (int)reader["ID"];
            coin.Name = (string)reader["NAME"];
            coin.Symbol = (string)reader["SYMBOL"];
            
            return coin;
        }

        protected override BaseEntity NewEntity()
        {
            return new Coin() as BaseEntity;
        }

        public CoinList SelectAll()
        {
            this.command.CommandText = "SELECT * FROM COINS";
            CoinList list = new CoinList(base.ExecuteCommand());
            return list;
        }

        public Coin SelectById(int id)
        {
            command.CommandText = string.Format("SELECT * FROM COINS WHERE (ID = {0})", id);
            CoinList list = new CoinList(base.ExecuteCommand());
            if (list.Count == 1)
                return list[0];
            return null;
        }

        public CoinList SelectByUser(User user)
        {
            this.command.CommandText = String.Format("SELECT * FROM WALLET INNER JOIN COINS ON WALLET.COINID = COINS.ID WHERE WALLET.USERID={0}", user.ID);
            CoinList list = new CoinList(base.ExecuteCommand());
            return list;
        }
    }
}

using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class CoinDB : BaseDB
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

        public Dictionary<Coin, double> SelectByUser(User user)
        {
            this.command.CommandText = String.Format("SELECT COINS.*, WALLET.[VALUE] FROM (COINS INNER JOIN WALLET ON COINS.ID = WALLET.COINID) WHERE (WALLET.USERID = {0})", user.ID);
            Dictionary<Coin, double> result = new Dictionary<Coin, double>();

            List<Tuple<BaseEntity, double>> tuples = base.ExecuteCommandWithValues();

            foreach (var item in tuples)
            {
                result.Add((Coin)item.Item1, item.Item2);
            }

            return result;
        }

        public bool InsertCoin(Coin newCoin)
        {
            // Assuming you have appropriate database columns for each property
            command.CommandText = "INSERT INTO COINS (NAME, SYMBOL) VALUES (@Name, @Symbol)";

            // Add parameters to prevent SQL injection
            LoadParameters(newCoin);

            // Execute the INSERT command
            return base.ExecuteCRUD();
        }

        public bool UpdateCoin(Coin updatedCoin)
        {
            // Assuming you have an appropriate primary key column in your database
            command.CommandText = "UPDATE COINS SET NAME = @Name, SYMBOL = @Symbol WHERE ID = @ID";

            // Add parameters to prevent SQL injection
            LoadParameters(updatedCoin);

            // Execute the UPDATE command
          return   base.ExecuteCRUD();
        }

        public bool DeleteCoin(int coinId)
        {
            // Assuming you have an appropriate primary key column in your database
            command.CommandText = "DELETE FROM COINS WHERE ID = @ID";

            // Add parameters to prevent SQL injection
            command.Parameters.AddWithValue("@ID", coinId);

            // Execute the DELETE command
          return   base.ExecuteCRUD();
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            Coin coin = entity as Coin;
            command.Parameters.AddWithValue("@Name", coin.Name);
            command.Parameters.AddWithValue("@Symbol", coin.Symbol);
            command.Parameters.AddWithValue("@ID", coin.ID);
        }
    }
}

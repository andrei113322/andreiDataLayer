using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class MyCoinDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            MyCoin coin = new MyCoin();
            coin.value = double.Parse(reader["VALUE"].ToString());
            CoinDB coinDB = new CoinDB();
            coin.Coin = coinDB.SelectById((int)reader["COINID"]);
            UsersDB userDB = new UsersDB();
            coin.User = userDB.SelectById((int)reader["USERID"]);
            return coin;
        }

        protected override BaseEntity NewEntity()
        {
            return new MyCoin() as BaseEntity;
        }

        public MyCoinList SelectCoinsByUser(User user)
        {
            this.command.CommandText = $"SELECT * FROM WALLET WHERE USERID={user.ID}";
            MyCoinList list = new MyCoinList(base.ExecuteCommand());
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


        public bool InsertCoin(MyCoin newCoin)
        {
            // Assuming you have appropriate database columns for each property
            command.CommandText = "INSERT INTO WALLET (USERID, COINID, VALUE) VALUES (@User, @Coin, @Value)";

            // Add parameters to prevent SQL injection
            LoadParameters(newCoin);

            // Execute the INSERT command
          return   base.ExecuteCRUD();
        }

        public bool UpdateCoin(MyCoin updatedCoin)
        {
            // Assuming you have an appropriate primary key column in your database
            command.CommandText = "UPDATE COINS SET USERID = @User, COINID = @Coin, VALUE=@Value WHERE ID = @ID";

            // Add parameters to prevent SQL injection
            LoadParameters(updatedCoin);

            // Execute the UPDATE command
          return   base.ExecuteCRUD();
        }

        public bool DeleteCoin(MyCoin coinId)
        {
            // Assuming you have an appropriate primary key column in your database
            command.CommandText = "DELETE FROM WALLET WHERE ID = @ID";

            // Add parameters to prevent SQL injection
            command.Parameters.AddWithValue("@ID", coinId);

            // Execute the DELETE command
           return   base.ExecuteCRUD();
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            MyCoin coin = entity as MyCoin;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@User", coin.User.ID);
            command.Parameters.AddWithValue("@Coin", coin.Coin.ID);
            command.Parameters.AddWithValue("@Value", coin.Value);
        }
    }
}
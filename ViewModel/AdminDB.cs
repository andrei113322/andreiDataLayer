using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class AdminDB : BaseDB
    {
        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Admin myAdmin = new Admin();
            myAdmin.Assets = double.Parse(reader["ASSETS"].ToString());
            myAdmin.Profits = double.Parse(reader["PROFITS"].ToString());
            myAdmin.Volume = double.Parse(reader["VOLUME"].ToString());
            myAdmin.Users = int.Parse(reader["USERS"].ToString());
            myAdmin.Liquidations = double.Parse(reader["LIQUIDATIONS"].ToString());
            myAdmin.OpenPositions = int.Parse(reader["OPENPOSITIONS"].ToString());
            myAdmin.Transfers = double.Parse(reader["TRANSFERS"].ToString());
            return myAdmin;
        }

        public AdminList getAdmin()
        {
            this.command.CommandText = "SELECT * FROM ADMIN";
            AdminList list = new AdminList(base.ExecuteCommand());
            return list;
        }

        public bool updateAdmin(Admin test)
        {
            this.command.CommandText = $"UPDATE ADMIN SET VOLUME = {test.Volume}, USERS = {test.Users}, ASSETS = {test.Assets}, LIQUIDATIONS = {test.Liquidations}, PROFITS = {test.Profits}, TRANSFERS = {test.Transfers}, OPENPOSITIONS = {test.OpenPositions}";

            return base.ExecuteCRUD();
        }

        protected override void LoadParameters(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        protected override BaseEntity NewEntity()
        {
            return new Admin() as BaseEntity;
        }
    }
}

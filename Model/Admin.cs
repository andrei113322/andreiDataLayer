using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [DataContract]
    public class Admin : BaseEntity
    {
        private double volume;
        private int users;
        private double assets;
        private double liquidations;
        private double profits;

        [DataMember]
        public double Volume { get { return volume; } set { volume = value; } }
        [DataMember]
        public int Users { get { return users; } set { users = value; } }
        [DataMember]
        public double Assets { get { return assets; } set { assets = value; } }
        [DataMember]
        public double Liquidations { get { return liquidations; } set {liquidations = value; } }
        [DataMember]
        public double Profits { get { return profits; } set { profits = value; } }
    }

    [CollectionDataContract]
    public class AdminList : List<Admin>
    {
        //בנאי ברירת מחדל - אוסף ריק
        public AdminList() { }
        //המרה אוסף גנרי לרשימת משתמשים
        public AdminList(IEnumerable<Admin> list)
            : base(list) { }
        //המרה מטה מטיפוס בסיס לרשימת משתמשים
        public AdminList(IEnumerable<BaseEntity> list)
            : base(list.Cast<Admin>().ToList()) { }
    }
}

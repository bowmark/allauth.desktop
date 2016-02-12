using AllAuth.Lib.Db.Sqlite;
using SQLite.Net.Attributes;

namespace AllAuth.Mobile.TestDevice.AccountModels
{
    public class Links : DbTable<Link> { }

    [Table("Links")]
    public class Link : DbRow
    {
        public string Identifier { get { return Get<string>(); } set { Set(value); } }
        //public int LinkedClientCryptoKeyId { get { return Get<int>(); } set { Set(value); } }
    }
}

using AllAuth.Lib.Db.Sqlite;
using SQLite.Net.Attributes;

namespace AllAuth.Mobile.TestDevice.AccountModels
{
    public class CryptoKeys : DbTable<CryptoKey> { }

    [Table("CryptoKeys")]
    public class CryptoKey : DbRow
    {
        public bool OwnKey { get { return Get<bool>(); } set { Set(value); } }
        public bool Trust { get { return Get<bool>(); } set { Set(value); } }
        public string PrivateKeyPem { get { return Get<string>(); } set { Set(value); } }
        public string PublicKeyPem { get { return Get<string>(); } set { Set(value); } }
        public string PublicKeyPemHash { get { return Get<string>(); } set { Set(value); } }
    }
}

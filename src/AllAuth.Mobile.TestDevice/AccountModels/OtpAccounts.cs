using AllAuth.Lib.Db.Sqlite;
using SQLite.Net.Attributes;

namespace AllAuth.Mobile.TestDevice.AccountModels
{
    public class OtpAccounts : DbTable<OtpAccount> { }

    [Table("OtpAccounts")]
    public class OtpAccount : DbRow
    {
        public string Type { get { return Get<string>(); } set { Set(value); } }
        public string Label { get { return Get<string>(); } set { Set(value); } }
        public string Issuer { get { return Get<string>(); } set { Set(value); } }
        public string Algorithm { get { return Get<string>(); } set { Set(value); } }
        public string Secret { get { return Get<string>(); } set { Set(value); } }
        public int Digits { get { return Get<int>(); } set { Set(value); } }
        public int Counter { get { return Get<int>(); } set { Set(value); } }
        public int Period { get { return Get<int>(); } set { Set(value); } }
    }
}

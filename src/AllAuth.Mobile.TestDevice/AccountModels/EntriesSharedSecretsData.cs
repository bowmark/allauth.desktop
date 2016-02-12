using AllAuth.Lib.Db.Sqlite;
using SQLite.Net.Attributes;

namespace AllAuth.Mobile.TestDevice.AccountModels
{
    public class EntriesSharedSecretsData : DbTable<EntrySharedSecretData> { }

    [Table("EntriesSharedSecretsData")]
    public class EntrySharedSecretData : DbRow
    {
        public string ShareType { get { return Get<string>(); } set { Set(value); } }
        public string Secret { get { return Get<string>(); } set { Set(value); } }
    }
}

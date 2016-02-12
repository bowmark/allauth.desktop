using AllAuth.Lib.Db.Sqlite;
using SQLite.Net.Attributes;

namespace AllAuth.Mobile.TestDevice.AccountModels
{
    public class EntriesSharedSecretsSync : DbTable<EntrySharedSecretSync> { }

    [Table("EntriesSharedSecretsSync")]
    public class EntrySharedSecretSync : DbRow
    {
        public int EntrySecretId { get { return Get<int>(); } set { Set(value); } }
    }
}

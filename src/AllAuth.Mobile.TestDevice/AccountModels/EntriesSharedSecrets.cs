using AllAuth.Lib.Db.Sqlite;
using SQLite.Net.Attributes;

namespace AllAuth.Mobile.TestDevice.AccountModels
{
    public class EntriesSharedSecrets : DbTable<EntrySharedSecret> { }

    [Table("EntriesSharedSecrets")]
    public class EntrySharedSecret : DbRow
    {
        public int EntryId { get { return Get<int>(); } set { Set(value); } }
        public string SecretIdentifier { get { return Get<string>(); } set { Set(value); } }
        public int EntrySecretDataId { get { return Get<int>(); } set { Set(value); } }
        public bool ToBeDeleted { get { return Get<bool>(); } set { Set(value); } }
    }
}

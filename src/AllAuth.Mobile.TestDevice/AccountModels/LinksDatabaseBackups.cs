using AllAuth.Lib.Db.Sqlite;
using SQLite.Net.Attributes;

namespace AllAuth.Mobile.TestDevice.AccountModels
{
    public class LinksDatabaseBackups : DbTable<LinkDatabaseBackup> { }

    [Table("LinksDatabaseBackups")]
    public class LinkDatabaseBackup : DbRow
    {
        public int LinkId { get { return Get<int>(); } set { Set(value); } }
        public string EncryptedDatabase { get { return Get<string>(); } set { Set(value); } }
    }
}

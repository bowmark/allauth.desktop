using System;
using AllAuth.Lib.Db.Sqlite;
using SQLite.Net.Attributes;

namespace AllAuth.Mobile.TestDevice.AppModels
{
    public class ServerAccounts : DbTable<ServerAccount> { }

    [Table("ServerAccounts")]
    public class ServerAccount : DbRow
    {
        public string ServerIdentifier { get { return Get<string>(); } set { Set(value); } }
        public DateTime LastBackupTime { get { return Get<DateTime>(); } set { Set(value); } }
    }
}

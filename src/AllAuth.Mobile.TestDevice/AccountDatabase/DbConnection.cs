using System;
using System.IO;
using SQLite.Net.Interop;
using SQLite.Net.Platform.Generic;

namespace AllAuth.Mobile.TestDevice.AccountDatabase
{
    internal sealed class DbConnection : AllAuth.Lib.Db.Sqlite.DbConnection
    {
        public DbConnection(string databaseFilename)
        {
            var appSettings = System.Configuration.ConfigurationManager.AppSettings;
            var dbPath = appSettings["AccountDatabasePath"].Replace("{AppDir}", AppDomain.CurrentDomain.BaseDirectory);
            DatabaseFilepath = Path.Combine(dbPath, databaseFilename + ".sqlite3");
            
            Create();
        }
        
        private void Create()
        {
            new MigrationsRunner().MigrateToLatest(this);
        }

        protected override ISQLitePlatform GetDbConnectionPlatform()
        {
            return new SQLitePlatformGeneric();
        }
    }
}

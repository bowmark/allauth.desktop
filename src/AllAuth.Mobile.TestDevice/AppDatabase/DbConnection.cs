using SQLite.Net.Interop;
using SQLite.Net.Platform.Win32;

namespace AllAuth.Mobile.TestDevice.AppDatabase
{
    internal sealed class DbConnection : AllAuth.Lib.Db.Sqlite.DbConnection
    {
        public DbConnection()
        {
            DatabaseFilepath = "_database.db3";

            Create();
        }
        
        private void Create()
        {
            new MigrationsRunner().MigrateToLatest(this);
        }

        protected override ISQLitePlatform GetDbConnectionPlatform()
        {
            return new SQLitePlatformWin32("sqlite3");
        }
    }
}

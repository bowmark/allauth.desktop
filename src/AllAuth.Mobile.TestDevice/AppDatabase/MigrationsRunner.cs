using AllAuth.Lib.Db.Sqlite;
using AllAuth.Mobile.TestDevice.AppDatabase.Migrations;
using SQLite.Net;

namespace AllAuth.Mobile.TestDevice.AppDatabase
{
    internal class MigrationsRunner : Migrator
    {
        protected override bool MigrateToVersion(SQLiteConnection dbConn, int version)
        {
            switch (version)
            {
                case 1:
                    Mig0001CreateInitialTables.Up(dbConn);
                    InsertVersion(dbConn, version, "Mig0001CreateInitialTables");
                    return true;
            }

            return false;
        }
    }
}

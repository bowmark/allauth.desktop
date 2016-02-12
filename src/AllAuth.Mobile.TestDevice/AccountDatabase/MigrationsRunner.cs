using AllAuth.Lib.Db.Sqlite;
using AllAuth.Mobile.TestDevice.AccountDatabase.Migrations;
using SQLite.Net;

namespace AllAuth.Mobile.TestDevice.AccountDatabase
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
                case 2:
                    Mig0002PendingSecretRequestsTable.Up(dbConn);
                    InsertVersion(dbConn, version, "Mig0002PendingSecretRequestsTable");
                    return true;
            }

            return false;
        }
    }
}

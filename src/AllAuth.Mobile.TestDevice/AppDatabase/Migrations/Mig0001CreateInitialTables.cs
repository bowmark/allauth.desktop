using SQLite.Net;

namespace AllAuth.Mobile.TestDevice.AppDatabase.Migrations
{
    internal static class Mig0001CreateInitialTables
    {
        public static void Up(SQLiteConnection dbConn)
        {
            var sql = "CREATE TABLE `ServerAccounts` (" +
                      "`Id` INTEGER PRIMARY KEY AUTOINCREMENT, " +
                      "`DeletedAt` DATETIME DEFAULT NULL, " +
                      "`CreatedAt` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                      "`ModifiedAt` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                      "`ServerIdentifier` STRING NOT NULL," +
                      "`LastBackupTime` DATETIME NOT NULL" +
                      ");";
            
            dbConn.Execute(sql);
        }
    }
}
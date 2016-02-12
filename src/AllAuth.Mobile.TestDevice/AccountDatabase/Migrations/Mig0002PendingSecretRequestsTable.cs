using SQLite.Net;

namespace AllAuth.Mobile.TestDevice.AccountDatabase.Migrations
{
    internal static class Mig0002PendingSecretRequestsTable
    {
        public static void Up(SQLiteConnection dbConn)
        {
            var sql = "CREATE TABLE `EntriesSharedSecretsRequests` (" +
                      "`Id` INTEGER PRIMARY KEY AUTOINCREMENT, " +
                      "`DeletedAt` DATETIME DEFAULT NULL, " +
                      "`CreatedAt` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                      "`ModifiedAt` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP," +
                      "`RequestMessageIdentifier` TEXT NOT NULL," +
                      "`ValidUntil` DATETIME NOT NULL," +
                      "`EntryId` INTEGER NOT NULL," +
                      "`EntrySecretId` INTEGER NOT NULL," +
                      "`Processed` INT NOT NULL DEFAULT 0," +
                      "`ProcessedAt` DATETIME DEFAULT NULL," +
                      "`ProcessedSuccess` INT NOT NULL DEFAULT 0" +
                      ");";

            dbConn.Execute(sql);
        }
    }
}
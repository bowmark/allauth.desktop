using SQLite.Net;

namespace AllAuth.Mobile.TestDevice.AccountDatabase.Migrations
{
    internal static class Mig0001CreateInitialTables
    {
        public static void Up(SQLiteConnection dbConn)
        {
            var sql = "CREATE TABLE `CryptoKeys` (" +
                      "`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                      "`DeletedAt` DATETIME DEFAULT NULL, " +
                      "`CreatedAt` DATETIME NOT NULL, " +
                      "`ModifiedAt` DATETIME NOT NULL, " +
                      "`OwnKey` INTEGER NOT NULL, " +
                      "`Trust` INTEGER NOT NULL, " +
                      "`PrivateKeyPem` TEXT NOT NULL, " +
                      "`PublicKeyPem` TEXT NOT NULL, " +
                      "`PublicKeyPemHash` TEXT NOT NULL" +
                      ");";
            dbConn.Execute(sql);

            sql = "CREATE TABLE `Entries` (" +
                  "`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                  "`DeletedAt` DATETIME DEFAULT NULL, " +
                  "`CreatedAt` DATETIME NOT NULL, " +
                  "`ModifiedAt` DATETIME NOT NULL, " +
                  "`Identifier` TEXT NOT NULL, " +
                  "`LinkId` TEXT NOT NULL" +
                  ");";
            dbConn.Execute(sql);

            sql = "CREATE TABLE `EntriesSharedSecrets` (" +
                  "`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                  "`DeletedAt` DATETIME DEFAULT NULL, " +
                  "`CreatedAt` DATETIME NOT NULL, " +
                  "`ModifiedAt` DATETIME NOT NULL, " +
                  "`EntryId` INTEGER NOT NULL, " +
                  "`SecretIdentifier` TEXT NOT NULL, " +
                  "`EntrySecretDataId` INTEGER NOT NULL, " +
                  "`ToBeDeleted` INTEGER NOT NULL " +
                  ");";
            dbConn.Execute(sql);

            sql = "CREATE TABLE `EntriesSharedSecretsData` (" +
                      "`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                      "`DeletedAt` DATETIME DEFAULT NULL, " +
                      "`CreatedAt` DATETIME NOT NULL, " +
                      "`ModifiedAt` DATETIME NOT NULL, " +
                      "`ShareType` TEXT NOT NULL, " +
                      "`Secret` TEXT NOT NULL" +
                      ");";
            dbConn.Execute(sql);

            sql = "CREATE TABLE `EntriesSharedSecretsSync` (" +
                  "`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                  "`DeletedAt` DATETIME DEFAULT NULL, " +
                  "`CreatedAt` DATETIME NOT NULL, " +
                  "`ModifiedAt` DATETIME NOT NULL, " +
                  "`EntrySecretId` INTEGER NOT NULL" +
                  ");";
            dbConn.Execute(sql);

            sql = "CREATE TABLE `Links` (" +
                  "`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                  "`DeletedAt` DATETIME DEFAULT NULL, " +
                  "`CreatedAt` DATETIME NOT NULL, " +
                  "`ModifiedAt` DATETIME NOT NULL, " +
                  "`Identifier` TEXT NOT NULL" +
                  ");";
            dbConn.Execute(sql);

            sql = "CREATE TABLE `OtpAccounts` (" +
                  "`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                  "`DeletedAt` DATETIME DEFAULT NULL, " +
                  "`CreatedAt` DATETIME NOT NULL, " +
                  "`ModifiedAt` DATETIME NOT NULL, " +
                  "`Type` TEXT NOT NULL, " +
                  "`Label` TEXT NOT NULL, " +
                  "`Issuer` TEXT NOT NULL, " +
                  "`Algorithm` TEXT NOT NULL, " +
                  "`Secret` TEXT NOT NULL, " +
                  "`Digits` INTEGER NOT NULL, " +
                  "`Counter` INTEGER NOT NULL, " +
                  "`Period` INTEGER NOT NULL" +
                  ");";
            dbConn.Execute(sql);

            sql = "CREATE TABLE `ServerAccountSettings` (" +
                  "`Id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, " +
                  "`DeletedAt` DATETIME DEFAULT NULL, " +
                  "`CreatedAt` DATETIME NOT NULL, " +
                  "`ModifiedAt` DATETIME NOT NULL, " +
                  "`Identifier` TEXT NOT NULL, " +
                  "`Label` TEXT NOT NULL, " +
                  "`HttpsEnabled` INTEGER NOT NULL, " +
                  "`Host` TEXT NOT NULL, " +
                  "`Port` INTEGER NOT NULL, " +
                  "`ApiVersion` INTEGER NOT NULL, " +
                  "`UserIdentifier` TEXT NOT NULL, " +
                  "`DeviceIdentifier` TEXT NOT NULL, " +
                  "`OtpAccountId` INTEGER NOT NULL, " +
                  "`ApiKey` TEXT NOT NULL, " +
                  "`EmailAddress` TEXT NOT NULL, " +
                  "`ApiCryptoKeyId` INTEGER NOT NULL, " +
                  "`LinkedDeviceCryptoKeyId` INTEGER NOT NULL," +
                  "`BackupRecoveryPasswordHashSet` INTEGER NOT NULL," +
                  "`BackupRecoveryPasswordHash` TEXT NOT NULL, " +
                  "`RecoveryRequired` INTEGER NOT NULL" +
                  ");";
            dbConn.Execute(sql);
        }
    }
}
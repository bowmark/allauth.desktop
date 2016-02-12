using AllAuth.Desktop.App;
using AllAuth.Desktop.Common.Database;
using AllAuth.Desktop.Common.Models;

namespace AllAuth.Desktop
{
    internal static class Model
    {
        public static CryptoKeys CryptoKeys;
        public static Databases Databases;
        public static DatabasesEntries DatabasesEntries;
        public static DatabasesEntriesData DatabasesEntriesData;
        public static DatabasesEntriesDataSync DatabasesEntriesDataSync;
        public static DatabasesEntriesDataVersions DatabasesEntriesDataVersions;
        public static DatabasesGroups DatabasesGroups;
        public static DatabasesGroupsMeta DatabasesGroupsMeta;
        public static DatabasesGroupsMetaSync DatabasesGroupsMetaSync;
        public static DatabasesGroupsMetaVersions DatabasesGroupsMetaVersions;
        public static DatabasesMeta DatabasesMeta;
        public static DatabasesMetaSync DatabasesMetaSync;
        public static DatabasesMetaVersions DatabasesMetaVersions;
        public static ServerAccounts ServerAccounts;
        public static ServerManagementAccounts ServerManagementAccounts;

        public static void Init()
        {
            var db = new DbConnection(Config.GetDatabasePath(), DbProtection.GetDatabaseKey());

            CryptoKeys = new CryptoKeys { Db = db };
            Databases = new Databases { Db = db };
            DatabasesEntries = new DatabasesEntries { Db = db };
            DatabasesEntriesData = new DatabasesEntriesData { Db = db };
            DatabasesEntriesDataSync = new DatabasesEntriesDataSync { Db = db };
            DatabasesEntriesDataVersions = new DatabasesEntriesDataVersions { Db = db };
            DatabasesEntries = new DatabasesEntries { Db = db };
            DatabasesGroups = new DatabasesGroups { Db = db };
            DatabasesGroupsMeta = new DatabasesGroupsMeta { Db = db };
            DatabasesGroupsMetaSync = new DatabasesGroupsMetaSync { Db = db };
            DatabasesGroupsMetaVersions = new DatabasesGroupsMetaVersions { Db = db };
            DatabasesMeta = new DatabasesMeta { Db = db };
            DatabasesMetaSync = new DatabasesMetaSync { Db = db };
            DatabasesMetaVersions = new DatabasesMetaVersions { Db = db };
            ServerAccounts = new ServerAccounts { Db = db };
            ServerManagementAccounts = new ServerManagementAccounts { Db = db };
        }
    }
}

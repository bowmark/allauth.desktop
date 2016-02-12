using System;
using AllAuth.Lib.Db;

namespace AllAuth.Desktop.Common.Models
{
    public class ServerManagementAccounts : DbTable<ServerManagementAccount> { }

    public class ServerManagementAccount : DbRow
    {
        public bool     HttpsEnabled { get { return Get<bool>(); } set { Set(value); } }
        public string   Label { get { return Get<string>(); } set { Set(value); } }
        public string   Host { get { return Get<string>(); } set { Set(value); } }
        public int      Port { get { return Get<int>(); } set { Set(value); } }
        public int      ApiVersion { get { return Get<int>(); } set { Set(value); } }
        
        public string   UserIdentifier { get { return Get<string>(); } set { Set(value); } }
        public string   EmailAddress { get { return Get<string>(); } set { Set(value); } }
        public string   ApiKey { get { return Get<string>(); } set { Set(value); } }

        public bool Subscribed { get { return Get<bool>(); } set { Set(value); } }
        public bool InTrial { get { return Get<bool>(); } set { Set(value); } }
        public DateTime? TrialEndsAt { get { return Get<DateTime?>(); } set { Set(value); } }
    }
}

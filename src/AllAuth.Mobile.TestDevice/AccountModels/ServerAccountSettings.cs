using AllAuth.Lib.Db.Sqlite;
using SQLite.Net.Attributes;

namespace AllAuth.Mobile.TestDevice.AccountModels
{
    public class ServerAccountSettings : DbTable<ServerAccountSetting> { }

    [Table("ServerAccountSettings")]
    public class ServerAccountSetting : DbRow
    {
        public string Identifier { get { return Get<string>(); } set { Set(value); } }
        public string Label { get { return Get<string>(); } set { Set(value); } }
        public bool HttpsEnabled { get { return Get<bool>(); } set { Set(value); } }
        public string Host { get { return Get<string>(); } set { Set(value); } }
        public int Port { get { return Get<int>(); } set { Set(value); } }
        public int ApiVersion { get { return Get<int>(); } set { Set(value); } }
        public string UserIdentifier { get { return Get<string>(); } set { Set(value); } }
        public string DeviceIdentifier { get { return Get<string>(); } set { Set(value); } }
        public int OtpAccountId { get { return Get<int>(); } set { Set(value); } }
        public string ApiKey { get { return Get<string>(); } set { Set(value); } }
        public int ApiCryptoKeyId { get { return Get<int>(); } set { Set(value); } }
        public string EmailAddress { get { return Get<string>(); } set { Set(value); } }
        public int LinkedDeviceCryptoKeyId { get { return Get<int>(); } set { Set(value); } }
        public bool BackupRecoveryPasswordHashSet { get { return Get<bool>(); } set { Set(value); } }
        public string BackupRecoveryPasswordHash { get { return Get<string>(); } set { Set(value); } }
        public bool RecoveryRequired { get { return Get<bool>(); } set { Set(value); } }
    }
}

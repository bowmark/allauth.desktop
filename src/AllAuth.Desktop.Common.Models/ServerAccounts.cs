using AllAuth.Lib.Db;

namespace AllAuth.Desktop.Common.Models
{
    public class ServerAccounts : DbTable<ServerAccount> { }

    public class ServerAccount : DbRow
    {
        public bool     Managed { get { return Get<bool>(); } set { Set(value); } }
        public bool     HttpsEnabled { get { return Get<bool>(); } set { Set(value); } }
        public string   ServerIdentifier { get { return Get<string>(); } set { Set(value); } }
        public string   ServerLabel { get { return Get<string>(); } set { Set(value); } }
        public string   ServerHost { get { return Get<string>(); } set { Set(value); } }
        public int      ServerPort { get { return Get<int>(); } set { Set(value); } }
        public int      ServerApiVersion { get { return Get<int>(); } set { Set(value); } }

        public string   UserIdentifier { get { return Get<string>(); } set { Set(value); } }
        public string   DeviceIdentifier { get { return Get<string>(); } set { Set(value); } }
        public string   EmailAddress { get { return Get<string>(); } set { Set(value); } }
        public string   ApiKey { get { return Get<string>(); } set { Set(value); } }
        public int      CryptoKeyId { get { return Get<int>(); } set { Set(value); } }

        public bool     LinkedDeviceSetup { get { return Get<bool>(); } set { Set(value); } }
        public int      LinkedDeviceCryptoKeyId { get { return Get<int>(); } set { Set(value); } }

        public string   BackupEncryptionPassword { get { return Get<string>(); } set { Set(value); } }
    }
}

using AllAuth.Lib.Db;

namespace AllAuth.Desktop.Common.Models
{
    public class DatabasesEntriesData : DbTable<DatabaseEntryData> { }

    public class DatabaseEntryData : DbRow
    {
        public string Name { get { return Get<string>(); } set { Set(value); } }
        public string Username { get { return Get<string>(); } set { Set(value); } }
        public string Url { get { return Get<string>(); } set { Set(value); } }
        public string Password { get { return Get<string>(); } set { Set(value); } }
        public bool   PasswordShared { get { return Get<bool>(); } set { Set(value); } }
        public string PasswordSharedIdentifier { get { return Get<string>(); } set { Set(value); } }
        public string PasswordEncryptedData { get { return Get<string>(); } set { Set(value); } }
        public string Notes { get { return Get<string>(); } set { Set(value); } }
    }
}

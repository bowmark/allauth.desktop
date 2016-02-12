using AllAuth.Lib.Db;

namespace AllAuth.Desktop.Common.Models
{
    public class DatabasesEntries : DbTable<DatabaseEntry> { }

    public class DatabaseEntry : DbRow
    {
        public int DatabaseId { get { return Get<int>(); } set { Set(value); } }
        public int DatabaseGroupId { get { return Get<int>(); } set { Set(value); } }
        public string Identifier { get { return Get<string>(); } set { Set(value); } }
        public int DatabaseEntryDataId { get { return Get<int>(); } set { Set(value); } }
        public int Version { get { return Get<int>(); } set { Set(value); } }
        public bool ToBeDeleted { get { return Get<bool>(); } set { Set(value); } }
    }
}

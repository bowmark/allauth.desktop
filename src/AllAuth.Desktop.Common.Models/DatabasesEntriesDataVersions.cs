using AllAuth.Lib.Db;

namespace AllAuth.Desktop.Common.Models
{
    public class DatabasesEntriesDataVersions : DbTable<DatabaseEntryDataVersion> { }

    public class DatabaseEntryDataVersion : DbRow
    {
        public int DatabaseEntryId { get { return Get<int>(); } set { Set(value); } }
        public int Version { get { return Get<int>(); } set { Set(value); } }
        public int DatabaseEntryDataId { get { return Get<int>(); } set { Set(value); } }
    }
}

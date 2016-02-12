using AllAuth.Lib.Db;

namespace AllAuth.Desktop.Common.Models
{
    public class DatabasesEntriesDataSync : DbTable<DatabaseEntryDataSync> { }

    public class DatabaseEntryDataSync : DbRow
    {
        public int DatabaseEntryId { get { return Get<int>(); } set { Set(value); } }
    }
}

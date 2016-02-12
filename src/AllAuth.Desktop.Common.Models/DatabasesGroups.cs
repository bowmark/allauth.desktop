using AllAuth.Lib.Db;

namespace AllAuth.Desktop.Common.Models
{
    public class DatabasesGroups : DbTable<DatabaseGroup> { }

    public class DatabaseGroup : DbRow
    {
        public int DatabaseId { get { return Get<int>(); } set { Set(value); } }
        public string Identifier { get { return Get<string>(); } set { Set(value); } }
        public int DatabaseGroupMetaId { get { return Get<int>(); } set { Set(value); } }
        public int Version { get { return Get<int>(); } set { Set(value); } }
    }
}

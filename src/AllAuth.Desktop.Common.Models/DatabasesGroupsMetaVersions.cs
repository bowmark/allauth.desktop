using AllAuth.Lib.Db;

namespace AllAuth.Desktop.Common.Models
{
    public class DatabasesGroupsMetaVersions : DbTable<DatabaseGroupMetaVersion> { }

    public class DatabaseGroupMetaVersion : DbRow
    {
        public int DatabaseGroupId { get { return Get<int>(); } set { Set(value); } }
        public int Version { get { return Get<int>(); } set { Set(value); } }
        public int DatabaseGroupMetaId { get { return Get<int>(); } set { Set(value); } }
    }
}

using AllAuth.Lib.Db;

namespace AllAuth.Desktop.Common.Models
{
    public class DatabasesGroupsMetaSync : DbTable<DatabaseGroupMetaSync> { }

    public class DatabaseGroupMetaSync : DbRow
    {
        public int DatabaseGroupId { get { return Get<int>(); } set { Set(value); } }
    }
}

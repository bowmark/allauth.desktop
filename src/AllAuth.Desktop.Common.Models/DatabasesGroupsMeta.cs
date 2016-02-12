using AllAuth.Lib.Db;

namespace AllAuth.Desktop.Common.Models
{
    public class DatabasesGroupsMeta : DbTable<DatabaseGroupMeta> { }

    public class DatabaseGroupMeta : DbRow
    {
        public string Name { get { return Get<string>(); } set { Set(value); } }
    }
}

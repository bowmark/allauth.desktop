using AllAuth.Lib.Db;

namespace AllAuth.Desktop.Common.Models
{
    public class DatabasesMeta : DbTable<DatabaseMeta> { }

    public class DatabaseMeta : DbRow
    {
        public string Name { get { return Get<string>(); } set { Set(value); } }
    }
}

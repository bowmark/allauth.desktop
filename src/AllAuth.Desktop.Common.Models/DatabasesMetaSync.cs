using AllAuth.Lib.Db;

namespace AllAuth.Desktop.Common.Models
{
    public class DatabasesMetaSync : DbTable<DatabaseMetaSync> { }

    public class DatabaseMetaSync : DbRow
    {
        public int DatabaseId { get { return Get<int>(); } set { Set(value); } }
    }
}

using AllAuth.Lib.Db;

namespace AllAuth.Desktop.Common.Models
{
    public class DatabasesMetaVersions : DbTable<DatabaseMetaVersion> { }

    public class DatabaseMetaVersion : DbRow
    {
        public int DatabaseId { get { return Get<int>(); } set { Set(value); } }
        public int Version { get { return Get<int>(); } set { Set(value); } }
        public int DatabaseMetaId { get { return Get<int>(); } set { Set(value); } }
    }
}

using AllAuth.Lib.Db;

namespace AllAuth.Desktop.Common.Models
{
    public class Databases : DbTable<Database> { }

    public class Database : DbRow
    {
        public int ServerAccountId { get { return Get<int>(); } set { Set(value); } }
        public string Identifier { get { return Get<string>(); } set { Set(value); } }
        public int DatabaseMetaId { get { return Get<int>(); } set { Set(value); } }
        public int DatabaseMetaVersion { get { return Get<int>(); } set { Set(value); } }
    }
}

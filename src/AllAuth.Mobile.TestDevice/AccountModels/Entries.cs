using AllAuth.Lib.Db.Sqlite;
using SQLite.Net.Attributes;

namespace AllAuth.Mobile.TestDevice.AccountModels
{
    public class Entries : DbTable<Entry> { }

    [Table("Entries")]
    public class Entry : DbRow
    {
        public string Identifier { get { return Get<string>(); } set { Set(value); } }
        public int LinkId { get { return Get<int>(); } set { Set(value); } }
    }
}

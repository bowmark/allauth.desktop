using FluentMigrator;

namespace AllAuth.Desktop.Common.Database.Migrations
{
    [Migration(2)]
    public class EntryToBeDeletedCol : Migration
    {
        public override void Up()
        {
            Alter.Table("DatabasesEntries")
                .AddColumn("ToBeDeleted").AsInt32().WithDefaultValue(0);
        }

        public override void Down() { }
    }
}

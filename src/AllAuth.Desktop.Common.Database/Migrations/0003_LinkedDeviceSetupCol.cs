using FluentMigrator;

namespace AllAuth.Desktop.Common.Database.Migrations
{
    [Migration(3)]
    public class LinkedDeviceSetupCol : Migration
    {
        public override void Up()
        {
            Alter.Table("ServerAccounts")
                .AddColumn("LinkedDeviceSetup").AsInt32().WithDefaultValue(0);
        }

        public override void Down() { }
    }
}

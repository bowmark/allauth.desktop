using FluentMigrator;

namespace AllAuth.Desktop.Common.Database.Migrations
{
    [Migration(4)]
    public class ManagementSubscription : Migration
    {
        public override void Up()
        {
            Alter.Table("ServerManagementAccounts")
                .AddColumn("Subscribed").AsInt32().WithDefaultValue(0)
                .AddColumn("InTrial").AsInt32().WithDefaultValue(0)
                .AddColumn("TrialEndsAt").AsDateTime().Nullable().WithDefaultValue(null);
        }

        public override void Down() { }
    }
}

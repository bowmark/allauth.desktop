using FluentMigrator;

namespace AllAuth.Desktop.Common.Database.Migrations
{
    [Migration(1)]
    public class CreateInitialTables : Migration
    {
        public override void Up()
        {
            Create.Table("CryptoKeys")
                .WithIdColumn().WithTimestampColumns()
                .WithColumn("OwnKey").AsInt32()
                .WithColumn("Trust").AsInt32()
                .WithColumn("PrivateKeyPem").AsString()
                .WithColumn("PublicKeyPem").AsString()
                .WithColumn("PublicKeyPemHash").AsString();

            Create.Table("Databases")
                .WithIdColumn().WithTimestampColumns()
                .WithColumn("ServerAccountId").AsInt32()
                .WithColumn("Identifier").AsString()
                .WithColumn("DatabaseMetaId").AsInt32()
                .WithColumn("DatabaseMetaVersion").AsInt32();
            
            Create.Table("DatabasesEntries")
                .WithIdColumn().WithTimestampColumns()
                .WithColumn("DatabaseId").AsInt32()
                .WithColumn("DatabaseGroupId").AsInt32()
                .WithColumn("Identifier").AsString()
                .WithColumn("DatabaseEntryDataId").AsInt32()
                .WithColumn("Version").AsInt32();

            Create.Table("DatabasesEntriesData")
                .WithIdColumn().WithTimestampColumns()
                .WithColumn("Name").AsString()
                .WithColumn("Username").AsString()
                .WithColumn("Url").AsString()
                .WithColumn("Password").AsString()
                .WithColumn("PasswordShared").AsInt32()
                .WithColumn("PasswordSharedIdentifier").AsString()
                .WithColumn("PasswordEncryptedData").AsString()
                .WithColumn("Notes").AsString();
            
            Create.Table("DatabasesEntriesDataSync")
                .WithIdColumn().WithTimestampColumns()
                .WithColumn("DatabaseEntryId").AsInt32();

            Create.Table("DatabasesEntriesDataVersions")
                .WithIdColumn().WithTimestampColumns()
                .WithColumn("DatabaseEntryId").AsInt32()
                .WithColumn("Version").AsInt32()
                .WithColumn("DatabaseEntryDataId").AsInt32();

            Create.Table("DatabasesGroups")
                .WithIdColumn().WithTimestampColumns()
                .WithColumn("DatabaseId").AsInt32()
                .WithColumn("Identifier").AsString()
                .WithColumn("DatabaseGroupMetaId").AsInt32()
                .WithColumn("Version").AsInt32();
            
            Create.Table("DatabasesGroupsMeta")
                .WithIdColumn().WithTimestampColumns()
                .WithColumn("Name").AsString();

            Create.Table("DatabasesGroupsMetaSync")
                .WithIdColumn().WithTimestampColumns()
                .WithColumn("DatabaseGroupId").AsInt32();

            Create.Table("DatabasesGroupsMetaVersions")
                .WithIdColumn().WithTimestampColumns()
                .WithColumn("DatabaseGroupId").AsInt32()
                .WithColumn("Version").AsInt32()
                .WithColumn("DatabaseGroupMetaId").AsInt32();
            
            Create.Table("DatabasesMeta")
                .WithIdColumn().WithTimestampColumns()
                .WithColumn("Name").AsString();

            Create.Table("DatabasesMetaSync")
                .WithIdColumn().WithTimestampColumns()
                .WithColumn("DatabaseId").AsInt32();

            Create.Table("DatabasesMetaVersions")
                .WithIdColumn().WithTimestampColumns()
                .WithColumn("DatabaseId").AsInt32()
                .WithColumn("Version").AsInt32()
                .WithColumn("DatabaseMetaId").AsInt32();

            Create.Table("ServerAccounts")
                .WithIdColumn().WithTimestampColumns()
                .WithColumn("Managed").AsInt32()
                .WithColumn("HttpsEnabled").AsInt32()
                .WithColumn("ServerIdentifier").AsString()
                .WithColumn("ServerLabel").AsString()
                .WithColumn("ServerHost").AsString()
                .WithColumn("ServerPort").AsInt32()
                .WithColumn("ServerApiVersion").AsInt32()
                .WithColumn("UserIdentifier").AsString()
                .WithColumn("DeviceIdentifier").AsString()
                .WithColumn("EmailAddress").AsString()
                .WithColumn("ApiKey").AsString()
                .WithColumn("CryptoKeyId").AsInt32()
                .WithColumn("LinkedDeviceCryptoKeyId").AsInt32()
                .WithColumn("BackupEncryptionPassword").AsString();

            Create.Table("ServerManagementAccounts")
                .WithIdColumn().WithTimestampColumns()
                .WithColumn("HttpsEnabled").AsInt32()
                .WithColumn("Label").AsString()
                .WithColumn("Host").AsString()
                .WithColumn("Port").AsInt32()
                .WithColumn("ApiVersion").AsInt32()
                .WithColumn("UserIdentifier").AsString()
                .WithColumn("EmailAddress").AsString()
                .WithColumn("ApiKey").AsString();
        }

        public override void Down() { }
    }
}

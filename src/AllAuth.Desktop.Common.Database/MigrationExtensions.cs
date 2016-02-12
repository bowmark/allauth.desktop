using FluentMigrator.Builders.Create.Table;

namespace AllAuth.Desktop.Common.Database
{
    public static class MigrationExtensions
    {
        public static ICreateTableColumnOptionOrWithColumnSyntax WithIdColumn(
            this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity();
        }

        public static ICreateTableColumnOptionOrWithColumnSyntax WithTimestampColumns(
            this ICreateTableWithColumnSyntax tableWithColumnSyntax)
        {
            return tableWithColumnSyntax
                .WithColumn("DeletedAt").AsDateTime().Nullable().WithDefaultValue(null)
                .WithColumn("CreatedAt").AsDateTime()
                .WithColumn("ModifiedAt").AsDateTime();
        }
    }
}

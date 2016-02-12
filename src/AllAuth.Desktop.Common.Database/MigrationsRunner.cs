using System.Reflection;
using FluentMigrator;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;

namespace AllAuth.Desktop.Common.Database
{
    public static class MigrationsRunner
    {
        public class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }
            public string ProviderSwitches { get; set; }
            public int Timeout { get; set; }
        }

        public static void MigrateToLatest(string connectionString)
        {
            // var announcer = new NullAnnouncer();
            var announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s));
            var assembly = Assembly.GetExecutingAssembly();
            
            var migrationContext = new RunnerContext(announcer)
            {
                Namespace = typeof(MigrationsRunner).Namespace + ".Migrations"
            };
            
            var options = new MigrationOptions { PreviewOnly = false, Timeout = 60 };
            var factory = new FluentMigrator.Runner.Processors.SQLite.SQLiteProcessorFactory();
            using (var processor = factory.Create(connectionString, announcer, options))
            {
                var runner = new FluentMigrator.Runner.MigrationRunner(assembly, migrationContext, processor);
                runner.MigrateUp(true);
            }
        }
    }
}

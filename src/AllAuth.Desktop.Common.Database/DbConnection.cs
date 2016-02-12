namespace AllAuth.Desktop.Common.Database
{
    public class DbConnection : Lib.Db.Connection.Sqlite.DbConnection
    {
        public DbConnection(string dbPath, string dbPassword)
        {
            var passwordConnString = "";
            if (!string.IsNullOrEmpty(dbPassword))
                passwordConnString = "Password=" + dbPassword + ";";
            
            DbConnString = "Data Source=" + dbPath + ";" + passwordConnString;
            Create();
        }

        private void Create()
        {
            MigrationsRunner.MigrateToLatest(DbConnString);
        }
    }
}

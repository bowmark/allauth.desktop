using System.Linq;
using AllAuth.Mobile.TestDevice.AppModels;

namespace AllAuth.Mobile.TestDevice
{
    internal static class AppModel
    {
        public static ServerAccounts ServerAccounts { get; private set; }

        public static void Init()
        {
            var db = new AppDatabase.DbConnection();
            var dbConn = db.Connect();

            ServerAccounts = new ServerAccounts {Db = db};
        }

        public static ServerAccount GetServerAccountForIdentifier(string identifier)
        {
            return ServerAccounts.Query().FirstOrDefault(r => r.ServerIdentifier == identifier);
        }
    }
}

using System.IO;
using AllAuth.Desktop.App;
using AllAuth.Lib.Crypto;

namespace AllAuth.Desktop
{
    internal static class DbProtection
    {
        public static string GetDatabaseKey()
        {
            if (Program.AppEnvDebug)
                return "";

            var keyPath = Config.GetDatabaseKeyPath();

            string databaseKey;
            if (!File.Exists(keyPath))
            {
                // Need to create a new key
                databaseKey = RandomUtil.GenerateDatabaseKey();
                var encryptedKey = UserDataProtection.EncryptData(databaseKey);
                File.WriteAllText(keyPath, encryptedKey);
            }
            else
            {
                var encryptedKey = File.ReadAllText(keyPath);
                databaseKey = UserDataProtection.DecryptData(encryptedKey);
            }

            return databaseKey;
        }
    }
}

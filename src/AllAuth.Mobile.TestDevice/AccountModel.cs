using System;
using System.Linq;
using System.Text.RegularExpressions;
using AllAuth.Mobile.TestDevice.AccountDatabase;
using AllAuth.Mobile.TestDevice.AccountModels;

namespace AllAuth.Mobile.TestDevice
{
    internal sealed class AccountModel
    {
        public CryptoKeys CryptoKeys { get; private set; }
        public Links Links { get; private set; }
        public LinksDatabaseBackups LinksDatabaseBackups { get; private set; }
        public Entries Entries { get; private set; }
        public EntriesSharedSecrets EntriesSharedSecrets { get; private set; }
        public EntriesSharedSecretsData EntriesSharedSecretsData { get; private set; }
        public EntriesSharedSecretsSync EntriesSharedSecretsSync { get; private set; }
        public OtpAccounts OtpAccounts { get; private set; }
        public ServerAccountSettings ServerAccountSettings { get; private set; }

        public DbConnection DbConnection { get; private set; }

        public static AccountModel GetModel(int serverAccountId)
        {
            return new AccountModel(serverAccountId);
        }

        public AccountModel(int serverAccountId)
        {
            var serverAccount = AppModel.ServerAccounts.Query().First(row => row.Id == serverAccountId);

            if (Regex.IsMatch(serverAccount.ServerIdentifier, "[^A-Za-z0-9-]"))
                throw new Exception("Unexpected server identifier format");

            DbConnection = new DbConnection("_database_account_" + serverAccount.ServerIdentifier);

            LoadModels(DbConnection);
        }

        private void LoadModels(DbConnection db)
        {
            CryptoKeys = new CryptoKeys { Db = db };
            Links = new Links { Db = db };
            LinksDatabaseBackups = new LinksDatabaseBackups { Db = db };
            Entries = new Entries { Db = db };
            EntriesSharedSecrets = new EntriesSharedSecrets { Db = db };
            EntriesSharedSecretsData = new EntriesSharedSecretsData { Db = db };
            EntriesSharedSecretsSync = new EntriesSharedSecretsSync { Db = db };
            OtpAccounts = new OtpAccounts { Db = db };
            ServerAccountSettings = new ServerAccountSettings { Db = db };
        }
    }
}

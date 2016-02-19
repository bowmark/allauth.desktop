using System;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using AllAuth.Lib;
using Gnome.Keyring;

namespace AllAuth.Desktop
{
    public static class UserDataProtection
    {
        public static string Protect(string data)
        {
            if (data.Length <= 0)
                throw new ArgumentException(nameof(data));
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                return EncryptDataDpapi(data);

            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                if (Ring.Available)
                    return SaveInGnomeKeyring(data);
            }

            // Should probably be a nicer error than this.
            throw new Exception("No supported data protection methods available");
        }
        
        private static string EncryptDataDpapi(string data)
        {
            var bytesToEncrypt = Encoding.UTF8.GetBytes(data);
            var encryptedBytes = ProtectedData.Protect(bytesToEncrypt, null, DataProtectionScope.CurrentUser);
            return Convert.ToBase64String(encryptedBytes);
        }

        private static string SaveInGnomeKeyring(string data)
        {
            Logger.Info("Gnome keyring available");
            var keyring = Ring.GetDefaultKeyring();
            if (keyring == null)
                throw new Exception("No default keyring, can't use gnome keyring");
            
            Logger.Info("Saving data into Gnome keyring: " + keyring);
            var id = Ring.CreateItem(
                keyring, ItemType.GenericSecret, "AllAuth Local Database", new Hashtable(), data, true);

            return id.ToString();
        }

        public static string Unprotect(string data)
        {
            if (data.Length <= 0)
                throw new ArgumentException(nameof(data));
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                return DecryptDataDpapi(data);

            if (Environment.OSVersion.Platform == PlatformID.Unix)
            {
                if (Ring.Available)
                    return RetrieveFromGnomeKeyring(data);
            }

            // Should probably be a nicer error than this.
            throw new Exception("No supported data protection methods available");
        }

        private static string DecryptDataDpapi(string data)
        {
            var bytesToDecrypt = Convert.FromBase64String(data);
            var decryptedBytes = ProtectedData.Unprotect(bytesToDecrypt, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(decryptedBytes);
        }
        
        private static string RetrieveFromGnomeKeyring(string data)
        {
            Logger.Info("Gnome keyring available");
            var keyring = Ring.GetDefaultKeyring();
            if (keyring == null)
                throw new Exception("No default keyring, can't use gnome keyring");

            Logger.Info("Attempting to unlock keyring " + keyring);

            Ring.Unlock(keyring, null);

            Logger.Info("Retrieving data from Gnome keyring");
            return Ring.GetItemInfo(keyring, int.Parse(data)).Secret;
        }
    }
}

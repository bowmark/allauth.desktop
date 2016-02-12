using System;
using System.Security.Cryptography;
using System.Text;
using AllAuth.Lib;

namespace AllAuth.Desktop
{
    public static class UserDataProtection
    {
        public static string EncryptData(string dataToEncrypt)
        {
            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                Logger.Warning("Unsupported platform for user data protection. Using plaintext.");
                return dataToEncrypt;
            }

            if (dataToEncrypt.Length <= 0)
                throw new ArgumentException(nameof(dataToEncrypt));
            if (dataToEncrypt == null)
                throw new ArgumentNullException(nameof(dataToEncrypt));

            var bytesToEncrypt = Encoding.UTF8.GetBytes(dataToEncrypt);
            var encryptedData = ProtectedData.Protect(bytesToEncrypt, null, DataProtectionScope.CurrentUser);

            return Convert.ToBase64String(encryptedData);
        }

        public static string DecryptData(string dataToDecrypt)
        {
            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                Logger.Warning("Unsupported platform for user data protection. Using plaintext.");
                return dataToDecrypt;
            }

            if (dataToDecrypt.Length <= 0)
                throw new ArgumentException(nameof(dataToDecrypt));
            if (dataToDecrypt == null)
                throw new ArgumentNullException(nameof(dataToDecrypt));

            var bytesToDecrypt = Convert.FromBase64String(dataToDecrypt);
            var decryptedData = ProtectedData.Unprotect(bytesToDecrypt, null, DataProtectionScope.CurrentUser);

            return Encoding.UTF8.GetString(decryptedData);
        }
    }
}

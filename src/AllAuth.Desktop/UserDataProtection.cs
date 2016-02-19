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
            if (dataToEncrypt.Length <= 0)
                throw new ArgumentException(nameof(dataToEncrypt));
            if (dataToEncrypt == null)
                throw new ArgumentNullException(nameof(dataToEncrypt));

            var bytesToEncrypt = Encoding.UTF8.GetBytes(dataToEncrypt);

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                return Convert.ToBase64String(EncryptDataDpapi(bytesToEncrypt));
            
            Logger.Warning("Unsupported platform for user data protection. Using plaintext.");
            return dataToEncrypt;
        }

        private static byte[] EncryptDataDpapi(byte[] data)
        {
            return ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
        }

        public static string DecryptData(string dataToDecrypt)
        {
            if (dataToDecrypt.Length <= 0)
                throw new ArgumentException(nameof(dataToDecrypt));
            if (dataToDecrypt == null)
                throw new ArgumentNullException(nameof(dataToDecrypt));

            var bytesToDecrypt = Convert.FromBase64String(dataToDecrypt);

            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                return Encoding.UTF8.GetString(DecryptDataDpapi(bytesToDecrypt));
            
            Logger.Warning("Unsupported platform for user data protection. Using plaintext.");
            return dataToDecrypt;
        }

        private static byte[] DecryptDataDpapi(byte[] data)
        {
            return ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
        }
    }
}

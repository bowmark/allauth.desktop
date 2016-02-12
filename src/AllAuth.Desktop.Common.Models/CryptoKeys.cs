using AllAuth.Lib.Crypto;
using AllAuth.Lib.Db;

namespace AllAuth.Desktop.Common.Models
{
    public class CryptoKeys : DbTable<CryptoKey> { }

    public class CryptoKey : DbRow
    {
        public bool OwnKey { get { return Get<bool>(); } set { Set(value); } }
        public bool Trust { get { return Get<bool>(); } set { Set(value); } }
        public string PrivateKeyPem { get { return Get<string>(); } set { Set(value); } }
        public string PublicKeyPem
        {
            get { return Get<string>(); }
            set
            {
                PublicKeyPemHash = HashUtil.Sha256(value);
                Set(value);
            }
        }
        public string PublicKeyPemHash { get { return Get<string>(); } set { Set(value); } }
    }
}

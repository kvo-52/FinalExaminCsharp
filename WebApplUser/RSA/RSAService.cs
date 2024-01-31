using System.Security.Cryptography;

namespace WebAppUser.rsa
{
    public static class RSAService
    {
        public static RSA GetPublicKey()
        {
            var key = File.ReadAllText(@"..\WebAppUser\RSA\public_key.pem");
            var rsa = RSA.Create();
            rsa.ImportFromPem(key);
            return rsa;
        }

        public static RSA GetPrivateKey()
        {
            var key = File.ReadAllText(@"..\WebAppUser\RSA\private_key.pem");
            var rsa = RSA.Create();
            rsa.ImportFromPem(key);
            return rsa;
        }
    }
}

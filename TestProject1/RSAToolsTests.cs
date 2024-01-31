using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebAppUser.Controllers;

namespace TestProject1
{
    [TestFixture]
    public class RSAToolsTests
    {
        [Test]
        public void TestDecryptMethod()
        {
            string path = ".\\WebApplUser\\rsa\\private_key.pem";
            RSA plaintext = RSATools.GetPrivateKey(path);

            Assert.NotNull(plaintext);
        }

    }
}


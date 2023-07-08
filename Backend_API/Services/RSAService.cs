using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Services
{
    public class RSAService
    {
        public static void Generator(out string PrivateKey, out string PublicKey, int keySize = 2048)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(keySize);
            PrivateKey = rsa.ToXmlString(true);
            PublicKey = rsa.ToXmlString(false);
        }

        public static string RSAEncrypt(string PublicKey, string EncryptString)
        {
            byte[] PlainTextArray;
            byte[] EncryptTextArray;
            string result;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(PublicKey);
            PlainTextArray = new UnicodeEncoding().GetBytes(EncryptString);
            EncryptTextArray = rsa.Encrypt(PlainTextArray, false);
            result = Convert.ToBase64String(EncryptTextArray);
            return result;
        }

        public static string RSADECrypt(string PrivateKey, string decryptString)
        {
            byte[] PlainTextArray;
            byte[] DecryptTextArray;
            string result;

            RSACryptoServiceProvider rSA = new RSACryptoServiceProvider();
            rSA.FromXmlString(PrivateKey);
            PlainTextArray = Convert.FromBase64String(decryptString);
            DecryptTextArray = rSA.Decrypt(PlainTextArray, false);
            result = new UnicodeEncoding().GetString(DecryptTextArray);
            return result;
        }
    }
}

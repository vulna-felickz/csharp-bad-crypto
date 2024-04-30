using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AesSample
{
    public class AesEncryption
    {
        private static string encryptionKey = "BADBADBADBADBADBADBADBAD";

        public static string EncryptData(string data)
        {
            using (SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create("AES"))
            {

                byte[] keyBytes = Encoding.ASCII.GetBytes(encryptionKey);
                algorithm.Key = keyBytes;

                var ct = algorithm.CreateEncryptor();
                byte[] encrypted = ct.TransformFinalBlock(Encoding.ASCII.GetBytes(data), 0, data.Length);

                Console.WriteLine($"Encrypted data: {Convert.ToBase64String(encrypted)}");
                return Convert.ToBase64String(encrypted);
            }
        }
        public static void DecryptData(string data)
        {
            using (SymmetricAlgorithm algorithm = SymmetricAlgorithm.Create("AES"))
            {
                byte[] keyBytes = Encoding.ASCII.GetBytes(encryptionKey);
                algorithm.Key = keyBytes;

                var ct = algorithm.CreateDecryptor();
                byte[] dataBytes = Convert.FromBase64String(data);
                byte[] decrypted = ct.TransformFinalBlock(dataBytes, 0, dataBytes.Length);

                Console.WriteLine($"Decrypted data: {Encoding.ASCII.GetString(decrypted)}");
            }
        }
    }
}
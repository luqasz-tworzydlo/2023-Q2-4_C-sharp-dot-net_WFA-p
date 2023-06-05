using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;

namespace EncryptionConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose encryption algorithm (1 for AES, 2 for DES): ");
            int algorithmChoice = Convert.ToInt32(Console.ReadLine());

            string algorithmName;
            SymmetricAlgorithm algorithm;

            if (algorithmChoice == 1)
            {
                algorithmName = "AES";
                algorithm = new AesManaged();
            }
            else
            {
                algorithmName = "DES";
                algorithm = new DESCryptoServiceProvider();
            }

            Console.WriteLine($"Selected {algorithmName} encryption algorithm");

            Console.WriteLine("Enter file path: ");
            string filePath = Console.ReadLine();

            Console.WriteLine("Enter output file path: ");
            string outputPath = Console.ReadLine();

            Console.WriteLine("Enter key: ");
            byte[] key = Convert.FromBase64String(Console.ReadLine());

            Console.WriteLine("Enter IV: ");
            byte[] iv = Convert.FromBase64String(Console.ReadLine());

            byte[] fileData = File.ReadAllBytes(filePath);
            byte[] decryptedData = DecryptData(algorithm, fileData, key, iv);

            File.WriteAllBytes(outputPath, decryptedData);

            Console.WriteLine("Decryption completed.");
        }

        static byte[] EncryptData(SymmetricAlgorithm algorithm, byte[] data)
        {
            algorithm.GenerateKey();
            algorithm.GenerateIV();

            byte[] key = algorithm.Key;
            byte[] iv = algorithm.IV;

            ICryptoTransform encryptor = algorithm.CreateEncryptor(key, iv);

            byte[] encryptedData;

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                }

                encryptedData = memoryStream.ToArray();
            }

            byte[] combinedData = new byte[key.Length + iv.Length + encryptedData.Length];

            Buffer.BlockCopy(key, 0, combinedData, 0, key.Length);
            Buffer.BlockCopy(iv, 0, combinedData, key.Length, iv.Length);
            Buffer.BlockCopy(encryptedData, 0, combinedData, key.Length + iv.Length, encryptedData.Length);

            return combinedData;
        }

        static byte[] DecryptData(SymmetricAlgorithm algorithm, byte[] data, byte[] key, byte[] iv)
        {
            byte[] encryptedData = new byte[data.Length - key.Length - iv.Length];

            Buffer.BlockCopy(data, key.Length + iv.Length, encryptedData, 0, encryptedData.Length);

            ICryptoTransform decryptor = algorithm.CreateDecryptor(key, iv);

            byte[] decryptedData;

            using (MemoryStream memoryStream = new MemoryStream(encryptedData))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader(cryptoStream))
                    {
                        decryptedData = Encoding.ASCII.GetBytes(streamReader.ReadToEnd());
                    }
                }
            }

            return decryptedData;
        }
    }
}

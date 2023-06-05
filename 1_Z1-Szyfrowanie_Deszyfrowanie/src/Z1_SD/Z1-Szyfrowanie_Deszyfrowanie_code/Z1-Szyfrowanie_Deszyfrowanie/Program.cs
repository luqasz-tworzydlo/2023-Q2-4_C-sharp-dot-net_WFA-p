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

            byte[] fileData = File.ReadAllBytes(filePath);
            byte[] encryptedData = EncryptData(algorithm, fileData);

            File.WriteAllBytes(outputPath, encryptedData);

            Console.WriteLine("Encryption completed.");
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
    }
}

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
            InstrukcjaDzialaniaProgramu();
            Console.ReadLine();
        }
        public static void InstrukcjaDzialaniaProgramu()
        {
            Console.WriteLine("\n////////// ////////// ////////// ////////// //////////\n");

            Console.WriteLine("Niniejszy program służy do szyfrowania oraz deszyfrowania tekstu plików, czyli" +
                "\n(0) przygotowanie pliku, na którym będziemy działać [np. do zaszyfrowania]" +
                "\n(1) wczytanie pliku .txt, który zawiera tekst do zaszyfrowania lub odszyfrowania" +
                "\n(1a) aby wczytać plik .txt należy podać dokładną ścieżkę do tego pliku" +
                "\n(1b) przykładowa ścieżka to: C:/Users/luqasz/Desktop/tekst.txt" +
                "\n(2) następnym krokiem jest podanie miejsca, gdzie ma być zapisany plik" +
                "\n(2a) może to być ta sama lokalizacja i ten sam plik, lecz wtedy będzie plik nadpisany" +
                "\n(2b) jeśli chcemy zapisać do innego pliku to też można, lecz także będzie on nadpisany" +
                "\n(2c) jeśli chcemy zapisać wynik działania to wtedy można stworzyć nowy plik w nowym miejscu" +
                "\n(2d) przykładowo, stworzenie nowego pliku w danym miejscu to: C:/Users/luqasz/Desktop/wynik.txt" +
                "\n(3) wybranie algorytmu szyfrującego/deszyfrującego, czyli algorytm AES bądź algorytm DES" +
                "\n(3a) algorytm AES jest bardziej bezpieczny i trudniejszy do złamania" +
                "\n(3b) algorytm DES jest którszy i też trochę prostszy do złamania" +
                "\n(4) po wybraniu algorytmu trzeba wybrać, czy chcemy szyfrować, czy deszyfrować tekst w pliku" +
                "\n(4a) po wybraniu szyfrowania będzie stworzony zaszyfrowany tekst w nowym lub istniejącym pliku" +
                "\n(4b) po wybraniu deszyfrowania będzie stworzony odszyfrowany tekst w nowym lub istniejącym pliku");

            Console.WriteLine("\n////////// ////////// ////////// ////////// //////////\n");

            Console.WriteLine("Wciśnij cokolwiek, aby kontynuować...");
            string IDP;
            IDP = Convert.ToString(Console.ReadLine());
            switch (IDP)
            {
                default:
                    SzyfrowanieDeszyfrowanieTekstuPliku(); break;
            }
        }
        public static (string, string) SzyfrowanieDeszyfrowanieTekstuPliku()
        {
            Console.WriteLine("=> Wprowadź ścieżkę pliku do wczytania ( przykładowo: C:/Users/luqasz/Desktop/tekst.txt ):");
            string SciezkaPlikuDoWczytania = Console.ReadLine();

            Console.WriteLine("\n=> Wprowadź ścieżkę pliku do zapisania ( przykładowo: C:/Users/luqasz/Desktop/wynik.txt ):");
            string SciezkaPlikuDoZapisania = Console.ReadLine();

            Console.WriteLine("\nWciśnij cokolwiek, aby przejść do wybrania algorytmu szyfrującego...");
            string IDP;
            IDP = Convert.ToString(Console.ReadLine());
            switch (IDP)
            {
                default:
                    WyborAlgorytmuAESlubDES(); break;
            }

            return (SciezkaPlikuDoWczytania, SciezkaPlikuDoZapisania);
        }
        public static SymmetricAlgorithm WyborAlgorytmuAESlubDES()
        {
            Console.WriteLine("=> Wybierz algorytm szyfrujący AES bądź DES:" +
                "\n(1) AES (aby wybrać algorytm AES wpisz AES lub nieparzystą liczbę jednocyfrową, czyli: AES, 1, 3, 5, 7 lub 9)" +
                "\n(2) DES (aby wybrać algorytm DES wpisz DES lub parzystą liczbę jednocyfrową, czyli: DES, 2, 4, 6 bądź 8)");
            string WybórAlgorytmu = Convert.ToString(Console.ReadLine());

            string NazwaAlgorytmu;
            SymmetricAlgorithm Algorytm;

            if (WybórAlgorytmu == "AES" || WybórAlgorytmu == "1" || WybórAlgorytmu == "3" || WybórAlgorytmu == "5" || WybórAlgorytmu == "7" || WybórAlgorytmu == "9")
            {
                NazwaAlgorytmu = "AES";
                Algorytm = new AesManaged();

            }
            else if (WybórAlgorytmu == "DES" || WybórAlgorytmu == "2" || WybórAlgorytmu == "4" || WybórAlgorytmu == "6" || WybórAlgorytmu == "8")
            {
                NazwaAlgorytmu = "DES";
                Algorytm = new DESCryptoServiceProvider();
            }
            else
            {
                BladPrzyWyborzeAlgorytmu();
                return null;
            }

            Console.WriteLine($"\nWybrano następujący algorytm szyfrujący: {NazwaAlgorytmu}");
            return Algorytm;

        }
        public static void BladPrzyWyborzeAlgorytmu()
        {
            Console.WriteLine("\nNie został wybrany żaden algorytm... należy powtórzyć działanie.\n");

            Console.WriteLine("Wciśnij cokolwiek w celu ponownego wybrania algorytmu...");
            string IDP;
            IDP = Convert.ToString(Console.ReadLine());
            switch (IDP)
            {
                default:
                    WyborAlgorytmuAESlubDES(); break;
            }
        }
        public static void CzySzyfrowacCzyDeszyfrowac()
        {
            SymmetricAlgorithm Algorytm = WyborAlgorytmuAESlubDES();
            (string SciezkaPlikuDoWczytania, string SciezkaPlikuDoZapisania) = SzyfrowanieDeszyfrowanieTekstuPliku();

            Console.WriteLine("=> Będziemy szyfrować czy deszyfrować następujący plik?" +
                "\n(1) Aby wykonać szyfrowanie wpisz '1' lub 'szyfr'" +
                "\n(2) Aby wykonać szyfrowanie wpisz '2' lub 'deszyfr'");
            string WyborSzyfrowaniaLubDeszyfrowania = Console.ReadLine();

            if (WyborSzyfrowaniaLubDeszyfrowania == "1" || WyborSzyfrowaniaLubDeszyfrowania == "szyfr")
            {
                if (File.Exists(SciezkaPlikuDoWczytania))
                {
                    byte[] DanePlikuDoZaszyfrowania = File.ReadAllBytes(SciezkaPlikuDoWczytania);
                    byte[] ZaszyfrowaneDanePliku = EncryptData(Algorytm, DanePlikuDoZaszyfrowania);

                    File.WriteAllBytes(SciezkaPlikuDoZapisania, ZaszyfrowaneDanePliku);

                    Console.WriteLine("Szyfrowanie zakończone sukcesem!");
                }
                else
                {
                    Console.WriteLine("\nBrak wczytanego pliku...");
                }

            }
            else if (WyborSzyfrowaniaLubDeszyfrowania == "2" || WyborSzyfrowaniaLubDeszyfrowania == "deszyfr")
            {
                if (File.Exists(SciezkaPlikuDoWczytania))
                {
                    byte[] DaneDoRozszyfrowania = File.ReadAllBytes(SciezkaPlikuDoWczytania);
                    byte[] OdszyfrowaneDanePliku = DecryptData(Algorytm, DaneDoRozszyfrowania);

                    File.WriteAllBytes(SciezkaPlikuDoZapisania, OdszyfrowaneDanePliku);

                    Console.WriteLine("Deszyfrowanie zakończone sukcesem!");
                }
                else
                {
                    Console.WriteLine("\nBrak wczytanego pliku...");
                }
            }
            else
            {
                Console.WriteLine("Brak pliku bądź nie wybrano odpowiedniej opcji...");
            }

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
        static byte[] DecryptData(SymmetricAlgorithm algorithm, byte[] combinedData)
        {
            byte[] key = new byte[algorithm.KeySize / 8];
            byte[] iv = new byte[algorithm.BlockSize / 8];
            byte[] encryptedData = new byte[combinedData.Length - key.Length - iv.Length];

            Buffer.BlockCopy(combinedData, 0, key, 0, key.Length);
            Buffer.BlockCopy(combinedData, key.Length, iv, 0, iv.Length);
            Buffer.BlockCopy(combinedData, key.Length + iv.Length, encryptedData, 0, encryptedData.Length);

            ICryptoTransform decryptor = algorithm.CreateDecryptor(key, iv);

            byte[] decryptedData;

            using (MemoryStream memoryStream = new MemoryStream(encryptedData))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    decryptedData = new byte[encryptedData.Length];
                    int bytesRead = cryptoStream.Read(decryptedData, 0, decryptedData.Length);
                    Array.Resize(ref decryptedData, bytesRead);
                }
            }

            return decryptedData;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Security.Cryptography;

//////////////////////////////////////////////////
//
// => Imię i nazwisko: Łukasz Tworzydło
// => Numer albumu: gd29623
// => Nr. kierunku: INIS4_PR2.2
// => Przedmiot: Programowanie .NET
//
//////////////////////////////////////////////////
//
// Łukasz Tworzydło - nr albumu: gd29623 [projekt nr 1]
//
//////////////////////////////////////////////////

namespace Z1_Szyfrowanie_Deszyfrowanie
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
                    WyborAlgorytmuAESlubDES(SciezkaPlikuDoWczytania, SciezkaPlikuDoZapisania); break;
            }

            return (SciezkaPlikuDoWczytania, SciezkaPlikuDoZapisania);
        }
        public static void WyborAlgorytmuAESlubDES(string SciezkaPlikuDoWczytania, string SciezkaPlikuDoZapisania)
        {
            Console.WriteLine("=> Wybierz algorytm szyfrujący AES bądź DES:" +
                "\n(1) AES (aby wybrać algorytm AES wpisz AES lub nieparzystą liczbę jednocyfrową, czyli: AES, 1, 3, 5, 7 lub 9)" +
                "\n(2) DES (aby wybrać algorytm DES wpisz DES lub parzystą liczbę jednocyfrową, czyli: DES, 2, 4, 6 bądź 8)");
            string WybórAlgorytmu = Convert.ToString(Console.ReadLine());

            string NazwaAlgorytmu;
            SymmetricAlgorithm Algorytm = null;

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
                Console.WriteLine("\nNie został wybrany żaden algorytm... należy powtórzyć działanie.\n");
                BladPrzyWyborzeAlgorytmuLubPrzyPliku();
                NazwaAlgorytmu = "";
            }

            Console.WriteLine($"\nWybrano następujący algorytm szyfrujący: {NazwaAlgorytmu}");

            Console.WriteLine("\n=> Będziemy szyfrować czy deszyfrować następujący plik?" +
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

                    Console.WriteLine("\n/// /// /// /// /// /// /// /// ///");
                    Console.WriteLine("Szyfrowanie zakończone sukcesem!");
                    Console.WriteLine("/// /// /// /// /// /// /// /// ///");
                }
                else
                {
                    Console.WriteLine("\nBrak wczytanego pliku... należy powtórzyć działanie programu\n"); BladPrzyWyborzeAlgorytmuLubPrzyPliku();
                }

            }
            else if (WyborSzyfrowaniaLubDeszyfrowania == "2" || WyborSzyfrowaniaLubDeszyfrowania == "deszyfr")
            {
                if (File.Exists(SciezkaPlikuDoWczytania))
                {
                    byte[] DaneDoRozszyfrowania = File.ReadAllBytes(SciezkaPlikuDoWczytania);
                    byte[] OdszyfrowaneDanePliku = DecryptData(Algorytm, DaneDoRozszyfrowania);

                    File.WriteAllBytes(SciezkaPlikuDoZapisania, OdszyfrowaneDanePliku);

                    Console.WriteLine("\n/// /// /// /// /// /// /// /// ///");
                    Console.WriteLine("Deszyfrowanie zakończone sukcesem!");
                    Console.WriteLine("/// /// /// /// /// /// /// /// ///");
                }
                else
                {
                    Console.WriteLine("\nBrak wczytanego pliku... należy powtórzyć działanie programu\n"); BladPrzyWyborzeAlgorytmuLubPrzyPliku();
                }
            }
            else
            {
                Console.WriteLine("Brak pliku bądź nie wybrano odpowiedniej opcji... należy powtórzyć działanie programu\n"); BladPrzyWyborzeAlgorytmuLubPrzyPliku();
            }

        }
        public static void BladPrzyWyborzeAlgorytmuLubPrzyPliku()
        {
            Console.WriteLine("Wciśnij cokolwiek w celu powtórzenia działania programu...");
            string IDP;
            IDP = Convert.ToString(Console.ReadLine());
            switch (IDP)
            {
                default:
                    InstrukcjaDzialaniaProgramu(); break;
            }
        }

        static byte[] EncryptData(SymmetricAlgorithm Algorytm, byte[] DaneDoZaszyfrowania)
        {
            Algorytm.GenerateKey();
            Algorytm.GenerateIV();

            byte[] KluczSzyfrujacy = Algorytm.Key;
            byte[] KluczaWartoscIV = Algorytm.IV;

            ICryptoTransform NarzędzieSzyfrujące = Algorytm.CreateEncryptor(KluczSzyfrujacy, KluczaWartoscIV);

            byte[] ZaszyfrowaneDanePliku;

            using (MemoryStream PrzechowywanieStrumieniaBajtow = new MemoryStream())
            {
                using (CryptoStream TransformacjeKryptograficzne = new CryptoStream(PrzechowywanieStrumieniaBajtow, NarzędzieSzyfrujące, CryptoStreamMode.Write))
                {
                    TransformacjeKryptograficzne.Write(DaneDoZaszyfrowania, 0, DaneDoZaszyfrowania.Length);
                }

                ZaszyfrowaneDanePliku = PrzechowywanieStrumieniaBajtow.ToArray();
            }

            byte[] DaneDoRozszyfrowania = new byte[KluczSzyfrujacy.Length + KluczaWartoscIV.Length + ZaszyfrowaneDanePliku.Length];

            Buffer.BlockCopy(KluczSzyfrujacy, 0, DaneDoRozszyfrowania, 0, KluczSzyfrujacy.Length);
            Buffer.BlockCopy(KluczaWartoscIV, 0, DaneDoRozszyfrowania, KluczSzyfrujacy.Length, KluczaWartoscIV.Length);
            Buffer.BlockCopy(ZaszyfrowaneDanePliku, 0, DaneDoRozszyfrowania, KluczSzyfrujacy.Length + KluczaWartoscIV.Length, ZaszyfrowaneDanePliku.Length);

            return DaneDoRozszyfrowania;
        }
        static byte[] DecryptData(SymmetricAlgorithm Algorytm, byte[] DaneDoRozszyfrowania)
        {
            byte[] KluczSzyfrujacy = new byte[Algorytm.KeySize / 8];
            byte[] KluczaWartoscIV = new byte[Algorytm.BlockSize / 8];
            byte[] ZaszyfrowaneDanePliku = new byte[DaneDoRozszyfrowania.Length - KluczSzyfrujacy.Length - KluczaWartoscIV.Length];

            Buffer.BlockCopy(DaneDoRozszyfrowania, 0, KluczSzyfrujacy, 0, KluczSzyfrujacy.Length);
            Buffer.BlockCopy(DaneDoRozszyfrowania, KluczSzyfrujacy.Length, KluczaWartoscIV, 0, KluczaWartoscIV.Length);
            Buffer.BlockCopy(DaneDoRozszyfrowania, KluczSzyfrujacy.Length + KluczaWartoscIV.Length, ZaszyfrowaneDanePliku, 0, ZaszyfrowaneDanePliku.Length);

            ICryptoTransform NarzedzieDeszyfrujace = Algorytm.CreateDecryptor(KluczSzyfrujacy, KluczaWartoscIV);

            byte[] OdszyfrowaneDanePliku;

            using (MemoryStream PrzechowywanieStrumieniaBajtow = new MemoryStream(ZaszyfrowaneDanePliku))
            {
                using (CryptoStream TransformacjeKryptograficzne = new CryptoStream(PrzechowywanieStrumieniaBajtow, NarzedzieDeszyfrujace, CryptoStreamMode.Read))
                {
                    OdszyfrowaneDanePliku = new byte[ZaszyfrowaneDanePliku.Length];
                    int DoOdczytuBajtyPliku = TransformacjeKryptograficzne.Read(OdszyfrowaneDanePliku, 0, OdszyfrowaneDanePliku.Length);
                    Array.Resize(ref OdszyfrowaneDanePliku, DoOdczytuBajtyPliku);
                }
            }

            return OdszyfrowaneDanePliku;
        }
    }
}

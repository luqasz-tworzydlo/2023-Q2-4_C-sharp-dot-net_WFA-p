using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// w celu działania niniejszego programu należy
// zainstalować dodatkowy pakiet Newtonsoft.Json
using Newtonsoft.Json;

//////////////////////////////////////////////////
//
// => Imię i nazwisko: Łukasz Tworzydło
// => Numer albumu: gd29623
// => Nr. kierunku: INIS4_PR2.2
// => Przedmiot: Programowanie .NET
//
//////////////////////////////////////////////////
//
// Łukasz Tworzydło - nr albumu: gd29623 [projekt nr 2]
//
//////////////////////////////////////////////////

namespace Z2_Serializacja_Deserializacja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JakieJestDzialanieProgramu();

            // w pierwszej kolejności tworzymy nową osobę
            // oraz przypisujemy jej konkretne wartości,
            // czyli imię, nazwisko, wiek, płeć

            Osoba Osoba = new Osoba
            {
                Imie = "Signy",
                Nazwisko = "Svfnir",
                PlecOsoby = "kobieta",
                Pochodzenie = "Skandynawia",
                WiekOsoby = 27
            };

            Console.WriteLine("---> Przed chwilą wewnątrz programu został utworzony" +
                "\nnowy obiekt Osoba wraz z jej właściwościami");

            KontynuacjaProgramu();

            // serializacja obiektu Osoba na JSON
            string JSON = JsonConvert.SerializeObject(Osoba);

            Console.WriteLine("---> Teraz nastąpi serializowanie obiektu Osoba");

            KontynuacjaProgramu();

            Console.WriteLine("=> Serializowany string JSON:");
            Console.WriteLine(JSON);

            Console.WriteLine("\n---> Kolejnym krokiem jest deserializacja," +
                "\na więc teraz nastąpi zdeserializowanie obiektu Osoba");

            KontynuacjaProgramu();

            // deserializacja stringu JSON na nowy obiekt Osoba
            Osoba ZdeserializowanaOsoba = JsonConvert.DeserializeObject<Osoba>(JSON);

            Console.WriteLine("=> Zdeserializowany obiekt Osoba");
            Console.WriteLine("(1) Imię: " + ZdeserializowanaOsoba.Imie);
            Console.WriteLine("(2) Nazwisko: " + ZdeserializowanaOsoba.Nazwisko);
            Console.WriteLine("(3) Płeć osoby: " + ZdeserializowanaOsoba.PlecOsoby);
            Console.WriteLine("(4) Pochodzenie: " + ZdeserializowanaOsoba.Pochodzenie);
            Console.WriteLine("(5) Wiek osoby: " + ZdeserializowanaOsoba.WiekOsoby);

            Console.ReadLine();
        }

        public static void JakieJestDzialanieProgramu()
        {
            Console.WriteLine("\n////////// ////////// ////////// ////////// //////////\n");

            Console.WriteLine("Niniejszy program 'Z2_Serializacja_Deserializacja' służy do:" +
                "\n(1) przedstawienia w prosty sposób działania serializacji oraz deserializacji" +
                "\n(2) wyjaśnienia w prosty sposób działania serializacji oraz deserializacji");

            Console.WriteLine("\n////////// ////////// ////////// ////////// //////////\n");

            Console.WriteLine("Wciśnij cokolwiek, aby kontynuować...");
            string IDP;
            IDP = Convert.ToString(Console.ReadLine());
            switch (IDP)
            {
                default:
                    break;
            }
        }
        public static void KontynuacjaProgramu()
        {
            Console.WriteLine("\nWciśnij cokolwiek, aby kontynuować...");
            string IDP;
            IDP = Convert.ToString(Console.ReadLine());
            switch (IDP)
            {
                default:
                    break;
            }
        }
    }
    public class Osoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string PlecOsoby { get; set; }
        public string Pochodzenie { get; set; }
        public int WiekOsoby { get; set; }
    }
}

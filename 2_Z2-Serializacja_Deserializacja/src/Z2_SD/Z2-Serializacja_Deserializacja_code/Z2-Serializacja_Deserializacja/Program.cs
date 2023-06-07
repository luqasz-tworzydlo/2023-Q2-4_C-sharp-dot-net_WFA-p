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
    public class Osoba
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string PlecOsoby { get; set; }
        public string Pochodzenie { get; set; }
        public int WiekOsoby { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
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

            // serializacja obiektu Osoba na JSON
            string JSON = JsonConvert.SerializeObject(Osoba);

            Console.WriteLine("Serializowany string JSON:");
            Console.WriteLine(JSON);

            // deserializacja stringu JSON na nowy obiekt Osoba
            Osoba ZdeserializowanaOsoba = JsonConvert.DeserializeObject<Osoba>(JSON);

            Console.WriteLine("Zdeserializowany obiekt Osoba");
            Console.WriteLine("Imię: " + ZdeserializowanaOsoba.Imie);
            Console.WriteLine("Nazwisko: " + ZdeserializowanaOsoba.Nazwisko);
            Console.WriteLine("Płeć osoby: " + ZdeserializowanaOsoba.PlecOsoby);
            Console.WriteLine("Pochodzenie: " + ZdeserializowanaOsoba.Pochodzenie);
            Console.WriteLine("Wiek osoby: " + ZdeserializowanaOsoba.WiekOsoby);

            Console.ReadLine();
        }
    }
}

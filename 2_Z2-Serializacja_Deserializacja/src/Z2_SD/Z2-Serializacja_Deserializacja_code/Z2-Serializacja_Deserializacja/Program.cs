using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Z2_Serializacja_Deserializacja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Osoba osoba = new Osoba("Dorota", 78); // utworzenie nowego obiektu Osoba

            // poniżej następuje serializacja obiektu (czyli Osoba) do pliku
            IFormatter formatowanie = new BinaryFormatter();
            Stream strumienDanych = new FileStream("osoba.bin", FileMode.Create, FileAccess.Write);
            formatowanie.Serialize(strumienDanych, osoba);
            strumienDanych.Close();

            // poniżej jest wykonana deserializacja obiektu (czyli Osoba) z pliku
            strumienDanych = new FileStream("osoba.bin", FileMode.Open, FileAccess.Read);
            Osoba deserializedPerson = (Osoba)formatowanie.Deserialize(strumienDanych);
            strumienDanych.Close();

            // poniżej jest wyświetlenie właściwości naszego desierializowanego obiektu (Osoba)
            Console.WriteLine("Imię osoby: " + deserializedPerson.Imie);
            Console.WriteLine("Wiek osoby: " + deserializedPerson.Wiek);

            Console.ReadLine();
        }
    }
    public class Osoba
    {
        public string Imie { get; set; }
        public int Wiek { get; set; }

        public Osoba(string imie, int wiek)
        {
            Imie = imie;
            Wiek = wiek;
        }
    }

}

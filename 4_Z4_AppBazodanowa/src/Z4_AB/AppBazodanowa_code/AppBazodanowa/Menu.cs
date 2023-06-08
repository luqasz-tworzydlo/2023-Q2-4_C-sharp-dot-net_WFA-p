using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using MySql.Data.MySqlClient;

////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Łukasz Tworzydło - nr albumu: gd29623 [projekt zaliczeniowy]
// Informatyka, grupa laboratoryjna: INiS4_PR2.2
// [projekt na laboratoria 'Programowanie .NET']
// <<< niniejszy program składa się z 6 obiektów >>>
//
////////////////////////////////////////////////////////////////////////////////////////////////////

namespace AppBazodanowa
{
    class C_Menu
    {
        public static void AdvActivityMenu() // główne menu programu / aplikacji
        {
            Console.WriteLine();

            int optionNumber = -1;
            Console.WriteLine("1. Dodaj nowy rekord do bazy danych do tabeli 'adv_books'");
            Console.WriteLine("2. Usuń wybrany rekord z tabeli 'adv_books' z bazy danych [niedostępne]");
            Console.WriteLine("3. Wybierz i wyświetl początki publikacji z książek dla 2018 lub 2019 roku");
            Console.WriteLine("4. Wyświetl początki publikacji wszystkich rodzajów książek z roku 2018 i 2019");
            Console.WriteLine("5. Wyświetl rodzaj ksiązki, jej początki, nazwę strony i odnośnik do strony www");
            Console.WriteLine("6. Wyświetl stronę i filmiki podróżnicze [Just Travel Today]");
            Console.WriteLine("7. Wyświetl wszystkie rodzaje oraz nazwy stron internetowych");
            Console.WriteLine("8. Wyświetl stronę wydawnictwa ADV Publishing oraz blog podróżniczy Just Travel Today");
            Console.WriteLine("9. Wpisz wartość 9, aby zakończyć program");
            Console.WriteLine();
            optionNumber = int.Parse(Console.ReadLine());
            switch (optionNumber)
            {
                default:
                    optionNumber = 9;
                    break;
                case 8:
                    D_CaseESS.ADVPublishing_JustTravelToday();
                    StartAgain();
                    break;
                case 7:
                    D_CaseESS.Type_NameOfAWebsite();
                    StartAgain();
                    break;
                case 6:
                    D_CaseESS.Website_TravelVideos();
                    StartAgain();
                    break;
                case 5:
                    E_CaseFF.Type_Since_Name_URL();
                    break;
                case 4:
                    E_CaseFF.TheBeginning();
                    StartAgain();
                    break;
                case 3:
                    F_CaseTWO.F18_F19();
                    StartAgain();
                    break;
                case 2:
                    F_CaseTWO.DeleteARecord();
                    StartAgain();
                    break;
                case 1:
                    F_CaseTWO.AddARecord();
                    StartAgain();
                    break;
            }
        }

        public static void StartAgain() // wykonanie restartu programu
        {
            Console.WriteLine("\n=> Rozpocząć ponownie działanie programu?");
            string YoN = "nie";
            {
                Console.WriteLine("tak");
                Console.WriteLine("nie");
                Console.WriteLine();
                YoN = Console.ReadLine();
                switch (YoN)
                {
                    case "nie": break;
                    case "tak": AdvActivityMenu(); break;
                }
            }
        }
    }
}

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
    public class F_CaseTWO
    {
        public static void F18_F19() // opcja nr 3 (główna) [ case no 3 (main) ]
        {
            Console.WriteLine("\n=> Wybierz rok, aby zobaczyć początki publikacji" +
                    "\n   poszczególnych rodzajów książek dla 2018 lub 2019 roku:\n");

            int option_year = 0;

            Console.WriteLine("0. Zrestartuj program");
            Console.WriteLine("1. Wybierz rok 2018");
            Console.WriteLine("2. Wybierz rok 2019");
            Console.WriteLine();
            option_year = int.Parse(Console.ReadLine());

            switch (option_year)
            {
                default:
                    option_year = 0;
                    break;
                case 1:
                    F2018();
                    break;
                case 2:
                    F2019();
                    break;
            }
        }
        public static void F2018() // opcja nr 3.1 [ case no 3.1 ]
        {
            Console.WriteLine("\n=> Początki z roku 2018:");

            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;database=5_adv_activity;user=root;password=;");
                con.Open();

                MySqlCommand cmd_c3 = new MySqlCommand("SELECT rodzaj_ksiazki FROM adv_books WHERE rok_rozpoczecia ='2018'", con);
                MySqlDataReader lc_3F1 = cmd_c3.ExecuteReader();

                while (lc_3F1.Read())
                {
                    Console.WriteLine("-> rodzaj: " + lc_3F1.GetString(0)); // wyświetlenie wszystkich rodzajów książek z 2018 roku
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public static void F2019() // opcja nr 3.2 [ case no 3.2 ]
        {
            Console.WriteLine("\n=> Początki z roku 2019:");

            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;database=5_adv_activity;user=root;password=;");
                con.Open();

                MySqlCommand cmd_c3 = new MySqlCommand("SELECT rodzaj_ksiazki FROM adv_books WHERE rok_rozpoczecia ='2019'", con);
                MySqlDataReader lc_3F2 = cmd_c3.ExecuteReader();

                while (lc_3F2.Read())
                {
                    Console.WriteLine("-> rodzaj: " + lc_3F2.GetString(0)); // wyświetlenie wszystkich rodzajów książek z 2019 roku
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public static void DeleteARecord() // opcja nr 2 [ case no 2 ]
        {
            Console.WriteLine("\n=> Niestety ta funkcja jest obecnie niedostępna :<" +
                    "\n   Kontynuuj, aby wrócić do menu oraz wybrać inną opcję");
            Console.WriteLine("\n=> Znaczy się... już nieaktualne ;P" +
                    "\n=> Niniejsza funkcja została już wprowadzona ^_^\n");

            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;port=3306;database=5_adv_activity;uid=root;");

                // usunięcie wybranego, konkretnego rekordu do tabeli 'adv_books'
                MySqlCommand stmtD = new MySqlCommand("DELETE FROM adv_books WHERE rodzaj_ksiazki = ?rodzaj_ksiazki", con);
                con.Open();

                Console.WriteLine("Wpisz kategorię ksiązek, którą chcesz usunąć [np. muzyczna]");
                string Parameter_Delete = Console.ReadLine();

                stmtD.Parameters.AddWithValue("rodzaj_ksiazki", Parameter_Delete); // dane do parametru 'rodzaj_ksiazki'
                stmtD.ExecuteNonQuery(); // usunięcie wybranego rekordu z tabeli 'adv_books' według parametru 'rodzaj_ksiazki'

                Console.WriteLine("\nGratulacje! Usunąłeś/aś wybrany rekord ( " + Parameter_Delete + " ) z tabeli bazy danych! :>");
                con.Close();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public static void AddARecord() // opcja nr 1 [ case no 1 ]
        {
            Console.WriteLine("\n=> Dodaj nowy rekord do bazy danych, jeden wiersz (krotkę) do tabeli 'adv_books':\n");

            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;port=3306;database=5_adv_activity;uid=root;");

                // dodanie nowego, dowolnego rekordu do tabeli 'adv_books'
                MySqlCommand stmt1 = new MySqlCommand("INSERT INTO adv_books (rodzaj_ksiazki, autor, rok_rozpoczecia) VALUES (?rodzaj_ksiazki, ?autor, ?rok_rozpoczecia)", con);
                con.Open();

                Console.WriteLine("Wpisz kategorię ksiązek [np. muzyczna]");
                string Parameter1 = Console.ReadLine();

                Console.WriteLine("Wpisz autora ksiązek [czyli imię + nazwisko]");
                string Parameter2 = Console.ReadLine();

                Console.WriteLine("Wpisz rok rozpoczęcia niniejszej kategorii książek [np. 2012]");
                string Parameter3 = Console.ReadLine();

                stmt1.Parameters.AddWithValue("rodzaj_ksiazki", Parameter1); // dane do parametru 'rodzaj_ksiazki'
                stmt1.Parameters.AddWithValue("autor", Parameter2); // dane do parametru 'autor'
                stmt1.Parameters.AddWithValue("rok_rozpoczecia", Parameter3); // dane do parametru 'rok_rozpoczecia'
                stmt1.ExecuteNonQuery(); // wpisanie nowego rekordu do tabeli

                Console.WriteLine("\nGratulacje! Wprowadziłeś/aś nowy rekord do tabeli bazy danych! :>");
                con.Close();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}

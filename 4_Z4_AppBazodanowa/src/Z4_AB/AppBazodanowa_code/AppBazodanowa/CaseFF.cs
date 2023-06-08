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
    public class E_CaseFF
    {
        public static void Type_Since_Name_URL() // opcja nr 5 (główna) [ case no 5 (main) ]
        {
            Console.WriteLine("\n=> Wybierz numer od 1 do 5 w celu wybrania rodzaju ksiązki, aby wyświetlić" +
                    "\n   jej nazwę, początki, nazwę strony i odnośnik do strony www:\n");
            int option_case = 0;

            Console.WriteLine("0. Wybierz 0, aby zresetować program");
            Console.WriteLine("1. Wybierz i wyświetl rodzaj 'muzyczna'");
            Console.WriteLine("2. Wybierz i wyświetl rodzaj 'edukacyjna'");
            Console.WriteLine("3. Wybierz i wyświetl rodzaj 'naukowa'");
            Console.WriteLine("4. Wybierz i wyświetl rodzaj 'religijna'");
            Console.WriteLine("5. Wybierz i wyświetl rodzaj 'projektowa'");
            Console.WriteLine();
            option_case = int.Parse(Console.ReadLine());

            switch (option_case)
            {
                default:
                    option_case = 0;
                    C_Menu.StartAgain();
                    break;
                case 1:
                    muzyczna();
                    C_Menu.StartAgain();
                    break;
                case 2:
                    edukacyjna();
                    C_Menu.StartAgain();
                    break;
                case 3:
                    naukowa();
                    C_Menu.StartAgain();
                    break;
                case 4:
                    religijna();
                    C_Menu.StartAgain();
                    break;
                case 5:
                    projektowa();
                    C_Menu.StartAgain();
                    break;
            }
        }

        // przy opcji nr 5.1, 5.2, 5.3 [ case no 5.1, 5.2, 5.3 ]
        // wykonano wykonanie każdych instrukcji w pętli while
        // [ wykonano optymalizację kodu poprzez pętlę while ]

        // przy opcji nr 5.4 [ case no 5.4 ]
        // wykonano wykonanie każdych instrukcji
        // w sposób tradycyjny [jedno za drugim]

        // przy opcji nr 5.5 [ case no 5.5 ]
        // wykonano wykonanie każdych instrukcji
        // wraz ze zastosowaniem pętli while

        public static void muzyczna() // opcja nr 5.1 [ case no 5.1 ]
        {
            Console.WriteLine();

            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=5_adv_activity;");
                con.Open();

                MySqlCommand cmdC5C1 = new MySqlCommand(@"SELECT adv_books.rodzaj_ksiazki, adv_books.rok_rozpoczecia, adv_websites.nazwa_strony,
                adv_websites.strona_www FROM adv_books JOIN adv_websites ON adv_books.autor = adv_websites.tworca_strony
                WHERE adv_books.rodzaj_ksiazki = 'muzyczna' AND adv_websites.rodzaj_strony = 'muzyczna'", con);

                MySqlDataReader reader = cmdC5C1.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("-> rodzaj: " + reader.GetString(0)); // wyświetlenie rodzaju ksiązki
                    Console.WriteLine("-> początki: " + reader.GetString(1)); // wyświetlenie roku rozpoczęcia
                    Console.WriteLine("-> nazwa strony: " + reader.GetString(2)); // wyświetlenie nazwy strony internetowej
                    Console.WriteLine("-> odnośnik do strony: " + reader.GetString(3)); // wyświetlenie odnośnika do strony internetowej
                }
                reader.Close();
                con.Close();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public static void edukacyjna() // opcja nr 5.2 [ case no 5.2 ]
        {
            Console.WriteLine();
            try
            {
                using (var con = new MySqlConnection("server=localhost;database=5_adv_activity;user=root;password="))
                {
                    con.Open();

                    using (var cmd = new MySqlCommand(@"SELECT adv_books.rodzaj_ksiazki, adv_books.rok_rozpoczecia, adv_websites.nazwa_strony,
                                                   adv_websites.strona_www FROM adv_books JOIN adv_websites ON adv_books.autor = adv_websites.tworca_strony
                                                   WHERE adv_books.rodzaj_ksiazki = 'edukacyjna' AND adv_websites.rodzaj_strony = 'edukacyjna'", con))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("-> rodzaj: " + reader.GetString(0)); // wyświetlenie rodzaju ksiązki
                                Console.WriteLine("-> początki: " + reader.GetString(1)); // wyświetlenie roku rozpoczęcia
                                Console.WriteLine("-> nazwa strony: " + reader.GetString(2)); // wyświetlenie nazwy strony internetowej
                                Console.WriteLine("-> odnośnik do strony: " + reader.GetString(3)); // wyświetlenie odnośnika do strony internetowej
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public static void naukowa() // opcja nr 5.3 [ case no 5.3 ]
        {
            Console.WriteLine();
            try
            {
                using (var con = new MySqlConnection("server=localhost;database=5_adv_activity;user=root;password="))
                {
                    con.Open();

                    using (var cmd = new MySqlCommand(@"SELECT adv_books.rodzaj_ksiazki, adv_books.rok_rozpoczecia, adv_websites.nazwa_strony,
                                                   adv_websites.strona_www FROM adv_books JOIN adv_websites ON adv_books.autor = adv_websites.tworca_strony
                                                   WHERE adv_books.rodzaj_ksiazki = 'naukowa' AND adv_websites.rodzaj_strony = 'naukowa'", con))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Console.WriteLine("-> rodzaj: " + reader.GetString(0)); // wyświetlenie rodzaju ksiązki
                                Console.WriteLine("-> początki: " + reader.GetString(1)); // wyświetlenie roku rozpoczęcia
                                Console.WriteLine("-> nazwa strony: " + reader.GetString(2)); // wyświetlenie nazwy strony internetowej
                                Console.WriteLine("-> odnośnik do strony: " + reader.GetString(3)); // wyświetlenie odnośnika do strony internetowej
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public static void religijna() // opcja nr 5.4 [ case no 5.4 ]
        {
            Console.WriteLine();
            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=5_adv_activity;port=3306;");
                con.Open();

                MySqlCommand stmt_c5c4 = new MySqlCommand("", con);

                string query = @"SELECT adv_books.rodzaj_ksiazki, adv_books.rok_rozpoczecia, adv_websites.nazwa_strony,
                            adv_websites.strona_www FROM adv_books JOIN adv_websites ON adv_books.autor = adv_websites.tworca_strony
                            WHERE adv_books.rodzaj_ksiazki = 'religijna' AND adv_websites.rodzaj_strony = 'religijna'";

                stmt_c5c4.CommandText = query;
                MySqlDataReader lc_5c4a = stmt_c5c4.ExecuteReader();
                while (lc_5c4a.Read()) Console.WriteLine("-> rodzaj: " + lc_5c4a.GetString(0)); // wyświetlenie rodzaju ksiązki
                lc_5c4a.Close();

                stmt_c5c4.CommandText = query;
                MySqlDataReader lc_5c4b = stmt_c5c4.ExecuteReader();
                while (lc_5c4b.Read()) Console.WriteLine("-> początki: " + lc_5c4b.GetString(1)); // wyświetlenie roku rozpoczęcia
                lc_5c4b.Close();

                stmt_c5c4.CommandText = query;
                MySqlDataReader lc_5c4c = stmt_c5c4.ExecuteReader();
                while (lc_5c4c.Read()) Console.WriteLine("-> nazwa strony: " + lc_5c4c.GetString(2)); // wyświetlenie nazwy strony internetowej
                lc_5c4c.Close();

                stmt_c5c4.CommandText = query;
                MySqlDataReader lc_5c4d = stmt_c5c4.ExecuteReader();
                while (lc_5c4d.Read()) Console.WriteLine("-> odnośnik do strony: " + lc_5c4d.GetString(3)); // wyświetlenie odnośnika do strony internetowej
                lc_5c4d.Close();

                con.Close();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static void projektowa() // opcja nr 5.5 [ case no 5.5 ]
        {
            Console.WriteLine();
            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=5_adv_activity;");
                con.Open();

                MySqlCommand cmd_c5c5 = new MySqlCommand("SELECT adv_books.rodzaj_ksiazki, adv_books.rok_rozpoczecia, adv_websites.nazwa_strony," +
                    "adv_websites.strona_www FROM adv_books JOIN adv_websites ON adv_books.autor = adv_websites.tworca_strony" +
                    " WHERE adv_books.rodzaj_ksiazki = 'projektowa' AND adv_websites.rodzaj_strony = 'projektowa'", con);

                using (MySqlDataReader lc_5c5a = cmd_c5c5.ExecuteReader())
                {
                    while (lc_5c5a.Read()) Console.WriteLine("-> rodzaj: " + lc_5c5a.GetString(0)); // wyświetlenie rodzaju ksiązki
                }

                using (MySqlDataReader lc_5c5b = cmd_c5c5.ExecuteReader())
                {
                    while (lc_5c5b.Read()) Console.WriteLine("-> początki: " + lc_5c5b.GetString(1)); // wyświetlenie roku rozpoczęcia
                }

                using (MySqlDataReader lc_5c5c = cmd_c5c5.ExecuteReader())
                {
                    while (lc_5c5c.Read()) Console.WriteLine("-> nazwa strony: " + lc_5c5c.GetString(2)); // wyświetlenie nazwy strony internetowej
                }

                using (MySqlDataReader lc_5c5d = cmd_c5c5.ExecuteReader())
                {
                    while (lc_5c5d.Read()) Console.WriteLine("-> odnośnik do strony: " + lc_5c5d.GetString(3)); // wyświetlenie odnośnika do strony internetowej
                }

                con.Close();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message, e);
            }
        }

        public static void TheBeginning() // opcja nr 4 [ case no 4 ]
        {
            Console.WriteLine("\n=> Początki publikacji wszystkich rodzajów książek z roku 2018 i 2019:\n");

            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=5_adv_activity;");
                con.Open();

                MySqlCommand cmd_c4 = new MySqlCommand("SELECT rodzaj_ksiazki, rok_rozpoczecia FROM adv_books", con);

                using (MySqlDataReader lc_4a = cmd_c4.ExecuteReader())
                {
                    while (lc_4a.Read()) Console.WriteLine("-> rodzaj: " + lc_4a.GetString(0)); // wyświetlenie wszystkich rodzajów książek
                }

                Console.WriteLine();

                using (MySqlDataReader lc_4b = cmd_c4.ExecuteReader())
                {
                    while (lc_4b.Read()) Console.WriteLine("-> początki: " + lc_4b.GetString(1)); // wyświetlenie początków danych rodzajów
                }

                con.Close();
            }
            catch (Exception e)
            {
                throw new InvalidOperationException(e.Message, e);
            }
        }
    }
}

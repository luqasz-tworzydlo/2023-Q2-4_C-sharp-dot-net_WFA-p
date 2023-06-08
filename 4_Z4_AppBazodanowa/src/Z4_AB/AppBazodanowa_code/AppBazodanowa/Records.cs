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
    public class B_Records
    {
        public static void AddNewRecords_17()
        {
            // odniesienie do lokalnej bazy danych [XAMPP]
            // oraz wywołanie bazy danych '5_adv_activity'
            string connectionString = "server=localhost;port=3306;database=5_adv_activity;uid=root;pwd=;";
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();

                // dodanie nowego rekordu do tabeli 'adv_books' [1.1]
                MySqlCommand stmt1 = new MySqlCommand("INSERT INTO adv_books (rodzaj_ksiazki, autor, rok_rozpoczecia) VALUES (?, ?, ?)", con);
                stmt1.Parameters.AddWithValue("1", "muzyczna");
                stmt1.Parameters.AddWithValue("2", "Łukasz Wojciech M. Tworzydło");
                stmt1.Parameters.AddWithValue("3", "2018");
                stmt1.ExecuteNonQuery();

                // dodanie nowego rekordu do tabeli 'adv_books' [1.2]
                MySqlCommand stmt2 = new MySqlCommand("INSERT INTO adv_books (rodzaj_ksiazki, autor, rok_rozpoczecia) VALUES (?, ?, ?)", con);
                stmt2.Parameters.AddWithValue("1", "edukacyjna");
                stmt2.Parameters.AddWithValue("2", "Łukasz Wojciech M. Tworzydło");
                stmt2.Parameters.AddWithValue("3", "2019");
                stmt2.ExecuteNonQuery();

                // dodanie nowego rekordu do tabeli 'adv_books' [1.3]
                MySqlCommand stmt3 = new MySqlCommand("INSERT INTO adv_books (rodzaj_ksiazki, autor, rok_rozpoczecia) VALUES (?, ?, ?)", con);
                stmt3.Parameters.AddWithValue("1", "naukowa");
                stmt3.Parameters.AddWithValue("2", "Łukasz Wojciech M. Tworzydło");
                stmt3.Parameters.AddWithValue("3", "2019");
                stmt3.ExecuteNonQuery();

                // dodanie nowego rekordu do tabeli 'adv_books' [1.4]
                MySqlCommand stmt4 = new MySqlCommand("INSERT INTO adv_books (rodzaj_ksiazki, autor, rok_rozpoczecia) VALUES (?, ?, ?)", con);
                stmt4.Parameters.AddWithValue("1", "religijna");
                stmt4.Parameters.AddWithValue("2", "Łukasz Wojciech M. Tworzydło");
                stmt4.Parameters.AddWithValue("3", "2019");
                stmt4.ExecuteNonQuery();

                // dodanie nowego rekordu do tabeli 'adv_books' [1.5]
                MySqlCommand stmt5 = new MySqlCommand("INSERT INTO adv_books (rodzaj_ksiazki, autor, rok_rozpoczecia) VALUES (?, ?, ?)", con);
                stmt5.Parameters.AddWithValue("1", "projektowa");
                stmt5.Parameters.AddWithValue("2", "Łukasz Wojciech M. Tworzydło");
                stmt5.Parameters.AddWithValue("3", "2019");
                stmt5.ExecuteNonQuery();

                // dodanie nowego rekordu do tabeli 'adv_websites' [2.1]
                MySqlCommand stmt6 = new MySqlCommand("INSERT INTO adv_websites (nazwa_strony, rodzaj_strony, tworca_strony, strona_www) VALUES (?, ?, ?, ?)", con);
                stmt6.Parameters.AddWithValue("1", "ADV Publishing");
                stmt6.Parameters.AddWithValue("2", "wydawnicza");
                stmt6.Parameters.AddWithValue("3", "Łukasz Wojciech M. Tworzydło");
                stmt6.Parameters.AddWithValue("4", "https://advpublishing.wordpress.com/");
                stmt6.ExecuteNonQuery();
                
                // dodanie nowego rekordu do tabeli 'adv_websites' [2.2]
                MySqlCommand stmt7 = new MySqlCommand("INSERT INTO adv_websites (nazwa_strony, rodzaj_strony, tworca_strony, strona_www) VALUES (?, ?, ?, ?)", con);
                stmt7.Parameters.AddWithValue("1", "Just Travel Today");
                stmt7.Parameters.AddWithValue("2", "podróżnicza");
                stmt7.Parameters.AddWithValue("3", "Łukasz Wojciech M. Tworzydło");
                stmt7.Parameters.AddWithValue("4", "https://just-travel-today.com/");
                stmt7.ExecuteNonQuery();

                // dodanie nowego rekordu do tabeli 'adv_websites' [2.3]
                MySqlCommand stmt8 = new MySqlCommand("INSERT INTO adv_websites (nazwa_strony, rodzaj_strony, tworca_strony, strona_www) VALUES (?, ?, ?, ?)", con);
                stmt8.Parameters.AddWithValue("1", "AVANT DE VENIR");
                stmt8.Parameters.AddWithValue("2", "muzyczna");
                stmt8.Parameters.AddWithValue("3", "Łukasz Wojciech M. Tworzydło");
                stmt8.Parameters.AddWithValue("4", "https://avantdevenir.wordpress.com/");
                stmt8.ExecuteNonQuery();
                
                // dodanie nowego rekordu do tabeli 'adv_websites' [2.4]
                MySqlCommand stmt9 = new MySqlCommand("INSERT INTO adv_websites (nazwa_strony, rodzaj_strony, tworca_strony, strona_www) VALUES (?, ?, ?, ?)", con);
                stmt9.Parameters.AddWithValue("1", "Edukacja Kreacja");
                stmt9.Parameters.AddWithValue("2", "edukacyjna");
                stmt9.Parameters.AddWithValue("3", "Łukasz Wojciech M. Tworzydło");
                stmt9.Parameters.AddWithValue("4", "https://edukacjakreacja.wordpress.com/");
                stmt9.ExecuteNonQuery();
                
                // dodanie nowego rekordu do tabeli 'adv_websites' [2.5]
                MySqlCommand stmt10 = new MySqlCommand("INSERT INTO adv_websites (nazwa_strony, rodzaj_strony, tworca_strony, strona_www) VALUES (?, ?, ?, ?)", con);
                stmt10.Parameters.AddWithValue("1", "Wiedza Przyszłości");
                stmt10.Parameters.AddWithValue("2", "naukowa");
                stmt10.Parameters.AddWithValue("3", "Łukasz Wojciech M. Tworzydło");
                stmt10.Parameters.AddWithValue("4", "https://wiedzaprzyszlosci.wordpress.com/");
                stmt10.ExecuteNonQuery();
                
                // dodanie nowego rekordu do tabeli 'adv_websites' [2.6]
                MySqlCommand stmt11 = new MySqlCommand("INSERT INTO adv_websites (nazwa_strony, rodzaj_strony, tworca_strony, strona_www) VALUES (?, ?, ?, ?)", con);
                stmt11.Parameters.AddWithValue("1", "Projekty AD");
                stmt11.Parameters.AddWithValue("2", "projektowa");
                stmt11.Parameters.AddWithValue("3", "Łukasz Wojciech M. Tworzydło");
                stmt11.Parameters.AddWithValue("4", "https://projektyad.wordpress.com/");
                stmt11.ExecuteNonQuery();

                // dodanie nowego rekordu do tabeli 'adv_websites' [2.7]
                MySqlCommand stmt12 = new MySqlCommand("INSERT INTO adv_websites (nazwa_strony, rodzaj_strony, tworca_strony, strona_www) VALUES (?, ?, ?, ?)", con);
                stmt12.Parameters.AddWithValue("1", "Sacris Coelum");
                stmt12.Parameters.AddWithValue("2", "religijna");
                stmt12.Parameters.AddWithValue("3", "Łukasz Wojciech M. Tworzydło");
                stmt12.Parameters.AddWithValue("4", "https://sacriscoelum.wordpress.com/");
                stmt12.ExecuteNonQuery();

                // dodanie nowego rekordu do tabeli 'adv_travel' [3.1]
                MySqlCommand stmtA = new MySqlCommand("INSERT INTO adv_travel (kraj, nazwa_filmu, tworca, nazwa_kanalu, www_youtube) VALUES (?, ?, ?, ?, ?)", con);
                stmtA.Parameters.AddWithValue("1", "Israel & Jordan");
                stmtA.Parameters.AddWithValue("2", "Let's start our journey!");
                stmtA.Parameters.AddWithValue("3", "JustTravelToday & luqastro :>");
                stmtA.Parameters.AddWithValue("4", "Just Travel Today");
                stmtA.Parameters.AddWithValue("5", "https://youtu.be/g6kZjtrKQtw");
                stmtA.ExecuteNonQuery();
                
                // dodanie nowego rekordu do tabeli 'adv_travel' [3.2]
                MySqlCommand stmtB = new MySqlCommand("INSERT INTO adv_travel (kraj, nazwa_filmu, tworca, nazwa_kanalu, www_youtube) VALUES (?, ?, ?, ?, ?)", con);
                stmtB.Parameters.AddWithValue("1", "Israel & Jordan");
                stmtB.Parameters.AddWithValue("2", "The Holy Land, and even more!");
                stmtB.Parameters.AddWithValue("3", "JustTravelToday & luqastro :>");
                stmtB.Parameters.AddWithValue("4", "Just Travel Today");
                stmtB.Parameters.AddWithValue("5", "https://youtu.be/-yAXYJTpksU");
                stmtB.ExecuteNonQuery();
                
                // dodanie nowego rekordu do tabeli 'adv_travel' [3.3]
                MySqlCommand stmtC = new MySqlCommand("INSERT INTO adv_travel (kraj, nazwa_filmu, tworca, nazwa_kanalu, www_youtube) VALUES (?, ?, ?, ?, ?)", con);
                stmtC.Parameters.AddWithValue("1", "Israel & Jordan");
                stmtC.Parameters.AddWithValue("2", "Let’s drive together!");
                stmtC.Parameters.AddWithValue("3", "JustTravelToday & luqastro :>");
                stmtC.Parameters.AddWithValue("4", "Just Travel Today");
                stmtC.Parameters.AddWithValue("5", "https://youtu.be/5DdLthH5ivg");
                stmtC.ExecuteNonQuery();
                
                // dodanie nowego rekordu do tabeli 'adv_travel' [3.4]
                MySqlCommand stmtD = new MySqlCommand("INSERT INTO adv_travel (kraj, nazwa_filmu, tworca, nazwa_kanalu, www_youtube) VALUES (?, ?, ?, ?, ?)", con);
                stmtD.Parameters.AddWithValue("1", "Israel & Jordan");
                stmtD.Parameters.AddWithValue("2", "Driving through Israel… breathtaking views!");
                stmtD.Parameters.AddWithValue("3", "JustTravelToday & luqastro :>");
                stmtD.Parameters.AddWithValue("4", "Just Travel Today");
                stmtD.Parameters.AddWithValue("5", "https://youtu.be/bwnLhjKIdcc");
                stmtD.ExecuteNonQuery();
                
                // dodanie nowego rekordu do tabeli 'adv_travel' [3.5]
                MySqlCommand stmtE = new MySqlCommand("INSERT INTO adv_travel (kraj, nazwa_filmu, tworca, nazwa_kanalu, www_youtube) VALUES (?, ?, ?, ?, ?)", con);
                stmtE.Parameters.AddWithValue("1", "Israel & Jordan");
                stmtE.Parameters.AddWithValue("2", "The Last Expedition!");
                stmtE.Parameters.AddWithValue("3", "JustTravelToday & luqastro :>");
                stmtE.Parameters.AddWithValue("4", "Just Travel Today");
                stmtE.Parameters.AddWithValue("5", "https://youtu.be/BhQvj6F6Wk4");
                stmtE.ExecuteNonQuery();
            }
        }
    }
}

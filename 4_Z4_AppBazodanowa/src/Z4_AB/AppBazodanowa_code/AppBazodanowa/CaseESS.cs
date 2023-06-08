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
    class D_CaseESS
    {
        public static void ADVPublishing_JustTravelToday() // opcja nr 8 [ case no 8 ]
        {
            Console.WriteLine("\n=> ADV Publishing & Just Travel Today:\n");

            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=5_adv_activity;");
                con.Open();

                MySqlCommand cmdC8 = new MySqlCommand(@"SELECT adv_websites.nazwa_strony, adv_websites.strona_www FROM adv_websites
                WHERE (adv_websites.nazwa_strony = 'ADV Publishing' OR adv_websites.nazwa_strony = 'Just Travel Today')", con);

                MySqlDataReader reader = cmdC8.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader.GetString(0)); // wyświetlenie nazw stron internetowych
                    Console.WriteLine(reader.GetString(1)); // wyświetlenie odnośników do stron www
                }
                reader.Close();
                con.Close();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public static void Type_NameOfAWebsite() // opcja nr 7 [ case no 7 ]
        {
            Console.WriteLine("\n=> Rodzaje i nazwy stron internetowych:\n");

            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=5_adv_activity;");
                con.Open();

                MySqlCommand cmdC7 = new MySqlCommand("SELECT adv_websites.rodzaj_strony, adv_websites.nazwa_strony FROM adv_websites", con);

                MySqlDataReader reader = cmdC7.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("* " + reader.GetString(0)); // wyświetlenie nazw stron internetowych
                    Console.WriteLine("* " + reader.GetString(1)); // wyświetlenie odnośników do stron www
                }
                reader.Close();
                con.Close();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }

        public static void Website_TravelVideos() // opcja nr 6 [ case no 6 ]
        {
            Console.WriteLine("\n=> Strona i filmiki podróżnicze [Just Travel Today]:\n");

            try
            {
                MySqlConnection con = new MySqlConnection("server=localhost;user=root;database=5_adv_activity;");
                con.Open();

                MySqlCommand cmdC6 = new MySqlCommand(@"SELECT adv_websites.nazwa_strony, adv_travel.nazwa_filmu, adv_travel.www_youtube FROM
                adv_websites JOIN adv_travel ON adv_websites.nazwa_strony = adv_travel.nazwa_kanalu", con);

                MySqlDataReader reader = cmdC6.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("a) " + reader.GetString(0)); // wyświetlenie nazwy strony podróżniczej
                    Console.WriteLine("b) " + reader.GetString(1)); // wyświetlenie nazwy filmu podróżniczego
                    Console.WriteLine("c) " + reader.GetString(2)); // wyświetlenie odnośniku do filmu podróżniczego
                }
                reader.Close();
                con.Close();
            }
            catch (Exception e)
            {
                throw new ApplicationException(e.Message);
            }
        }
    }
}

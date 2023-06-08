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
    class Program
    {
        static void Main(string[] args)
        {
            // uzupełnienie bazy danych o 17 rekordów [dla stworzonych 3 tabel]
            // B_Records.AddNewRecords_17(); // gdy kod zostanie użyty to należy go ukryć,
            // aby przypadkiem nie został wywołany po raz kolejny, zdublowany

            // rozpoczęcie działania menu wyboru niniejszego programu
            C_Menu.AdvActivityMenu();
        }
    }
}
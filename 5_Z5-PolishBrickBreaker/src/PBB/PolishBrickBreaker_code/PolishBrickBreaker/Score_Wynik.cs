using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//////////////////////////////////////////////////
//
// => Imię i nazwisko: Łukasz Tworzydło
// => Numer albumu: gd29623
// => Nr. kierunku: INIS4_PR2.2
// => Przedmiot: Programowanie .NET
//
//////////////////////////////////////////////////
//
// Łukasz Tworzydło - nr albumu: gd29623 [projekt nr 5]
//
//////////////////////////////////////////////////

// Rodzaje klas:
// (1) public static class Score_Wynik
// (2) public class Brick_Cegielka
// (3) public class Paddle_Plytka
// (4) public class Ball_Pileczka

namespace PolishBrickBreaker
{
    public static class Score_Wynik // klasa nr 1
    {
        // metoda odnoszaca sie do calkowitego wyniku
        public static int TotalScore_CalkowityWynik
        {
            get;
            set;
        }

        // metoda odnoszaca sie do zdobywania wyniku
        public static int GetScore_OtrzymajWynik
        {
            get
            {
                return TotalScore_CalkowityWynik;
            }
        }

        // metoda odnoszaca sie do konca gry
        public static bool GameOver_KoniecGry
        {
            get;
            set;
        }

        // wybrane kolory teczy [ang]: red, orange, yellow, green, blue, indigo, violet
        // metoda odnoszaca sie do obliczania wyniku
        public static void CalculateScore_ObliczWynik (PictureBox brick, PolishBrickBreaker form)
        {
            if (brick.BackColor == Color.Indigo)
                TotalScore_CalkowityWynik += 1;
            else if (brick.BackColor == Color.Blue)
                TotalScore_CalkowityWynik += 2;
            else if (brick.BackColor == Color.Green)
                TotalScore_CalkowityWynik += 3;
            else if (brick.BackColor == Color.Yellow)
                TotalScore_CalkowityWynik += 4;
            else if (brick.BackColor == Color.Orange)
                TotalScore_CalkowityWynik += 5;
            else // odnosi to sie do czarnego koloru
                TotalScore_CalkowityWynik += 6;

            // ponizsza instrukcja powoduje wypisanie wyniku
            form.Text = "Score / Wynik: " + TotalScore_CalkowityWynik;
        }
    }
}

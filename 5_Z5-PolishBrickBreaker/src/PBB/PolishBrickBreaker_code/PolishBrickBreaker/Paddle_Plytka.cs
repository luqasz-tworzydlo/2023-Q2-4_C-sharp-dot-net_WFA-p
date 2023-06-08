using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Rodzaje klas:
// (1) public static class Score_Wynik
// (2) public class Brick_Cegielka
// (3) public class Paddle_Plytka

namespace PolishBrickBreaker
{
    public class Paddle_Plytka // klasa nr 3
    {
        // metoda odnoszaca sie do predkosci plytki
        public int Speed_Predkosc
        {
            get;
            set;
        }
        // metoda odnoszaca sie do plytki gracza
        // [jej lewej, srodkowej oraz prawej czesci]
        public List<PictureBox> PlayerPaddles_PlytkiGracza
        {
            get;
            set;
        }
        private PolishBrickBreaker form;

        // metoda odnoszaca sie do plytki gracza i jej predkosci
        public Paddle_Plytka(PolishBrickBreaker form)
        {
            this.form = form;
            // predkosc plytki
            // ustawiona na 5 px
            Speed_Predkosc = 5;
            PlayerPaddles_PlytkiGracza = new List<PictureBox>();
            initialize_inicjowanie();
        }
        // metoda odnoszaca sie do generowania (inicjowania) naszej plytki,
        // ktora skladac sie bedzie z trzech czesci [czesc lewa, czesc srodkowa,
        // czesc prawa], ktora bedzie odbijac pileczke [ball], ktora bedziemy
        // pozniej zbijac cegielki [bricks] na formularzu / planszy [form]
        private void initialize_inicjowanie()
        {

        }
    }
}

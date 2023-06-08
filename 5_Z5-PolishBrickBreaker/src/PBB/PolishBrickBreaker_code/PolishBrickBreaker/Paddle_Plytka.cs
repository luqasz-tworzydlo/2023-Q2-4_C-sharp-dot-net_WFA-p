using System;
using System.Collections.Generic;
using System.Drawing;
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
        // czesc prawa], ktora bedzie poruszac i odbijac pileczke [ball],
        // ktora bedziemy pozniej zbijac cegielki [bricks] na planszy [form]
        private void initialize_inicjowanie()
        {
            // tworzymy trzy elementy PictureBox
            // trzy czesci plyki [lewa, srodek, prawa]
            for (int i = 0; i < 3; i++)
            {
                PlayerPaddles_PlytkiGracza.Add(new PictureBox()
                {
                    BackColor = Color.DarkOrange, // ustawienie koloru dla naszej plytki
                    Height = 11, // ustawienie wysokosci naszej plyki [czyli u nas to 11]
                    Visible = true, // ustawienie, aby nasza plytka byla widoczna na planszy
                    Width = 30, // ustawienie szerokosci plytki [laczna szerokosc to bedzie 90]
                    Top = form.ClientSize.Height - 11, // ustawienie polozenia naszej plytki na wysokosci
                    Left = (form.ClientSize.Width - 30) / 2 // ustawienie naszej plytki na szerokosci
                });

                // odpowiednie ustawienie naszych trzech czesci plytek,
                // czyli naszej lewej, srodkowej oraz prawej czesci
                if (i == 0) // ustawienie lewej czesci plytki
                    PlayerPaddles_PlytkiGracza[i].Left -= 30;
                if (i == 2) // ustawienie prawej czesci plytki
                    PlayerPaddles_PlytkiGracza[i].Left += 30;

                // dodanie naszej plytki do naszej planszy [form],
                // czyli dodanie trzech czesci naszej plytki
                form.Controls.Add(PlayerPaddles_PlytkiGracza[i]);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
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

        // metoda odnoszaca sie do plytki gracza i jej predkosci [jest to nasz konstruktor]
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
                    // DarkViolet zostal zainspirowany kolorem teczy 'violet'
                    // kolory teczy [ang]: red, orange, yellow, green, blue, indigo, violet
                    BackColor = Color.DarkViolet, // ustawienie koloru dla naszej plytki
                    Height = 12, // ustawienie wysokosci naszej plyki [czyli u nas to 12]
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
        // metoda odnoszaca sie do ruchu naszej plytki do gry,
        // gdzie beda uzywane dwa klawisze [lewa i prawa strzalka]
        // w celu poruszanie plytki od prawej do lewej na szerokosci
        // naszej planszy / formularza [form], czyli horyzontalnie
        public void PaddleMove_RuchPlytki(KeyEventArgs e)
        {
            for (int i =0; i < 3; i++)
            {
                // instrukcja przesuniecia plytki na lewo,
                // w przypadku wcisniecia lewej strzalki
                if (e.KeyCode == Keys.Left)
                    PlayerPaddles_PlytkiGracza[i].Left -= Speed_Predkosc;

                // przesuwanie na lewo przy wcisnieciu literki A
                if (e.KeyCode == Keys.A)
                    PlayerPaddles_PlytkiGracza[i].Left -= Speed_Predkosc;

                // instrukcja przesuniecia plytki na prawo,
                // w przypadku wcisniecia prawej strzalki
                if (e.KeyCode == Keys.Right)
                    PlayerPaddles_PlytkiGracza[i].Left += Speed_Predkosc;

                // przesuwanie na prawo przy wcisnieciu literki D
                if (e.KeyCode == Keys.D)
                    PlayerPaddles_PlytkiGracza[i].Left += Speed_Predkosc;
            }

            PaddleAtEdge_PlytkaNaKrawedzi();
        }
        // metoda odnoszaca sie do weryfikacji, sprawdzania
        // polozenia naszej plytki na planszy / formularzu
        private void PaddleAtEdge_PlytkaNaKrawedzi()
        {
            // sprawdzenie, czy lewa czesc naszej plytki
            // znajduje sie na pozycji rownej lub mniejszej 0
            // [jesli tak to uniemozliwienie dalsze przesuwanie
            // oraz odbicie naszej plytki (a wiec wszystkich
            // czesci naszej plytki) od lewej krawedzi]
            if (PlayerPaddles_PlytkiGracza[0].Left <= 0)
            {
                PlayerPaddles_PlytkiGracza[0].Left = 0; // lewa czesc naszej plytki
                PlayerPaddles_PlytkiGracza[1].Left = PlayerPaddles_PlytkiGracza[0].Width; // srodkowa czesc naszej plytki
                PlayerPaddles_PlytkiGracza[2].Left = PlayerPaddles_PlytkiGracza[0].Width + PlayerPaddles_PlytkiGracza[1].Width; // prawa czesc naszej plytki

            }

            // sprawdzenie, czy prawa czesc znajduje sie na krawedzi
            // naszego formularza [na takiej samej zasadzie, jak przy lewej]
            else if (PlayerPaddles_PlytkiGracza[2].Right >= form.ClientSize.Width)
            {
                PlayerPaddles_PlytkiGracza[0].Left = form.ClientSize.Width - PlayerPaddles_PlytkiGracza[0].Width - PlayerPaddles_PlytkiGracza[1].Width - PlayerPaddles_PlytkiGracza[2].Width; // lewa czesc plytki
                PlayerPaddles_PlytkiGracza[1].Left = form.ClientSize.Width - PlayerPaddles_PlytkiGracza[1].Width - PlayerPaddles_PlytkiGracza[2].Width; // srodkowa czesc plytki
                PlayerPaddles_PlytkiGracza[2].Left = form.ClientSize.Width - PlayerPaddles_PlytkiGracza[2].Width; // prawa czesc plytki
            }
        }
    }
}

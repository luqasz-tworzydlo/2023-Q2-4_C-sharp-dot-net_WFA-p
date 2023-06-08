using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Rodzaje klas:
// (1) public static class Score_Wynik
// (2) public class Brick_Cegielka
// (3) public class Paddle_Plytka
// (4) public class Ball_Pileczka

namespace PolishBrickBreaker
{
    public class Ball_Pileczka // klasa nr 4
    {
        // metoda odnoszaca sie do predkosci na osi X
        public int SpeedX_PredkoscX
        {
            get;
            set;
        }
        // metoda odnoszaca sie do predkosci na osi Y
        public int SpeedY_PredkoscY
        {
            get;
            set;
        }
        // metoda odnoszaca sie do podnoszenia predkosci pileczki
        public int IncreasedSpeed_PodniesionaPredkosc
        {
            get;
            set;
        }

        private PictureBox ball_pileczka;
        private PolishBrickBreaker form;
        private Paddle_Plytka paddle_plytka;
        private int LostBalls_UtraconePileczki;

        // metoda odnoszaca sie do pileczki [jest to nasz konstruktor]
        public Ball_Pileczka(PolishBrickBreaker form, PictureBox pic, Paddle_Plytka paddle_plytka)
        {
            this.form = form;
            
            IncreasedSpeed_PodniesionaPredkosc = 0;
            SpeedX_PredkoscX = 5; // predkosc X to 5 px
            SpeedY_PredkoscY = 5; // predkosc Y to 5 px

            this.paddle_plytka = paddle_plytka;

            LostBalls_UtraconePileczki = 0;
            this.ball_pileczka = new PictureBox()
            {
                Width = pic.Width, // szerokosc naszej pileczki
                Height = pic.Height, // wysokosc naszej pileczki
                Visible = true, // ustawienie pileczki, aby byla widoczna
                Image = pic.Image, // ustawienie zaladowanego wczesniej obrazka
                Left = (form.ClientSize.Width - pic.Width) / 2, // ustawienie
                // szerokosci po ktorej moze poruszac sie nasza pileczka [ball]
                Top = (form.ClientSize.Height - pic.Height) / 2, // ustawienie
                // wysokosci po ktorej moze poruszac sie nasza pileczka [ball]
                BackColor = Color.Transparent // ustawienie tla na przezroczyste,
                // jako ze uzywamy juz wczesniej zaladowanego obrazka dla pileczki
            };

            form.Controls.Add(ball_pileczka); // dodanie obiektu do naszego formularza [form]
        }
        // metoda odnoszaca sie do ruchu naszej pileczki [ball]
        public void MoveBall_RuchPileczki()
        {
            // pileczka bedzie tak dlugo, jak dlugo beda cegielki [bricks]
            // jesli nie ma juz cegielek to pileczka zniknie i gra sie zakonczy

            // sposob nr 1
            if (form.Controls.OfType<PictureBox>().Where(t => t.Tag == "Brick / Cegielka").Count() == 0)
            {
                Score_Wynik.GameOver_KoniecGry = true;
                MessageBox.Show("Congratulations! You win! ^_^ / Gratulacje! Wygrywasz! ^_^");
                return;
            }

            // sposob nr 2
            /*var counter_licznik = 0;
            foreach(var item_obiekt in form.Controls.OfType<PictureBox>())
            {
                if (item_obiekt.Tag == "Brick / Cegielka")
                    counter_licznik++;
            }
            if (counter_licznik == 0)
            {
                Score_Wynik.GameOver_KoniecGry = true;
                MessageBox.Show("Congratulations! You win! ^_^ / Gratulacje! Wygrywasz! ^_^");
                return;
            }*/

            // sprawdzenie, czy gra sie skonczyla czy nie [sprawdzamy wszystkie cegielki]
            foreach(var item_obiekt in form.Controls.OfType<PictureBox>().Where(t => t.Tag == "Brick / Cegielka"))
            {
                // sprawdzamy, czy pileczka odbila sie od cegielki
                if (ball_pileczka.Bounds.IntersectsWith(item_obiekt.Bounds))
                {
                    // jesli pileczka uderzyla obiekt [cegielke]
                    // to wtedy jest obliczany wynik dla gracza
                    Score_Wynik.CalculateScore_ObliczWynik(item_obiekt, form);
                    // cegielka, ktora zostala uderzona zostaje usunieta
                    form.Controls.Remove(item_obiekt);
                    // odwrocenie kierunku, w ktorym bedzie dalej isc pileczka,
                    // a wiec ustalenie, jaki przybierze kierunek pileczka
                    // po uderzeniu obiektu [po zbiciu cegielki] pileczka
                    SpeedY_PredkoscY *= -1;
                }
            }

            // odbicie pileczki [ball] od plytki [paddle]
            if (ball_pileczka.Bounds.IntersectsWith(paddle_plytka.PlayerPaddles_PlytkiGracza[0].Bounds))
            {
                // odbicie pileczki na lewo [w przypadku uderzenia pileczki w lewa czesc plytki]
                SpeedY_PredkoscY = -SpeedY_PredkoscY; // zmienienie kierunku na osi Y
                SpeedX_PredkoscX = Math.Abs(SpeedX_PredkoscX) * -1; // upewnienie sie,
                // ze pileczka zawsze odbije sie na lewa strone, bez wzgledu na to,
                // czy bedzie isc z prawej czy z lewej strony na plytke [paddle],
                // co zapewnia wbudowana funkcja w C#, czyli Math.Abs [!!!]
            }
            else if (ball_pileczka.Bounds.IntersectsWith(paddle_plytka.PlayerPaddles_PlytkiGracza[2].Bounds))
            {
                // odbicie pileczki na prawo [w przypadku uderzenia pileczki w prawa czesc plytki]
                SpeedY_PredkoscY = -SpeedY_PredkoscY; // zmienienie kierunku na osi Y
                SpeedX_PredkoscX = Math.Abs(SpeedX_PredkoscX); // upewnienie sie,
                // ze pileczka zawsze odbije sie na prawa strone, bez wzgledu na to,
                // czy bedzie isc z prawej czy z lewej strony na plytke [paddle],
                // co zapewnia wbudowana funkcja w C#, czyli Math.Abs [!!!]
            }

            else if (ball_pileczka.Bounds.IntersectsWith(paddle_plytka.PlayerPaddles_PlytkiGracza[1].Bounds))
            {
                // odbicie pileczki w gore [w przypadku uderzenia pileczki w srodkowa czesc plytki]
                SpeedY_PredkoscY = -SpeedY_PredkoscY; // zmienienie kierunku na osi Y
                SpeedX_PredkoscX = 0; // pileczka zawsze odbije sie w gore na osi X
            }
        }
    }
}

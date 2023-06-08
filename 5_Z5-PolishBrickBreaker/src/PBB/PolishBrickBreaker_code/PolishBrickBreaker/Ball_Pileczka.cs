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
    }
}

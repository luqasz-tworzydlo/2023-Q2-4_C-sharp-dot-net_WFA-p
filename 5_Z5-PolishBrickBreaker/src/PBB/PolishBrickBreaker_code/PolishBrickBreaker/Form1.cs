using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolishBrickBreaker
{
    public partial class PolishBrickBreaker : Form
    {
        // generowanie (inicjowanie) i wyświetlanie cegielek
        List<Brick_Cegielka> bricks;
        const int NumberOfBricks_NumerCegielek = 20;

        // stworzenie naszej plytki na formularzu [planszy]
        Paddle_Plytka paddle_plytka;

        // stworzenie obiektu naszej pileczki [ball]
        Ball_Pileczka ball_pileczka;

        // konstruktor naszego formularza [planszy]
        public PolishBrickBreaker()
        {
            InitializeComponent();
            bricks = new List<Brick_Cegielka>();
            paddle_plytka = new Paddle_Plytka(this);
            ball_pileczka = new Ball_Pileczka(this, picBall, paddle_plytka);
            DoubleBuffered = true; // zabezpieczenie, aby obiekt
            // na naszej planszy [form] nie wyszedł poza nia
        }

        // zaladowanie wygenerowanych obiektow [cegielek]
        private void PolishBrickBreaker_Load(object sender, EventArgs e)
        {
            // stworzneie nowej cegielki i dodanie jej do listy
            for (int i = 0; i < NumberOfBricks_NumerCegielek; i++)
            {
                bricks.Add(new Brick_Cegielka(this));
            }
        }

        // poruszanie naszej plytki na formularzu / planszy [form]
        private void Key_Down(object sender, KeyEventArgs e)
        {
            paddle_plytka.PaddleMove_RuchPlytki(e);
        }

        // sprawdza
        private void Timer_Tick(object sender, EventArgs e)
        {
            // sprawdzenie, czy jest koniec gry
            if (Score_Wynik.GameOver_KoniecGry)
            {
                // jesli jest koniec gry to wtedy czasomierz jest zatrzymany
                timer.Enabled = false;
                return;
            }

            // jesli nie ma konca gry to gra jest kontynuowana
            ball_pileczka.MoveBall_RuchPileczki(); // ruch pileczki
            // jesli wynik jest równy bądź większy niz 20 punktow
            // to wtedy ruch naszej pileczki jest wiekszy (czyli
            // pileczka szybciej porusza sie na planszy [form]),
            // jak i rowniez predkosc poruszania plytki
            if (Score_Wynik.GetScore_OtrzymajWynik >= 20)
            {
                // podniesiona predkosc naszej pileczki na planszy [form]
                ball_pileczka.IncreasedSpeed_PodniesionaPredkosc = 7;
                // podniesiona predkosc poruszania plytki na planszy
                paddle_plytka.Speed_Predkosc = 7;
            }
            else if (Score_Wynik.GetScore_OtrzymajWynik >= 15)
            {
                // podniesiona predkosc naszej pileczki na planszy [form]
                ball_pileczka.IncreasedSpeed_PodniesionaPredkosc = 5;
                // podniesiona predkosc poruszania plytki na planszy
                paddle_plytka.Speed_Predkosc = 6;
            }
            else if (Score_Wynik.GetScore_OtrzymajWynik >= 10)
            {
                // podniesiona predkosc naszej pileczki na planszy [form]
                ball_pileczka.IncreasedSpeed_PodniesionaPredkosc = 3;
            }
            else if (Score_Wynik.GetScore_OtrzymajWynik >= 5)
            {
                // podniesiona predkosc naszej pileczki na planszy [form]
                ball_pileczka.IncreasedSpeed_PodniesionaPredkosc = 1;
            }

        }
    }
}

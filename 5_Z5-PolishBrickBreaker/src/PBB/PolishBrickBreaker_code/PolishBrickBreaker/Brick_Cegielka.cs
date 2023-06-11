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
    public class Brick_Cegielka // klasa nr 2
    {
        private Random rand_los;
        private PictureBox brick;
        private PolishBrickBreaker form;
        private List<PictureBox> bricks;

        // metoda odnoszaca sie do tworzenia cegielek [jest to nasz konstruktor]
        public Brick_Cegielka(PolishBrickBreaker form)
        {
            rand_los = new Random();
            this.form = form;
            bricks = new List<PictureBox>();
            brick = new PictureBox()
            {
                BackColor = GetColor_PobierzKolor(rand_los.Next(1, 7)),
                Width = rand_los.Next(50, 101), // tworzenie losowej szerokosci
                // Height = rand_los.Next(10, 26), // tworzenie losowej wysokosci
                Height = 15, // tworzenie konkretnej szerokosci cegielek [bricks]
                Tag = "Brick_Cegielka",
                Visible = true
            };

            initialize_inicjowanie();
        }

        // wybrane kolory teczy [ang]: red, orange, yellow, green, blue, indigo, violet
        // metoda odnoszaca sie do kolorowania cegielek na planszy
        private Color GetColor_PobierzKolor(int c)
        {
            Color color_kolor;
            switch(c)
            {
                case 1:
                    color_kolor = Color.Indigo;
                    break;
                case 2:
                    color_kolor = Color.Blue;
                    break;
                case 3:
                    color_kolor = Color.Green;
                    break;
                case 4:
                    color_kolor = Color.Yellow;
                    break;
                case 5:
                    color_kolor = Color.Orange;
                    break;
                default:
                    color_kolor = Color.Red;
                    break;
            }

            return color_kolor;
        }

        // metoda odnoszaca sie do generowania (inicjowania) naszych cegielek
        private void initialize_inicjowanie()
        {
            GetAllBricks_PobierzWszystkieCegielki();
            SetBrickLeftTop_UstawCegielkeLewaGora();
            form.Controls.Add(brick);
        }

        // metoda odnoszaca sie do odpowiedniego ustawienia cegielek,
        // ktore ida od lewej strony samej gory na naszej planszy [form]
        private void SetBrickLeftTop_UstawCegielkeLewaGora()
        {
            do
            {
                // tworzenie cegielek na calej szerokosci od lewej strony do prawej
                brick.Left = rand_los.Next(0, (form.ClientSize.Width - brick.Width));
                // tworzenie cegielek na polowie wysokosci, liczac od gory formularza
                brick.Top = rand_los.Next(0, (form.ClientSize.Height / 2));

            } while (!CheckIntersect_SprawdzenieNakladania());

            bricks.Add(brick);
        }

        // metoda odnoszaca sie do sprawdzenia, czy kolejne cegielki
        // nie beda nachodzic na juz wczesniej wygenerowane cegielki,
        // aby cegielki nie nachodzily na siebie podczas ich generowania
        private bool CheckIntersect_SprawdzenieNakladania()
        {
            for (int i = 0; i < bricks.Count; i++)
            {
                if (this.brick.Bounds.IntersectsWith(bricks[i].Bounds))
                    return false;
            }
            return true;
        }

        // metoda odnoszaca sie do pobrania wszystkich cegielek
        private void GetAllBricks_PobierzWszystkieCegielki()
        {
            foreach (var item_obiekt in form.Controls.OfType<PictureBox>().Where(t => t.Tag == "Brick_Cegielka"))
            {
                bricks.Add(item_obiekt);
            }
        }
    }
}

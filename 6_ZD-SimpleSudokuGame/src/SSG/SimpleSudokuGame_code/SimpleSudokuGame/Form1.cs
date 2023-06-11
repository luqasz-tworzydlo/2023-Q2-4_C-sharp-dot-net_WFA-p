using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
// Łukasz Tworzydło - nr albumu: gd29623 [projekt dodatkowy]
//
//////////////////////////////////////////////////

namespace SimpleSudokuGame
{
    public partial class Form1 : Form
    {
        const int n_value = 3;
        const int sizeButton = 50;
        public int[,] map = new int[n_value * n_value, n_value * n_value];
        public Button[,] buttons = new Button[n_value * n_value, n_value * n_value];
        public Form1()
        {
            InitializeComponent();
            SudokuGenerateBoard_SudokuGenerowaniePlanszy();
        }

        public void SudokuGenerateBoard_SudokuGenerowaniePlanszy()
        {
            for (int i_value = 0; i_value < n_value * n_value; i_value++)
            {
                for (int j_value = 0; j_value < n_value * n_value; j_value++)
                {
                    map[i_value, j_value] = (i_value * n_value + i_value / n_value + j_value) % (n_value * n_value) + 1;
                    buttons[i_value, j_value] = new Button();
                }
            }
            Random rand_los = new Random();
            for (int i_value = 0; i_value < 50; i_value++)
            {
                ShuffleBoard_WymieszajPlansze(rand_los.Next(0, 5));
            }

            SudokuCreateBoard_SudokuStworzPlansze();
            SudokuHideCells_SudokuUkryjKomorki();
        }

        public void SudokuHideCells_SudokuUkryjKomorki()
        {
            int NumberOfHiddenCells_LiczbaUkrytychKomorek = 50;
            Random r = new Random();
            while (NumberOfHiddenCells_LiczbaUkrytychKomorek > 0)
            {
                for (int i_value = 0; i_value < n_value * n_value; i_value++)
                {
                    for (int j_value = 0; j_value < n_value * n_value; j_value++)
                    {
                        if (!string.IsNullOrEmpty(buttons[i_value, j_value].Text))
                        {
                            int a_value = r.Next(0, 3);
                            buttons[i_value, j_value].Text = a_value == 0 ? "" : buttons[i_value, j_value].Text;
                            buttons[i_value, j_value].Enabled = a_value == 0 ? true : false;

                            if (a_value == 0)
                                NumberOfHiddenCells_LiczbaUkrytychKomorek--;
                            if (NumberOfHiddenCells_LiczbaUkrytychKomorek <= 0)
                                break;
                        }
                    }
                    if (NumberOfHiddenCells_LiczbaUkrytychKomorek <= 0)
                        break;
                }
            }
        }

        public void ShuffleBoard_WymieszajPlansze(int i_value)
        {
            switch (i_value)
            {
                case 0:
                    MatrixTransposition_TranspozycjaMacierzy();
                    break;
                case 1:
                    SwapRowsInBlock_ZamianaWierszyWRzedzie();
                    break;
                case 2:
                    SwapColumnsInBlock_ZamianaKolumnWKolumnie();
                    break;
                case 3:
                    SwapBlocksInRow_ZamianaBlokowWRzedzie();
                    break;
                case 4:
                    SwapBlocksInColumn_ZamianaBlokuWKolumnie();
                    break;
                default:
                    MatrixTransposition_TranspozycjaMacierzy();
                    break;
            }
        }

        public void SwapBlocksInColumn_ZamianaBlokuWKolumnie()
        {
            Random rand_los = new Random();
            var block1 = rand_los.Next(0, n_value);
            var block2 = rand_los.Next(0, n_value);
            while (block1 == block2)
                block2 = rand_los.Next(0, n_value);
            block1 *= n_value;
            block2 *= n_value;
            for (int i_value = 0; i_value < n_value * n_value; i_value++)
            {
                var k_value = block2;
                for (int j_value = block1; j_value < block1 + n_value; j_value++)
                {
                    var temp = map[i_value, j_value];
                    map[i_value, j_value] = map[i_value, k_value];
                    map[i_value, k_value] = temp;
                    k_value++;
                }
            }
        }

        public void SwapBlocksInRow_ZamianaBlokowWRzedzie()
        {
            Random r = new Random();
            var block1 = r.Next(0, n_value);
            var block2 = r.Next(0, n_value);
            while (block1 == block2)
                block2 = r.Next(0, n_value);
            block1 *= n_value;
            block2 *= n_value;
            for (int i_value = 0; i_value < n_value * n_value; i_value++)
            {
                var k_value = block2;
                for (int j_value = block1; j_value < block1 + n_value; j_value++)
                {
                    var temp = map[j_value, i_value];
                    map[j_value, i_value] = map[k_value, i_value];
                    map[k_value, i_value] = temp;
                    k_value++;
                }
            }
        }

        public void SwapRowsInBlock_ZamianaWierszyWRzedzie()
        {
            Random r = new Random();
            var block = r.Next(0, n_value);
            var row1 = r.Next(0, n_value);
            var line1 = block * n_value + row1;
            var row2 = r.Next(0, n_value);
            while (row1 == row2)
                row2 = r.Next(0, n_value);
            var line2 = block * n_value + row2;
            for (int i_value = 0; i_value < n_value * n_value; i_value++)
            {
                var temp = map[line1, i_value];
                map[line1, i_value] = map[line2, i_value];
                map[line2, i_value] = temp;
            }
        }

        public void SwapColumnsInBlock_ZamianaKolumnWKolumnie()
        {
            Random r = new Random();
            var block = r.Next(0, n_value);
            var row1 = r.Next(0, n_value);
            var line1 = block * n_value + row1;
            var row2 = r.Next(0, n_value);
            while (row1 == row2)
                row2 = r.Next(0, n_value);
            var line2 = block * n_value + row2;
            for (int i_value = 0; i_value < n_value * n_value; i_value++)
            {
                var temp = map[i_value, line1];
                map[i_value, line1] = map[i_value, line2];
                map[i_value, line2] = temp;
            }
        }

        public void MatrixTransposition_TranspozycjaMacierzy()
        {
            int[,] tBoard_tPlanszy = new int[n_value * n_value, n_value * n_value];
            for (int i = 0; i < n_value * n_value; i++)
            {
                for (int j = 0; j < n_value * n_value; j++)
                {
                    tBoard_tPlanszy[i, j] = map[j, i];
                }
            }
            map = tBoard_tPlanszy;
        }

        public void SudokuCreateBoard_SudokuStworzPlansze()
        {
            for (int i_value = 0; i_value < n_value * n_value; i_value++)
            {
                for (int j_value = 0; j_value < n_value * n_value; j_value++)
                {
                    Button button = new Button();
                    buttons[i_value, j_value] = button;
                    button.Size = new Size(sizeButton, sizeButton);
                    button.Text = map[i_value, j_value].ToString();
                    button.Click += CellClicked_KliknietaKomorka;
                    button.Location = new Point(j_value * sizeButton, i_value * sizeButton);
                    this.Controls.Add(button);
                }
            }
        }

        public void CellClicked_KliknietaKomorka(object sender, EventArgs e)
        {
            Button pressedButton_wcisnietyPrzycisk = sender as Button;
            string buttonText_tekstPrzycisku = pressedButton_wcisnietyPrzycisk.Text;
            if (string.IsNullOrEmpty(buttonText_tekstPrzycisku))
            {
                pressedButton_wcisnietyPrzycisk.Text = "1";
            }
            else
            {
                int num_value = int.Parse(buttonText_tekstPrzycisku);
                num_value++;
                if (num_value == 10)
                    num_value = 1;
                pressedButton_wcisnietyPrzycisk.Text = num_value.ToString();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i_value = 0; i_value < n_value * n_value; i_value++)
            {
                for (int j_value = 0; j_value < n_value * n_value; j_value++)
                {
                    var btnText = buttons[i_value, j_value].Text;
                    if (btnText != map[i_value, j_value].ToString())
                    {
                        MessageBox.Show("Plansza zostala zle wypełniona!\nSpróbuj jeszcze raz! :P");
                        return;
                    }
                }
            }
            MessageBox.Show("Gratulacje! Udalo Ci sie!\nWypelniles/as prawidlowo cala plansze sudoku! ^_^");
            for (int i_value = 0; i_value < n_value * n_value; i_value++)
            {
                for (int j_value = 0; j_value < n_value * n_value; j_value++)
                {
                    this.Controls.Remove(buttons[i_value, j_value]);
                }
            }
            SudokuGenerateBoard_SudokuGenerowaniePlanszy();
        }
    }
}
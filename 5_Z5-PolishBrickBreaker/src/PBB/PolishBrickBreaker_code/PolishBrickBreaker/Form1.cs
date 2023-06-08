﻿using System;
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

        // konstruktor naszego formularza [planszy]
        public PolishBrickBreaker()
        {
            InitializeComponent();
            bricks = new List<Brick_Cegielka>();
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
    }
}
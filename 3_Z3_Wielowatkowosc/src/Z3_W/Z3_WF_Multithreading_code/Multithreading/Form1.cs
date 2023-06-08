using System.Numerics;
using System.Threading;

namespace Multithreading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Color myRed = Color.FromArgb(217, 83, 79);
        Color myBlue = Color.FromArgb(138, 202, 222);
        Color myGreen = Color.FromArgb(140, 172, 106);

        Thread thread1;
        Thread thread2;
        Thread thread3;

        Random random;

        private void buttonThread1_Click(object sender, EventArgs e)
        {
            Thread watek1 = new Thread(() =>
            {
                double wynik_obliczen = 0;
                for (int i = 0; i < 100000000; i++)
                {
                    wynik_obliczen += Math.Sin(i) * Math.Cos(i);
                }
                label4.Invoke(new Action(() =>
                {
                    label4.Text = $"Wynik obliczen z 100'000'000 iteracji\npetli wynosi = {wynik_obliczen}";
                }));
            });
            watek1.Start();
        }

        private void buttonThread2_Click(object sender, EventArgs e)
        {
            Thread watek2 = new Thread(() =>
            {
                BigInteger wynik_silnia = 1;
                for (int i = 2; i <=25; i++)
                {
                    wynik_silnia *= i;
                }
                label5.Invoke(new Action(() =>
                {
                    label5.Text = $"Wynik obliczen silnii z 25 wynosi\n= {wynik_silnia}";
                }));
            });
            watek2.Start();
        }

        private void buttonThread3_Click(object sender, EventArgs e)
        {
            Thread watek3 = new Thread(() =>
            {
                /*int suma_liczb_parzystych = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    if (i % 2 == 0)
                    {
                        suma_liczb_parzystych += i;
                    }
                    else
                    {
                        suma_liczb_parzystych -= i;
                    }
                }*/
                int suma_liczb_parzystych = 0;
                for (int i = 0; i < 1000000; i++)
                {
                    if (i % 2 == 0)
                    {
                        suma_liczb_parzystych += i;
                    }
                    else
                    {
                        continue;
                    }
                }
                label6.Invoke(new Action(() =>
                {
                    label6.Text = $"Wynik obliczen sumy liczb parzystych\nod 0 do 1'000'000 wynosi= {suma_liczb_parzystych}";
                }));
            });
            watek3.Start();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            try
            {
                thread1.Interrupt();
                thread2.Interrupt();
                thread3.Interrupt();
            }
            catch (ThreadInterruptedException d)
            {
                thread1.Interrupt();
                thread2.Interrupt();
                thread3.Interrupt();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            random = new Random();
        }

        private void buttonStopThread1_Click(object sender, EventArgs e)
        {
            if (thread1 != null)
            {
                thread1.Interrupt();
            }
        }
        private void buttonStopThread2_Click(object sender, EventArgs e)
        {
            if (thread2 != null)
            {
                thread2.Interrupt();
            }
        }
        private void buttonStopThread3_Click(object sender, EventArgs e)
        {
            if (thread3 != null)
            {
                thread3.Interrupt();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }
        private void label5_Click(object sender, EventArgs e)
        {
        }
        private void label6_Click(object sender, EventArgs e)
        {
        }

    }
}
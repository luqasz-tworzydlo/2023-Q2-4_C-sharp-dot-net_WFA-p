using System.Numerics;
using System.Threading;

//////////////////////////////////////////////////
//
// => Imie i nazwisko: Lukasz Tworzydlo
// => Numer albumu: gd29623
// => Nr. kierunku: INIS4_PR2.2
// => Przedmiot: Programowanie .NET
//
//////////////////////////////////////////////////
//
// Lukasz Tworzydlo - nr albumu: gd29623 [projekt nr 3]
//
//////////////////////////////////////////////////

namespace Multithreading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Thread thread1;
        Thread thread2;
        Thread thread3;

        Random random;

        private void buttonThread1_Click(object sender, EventArgs e)
        {
            Thread thread1 = new Thread(() =>
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
            thread1.Start();
        }

        private void buttonThread2_Click(object sender, EventArgs e)
        {
            Thread thread2 = new Thread(() =>
            {
                BigInteger wynik_silnia = 1;
                for (int i = 2; i <=32; i++)
                {
                    wynik_silnia *= i;
                }
                label5.Invoke(new Action(() =>
                {
                    label5.Text = $"Wynik obliczen silnii z 32 wynosi\n= {wynik_silnia}";
                }));
            });
            thread2.Start();
        }

        private void buttonThread3_Click(object sender, EventArgs e)
        {
            Thread thread3 = new Thread(() =>
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
                BigInteger suma_liczb_parzystych = 0;
                for (int i = 0; i < 100000000; i++)
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
                    label6.Text = $"Wynik obliczen sumy liczb parzystych [dodatnich]\nod 0 do 100'000'000 wynosi= {suma_liczb_parzystych}";
                }));
            });
            thread3.Start();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            try
            {
                if (thread1 != null)
                {
                    thread1.Interrupt();
                }
                if (thread2 != null)
                {
                    thread2.Interrupt();
                }
                if (thread3 != null)
                {
                    thread3.Interrupt();
                }
            }
            catch (ThreadInterruptedException d)
            {
                if (thread1 != null)
                {
                    thread1.Interrupt();
                }
                if (thread2 != null)
                {
                    thread2.Interrupt();
                }
                if (thread3 != null)
                {
                    thread3.Interrupt();
                }
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
    }
}
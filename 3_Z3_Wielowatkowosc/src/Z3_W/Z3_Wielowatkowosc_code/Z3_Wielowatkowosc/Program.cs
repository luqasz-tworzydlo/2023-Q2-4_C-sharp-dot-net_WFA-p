using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace Z3_Wielowatkowosc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JakieJestDzialanieProgramu();

            DemonstracjaDzialaniaWielowatkowosci();

            WprowadzenieDoDefinicjiWielowatkowosci();

            Console.ReadKey();
        }
        public static void JakieJestDzialanieProgramu()
        {
            DodatkoweOddzielenieA();
            Console.WriteLine("Niniejszy program 'Z3_Wielowatkowosc' służy do:" +
                "\n(1) zademonstrowania zasady działania wielowątkowości" +
                "\n(2) wyjaśnienia czym jest w ogóle wielowątkowość");
            DodatkoweOddzielenieA();

            KontynuacjaProgramu();
        }
        public static void DemonstracjaDzialaniaWielowatkowosci()
        {
            Console.WriteLine("Demonstracja zasady działania wielowątkowości...\n");

            // poniżej są utworzone trzy obiekty Thread
            // oraz mają przypisane do siebie metodę do wykonania
            Thread t1 = new Thread(new ThreadStart(WielowatkowoscObliczeniaNr1));
            Thread t2 = new Thread(new ThreadStart(WielowatkowoscObliczeniaNr2));
            Thread t3 = new Thread(new ThreadStart(WielowatkowoscObliczeniaNr3));

            // t1, t2 oraz t3 odnoszą się do słowa 'threading' (czyli wielowątkowość)

            // metody, które są wykonywane przez trzy wątki to: WielowatkowoscObliczeniaNr1,
            // WielowatkowoscObliczeniaNr2, jak i również WielowatkowoscObliczeniaNr3

            // poniżej jest uruchomienie trzech wątków równolegle w sposób równoległy
            t1.Start();
            t2.Start();
            t3.Start();

            // poniżej jest oczekiwanie na zakończenie
            // wszystkich wątków przed zakończeniem aplikacji
            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("\nPrzykład wielowątkowości został zakończony.\n");

            KontynuacjaProgramu();
        }
        static void WielowatkowoscObliczeniaNr1()
        {
            Console.WriteLine("=> Wątek 1: rozpoczynamy obliczenia...");
            // wykonanie jakichś obliczeń matematycznych lub innych akcji
            {
                double wynik_obliczen = 0;
                for (int i = 0; i < 100000; i++)
                {
                    wynik_obliczen += Math.Sin(i) * Math.Cos(i);
                }
                Console.WriteLine($"Wątek 1: Wynik obliczeń z 100'000 iteracji pętli wynosi = {wynik_obliczen}");
            }
            // powyższa operacja matematyczna wykonuje 1 milion iteracji pętli for
            // oraz dla każdej wartości wylicza sinus oraz cosinus, a następnie
            // dodaje je do zmiennej wynik_obliczen
            Thread.Sleep(5000);
            Console.WriteLine("=> Wątek 1: zakończono obliczenia.");
        }
        static void WielowatkowoscObliczeniaNr2()
        {
            Console.WriteLine("=> Wątek 2: rozpoczynamy obliczenia...");
            // wykonanie jakichś obliczeń matematycznych lub innych akcji
            Int64 wynik_silnia = 1;
            for (int i = 2; i <= 100000; i++)
            {
                wynik_silnia *= i;
            }
            Console.WriteLine($"Wątek 2: Wynik obliczeń silnii z 100'000 wynosi = {wynik_silnia}");
            // powyższa operacja matematyczna oblicza silnię z liczby 1000,
            // (obliczenie dłuższych operacji jest możliwe do wykonania
            // w sposób nieco szybszy dzięki wykorzystania wielowątkowości,
            // która pozwala na równoległe obliczenie długiej operacji);
            Thread.Sleep(4000);
            Console.WriteLine("=> Wątek 2: zakończono obliczenia.");
        }
        static void WielowatkowoscObliczeniaNr3()
        {
            Console.WriteLine("=> Wątek 3: rozpoczynamy obliczenia...");
            // wykonanie jakichś obliczeń matematycznych lub innych akcji
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
            Console.WriteLine($"Wątek 3: Wynik obliczeń sumy liczb parzystych od 0 do 1'000'000 wynosi: {suma_liczb_parzystych}");

            // powyższa operacja matematyczna
            Thread.Sleep(6000);
            Console.WriteLine("=> Wątek 3: zakończono obliczenia.");
        }
        public static void KontynuacjaProgramu()
        {
            Console.WriteLine("Wciśnij enter lub wpisz cokolwiek i zaakceptuj, aby kontynuować...");
            string IDP;
            IDP = Convert.ToString(Console.ReadLine());
            switch (IDP)
            {
                default:
                    break;
            }
        }
        public static void DodatkoweOddzielenieA()
        {
            Console.WriteLine("\n////////// ////////// ////////// ////////// ////////// ////////// //////////\n");
        }
        public static void DodatkoweOddzielenieB()
        {
            Console.WriteLine("////////// ////////// ////////// ////////// ////////// ////////// //////////\n");
        }
        public static void WprowadzenieDoDefinicjiWielowatkowosci()
        {
            DodatkoweOddzielenieB();
            Console.WriteLine("Po zakończeniu demonstracji zasad działania" +
                "\nwielowątkowości teraz zostanie w krótki sposób" +
                "\nwyjaśnione czym jest wielowątkowość i jak działa");
            DodatkoweOddzielenieA();

            Console.WriteLine("Wciśnij enter lub wpisz cokolwiek i zaakceptuj, aby kontynuować...");
            string IDP;
            IDP = Convert.ToString(Console.ReadLine());
            switch (IDP)
            {
                default:
                    PrzedstawienieDefinicjiWielowatkowosci(); break;
            }
        }
        public static void PrzedstawienieDefinicjiWielowatkowosci()
        {
            // poniższy fragment został dostosowany przez autora niniejszego programu
            // (aplikacji konsolowej) do przedstawionych definicji ze strony SJP
            Console.WriteLine("Wielowątkowość można wyjaśnić na kilka sposobów," +
                "\njak i jest też wiele definicji, jednak aby zrozumieć" +
                "\no co chodzi w wielowątkowości przyjrzyjmy się" +
                "\nnastępującym trzem wyjaśnieniom, które można" +
                "\nznaleźć w Słowniku SJP (Słownik Języka Polskiego):" +
                "\n(1) wielowątkowość to cecha czegoś mającego" +
                "\n    lub wykorzystującego wiele wątków" +
                "\n(2) wielowątkowość to cecha czegoś dotyczącego" +
                "\n    wielu czynności lub wielu tematów" +
                "\n(3) wielowątkowość to cecha osoby potrafiącej" +
                "\n    skupić się na wielu czynnościach lub wielu tematach" +
                "\n\nW naszym przypadku jednak wielowątkowość najlepiej" +
                "\nprzedstawia pierwsze wyjaśnienie, czyli:" +
                "\n-> wielowątkowość to cecha czegoś mającego" +
                "\n   lub wykorzystującego wiele wątków\n");

            KontynuacjaProgramu();

            Console.WriteLine("Wątek jest definiowany jako ścieżka wykonywania programu." +
                "\nKażdy z wątków definiuje unikalny przepływ sterowania" +
                "\nJeśli aplikacja wymaga skomplikowanych i czasochłonnych" +
                "\nczynności wówczas można ustawić różne ścieżki wykonywania" +
                "\nczęści programu tak, aby każdy wątek wykonywał określoną pracę.\n");

            KontynuacjaProgramu();

            Console.WriteLine("Wątki są lekkimi procesami. Jednym z przykładów użycia" +
                "\njest operacja projektowania współczesnych systemów" +
                "\noperacyjnych. Korzystanie z wątków pozwala zaoszczędzić" +
                "\nstraty mocy obliczeniowej procesora oraz pozwala" +
                "\nna wzrost wydajności działania aplikacji.\n");

            KontynuacjaProgramu();

            // poniższy fragment został zmodyfikowany przez autora niniejszego programu
            // (aplikacji konsolowej) oraz różni się nieco od oryginalnego ze strony
            Console.WriteLine("Podczas tworzenia pierwszych aplikacji programy" +
                "\nnajczęściej działały jako pojedynczy proces," +
                "\nktóry uruchamiał instancję danej aplikacji." +
                "\nJednakże, pisząc programy w taki sposób" +
                "\n[z pojedyńczym procesem] jesteśmy w stanie" +
                "\nwykonywać tylko jedno zadanie w danym momencie." +
                "\nAby wykonywać więcej niż jedno zadanie w danym" +
                "\nczasie należy program podzielić na mniejsze wątki.\n");

            KontynuacjaProgramu();

            Console.WriteLine("Źródło użytych stron w celu wyjaśnienia wielowątkowości:" +
                "\n=> https://sjp.pl/wielow%C4%85tkowo%C5%9B%C4%87" +
                "\n=> https://www.plukasiewicz.net/Csharp_dla_zaawansowanych/Wielowatkowosc");

            DodatkoweOddzielenieA();
        }
    }
}

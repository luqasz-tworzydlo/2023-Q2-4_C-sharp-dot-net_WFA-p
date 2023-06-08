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
            //JakieJestDzialanieProgramu();

            GlownyWatek_MultiThreading();
            DodatkoweOddzielenieA();
            TworzenieKilkuWatkow();

            //WprowadzenieDoDefinicjiWielowatkowosci();

            Console.ReadKey();
        }
        public static void GlownyWatek_MultiThreading()
        {
            // Thread umożliwia nam pracę z wątkami
            Thread Watek = Thread.CurrentThread;
            Watek.Name = "GłównyWątek (testowanie działania)";
            Console.WriteLine("To jest: {0}", Watek.Name);
        }
        public static void TworzenieKilkuWatkow()
        {
            ThreadStart WatekN = new ThreadStart(WezwanieWatkuPochodnego);
            Console.WriteLine("(GW) Główny wątek: Utworzenie wątku pochodnego");
            Thread pochodnyWatek = new Thread(WatekN);
            // Uruchamiamy wątek pochodny
            pochodnyWatek.Start();
        }
        public static void WezwanieWatkuPochodnego()
        {
            // WezwanieWatkuPochodnego to inaczej CallToChildThread
            Console.WriteLine("(WP) Rozpoczęcie wątku pochodnego");
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
            DodatkoweOddzielenieA();
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

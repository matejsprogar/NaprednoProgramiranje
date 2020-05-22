using System;
using System.Collections.Generic;
using System.Text;


namespace Predavanja
{
    // izpisi stevila od 1..100
    // A: ce deljivo s 3 izpisi FIZZ
    // B: ce deljivo s 5 izpisi BUZZ
    // C: ce deljivo s 3 in s 5 izpisi FIZZBUZZ
    // primer:
    // 1 2 FIZZ 4 BUZZ FIZZ 7 8 FIZZ BUZZ 11 BUZZ 13 14 FIZZBUZZ ...
    class FizzBuzz
    {
        static void xMain()
        {
            for (int i=1; i<=100; ++i)
            {
                if (i%3==0 && i%5==0)
                    Console.Write("FIZZBUZZ ");
                else if (i%3 == 0)
                    Console.Write("FIZZ ");
                else if (i % 5 == 0)
                    Console.Write("BUZZ ");
                else
                    Console.Write("{0} ", i);
            }
        }
        // S: 1 2 3 4 ... 15 ...  100
        // FB:1 2 3 4 5 6 7 8 9 10 11 12 13 14 16 ...       
        // F: 1 2 4 5 7 8 10 11 ...                         
        // B: 1 2 4 7 8 11 ...                              
        static void yMain()
        {
            IEnumerable<int> S = sekvenca(1, 30);   // obljuba sekvence od 1 do 30, sekvence se NI
            //dump(S);                                // UPORABI sekvenco, zato jo moram narediti ZDAJ

            // nacin 1: S -> FBS -> FFBS -> BFFBS;
            IEnumerable<int> FBS = izloci_stevila(S, deljivo_s_15, ()=>Console.Write("XX "));
            IEnumerable<int> FFBS = izloci_stevila(FBS, x => x%3 == 0, "F");
            IEnumerable<int> BFFBS = izloci_stevila_ki_so_deljiva_z_deliteljem(FFBS, 5, "B");

            dump(BFFBS);    // OBJAVA rezultata

            // nacin 2: S -> BFFBS
            foreach (int x in izloci_stevila_ki_so_deljiva_z_deliteljem(izloci_stevila_ki_so_deljiva_z_deliteljem(izloci_stevila_ki_so_deljiva_z_deliteljem(S, 15, "FB"), 3, "F"), 5, "B"))
                Console.Write(x+" ");

            // nacin 3
            Console.WriteLine();
            foreach(int x in izloci_stevila(izloci_stevila(izloci_stevila(S, x => x % 15 == 0, "FB"), x => x % 3 == 0, "F"), x=>x%5 == 0,"B"))
                Console.Write(x + " ");

            // nacin 4
            Console.WriteLine();
            dump(izloci_stevila(izloci_stevila(izloci_stevila(S, x => x % 15 == 0, "FB"), x => x % 3 == 0, "F"), x => x % 5 == 0, "B"));

        }
        static bool deljivo_s_15(int x)
        {
            return x % 15 == 0;
        }

        // ce najdem v sekvenci stevilo, ki izpolnjuje kriterij, ga izlocim in izpisem sporocilo, sicer ga vrnem kot del nove sekvence
        private static IEnumerable<int> izloci_stevila(IEnumerable<int> seq, Func<int, bool> kriterij, Action ob_izlocitvi)
        {
            foreach (int x in seq)
                //if (x % delitelj != 0)      
                if (!kriterij(x))
                    yield return x;
                else
                    //Console.Write(msg + " ");
                    ob_izlocitvi();
            // yield break === return
        }

        // ce najdem v sekvenci stevilo, ki izpolnjuje kriterij, ga izlocim in izpisem sporocilo, sicer ga vrnem kot del nove sekvence
        private static IEnumerable<int> izloci_stevila<T>(IEnumerable<int> seq, Func<int, bool> kriterij, T msg)
        {
            foreach (int x in seq)
                //if (x % delitelj != 0)      
                if (!kriterij(x))
                    yield return x;
                else
                    Console.Write(msg + " ");
            // yield break === return
        }
        // ce najdem v sekvenci stevilo, ki je deljivo z deliteljem, ga izlocim in izpisem sporocilo, sicer ga vrnem kot del nove sekvence
        private static IEnumerable<int> izloci_stevila_ki_so_deljiva_z_deliteljem(IEnumerable<int> seq, int delitelj, string msg)
        {
            foreach (int x in seq)
                if (x % delitelj != 0)      // ALTERNATIVNE RESITVE???
                    yield return x;
                else
                    Console.Write(msg + " ");
            // yield break === return
        }
        // kako zgradim sekvenco, KO jo bom rabil
        private static IEnumerable<int> sekvenca(int v1, int v2)
        {
            // yield return 1;
            // yield return 2;
            // ...
            // yield return 100;
            for (int i = v1; i <= v2; ++i)
                yield return i;
        }
        static void dump(IEnumerable<int> seq)
        {
            foreach(int x in seq)
                Console.Write(x + " ");
            Console.WriteLine();
        }    
    }
}

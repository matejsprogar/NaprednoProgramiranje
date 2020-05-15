using System;
using System.Collections;
using System.Collections.Generic;

namespace Predavanja
{
    // omogoča foreach(int x in new Gajba())
    // pozor, to uradno NI sekvenca integerjev (IEnumerable<int>)
    class Gajba
    {
        public int[] tab = { 10, 20, 30 };

        // IEnumerable<int>
        public GajbaIterator GetEnumerator()
        {
            return new GajbaIterator(tab);
        }
    }
    class GajbaIterator
    {
        int kje_sem = -1;
        int[] polje = null;
        public GajbaIterator(int[] p) { polje = p; }

        // IEnumerator<int>
        public int Current => polje [kje_sem];
        public bool MoveNext() => ++kje_sem < polje.Length;
    }

    // enakovredno Gajba, le na krajši način
    class Gajba2
    {
        public int[] tab = { 100, 200, 300 };
        public IEnumerator<int> GetEnumerator()
        {
            //yield return 100;
            //yield return 200;
            //yield break;
            //yield return 300;
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] > 200)
                    yield break;            // prekine itr blok
                yield return tab[i];
            }
        }
    }

    // C#1: IEnumerator, IEnumerable
    // C#2: IEnumerator<T> : IEnumerator, IEnumerable<T> : IEnumerable

    // Gajba3 se obnaša kot sekvenca integerjev
    class Gajba3 : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            yield return 42;
            yield return 17;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    class Enumeracija
    {
        public static void Main()
        {
            // foreach uporablja tudi "neuradne" sekvence
            foreach(int x in new Gajba())
                Console.WriteLine(x);

            // KAJ DEJANSKO IZVEDE foreach
            // GajbaIterator itr = gajba.GetEnumerator();
            // while (itr.MoveNext())
            //     Console.WriteLine(itr.Current);

            //izpisi(new Gajba());      // syntax error, ker Gajba uradno NI sekvenca
            izpisi( new Gajba3() );     // Gajba3 JE sekvenca

            izpisi( vir() );            
            izpisi( dolzina(vir()) );   // sestavljanje sekvenc
        }

        static void izpisi<T>(IEnumerable<T> sekvenca)
        {
            Console.WriteLine("IZPISI:");

            foreach (var elt in sekvenca)    // premik na naslednji yield return v sekvenca
            {
                Console.WriteLine("izpis: {0}", elt);
            }
        }

        static IEnumerable<string> vir()
        {
            Console.WriteLine("VIR:");

            Console.WriteLine("ENA");
            yield return "alfa";
            Console.WriteLine("DVA");
            yield return "beta";
            Console.WriteLine("TRI");
            yield return "gama";
        }

        static IEnumerable<int> dolzina(IEnumerable<string> besede)
        {
            Console.WriteLine("DOLZINA:");

            foreach (string b in besede)    // premik na naslednji yield return v besede
            {
                Console.WriteLine(b);
                yield return b.Length;
            }
        }
    }
}

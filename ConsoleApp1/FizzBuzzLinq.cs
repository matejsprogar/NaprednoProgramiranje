using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Predavanja
{
    class Tip
    {
        public int stevilo;
        public string beseda;

        public Tip(int i) { stevilo = i; beseda = null; }
        public Tip(string msg) { stevilo = -1; beseda = msg; }
        public Tip(int i, string msg) { stevilo = i; beseda = msg; }
        public override string ToString()
        {
            return beseda==null ? stevilo.ToString() : beseda;
        }
        public Tip dodaj(string msg)
        {
            return new Tip(stevilo, beseda + msg);
        }
        public Tip preslikaj(int delitelj, string msg)
        {
            return stevilo % delitelj != 0 ? this : dodaj(msg);
        }
    }
    class FizzBuzzLinq
    {
        // najbolj kompaktna resitev
        static void Main()
        {
            // T<Tip>: (1, null),(2,null),(3,null)...,(30,null)
            IEnumerable<Tip> T = Enumerable.Range(1, 100).Select(x => new Tip(x));

            // IEnumerable<Tip> F = T.Select(x => x.stevilo % 3 != 0 ? x : x.dodaj("F"));
            IEnumerable<Tip> R = T.Select(x => x.preslikaj(3, "F")).Select(x => x.preslikaj(5, "B"));

            // izpis
            foreach (var x in R)
                Console.Write(x + " ");
        }

        // splosna resitev, brez deljivost s 15
        static void aMain()
        {
            // S<int>: 1,2,3,...,14,15,...,30
            IEnumerable<int> S = Enumerable.Range(1, 30);

            // S -> T<Tip>: (1, null),(2,null),(3,null)...,(30,null)
            IEnumerable<Tip> T = S.Select(x=>new Tip(x));

            // T -> F<Tip>: (1, null),(2,null),(3,"F"),..., (14,null),(15,"F"), ..., (29,null),(30, "F")
            IEnumerable<Tip> F = T.Select(x => { if(x.stevilo%3!=0) return x; return new Tip(x.stevilo, x.beseda+"F"); });

            // F -> B<Tip>: (1, null),(2,null),(3,"F"),..., (14,null),(15,"FB"), ..., (29,null),(-1, "FB")
            // IEnumerable<Tip> B = F.Select(x => { if(x.stevilo%5!=0) return x; return x.dodaj("B"); });
            // IEnumerable<Tip> B = F.Select(x => { return x.stevilo%5 != 0 ? x : x.dodaj("B"); });  // pogoj?true:false;
            IEnumerable<Tip> B = F.Select(x => x.stevilo%5 != 0 ? x : x.dodaj("B"));  // pogoj?true:false;

            // izpis
            // B: (1, null),(2,null),(3,"F"),(4,null),(5,"B"),..., (14,null),(15,"FB"), ..., (29,null),(30, "FB")
            foreach (var x in B)
                Console.Write(x+" ");
        }

        // prvi poskus: deljivost s 15, 3, 5
        static void xMain()
        {
            // S<int>: 1,2,3,...,14,15,...,30
            IEnumerable<int> S = Enumerable.Range(1, 30);

            // S -> T<Tip>: (1, null),(2,null),...,(30,null)
            IEnumerable<Tip> T = S.Select(x => new Tip(x));

            // T -> T15<Tip>: (1, null),(2,null),(3,null),..., (14,null),(-1,"FB"),...,(-1,FB)
            IEnumerable<Tip> T15 = T.Select(x => { if (x.stevilo % 15 != 0) return x; return new Tip("FB"); });

            // T15 -> F3<Tip>: (1, null),(2,null),(-1,"F"),..., (14,null),(-1,"FB"), ..., (29,null),(-1, "FB")
            IEnumerable<Tip> F3 = T15.Select(x => { if (x.stevilo % 3 != 0) return x; return new Tip("F"); });

            // F3 -> B5<Tip>: (1, null),(2,null),(-1,"F"),..., (14,null),(-1,"FB"), ..., (29,null),(-1, "FB")
            IEnumerable<Tip> B5 = F3.Select(x => { if (x.stevilo % 5 != 0) return x; return new Tip("B"); });


            // izpis
            // B5: (1, null),(2,null),(-1,"F"),(4,null),(-1,"B"),..., (14,null),(-1,"FB"), ..., (29,null),(-1, "FB")
            foreach (var x in B5)
                Console.Write(x + " ");
        }

    }
}

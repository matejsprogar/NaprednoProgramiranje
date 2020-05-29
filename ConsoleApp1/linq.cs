using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Predavanja
{
    static class lksjdflksdjf
    {// Jon Skeet
        public static int stej(this IEnumerable<int> seq)
        {
            int n = 0;
            foreach (int x in seq)
                n++;
            return n;
        }
    }
    class linq
    {
        public static void xMain()
        {
            int[] tab = { 2, 7, -3, 21, 14, 0, 5 };

            // dump(filter(tab, x=>x>2));
            dump(tab.Where(x => x > 2).Select(x => x * 10).OrderBy(x => x));

            // 1: sekvenca -> sekvenca (Where, Select, OrderBy, Take...)
            IEnumerable<int> q = from x in tab where x > 2 select x;

            // 2: sekvenca -> objekt (Count, Max, Min, First...)
            int cnt = tab.Count();

            // 3: () -> sekvenca (Range, ...)
            IEnumerable<int> seq = Enumerable.Range(5, 42);

            dump(q);
        }
        // sql: select 10*cena from tab where cena > 2 order by cena;
        public static void dump<T>(IEnumerable<T> tab)
        {
            foreach (var x in tab)
                Console.WriteLine(x);
        }

        public IEnumerable<int> produciraj()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }
}


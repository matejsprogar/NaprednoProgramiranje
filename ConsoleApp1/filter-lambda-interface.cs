using System;
using System.Collections.Generic;
using System.Text;

namespace Predavanja
{
    class filter_lambda_interface
    {
        public static void xMain()
        {
            int[] tab = { 3, 5, 1, 6, -2, 4, 8, 0 };

            fun_izpise_stevila_vecja(tab, 1);
            Console.WriteLine();
            fun_izpise_izbrana_stevila(tab, new Manjse(1));
            Console.WriteLine();
            fun_izpise_izbrana_stevila(tab, x=>x<1);

            //Func<int, bool> less1 = x => x < 1;
            //fun_izpise_izbrana_stevila(tab, less1);
            //fun_izpise_izbrana_stevila(tab, manjse1);
        }
        static bool manjse(int x, int meja) { return x < meja; }
        static bool manjse1(int x) { return x < 1; }

        // OPDP
        private static void fun_izpise_stevila_vecja(int[] tab, int meja)
        {
            foreach(int x in tab)
                if (x > meja)
                    Console.WriteLine(x);
        }

        // NP hierarhije
        private static void fun_izpise_izbrana_stevila(int[] tab, IKriterij test)
        {
            foreach (int x in tab)
                if (test.primerjaj(x))
                    Console.WriteLine(x);
        }
        // NP lambda
        private static void fun_izpise_izbrana_stevila(int[] tab, Func<int, bool> kriterij)
        {
            foreach (int x in tab)
                if (kriterij(x))
                    Console.WriteLine(x);
        }
    }
    interface IKriterij
    {
        bool primerjaj(int x);
    }
    abstract class Kriterij : IKriterij
    {
        protected int meja;
        protected Kriterij(int meja) { this.meja = meja;  }
        public abstract bool primerjaj(int x);
    }
    class Manjse : Kriterij
    {
        public Manjse(int meja) : base(meja) {}
        public override bool primerjaj(int x) { return x < meja; }
    }
    class Vecje : Kriterij
    {
        public Vecje(int meja) : base(meja) {  }
        public override bool primerjaj(int x) { return x > meja; }
    }
}
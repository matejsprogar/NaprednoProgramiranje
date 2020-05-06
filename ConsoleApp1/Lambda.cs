using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Lambda
    {
        public int dolzina(string s) { return s.Length; }

        delegate int transform(string s);

        public static void Main()
        {
            int a = 1;
            Action f1 = () => Console.WriteLine(a);
            a = 2;
            Action f2 = () => Console.WriteLine(a);
            a = 3;
            Action f3 = () => Console.WriteLine(a);

            f1();
            f2();
            f3();                   // 3 3 3

            Action[] pf = new Action[3];
            for (int i = 1; i <= 3; ++i)
            {
                int lokalna_kopija_i = i;
                pf[i - 1] = () => Console.WriteLine(lokalna_kopija_i);
            }

            foreach (var f in pf)
                f();                // 1 2 3
        }

        public static void lambda_alternative()
        {
            Lambda lam = new Lambda();
            
            lam.dolzina("abc");             // 3

            transform f = lam.dolzina;
            f("abc");                       // 3

            Func<string, int> g = lam.dolzina;
            g("abc");                       // 3

            Func<string, int> h = (string s) => { return s.Length; };
            Func<string, int> k = (s) => { return s.Length; };
            Func<string, int> m = s => { return s.Length; };

            Console.WriteLine( m("abcd") );

            Func<int, double, string> x = (i, d) => "aleluja";
            string s = x(1, 3.14);
            Console.WriteLine(s);

            Func<string, int> n = s => s.Length;
            foo(n, "abc");

            foo(x => x.Length, "abc");
        }

        static void foo(Func<string, int> x, string s)
        {
            Console.WriteLine("Aha, rezultat x({1}) = {0}!", x(s), s);
        }

        public static void lambda_zapisi()
        {
            Action a = () => { Console.WriteLine("halo!"); };
            Func<string, int> b = (string s) => { return s.Length; };
            Func<int> c = () => { return 42; };
            Func<int> d = () => 37;
            Func<int, int> e = (x) => { return x + 1; };
            Func<int, int> f = x => x+1;

            a();
            Console.WriteLine(b("keks"));
            Console.WriteLine(e(12));
        }
    }
}

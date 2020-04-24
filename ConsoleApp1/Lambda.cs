using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Lambda
    {
        public static void Main()
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

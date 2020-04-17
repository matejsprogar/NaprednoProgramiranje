using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class Demokracija
    {
        static void Main()
        {
            Novinar rtvslo = new Novinar("RTV");
            Novinar poptv = new Novinar("POP");

            List <Action<bool>> sezAkcij = new List<Action<bool>> { rtvslo.obvesti, poptv.obvesti };
            // while(true)
            {
                NIJZ.obvesti(sezAkcij);
            }
        }
    }

    class NIJZ
    {
        public static void obvesti(List<Action<bool>> sezAkcij) 
        {
            bool rez = false;
            foreach(var obvesti in sezAkcij)
                obvesti(rez);
        }
    }
    
    class Novinar
    {
        string ime;
        public Novinar(string ime) { this.ime = ime; }
        public void obvesti(bool rezultat)
        {
            Console.WriteLine("{0}: nekdo je {1}", ime, rezultat);
        }
    }
}

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

            //List<Action<bool>> sezAkcij = new List<Action<bool>> { rtvslo.obvesti, poptv.obvesti };   // utopija
            NIJZ.akcijaObCovid19Testu += rtvslo.obvesti;        // 1
            NIJZ.registriraj_se_za_test_covid19(poptv.obvesti);
            NIJZ.akcijaObCovid19Testu -= poptv.obvesti;         // 2
            
            // problem, vlada OBSTAJA! cenzura!??
            //NIJZ.akcijaObCovid19Testu = vlada.obvesti;        // 3 ERROR
            //NIJZ.akcijaObCovid19Testu = null;                 // 4 ERROR
            //NIJZ.akcijaObCovid19Testu(false);                 // 5 ERROR

            //NIJZ.registriraj_se_za_test_covid19(poptv.obvesti);

            NIJZ.simuliraj_delo();


            // varianta z vmesnikom

            Obcan vk = new Obcan();
            NIJZ2.registriraj_se_za_test_covid19(vk);
            NIJZ2.sezObjektovZaObvestit.Add(vk);

            NIJZ2.obvesti_javnost(true);
        }
    }

    //  NIJZ "obvešča" po vsakem laboatorijskem testu

    class NIJZ
    {
        public static event Action<bool> akcijaObCovid19Testu = null;

        public static void obvesti_javnost(bool rez) 
        {
            if (akcijaObCovid19Testu != null)
                akcijaObCovid19Testu(rez);
        }

        public static void registriraj_se_za_test_covid19(Action<bool> akcija) { 
            akcijaObCovid19Testu += akcija; 
        }
        internal static void simuliraj_delo()
        {
            obvesti_javnost(false);
            obvesti_javnost(true);
            obvesti_javnost(false);
        }
    }
    class Novinar
    {
        string ime;
        public Novinar(string ime) { this.ime = ime; }
        public void obvesti(bool rezultat)
        {
            Console.WriteLine("{0}: nekdo je {1}", ime, rezultat ? "pozitiven" : "negativen");
        }
        public void kuhaj(bool trma)
        {
            Console.WriteLine("{0}: {1} trmast", ime, trma ? "sem" : "nisem");
        }
    }

    // Enak učinek, ampak z uporabo vmesnikov
    interface IObvesti
    {
        void obvesti(bool rez);
    }
    class Obcan : IObvesti
    {
        public void obvesti(bool rez)
        {
            Console.WriteLine("Obcan: nekdo je {0}", rez ? "pozitiven" : "negativen");
        }
    }

    class NIJZ2
    {
        public static List<IObvesti> sezObjektovZaObvestit = new List<IObvesti>();

        public static void obvesti_javnost(bool rez)
        {
            foreach (IObvesti ob in sezObjektovZaObvestit)
                ob.obvesti(rez);
        }

        public static void registriraj_se_za_test_covid19(IObvesti ob)
        {
            sezObjektovZaObvestit.Add(ob);
        }
    }


}

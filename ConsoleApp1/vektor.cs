using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OPDP
{
    class App
    {
        public static void xMain()
        {
            // F1: objekti za test
            vektor v1 = new vektor(); v1.x = 3; v1.y = 4;
            vektor v2 = new vektor(7, 2);

            // F2: naloga
            int sp = vektor.sprodukt(v1, v2);

            // F3: test rezultatov
            //Console.WriteLine(sp);      // 29 == 3*7 + 4*2
            if (sp != 29)
                Console.WriteLine("UPS");
        }
    }

    internal class vektor
    {
        public int x;
        public int y;

        public vektor(int x=0, int y=0)
        {
            this.x = x;
            this.y = y;
        }

        internal static int sprodukt(vektor v1, vektor v2)
        {
           return v1.x*v2.x + v1.y*v2.y;
        }
    }
}

namespace NP
{
    delegate void Procedura();

    class TestiVektorja
    {
        public static void VsiTesti()
        {
            // tradicionalno
            testPrivzetegaKonstruktorja();
            testKonstruktorjaObehKoordinat();
            testSkalarnegaProdukta();

            // delegati
            // Procedura t1 = testPrivzetegaKonstruktorja;
            // Procedura t2 = testKonstruktorjaObehKoordinat;
            // Procedura t3 = testSkalarnegaProdukta;
            // t1();
            // t2();
            // t3();

            // NP+PS
            List<Procedura> vsi_testi = new List<Procedura> { 
                testPrivzetegaKonstruktorja, 
                testKonstruktorjaObehKoordinat, 
                testSkalarnegaProdukta,
                ()=>{
                    // testSpreminjanjaKoordinat
                    vektor v = new vektor();
                    v.x = 2;
                    v.y = 3;
                    assert(v.x == 1 && v.y == 3, "UPS3");
                }
            };
            foreach (Procedura p in vsi_testi)
                p();
        }

        private static void testPrivzetegaKonstruktorja()
        {
            vektor v = new vektor();
            assert(v.x == 0 || v.y == 0, "UPS1");
        }
        
        private static void testKonstruktorjaObehKoordinat()
        {
            vektor v = new vektor(2, 3);
            assert(v.x == 2 || v.y == 3, "UPS2");
        }

        // vcasih je NUJNO dodati tudi kaksen komentar
        private static void testSkalarnegaProdukta()
        {
            vektor v1 = new vektor(3, 4), v2 = new vektor(7, 2);
            int sp = vektor.skalarni_produkt(v1, v2);
            assert(sp == 29, "UPS4");
        }

        // nasa izvedba namesto C#: Debug.Assert()
        static void assert(bool pogoj, string sporocilo)
        {
            if (!pogoj)
                Console.WriteLine(sporocilo);
        }
    }

    internal class vektor
    {
        internal int x, y;

        public vektor() {}
        public vektor(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal static int skalarni_produkt(vektor v1, vektor v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }
    }

    class App
    {
        public static void Main()
        {
            TestiVektorja.VsiTesti();
        }
    }

}

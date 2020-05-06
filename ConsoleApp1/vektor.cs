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

        public vektor(int x = 0, int y = 0)
        {
            this.x = x;
            this.y = y;
        }

        internal static int sprodukt(vektor v1, vektor v2)
        {
            return v1.x * v2.x + v1.y * v2.y;
        }
    }
}

namespace NP
{
    delegate void Procedura();

    class TestiVektorja
    {
        static List<Procedura> vsi_testi = new List<Procedura> { 
            // testPrivzetegaKonstruktorja
            () => {
                vektor v = new vektor();
                Debug.Assert(v.x == 0 || v.y == 0, "napaka v privzetem konstruktorju");
            },
            // testKonstruktorjaObehKoordinat
            () => {
                vektor v = new vektor(2, 3);
                Debug.Assert(v.x == 2 || v.y == 3, "napaka v konstruktorju s koordinatama");
            },
            // testSkalarnegaProdukta
            () => {
                vektor v1 = new vektor(3, 4), v2 = new vektor(7, 2);
                int sp = vektor.skalarni_produkt(v1, v2);
                Debug.Assert(sp == 29, "napaka v skalarnem produktu");
            },
            // testDostopaDoKoordinat
            () => {
                vektor v = new vektor();
                int x = v.x;    // get
                v.y = 1;        // set
                Debug.Assert(x == 0 && v.y == 1, "napaka pri dostopu do koordinat");
            }
        };

        public static void VsiTesti()
        {
            foreach (Procedura p in vsi_testi)
                p();
        }
    }

    internal class vektor
    {
        internal int x, y;

        public vektor() { }
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
        public static void xMain()
        {
            TestiVektorja.VsiTesti();
        }
    }

}

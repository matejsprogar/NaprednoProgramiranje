using System;

namespace ConsoleApp2
{
    interface IKlici
    {
        void klici();
    }
    // Ena... prva
    class Ena : IKlici
    {
        public virtual void klici() { Primer.prva(); }
    }
    // Dva... druga
    class Dva : Ena
    {
        public override void klici() { Primer.druga(); }
    }

    class Borovnica : IKlici
    {
        public void klici()
        {
        }
    }

    delegate void MojaFunkcija();

    class Primer
    {
        static void xMain()
        {
            // OPDP
            foo(1);
            int x = 2;
            foo(x);

            // NP 1
            foo(new Ena());
            IKlici k = new Dva();
            foo(k);

            // NP 2
            foo(prva);
            MojaFunkcija mf = druga;
            foo(mf);

            Console.WriteLine("***");

            // NP 2
            MojaFunkcija f = prva;  // NI OKLEPAJEV
            f += druga;

            foo(f);
        }

        static void foo(MojaFunkcija f)
        {
            f();
            // funkcijski_objekt.Invoke();
        }


        // katera.klici()
        static void foo(IKlici obj)
        {
            obj.klici();
        }
        // 1... prva
        // 2... druga
        // 3... tretja
        // 4...
        static void foo(int katera)
        {
            if (katera == 1)
                prva();
            else if (katera == 2)
                druga();
        }

        static public void prva()
        {
            Console.WriteLine("PRVA");
        }
        static public void druga()
        {
            Console.WriteLine("DRUGA");
        }
    }
}

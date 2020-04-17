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
        public virtual void klici() { delegati.prva(); }
    }
    // Dva... druga
    class Dva : Ena
    {
        public override void klici() { delegati.druga(); }
    }

    class Borovnica : IKlici
    {
        public void klici()
        {
        }
    }

    delegate void MojaAkcija();
    delegate void MojDelegatString(string x);

    // delegate void MojDelegatInt(int x);
    // delegate void MojDelegatDouble(double x);

    // delegate void Action();
    // delegate void Action<T>(T t);
    // delegate void Action<T, U>(T t, U u);
    // delegate void Action<T, U, V>(T t, U u, V v);
    // 
    // delegate T Func<out T>();
    // delegate T Func<in U, out T>(U u);
    // delegate T Func<in U, in V, out T>(U u, V v);

    class delegati
    {
        int lastnost = 0;

        static void alfa(int x) { }
        static void beta(string x) { }
        static void gama(string x, int y) { }

        static void xMain()
        {
            MojaAkcija a = prva;
            Action b = prva;
            // MojaFunkcija aa = b;
            MojaAkcija aa = new MojaAkcija(b);

            MojDelegatString c = beta;
            Action<string> d = beta;
            Action<string, int> e = gama;


            // OPDP
            foo(1);
            int x = 2;
            foo(x);

            // NP 1
            foo(new Ena());
            IKlici k = new Dva();
            foo(k);

            // NP 2
            klicatelj(prva);
            MojaAkcija mf = druga;
            klicatelj(mf);

            Console.WriteLine("***");

            // NP 2
            MojaAkcija f = prva;  // NI OKLEPAJEV
            f += druga;

            klicatelj(f);

            Console.WriteLine("+++++++++");
            delegati o = new delegati();
            o.naredi_nekaj();

            f += o.naredi_nekaj;
            o.lastnost = 42;
            f();

            MojaAkcija g = posrednik();
        }

        static MojaAkcija posrednik()
        {
            return prva;
        }

        static void klicatelj(MojaAkcija f)
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

        void naredi_nekaj()
        {
            Console.WriteLine(lastnost);
        }
    }
}

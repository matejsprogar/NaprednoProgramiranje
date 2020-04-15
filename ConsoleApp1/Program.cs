using System;
using System.Collections.Generic;

class MojSklad<Tip>
{
    Tip[] data;
    int kapaciteta = 0;
    int st_elementov = 0;

    public MojSklad(int kap = 10)
    {
        kapaciteta = kap;
        data = new Tip[kapaciteta];
    }

    public void push(Tip kaj) {
        if (st_elementov >= kapaciteta)
        {
            kapaciteta *= 2;
            Tip[] tmp = new Tip[kapaciteta];
            for (int i = 0; i < st_elementov; ++i)
                tmp[i] = data[i];
            data = tmp;
        }
        data[st_elementov++] = kaj;
    }
    public Tip pop() {
        if (st_elementov > 0)
            return data[--st_elementov];

        return default(Tip); 
    }
}

delegate void MojaFunkcija();

class Program {        
    static void Main()
    {
        var msi = new MojSklad<int>();
        var mss = new MojSklad<string>();
        var msf = new MojSklad<MojaFunkcija>();

        msf.push(ConsoleApp2.Primer.prva);

        msi.push(10);
        msi.push(20);
        msi.push(30);

        mss.push("abc");
        mss.push("def");

        int x = 4;
        int y = 7;
        swap(ref x, ref y);

        string u = "alfa", v = "beta";
        swap(ref u, ref v);
    }

    static void swap<T>(ref T a, ref T b)
    {
        var tmp = a;
        a = b;
        b = tmp;
    }
}


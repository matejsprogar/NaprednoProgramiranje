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

class Program {        
    static void xMain()
    {
        var msi = new MojSklad<int>();
        var mss = new MojSklad<string>();

        msi.push(10);
        msi.push(20);
        msi.push(30);

        mss.push("abc");
        mss.push("def");
    }
}


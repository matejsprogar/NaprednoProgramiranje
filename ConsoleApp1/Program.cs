using System;
using System.Collections.Generic;

class MojSklad<T>
{
    T[] data;
    int kapaciteta = 0;
    int st_elementov = 0;

    public MojSklad(int kap = 10)
    {
        kapaciteta = kap;
        data = new T[kapaciteta];
    }

    public void push(T kaj) {
        if (st_elementov >= kapaciteta)
        {
            kapaciteta *= 2;
            T[] tmp = new T[kapaciteta];
            for (int i = 0; i < st_elementov; ++i)
                tmp[i] = data[i];
            data = tmp;
        }
        data[st_elementov++] = kaj;
    }
    public T pop() {
        if (st_elementov > 0)
            return data[--st_elementov];

        return default(T); 
    }

    public T this[int pos] {  get { return data[pos]; } }
    public T at(int pos) {  return data[pos]; }
}

class Program {        
    static void Main()
    {
        var msi = new MojSklad<int>();
        var mss = new MojSklad<string>();

        msi.push(10);
        msi.push(20);
        msi.push(30);

        Console.WriteLine(msi[0]);
        Console.WriteLine(msi.at(0));

        mss.push("abc");
        mss.push("def");
    }
}


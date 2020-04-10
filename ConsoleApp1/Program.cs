using System;
using System.Collections.Generic;

interface IDelaj
{
    void delaj();
}
class Program {        
    static void Main()
    {
        izpis(10, 3);
        izpis(10.2, 5);
        izpis(7, "alfa");
        izpis("keks", "smreka");

        Alfa<int> a = new Alfa<int>(42);
        a.izpis();
        a.izpis("keks");
        a.izpis(42);
    }

    private static void izpis<T, U>(T v, U u)
    {
        Console.WriteLine("({0}; {1})", v.ToString(), u.ToString());
    }

    // Constraint
    public T max<T>(T a, T b)
             where T : IComparable<T>
    {
        return a.CompareTo(b) > 0 ? a : b;  // a > b
    }

    public void nekaj<T>(T a) where T : IDelaj, new()
    {
        T t = new T();
        a.delaj();
        Console.WriteLine(a);
    }

    public void nekaj(IDelaj a)
    {
        a.delaj();
        Console.WriteLine(a);
    }

    public void swap<T>(ref T a, ref T b)
    {
        T t = a;
        a = b;
        b = t;
    }
}

class Alfa<T>
{
    T podatek;

    public Alfa(T p) { podatek = p; }
    public void izpis()
    {
        Console.WriteLine("[{0}]", podatek);
    }
    public void izpis<U>(U u)
    {
        Console.WriteLine("[{0}, {1}]", podatek, u);
    }
    public void izpis(string t)
    {
        Console.WriteLine("({0})", t);
    }
}



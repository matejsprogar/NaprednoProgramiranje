using System;

interface IDelaj
{
    void delaj();
}

abstract class Zival : IDelaj
{
    public int teza;    // kg
    public abstract void delaj();
}

class Tiger : Zival
{
    public override void delaj() { Console.WriteLine("tiger"); }
}

class JezniTiger : Tiger
{
    public override void delaj() { Console.WriteLine("jezen"); }
}

class Program {        
    static void Main()
    {
        Zival z = new JezniTiger();
        z.delaj();
        z.teza -= 1;
    }
}




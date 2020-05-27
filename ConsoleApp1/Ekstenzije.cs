using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace Predavanja
{
    class Student { }
    class ExStudent : Student
    {
        public void bar(string s) { }
        public void delaj() { }
    }
    class EUR { 
        public static EUR operator+(EUR e, int x) { return e.plus(x); }
        public EUR plus(int x) { return new EUR(); }
    }
    static class MojeExtenzije
    {
        public static IEnumerable<T> preoblikuj<T>(this IEnumerable<T> S, Func<T, T> opravilo)
        {
            foreach (T x in S)
                yield return opravilo(x);
        }
        public static int foo(this string s, int k) { return 42; }
        public static void bar<T>(this T t, string s) {}
        public static void plavaj(this ExStudent s) { }
        public static void plavaj(this int x) { }
    }
    class EkstenzijskeMetode
    {
        public static void xMain()
        {
            var S = ustvari();
            // IDENTICNO
            S = MojeExtenzije.preoblikuj(S, x=>x*2);
            S = S.preoblikuj(x=>x+1);

            dump(S);

            // IDENTICNO: VERIZENJE FUNKCIJ ali ZAPOREDNE FUNKCIJE
            dump( MojeExtenzije.preoblikuj(MojeExtenzije.preoblikuj( ustvari(), x=>x*10 ), x => x + 1) );
            dump( ustvari().preoblikuj(x=>x*10).preoblikuj(x=>x+1) );

            // IDENTICNA KLICA METODE foo
            int r = MojeExtenzije.foo("abc", 7);
            r = "abc".foo(7);

            Student x = new Student();
            MojeExtenzije.bar(x, "abc");
            x.bar("abc");

            ExStudent ex = new ExStudent();
            ex.bar("abc");
            ex.delaj();
            ex.plavaj();
            
            42.plavaj();
            12.bar("abc");

            // lastno definiran operator + je lepsa varianta metode plus()
            EUR e = new EUR();
            e = e + 3;
            e = e.plus(3);
        }

        static IEnumerable<int> ustvari()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        static void dump<T>(IEnumerable<T> S)
        {
            foreach(T t in S)
                Console.WriteLine(t);
            Console.WriteLine();
        }

    }
}

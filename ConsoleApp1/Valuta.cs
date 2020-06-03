using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Predavanja2
{
    class Valuta
    {
        public Decimal stanje = 0;
        public string ime;

        public Valuta(Decimal st, string i) { stanje = st; ime = i; }

        internal void pristej(Decimal vrednost) { stanje += vrednost; }
        public static V sestej<V>(V a, V b) where V : Valuta, new()
        {
            V ret = new V();
            ret.stanje = a.stanje + b.stanje;
            return ret;
        }
    }
    class EUR : Valuta
    {
        public EUR() : base(0, "EUR") { }
        public EUR(Decimal st) : base(st, "EUR") { }

        public static EUR operator +(EUR eur, Decimal vrednost)
        {
            // DB.transakcija(new Polog(vrednost));                   // kompleksnost tukaj
            return new EUR(eur.stanje + vrednost);
        }
        public static EUR operator +(EUR eur1, EUR eur2)
        {
            return new EUR(eur1.stanje + eur2.stanje);
        }
    }
    class USD : Valuta { public USD(Decimal st) : base(st, "USD") { } }

    class DEMO
    {
        static void Main()
        {
            // pravi pristop v velikih programih
            EUR e = new EUR(3.2M);
            USD u = new USD(3M);

            e = e + 3;
            e = e + e;

            e += 3;                           // enostavna sintaksa, ki lahko skriva kompleksno logiko pologa
            e.pristej(3);                     // enakovredna sintaksa
            e = Valuta.sestej<EUR>(e, e);     // enakovredna sintaksa

            u.pristej(5);

            // CILJ JE NAPAKA!!!
            EUR stanje = e + u;               // nemogoce, NAPAKA PRI PREVAJANJU
            e = Valuta.sestej<EUR>(e, u);     // nemogoce, NAPAKA PRI PREVAJANJU
        }
    }
}
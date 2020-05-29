using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Predavanja2
{
    class EUR
    {
        Decimal stanje = 0;

        public EUR(Decimal st) { this.stanje = stanje; }
        internal void pristej(int vrednost)
        {
            stanje += vrednost;
        }
        public static EUR operator +(EUR eur, Decimal vrednost)
        {
            zabelezi_polog(vrednost);                   // kompleksnost tukaj
            return new EUR(eur.stanje + vrednost);
        }
        public static EUR operator +(EUR eur1, EUR eur2)
        {
            return new EUR(eur1.stanje + eur2.stanje);
        }
    }
    class USD
    {
        public Decimal stanje = 0;

        public USD(Decimal st) { this.stanje = stanje; }
        public static USD operator -(USD usd, Decimal vrednost)
        {
            return new USD(usd.stanje - vrednost);
        }
    }
    class Denar
    {
        static void Main()
        {
            // pravi pristop v velikih programih
            EUR eur = new EUR(3.2M);
            USD usd = new USD(10M);

            eur.pristej(3);
            eur = eur + 3;
            eur = eur + eur;

            eur += 3;                           // enostavna sintaksa, ki lahko skriva kompleksno logiko pologa
            eur.polozi(3);                      // enakovredna sintaksa
            eur.polozi(new EUR(3));             // enakovredna sintaksa

            eur.izvedi(new Polog(new EUR(3)));  // prekompleksen pristop

            usd -= 5;   // dvig 5 usd

            // nekje...
            EUR stanje = eur + usd; // nemogoce

            // zelimo prepreciti ta scenarij : verjetnost, da se zgodi usd+eur mora biti 0.
        }
    }
}

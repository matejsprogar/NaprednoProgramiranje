using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Predavanja
{
    class TujRazred
    {
        public TujRazred() { }
        // pravilen rezultat je vecji od 0
        // ce funkcija vrne -1 to pomeni napako
        public int tezko_delo(int delitelj, out int error) {
            error = 0;
            if (delitelj != 0)
                return 100 / delitelj;
            error = 12;
            return 0;
        }
        public int tezko_delo_alt(int delitelj, out int rezultat)
        {
            rezultat = 0;
            if (delitelj != 0)
            {
                rezultat = 100 / delitelj;
                return 0;
            }
            return 12;
        }
        public int tezko_delo_izjeme(int delitelj)
        {
            int rezultat = 100 / delitelj;
            Console.WriteLine("Aha, delim z {0}", delitelj);
            return rezultat;
        }
    }
    class izjeme
    {
        public static void Main()
        {
            TujRazred tezak = new TujRazred();

            // OPDP
            int err = 0;
            int td = tezak.tezko_delo(42/*0*/, out err);
            if (err == 0)
            {
                Console.WriteLine(td);
            }
            else
            {
                Console.WriteLine("ups, tezko delo ni uspelo! Koda {0}", err);
            }

            // NP izjeme
            try
            {
                int tdi = tezak.tezko_delo_izjeme(0);
                Console.WriteLine(tdi);
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("ups, deljenje z 0; sporocilo: {0}", e.Message);
                throw new MojaNapaka();
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("ups, nisem nasel datoteke");
                throw;
            }
            //catch(SystemException)
            //{
            //    Console.WriteLine("ups, nekaj je slo narobe");
            //}
            finally { }

            Console.WriteLine("nadaljujemo tukaj...");
        }
    }

    class MojaNapaka : SystemException
    {

    }
}

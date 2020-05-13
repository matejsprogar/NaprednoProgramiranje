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
        // vrne pravilen rezultat (vecje od 0) ALI -1 za napako
        // tezava, ce je pravilen rezultat lahko -1!?
        public int tezko_delo(int delitelj)
        {
            if (delitelj != 0)
            {
                int rezultat = 100 / delitelj;
                return rezultat;
            }
            return -1;
        }
        // vrne rezultat IN nastavi error kodo
        public int tezko_delo(int delitelj, out int error)
        {
            error = 0;
            if (delitelj != 0)
            {
                int rezultat = 100 / delitelj;
                return rezultat;
            }
            error = 12;
            return 0;
        }
        // vrne error kodo IN nastavi rezultat
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
        // vrne rezultat ALI vrze izjemo
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
            TujRazred tezak = new TujRazred();		// MANAGED nadzira prevajalnik/GC

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
            catch (FileNotFoundException)
            {
                Console.WriteLine("ups, nisem nasel datoteke");
                throw;
            }
            catch
            {
                Console.WriteLine("ups, nekaj je slo narobe");
            }
            finally { }

            Console.WriteLine("nadaljujemo tukaj...");


            // delo z datoteko
            StreamReader reader = null;
            try
            {
                reader = File.OpenText("datoteka.xxx");
                // throw new MojaNapaka(); // skoci na 101
                // ...
            }
            catch (FileNotFoundException)
            {
                // potem se finally
            }
            catch (MojaNapaka)
            {
                // potem se finally
            }
            catch
            {
                // potem se finally
            }
            finally
            {                   // VEDNO izveden, ne glede na izjeme, returne, goto-je
                reader.Dispose();       // rocno zapiranje unmanaged datoteke
            }
            Console.WriteLine("konec programa");
        }

        public static void programiranje_z_managed_resourci()
        {
            int i = 42;
            string s = "jaz sem string";
            // ...
        }

        public static void programiranje_z_unmanaged_resourci_s_pomocjo_try_in_finally()
        {
            StreamReader reader = null;
            try
            {
                reader = File.OpenText("datoteka.xxx"); // odpremo
                // ...
            }
            finally
            {                   // VEDNO izveden, ne glede na izjeme, returne, ...
                if (reader != null)
                    reader.Dispose();   // rocno zapiranje resursa
            }
        }

        public static void programiranje_z_unmanaged_resourci_s_pomocjo_using()
        {
            // nepravilno: StreamReader reader = File.OpenText("datoteka.xxx");
            using (StreamReader rd = File.OpenText("datoteka.xxx"))
            {
                // ...
            }
        }
    }

    class MojaNapaka : System.Exception
    {

    }
}

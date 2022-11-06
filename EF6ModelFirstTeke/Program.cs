using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6ModelFirstTeke
{
    class Program
    {
        static void Main()
        {
            using (var db = new TekeDbModelContainer())
            {
                /* 3. feladat
                 * Listázza ki az A korcsoportban indulók névsorát ábécé rendben!
                 */
                Console.WriteLine("3. feladat: Az A korcsoportban indulók névsora ábécé rendben:");
                db.Versenyzok.Where(v => v.Korcsop == "A").OrderBy(v => v.Nev).ToList().ForEach(v => Console.WriteLine(v.Nev));

                /* 4. feladat:
                 * Listázza ki azon versenyzők rajtszámait, akiknek volt üres gurítása! Ha több üres gurítása
                 * volt valakinek, akkor is csak egyszer írja ki a rajtszámát!
                 */
                Console.WriteLine("\n4. feladat: Üres gurítással rendelkező versenyzők:");
                (from v in db.Versenyzok
                join e in db.Eredmenyek
                on v.Rajtszam equals e.VersenyzoRajtszam
                where e.Ures > 0
                select new { Rajtszám = v.Rajtszam, Név = v.Nev }).Distinct().ToList().ForEach(v => Console.WriteLine($"{v.Rajtszám}, {v.Név}"));
                
            }
            Console.ReadKey();
        }
    }
}

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

                /* 5. feladat:
                 * Listázza ki minden versenyzőre az átlagos tarolási pontértékét! A versenyzők neve mellett
                 * a számított mező címkéje „atlagpont” legyen! A listát rendezze a számított mező szerint
                 * csökkenő rendbe! 5. feladat:)
                 */
                Console.WriteLine("\n5. feladat (a):");
                Console.WriteLine("Név, Átlagpont");
                (from v in db.Versenyzok
                 join e in db.Eredmenyek
                 on v.Rajtszam equals e.VersenyzoRajtszam
                 group new { v.Nev, e.Tarolas } by v.Rajtszam into tarolasGroup
                 let avg = tarolasGroup.Average(x => x.Tarolas)
                 orderby avg descending
                 select new { Név = tarolasGroup.FirstOrDefault().Nev, Átlag = avg } //itt is azvan mint a (b) verzióban
                 ).ToList().ForEach(r => Console.WriteLine($"{r.Név}, {r.Átlag}"));

                //félig query félig metoh syntax
                Console.WriteLine("\n5. feladat (b):");
                Console.WriteLine("Név, Átlagpont");
                (from v in db.Versenyzok
                 join e in db.Eredmenyek
                 on v.Rajtszam equals e.VersenyzoRajtszam
                 group new { v.Nev, e.Tarolas } by v.Rajtszam) // itt célszerű rajtszám szerint csoportosítani, mert lehetnek azonos nevű versenyzők...
                 .Select(g => new { Név = g.FirstOrDefault().Nev, Átlag = g.Average(x => x.Tarolas) }) //itt viszont akkor nem jó a g.Key, mert az a rajtszám lesz, ki kell venni az első elemet...
                 .OrderByDescending(x => x.Átlag).ToList()
                 .ForEach(r => Console.WriteLine($"{r.Név}, {r.Átlag}"));

                //Opps. Ha már van Navigation Property... a join-ra és a group by-ra sincs szükség!!!
                Console.WriteLine("\n5. feladat (c):");
                Console.WriteLine("Név, Átlagpont");
                db.Versenyzok
                    .Select(v => new { Név = v.Nev, Átlag = v.Eredmenyek.Average(e => e.Tarolas) })
                    .OrderByDescending(x => x.Átlag).ToList()
                    .ForEach(x => Console.WriteLine($"{x.Név}, {x.Átlag}"));

            }
            Console.ReadKey();
        }
    }
}

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
                //3. feladat
                Console.WriteLine("3. feladat: Az A korcsoportban indulók névsora ábécé rendben:");
                db.Versenyzok.Where(v => v.Korcsop == "A").OrderBy(v => v.Nev).ToList().ForEach(v => Console.WriteLine(v.Nev));

            }
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF6DbFirstTeke
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TekeDbEntities())
            {
                db.Egyesuleteks.ToList()[1].Versenyzoks.ToList().ForEach(v => Console.WriteLine(v.Nev));
            }

            Console.ReadKey();
        }
    }
}

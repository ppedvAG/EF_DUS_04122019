using ppedv.Hampelmann.Logic;
using ppedv.Hampelmann.Model;
using System;
using System.Linq;
using System.Text;

namespace ppedv.Hampelmann.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("*** Hampelmann v0.1 ***");

            var core = new Core();

            if (core.Repository.GetAll<Produkt>().Count() == 0)
                core.CreateDemoData();

            foreach (var s in core.Repository.GetAll<Stand>())
            {
                Console.WriteLine($"{s.Name} {s.Besitzer}");
                foreach (var p in s.Produkte)
                {
                    Console.WriteLine($"\t{p.Name} {p.Preis:c}");
                }
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}

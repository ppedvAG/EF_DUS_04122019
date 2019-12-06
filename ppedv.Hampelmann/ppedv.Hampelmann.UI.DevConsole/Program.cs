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

            if (core.UnitOfWork.GetRepo<Produkt>().Query().Count() == 0)
                core.CreateDemoData();

            foreach (var s in core.UnitOfWork.StandRepository.GetAll())
            {
                Console.WriteLine($"{s.Name} {s.Besitzer}");
                foreach (var p in s.Produkte)
                {
                    Console.WriteLine($"\t{p.Name} {p.Preis:c}");
                }
            }

            var stand = core.GetStandMitTeuerstensProdukten();
            Console.WriteLine($"Deluxe Stand: {stand.Name} von {stand.Besitzer}");

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}

using ppedv.Hampelmann.Logic;
using ppedv.Hampelmann.Model;
using System;

namespace ppedv.Hampelmann.UI.DevConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** Hampelmann v0.1 ***");

            var core = new Core();

            foreach (var s in core.Repository.GetAll<Stand>())
            {
                Console.WriteLine($"{s.Name} {s.Besitzer}");
            }

            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}

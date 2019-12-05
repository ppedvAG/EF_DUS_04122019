using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_FromDB
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hallo Welt");

            var con = new Model1();

            foreach (var item in con.Employees.ToList())
            {
                Console.WriteLine(item.LastName);
            }
            Console.WriteLine("Ende");
            Console.ReadLine();
        }
    }
}

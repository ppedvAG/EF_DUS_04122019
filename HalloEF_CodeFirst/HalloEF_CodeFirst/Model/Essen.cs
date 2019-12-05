using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloEF_CodeFirst.Model
{
    public class Essen : Produkt
    {
        public int KCal { get; set; }
        public bool Vegan { get; set; }

    }

    public class Getraenk : Produkt
    {
        public int Alk { get; set; }
        public string Farbe { get; set; }

    }

    public class Plunder : Produkt
    {
        public string Material { get; set; }
        public bool Glaenzt { get; set; }

    }
}

using System.Collections.Generic;

namespace HalloEF_CodeFirst.Model
{
    public class Stand
    {
        public long Id { get; set; }

        public string Besitzer { get; set; }
        public string Name { get; set; }
        public Standtyp Typ { get; set; }
        //public ICollection<Produkt> Produkte { get; set; } = new HashSet<Produkt>();
        public ICollection<Markt> Maerkte { get; set; } = new HashSet<Markt>();
    }

    public enum Standtyp
    {
        Getränke,
        Essen,
        Kram,
        Plunder,
        Zeug,
        Karusell

    }
}

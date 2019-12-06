using System.Collections.Generic;

namespace ppedv.Hampelmann.Model
{
    public class Stand : Entity
    {
        public string Besitzer { get; set; }
        public string Name { get; set; }
        public bool IsOffen { get; set; }
        public Standtyp Typ { get; set; }
        public virtual ICollection<Produkt> Produkte { get; set; } = new HashSet<Produkt>();
        public virtual ICollection<MarktStand> Maerkte { get; set; } = new HashSet<MarktStand>();
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

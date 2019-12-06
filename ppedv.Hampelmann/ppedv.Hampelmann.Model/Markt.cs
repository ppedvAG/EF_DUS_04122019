using System;
using System.Collections.Generic;

namespace ppedv.Hampelmann.Model
{
    public class Markt : Entity
    {
        public string Ort { get; set; }
        public DateTime Von { get; set; }
        public DateTime Bis { get; set; }
        public virtual ICollection<MarktStand> Staende { get; set; } = new HashSet<MarktStand>();
    }
}

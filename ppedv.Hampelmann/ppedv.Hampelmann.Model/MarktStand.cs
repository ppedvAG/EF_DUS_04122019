using System.Collections.Generic;

namespace ppedv.Hampelmann.Model
{
    public class MarktStand
    {
        public long MarktId { get; set; }
        public virtual Markt Markt { get; set; }
        public long StandId { get; set; }
        public virtual Stand Stand { get; set; }
    }
}

using System;

namespace ppedv.Hampelmann.Model
{
    public abstract class Entity
    {
        public long Id { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public DateTime Modified { get; set; } = DateTime.Now;
    }
}

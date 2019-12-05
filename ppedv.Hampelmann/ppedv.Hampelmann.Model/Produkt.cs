namespace ppedv.Hampelmann.Model
{
    public abstract class Produkt : Entity
    {
        public string Name { get; set; }
        public decimal Preis { get; set; }
        public virtual Stand Stand { get; set; }
    }
}

namespace HalloEF_CodeFirst.Model
{
    public abstract class Produkt
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public decimal Preis { get; set; }
        public Stand Stand { get; set; }
    }
}

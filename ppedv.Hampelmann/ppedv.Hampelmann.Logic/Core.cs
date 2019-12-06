using Bogus;
using ppedv.Hampelmann.Model;
using ppedv.Hampelmann.Model.Contracts;
using System;
using System.Linq;

namespace ppedv.Hampelmann.Logic
{
    public class Core
    {
        public IRepository Repository { get; }

        public Core(IRepository repo)
        {
            Repository = repo;
        }

        public Core() : this(new Data.EF.EfRepository())
        { }

        public Stand GetStandMitTeuerstensProdukten()
        {
            return  Repository.Query<Stand>().OrderByDescending(x => x.Produkte.Sum(y => y.Preis)).FirstOrDefault();
        }

        public void CreateDemoData()
        {
            var faker = new Faker("de");
            var markt = new Markt()
            {
                Ort = faker.Address.City(),
                Von = DateTime.MinValue,
                Bis = DateTime.MaxValue
            };

            for (int i = 0; i < 100; i++)
            {
                var stand = new Stand()
                {
                    Besitzer = faker.Name.FullName(),
                    Typ = faker.Random.Enum<Standtyp>(),
                    Name = faker.Company.CompanyName()

                };
                stand.Maerkte.Add(new MarktStand() { Markt = markt, Stand = stand });


                for (int j = 0; j < faker.Random.Int(3, 10); j++)
                {
                    var p = new Plunder()
                    {
                        Glaenzt = faker.Random.Bool(),
                        Material = faker.Commerce.ProductMaterial(),
                        Name = faker.Commerce.ProductName(),
                        Preis = faker.Random.Decimal(0.5m, 100),
                        Stand = stand
                    };
                    Repository.Add(p);
                }
            }
            Repository.Save();
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ppedv.Hampelmann.Model;
using ppedv.Hampelmann.Model.Contracts;
using System.Linq;

namespace ppedv.Hampelmann.Logic.Tests
{
    [TestClass]
    public class CoreTests
    {
        [TestMethod]
        public void Core_GetStandMitTeuerstensProdukten___()
        {
            var repoMock = new Mock<IRepository<Stand>>();
            var uowMock = new Mock<IUnitOfWork>();

            uowMock.Setup(x => x.GetRepo<Stand>()).Returns(repoMock.Object);

            repoMock.Setup(x => x.Query()).Returns(() =>
            {
                var s1 = new Stand() { Name = "s1" };
                s1.Produkte.Add(new Plunder() { Preis = 6m });
                s1.Produkte.Add(new Plunder() { Preis = 4m });

                var s2 = new Stand() { Name = "s2" };
                s2.Produkte.Add(new Plunder() { Preis = 10m });
                s2.Produkte.Add(new Plunder() { Preis = 8m });
                return new[] { s1, s2 }.AsQueryable();
            });
            var core = new Core(uowMock.Object);

            var result = core.GetStandMitTeuerstensProdukten();

            Assert.AreEqual("s2", result.Name);
        }

        [TestMethod]
        public void Core_GetStandMitTeuerstensProdukten_keine_stände()
        {
        }

        [TestMethod]
        public void Core_GetStandMitTeuerstensProdukten_keine_produkte()
        {

        }

        [TestMethod]
        public void Core_GetStandMitTeuerstensProdukten_zwei_ständer_gleiche_summe()
        {
        }
    }
}

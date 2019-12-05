using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ppedv.Hampelmann.Data.EF.Tests
{
    [TestClass]
    public class EfContextTests
    {
        [TestMethod]
        public void EfContext_can_create_db()
        {
            using (var con = new EfContext())
            {
                con.Database.EnsureDeleted();

                con.Database.EnsureCreated();

                Assert.IsTrue(con.Database.CanConnect());
            }
        }
    }
}

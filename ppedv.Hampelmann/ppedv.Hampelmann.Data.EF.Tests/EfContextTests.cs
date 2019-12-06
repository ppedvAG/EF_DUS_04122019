using Microsoft.VisualStudio.TestTools.UnitTesting;
using ppedv.Hampelmann.Model;
using System;

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

        [TestMethod]
        public void EfContext_can_CRUD_Stand()
        {
            var stand = new Stand()
            {
                Name = $"Teststand_{Guid.NewGuid()}"
            };
            var newName = $"NeuerStand_{Guid.NewGuid()}";

            using (var con = new EfContext())
            {
                //CREATE
                con.Staende.Add(stand);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check CREATE
                var loaded = con.Staende.Find(stand.Id);
                Assert.IsNotNull(loaded);
                Assert.AreEqual(stand.Name, loaded.Name);

                //UPDATE
                loaded.Name = newName;
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check UPDATE
                var loaded = con.Staende.Find(stand.Id);
                Assert.AreEqual(newName, loaded.Name);

                //DELETE
                con.Staende.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                //check DELETE
                var loaded = con.Staende.Find(stand.Id);
                Assert.IsNull(loaded);
            }
        }
    }
}
using HalloEF_CodeFirst.Model;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace HalloEF_CodeFirst.Data
{
    public class EfContext : DbContext
    {
        public DbSet<Stand> Staende { get; set; }
        public DbSet<Markt> Maerkte { get; set; }
        //public DbSet<Produkt> Produkte { get; set; }
        public DbSet<Plunder> Plunder { get; set; }
        public DbSet<Essen> Essen { get; set; }
        public DbSet<Getraenk> Getraenk { get; set; }

        //public EfContext() : base("Data Source=.;Initial Catalog=EfCodeFirst;Integrated Security=true")
        //public EfContext() : base("Server=(localdb)\\mssqllocaldb;Database=EfCodeFirst;Trusted_Connection=true")
        public EfContext() : base("Server=.\\SQLEXPRESS;Database=EfCodeFirst;Trusted_Connection=true")
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<EfContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<EfContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EfContext, Migrations.Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //System.Data.Entity.ModelConfiguration.Conventions.
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add(new MyDateTime2Conv());

            modelBuilder.Entity<Stand>().Property(x => x.Besitzer).HasMaxLength(25).IsRequired();
            //modelBuilder.Entity<Markt>().Property(x => x.Von).HasColumnType("datetime2");

            modelBuilder.Entity<Produkt>().ToTable("Produkt");
            modelBuilder.Entity<Essen>().ToTable("Essen");
            modelBuilder.Entity<Getraenk>().ToTable("Getraenk");
            modelBuilder.Entity<Plunder>().ToTable("Plunder");

        }
    }

    public class MyDateTime2Conv : Convention
    {
        public MyDateTime2Conv()
        {
            Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        }
    }
}
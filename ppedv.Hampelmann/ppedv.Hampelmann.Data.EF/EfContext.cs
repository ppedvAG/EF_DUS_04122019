using Microsoft.EntityFrameworkCore;
using ppedv.Hampelmann.Model;

namespace ppedv.Hampelmann.Data.EF
{
    public class EfContext : DbContext
    {
        public DbSet<Stand> Staende { get; set; }
        public DbSet<Markt> Maerkte { get; set; }
        public DbSet<Plunder> Plunder { get; set; }
        public DbSet<Essen> Essen { get; set; }
        public DbSet<Getraenk> Getraenk { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                          .UseSqlServer("Server=.\\SQLEXPRESS;Database=Hampelmann_dev;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MarktStand>().HasKey(x => new { x.MarktId, x.StandId });

            modelBuilder.Entity<MarktStand>().HasOne(m => m.Markt)
                                             .WithMany(x => x.Staende)
                                             .HasForeignKey(x => x.MarktId);

            modelBuilder.Entity<MarktStand>().HasOne(m => m.Stand)
                                             .WithMany(x => x.Maerkte)
                                             .HasForeignKey(x => x.StandId);

        }
    }
}

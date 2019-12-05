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
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=Hampelmann_dev;Trusted_Connection=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Markt>().HasMany(x => x.Staende);
            modelBuilder.Entity<Stand>().HasMany(x => x.Maerkte);
        }
    }
}

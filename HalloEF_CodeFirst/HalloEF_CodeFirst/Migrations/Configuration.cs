namespace HalloEF_CodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HalloEF_CodeFirst.Data.EfContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;

            ContextKey = "HalloEF_CodeFirst.Data.EfContext";
        }

        protected override void Seed(HalloEF_CodeFirst.Data.EfContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}

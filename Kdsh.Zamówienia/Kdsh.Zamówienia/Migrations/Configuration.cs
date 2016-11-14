namespace Kdsh.Zamówienia.Migrations
{
    using System.Data.Entity.Migrations;
   

    internal sealed class Configuration : DbMigrationsConfiguration<Kdsh.Zamówienia.Models.Encje.Kontekst>
    {
        public Configuration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
            ContextKey = "Kdsh.Zamówienia.Models.Encje.Kontekst";
        }

        protected override void Seed(Kdsh.Zamówienia.Models.Encje.Kontekst context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}

using System.Data.Entity;

namespace Kdsh.Zamówienia.Models.Encje
{
    public class Kontekst : DbContext
    {
        public DbSet<Administrator> Administratorzy { get; set; }
        public DbSet<Kolor> Kolory { get; set; }
        public DbSet<Sklep> Sklepy { get; set; }
        public DbSet<StatusZamówienia> StatusyZamówień { get; set; }
        public DbSet<Zamówienie> Zamówienia { get; set; }
        public DbSet<Zasób> Zasoby { get; set; }
    }
}
using Kdsh.Zamówienia.Models.Encje;

namespace Kdsh.Zamówienia.Models.Widok.Zamówienia
{
    public class Dodaj
    {
        public Sklep[] Sklepy { get; set; }
        public Zamówienie Zamówienie { get; set; }
        public Zasób[] Zasoby { get; set; }
    }
}
using Kdsh.Zamówienia.Models.Encje;

namespace Kdsh.Zamówienia.Models.Widok.Zamówienia
{
    public class Status
    {
        public StatusZamówienia[] Statusy { get; set; }
        public Zamówienie Zamówienie { get; set; }
    }
}
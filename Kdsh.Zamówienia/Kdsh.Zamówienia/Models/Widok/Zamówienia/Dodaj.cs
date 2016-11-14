using System.Collections.Generic;
using Kdsh.Zamówienia.Models.Encje;

namespace Kdsh.Zamówienia.Models.Widok.Zamówienia
{
    public class Dodaj
    {
        public Zamówienie Zamówienie { get; set; }
        public Zasób[] Zasoby { get; set; }
        public Dictionary<Zasób, Kolor[]> ZasóbNaKolory { get; set; }
    }
}
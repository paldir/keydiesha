using Kdsh.Zamówienia.Models.Encje;

namespace Kdsh.Zamówienia.Models.Widok.Sklepy
{
    public class Index
    {
        public long IdWybranegoSklepu { get; set; }
        public Sklep[] Sklepy { get; set; }
    }
}
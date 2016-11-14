using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kdsh.Zamówienia.Models.Encje
{
    public class Sklep
    {
        [Key]
        public long Id { get; set; }

        public virtual ICollection<Zamówienie> Zamówienia { get; set; }
    }
}
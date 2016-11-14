using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kdsh.Zamówienia.Models.Encje
{
    public class StatusZamówienia
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nazwa { get; set; }

        public virtual ICollection<Zamówienie> Zamówienia { get; set; }
    }
}
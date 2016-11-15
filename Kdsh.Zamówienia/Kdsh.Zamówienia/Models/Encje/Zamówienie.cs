using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kdsh.Zamówienia.Models.Encje
{
    public class Zamówienie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [Display(Name = "Data złożenia")]
        public DateTime DataZłożenia { get; set; }

        [Required]
        public int Ilość { get; set; }

        [Required]
        public long? KolorId { get; set; }

        public virtual Kolor Kolor { get; set; }

        [Required]
        public long? SklepId { get; set; }

        public virtual Sklep Sklep { get; set; }

        [Required]
        public long? StatusId { get; set; }

        public virtual StatusZamówienia Status { get; set; }

        [Required]
        public long? ZasóbId { get; set; }

        public virtual Zasób Zasób { get; set; }
    }
}
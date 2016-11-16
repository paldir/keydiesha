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
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy, HH:mm}")]
        public DateTime DataZłożenia { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Pole Ilość musi być większe od 0.")]
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
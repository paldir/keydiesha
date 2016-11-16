using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kdsh.Zamówienia.Models.Encje
{
    public class Administrator
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [Display(Name = "Nazwa użytkownika")]
        [Required]
        [StringLength(50)]
        public string Nazwa { get; set; }

        [Required]
        [StringLength(20)]
        public string Hasło { get; set; }
    }
}
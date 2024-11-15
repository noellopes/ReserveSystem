using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Ementa
    {

        [Key]
        public int EmentaId { get; set; }

        [Required]

        public Prato NomePrato { get; set; }

        [Required]
        public int IdSobremesas { get; set; }

        [Required]

        public int IdSopas { get; set; }

        [Required]

        public int IdBebidas { get; set; }

    }
}

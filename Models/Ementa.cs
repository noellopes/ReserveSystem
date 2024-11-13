using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Ementa
    {
        
        public int EmentaId { get; set; }

        [Required]

        public int IdPratos { get;}

        [Required]
        public int IdSobremesas { get; }

        [Required]

        public int IdSopas { get; }

        [Required]

        public int IdBebidas { get; }

    }
}

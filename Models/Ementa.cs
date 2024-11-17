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

       

    }
}

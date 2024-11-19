using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class TipoQuarto
    {
        [Key]
        // [Required]
        public int TipoQuartoId { get; set; }
        [Required]
        [MaxLength(25)]
        public string type { get; set; }

        [Required]
        public int capacity { get; set; }

        [Required]
        public int RoomQuantity { get; set; }


        [Required]
        public bool AcessibilityRoom { get; set; }

        [Required]
        public bool View { get; set; }

    }
}



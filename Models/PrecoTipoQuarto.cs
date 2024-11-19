using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class PrecoTipoQuarto
    {
        [Key]
        [Required]
        public int id_RTPrice { get; set; }

        [Required(ErrorMessage = "Please enter the base price for this room type")]
        public float BasePrice { get; set; }

        [Required(ErrorMessage = "Please enter the cancelation fee for this room type")]
        public float CancelationFee { get; set; }

        [Required(ErrorMessage = "Please enter the price of additional beds for this room type")]
        public float AdicionalBeds { get; set; }

        // Foreign key and navigation property
        [Required]
        public int TipoQuartoId { get; set; } // Foreign key
        public required TipoQuarto TipoQuarto { get; set; } // Navigation property
    }
}

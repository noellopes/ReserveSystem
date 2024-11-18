using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class TipoQuarto
    {
       // [Key] 
        [Required]
        public int TipoQuartoId { get; set; }
        [Required]
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



/*
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class TipoQuarto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TipoQuartoId { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public int Capacity { get; set; }

        [Required]
        public int RoomQuantity { get; set; }

        [Required]
        public bool AccessibilityRoom { get; set; }

        [Required]
        public bool View { get; set; }

        // Navigation property for one-to-one relationship
        public PrecoTipoQuarto PrecoTipoQuarto { get; set; }
    }
}
*/
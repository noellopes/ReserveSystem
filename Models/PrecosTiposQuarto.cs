using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models;
public class PrecoTipoQuarto : TipoQuarto
{

    [Key]
  //[Required]
    public int id_RTPrice { get; set; }
    [Required]
	public	float BasePrice {  get; set; }

    [Required]
    public float CancelationFee { get; set; }

    [Required]
    public float AdicionalBeds { get; set; } 
}
/*
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class PrecoTipoQuarto
    {
        [Key]
        [ForeignKey("TipoQuarto")] // Links this to TipoQuarto
        public int TipoQuartoId { get; set; }

        [Required]
        public float BasePrice { get; set; }

        [Required]
        public float CancellationFee { get; set; }

        [Required]
        public float AdditionalBeds { get; set; }

        // Navigation property back to TipoQuarto
        public TipoQuarto TipoQuarto { get; set; }
    }
}
*/
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models;
public class PrecoTipoQuarto : TipoQuarto
{

    [Key]
    public int id_RTPrice { get; set; }
    [Required]
	public	float BasePrice {  get; set; }

    [Required]
    public float CancelationFee { get; set; }

    [Required]
    public float AdicionalBeds { get; set; }

    /*
    [ForeignKey("TipoQuarto")] public int TipoQuartoId { get; set; } 
    // Navigation property
    public TipoQuarto TipoQuarto { get; set; }

    */
}


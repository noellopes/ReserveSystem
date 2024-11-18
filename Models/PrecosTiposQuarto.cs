using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models;
public class PrecoTipoQuarto 
{
    [Key]
    public int TipoQuartoId { get; set; }
    [Required]
    public string tipo { get; set; }

    [Required]
    public int capacidade { get; set; }

    [Required]
    public int quantidadeQuartos { get; set; }
   


    [Required]
	public	float PrecoBase {  get; set; }

    [Required]
    public float taxaCancelamento { get; set; }

    [Required]
    public float camaAdiconal { get; set; }


    [Required]
    public bool QuartoAdaptado { get; set; }

    [Required]
    public bool Vista {  get; set; }

    
}


using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models;
public class PrecoTipoQuarto : TipoQuarto
{

    [Key]
    public int precotq_id { get; set; }
    [Required]
	public	float PrecoBase {  get; set; }

    [Required]
    public float taxaCancelamento { get; set; }

    [Required]
    public float camaAdiconal { get; set; }



    
}


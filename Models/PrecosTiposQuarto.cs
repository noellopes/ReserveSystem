using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models;
public class PrecoTipoQuarto : Reserva
{
    [Key]
    public int precotq_id { get; set; }
    [Required]
    public string tipo { get; set; }
    [Required]
    public int QuantidadeDeQuartos { get; set; }
    [Required]
    public int capacidade { get; set; }

    [Required]
	public	float PrecoBase {  get; set; }

    [Required]
    public float taxaCancelamento { get; set; }

    [Required]
    public float taxaAdiconal { get; set; }

}


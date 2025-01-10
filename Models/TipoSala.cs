using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models;

public class TipoSala
{
    [Key]
    public long IdTipoSala { get; set; }

    [Required(ErrorMessage = "The 'Room Type Name' field is required.")]
    [StringLength(100, ErrorMessage = "The 'Room Type Name' must not exceed 100 characters.")]
    public string NomeSala { get; set; }

    [Required(ErrorMessage = "The 'Room Size' field is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "The 'Room Size' must be greater than 0.")]
    public int TamanhoSala { get; set; }

    [Required(ErrorMessage = "The 'Capacity' field is required.")]
    [Range(1, int.MaxValue, ErrorMessage = "The 'Capacity' must be greater than 0.")]
    public int Capacidade { get; set; }

    [Required(ErrorMessage = "The 'Hourly Price' field is required.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "The 'Hourly Price' must be greater than 0.")]
    public double PreçoHora { get; set; }

    public ICollection<Sala>? Salas { get; set; }
    
}
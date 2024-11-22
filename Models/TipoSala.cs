using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models;

public class TipoSala
{
    [Key]
    public long IdTipoSala { get; set; }

    [Required(ErrorMessage = "O campo 'NomeSala' é obrigatório.")]
    [StringLength(100, ErrorMessage = "O nome da sala deve ter no máximo 100 caracteres.")]
    public string NomeSala { get; set; }
    
    [Required(ErrorMessage = "O campo 'TamanhoSala' é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "O tamanho da sala deve ser maior que 0.")]
    public int TamanhoSala { get; set; }
    
    [Required(ErrorMessage = "O campo 'Capacidade' é obrigatório.")]
    [Range(1, int.MaxValue, ErrorMessage = "A capacidade deve ser maior que 0.")]
    public int Capacidade { get; set; }
    
    [Required(ErrorMessage = "O campo 'PreçoHora' é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O preço por hora deve ser maior que 0.")]
    public double PreçoHora { get; set; }

    // Collection of Salas linked to this TipoSala
    public ICollection<Sala> Salas { get; set; }
}
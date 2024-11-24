using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReserveSystem.Models;

public class Sala
{
    [Key]
    public long IdSala { get; set; }
    
    [Required(ErrorMessage = "O campo 'TempoPreparação' é obrigatório.")]
    public TimeSpan TempoPreparação { get; set; }
    
    [Required(ErrorMessage = "O campo 'HoraInicio' é obrigatório.")]
    public TimeOnly HoraInicio { get; set; }
    
    [Required(ErrorMessage = "O campo 'HoraFim' é obrigatório.")]
    public TimeOnly HoraFim { get; set; }
    
    [Required(ErrorMessage = "O campo 'IdTipoSala' é obrigatório.")]
    [ForeignKey("TipoSala")]
    public long IdTipoSala { get; set; }
    public TipoSala? TipoSala { get; set; }
}
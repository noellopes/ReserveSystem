using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models;

public class TipoSala
{
    [Key]
    public long IdTipoSala { get; set; }

    public string NomeSala { get; set; }
    
    public int TamanhoSala { get; set; }
    
    public int Capacidade { get; set; }
    
    public double PreçoHora { get; set; }

    public virtual ICollection<Sala> Salas { get; set; }
    
}
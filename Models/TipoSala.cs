using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models;

public class TipoSala
{
    
    [Key] 
    public long IdTipoSala { get; set; }

    public string NomeAvaria { get; set; }
    
    public int TamanhoSala { get; set; }
    
    public int Capacidade { get; set; }

    public virtual Sala Sala { get; set; }
    
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models;

public class Sala
{
    [Key]
    public long IdSala {get;set;}
    
    public DateTime TempoPreparação {get;set;}
    
    public DateTime HoraInicio {get;set;}
    
    public DateTime HoraFim {get;set;}
    
    public double Preço {get;set;}
    
    [ForeignKey("TipoSala")]
    public long IdTipoSala  {get;set;}
    
    public virtual TipoSala TipoSala { get; set; }
    
}
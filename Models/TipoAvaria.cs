using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class TipoAvaria
    {
        [Key] public int IdTipoAvaria { get; set; }
        public int NomeAvaria { get; set; }
    }
}

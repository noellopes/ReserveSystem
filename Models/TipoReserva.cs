using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class TipoReserva
    {
        [Key]
        public long idTipoReserva { get; set; }
        [Required]
        public string NomeReserva { get; set; }
    }
}

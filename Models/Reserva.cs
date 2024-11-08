using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Reserva
    {

        [Key] [Required] 
        int ReservaId { get; set; }

        [Required]
        int ClienteId { get; set; }

        [Required]
        DateTime DataCheckIn { get; set; }

        [Required]
        DateTime DataCheckOut { get; set; }

        [Required]
        DateTime DataReserva { get; set; }

        [Required]
        bool EstadoPagamento { get; set; }

        [Required]
        string Estado { get; set; }

        [Required]
        int NumeroPessoas { get; set; }


    }
}

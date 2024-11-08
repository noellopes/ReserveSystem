using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Reserva
    {

        [Key] [Required] 
        int ReservaId { get; set; }

        [Required]
        int ClienteId { get; set; }

        [Required(ErrorMessage = "Data de CheckIn Necessária")]
        DateTime DataCheckIn { get; set; }

        [Required(ErrorMessage = "Data de CheckOut Necessária")]
        DateTime DataCheckOut { get; set; }
        
        [Required(ErrorMessage = "Data de Reserva Necessária")]
        DateTime DataReserva { get; set; }

        [Required]
        bool EstadoPagamento { get; set; }

        [Required]
        string? Estado { get; set; }

        [Required]
        int NumeroPessoas { get; set; }


    }
}

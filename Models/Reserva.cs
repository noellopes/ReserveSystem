using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Reserva
    {

        [Key] 
        public int ReservaId { get; set; }
        [Required(ErrorMessage = "Data de CheckIn")]
        public DateTime DataCheckIn { get; set; }
        [Required(ErrorMessage = "Data de CheckOut")]
        public DateTime DataCheckOut { get; set; }
        [Required(ErrorMessage = "Data de Reserva")]
        public DateTime DataReserva { get; set; }
        [Required(ErrorMessage = "Estado de Reserva é obrigatório")]
        public string Estado { get; set; }
        public bool EstadoPagamento { get; set; }
        [Required(ErrorMessage = "Número da pessoa")]
        public int NumeroPessoas { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }



    }
}

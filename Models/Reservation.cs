using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Reservation
    {

        [Key] 
        public int ReservationId { get; set; }

        public int ClienteId { get; set; }


        [Required(ErrorMessage = "Data de CheckIn")]
        public DateTime CheckInDate { get; set; }

        [Required(ErrorMessage = "Data de CheckOut")]
        public DateTime CheckOutDate { get; set; }

        [Required(ErrorMessage = "Data de Reserva")]
        public DateTime ReservationDate { get; set; }


        public string Status { get; set; }
        public bool PaymentStatus { get; set; }

        [Required(ErrorMessage = "Número da pessoa")]
        public int TotalPeople { get; set; }

        public ClienteModel Cliente { get; set; }


    }
}

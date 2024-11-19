using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class ReservaModel
    {

        [Key]
        public int ID_BOOKING { get; set; }
        [Required(ErrorMessage = "Data de CheckIn")]
        public DateTime CHECKIN_DATE { get; set; }
        [Required(ErrorMessage = "Data de CheckOut")]
        public DateTime CHECKOUT_DATE { get; set; }
        [Required(ErrorMessage = "Data de Reserva")]
        public DateTime BOOKING_DATE { get; set; }
        [Required(ErrorMessage = "Estado de Reserva é obrigatório")]
        public bool BOOKED { get; set; }
        public bool PAYMENT_STATUS { get; set; }
        [Required(ErrorMessage = "Número da pessoa")]
        public int TOTAL_PERSONS_NUMBER { get; set; }

        [ForeignKey("ID_CLIENT")]
        public ClienteModel? Cliente { get; set; }
    }
}

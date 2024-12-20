using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class BookingModel
    {
        [Key]
        public int ID_BOOKING { get; set; }

        [ForeignKey("ID_CLIENT")]
        public ClientModel? Client { get; set; }

        [Required(ErrorMessage = "Inserir Data de Check-In")]
        [DataType(DataType.Date)]
        public DateTime CHECKIN_DATE { get; set; }

        [Required(ErrorMessage = "Inserir Data de Check-Out")]
        [DataType(DataType.Date)]
        public DateTime CHECKOUT_DATE { get; set; }

        [DataType(DataType.Date)]
        public DateTime BOOKING_DATE { get; set; }

        [Required(ErrorMessage = "Inserir numero de pessoas")]
        public int TOTAL_PERSONS_NUMBER { get; set; }

        public bool BOOKED { get; set; }
        public bool PAYMENT_STATUS { get; set; }

    }
}

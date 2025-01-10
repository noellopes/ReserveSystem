using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Booking
    {
        [Key]
        public int ID_BOOKING { get; set; }


        [ForeignKey("ClienteId")]
        public int ID_CLIENT { get; set; }


        [Required(ErrorMessage = "Inserir Data de Check-In")]
        [DataType(DataType.Date)]
        public DateOnly CHECKIN_DATE { get; set; }

        [Required(ErrorMessage = "Inserir Data de Check-Out")]
        [DataType(DataType.Date)]
        public DateOnly CHECKOUT_DATE { get; set; }

        [DataType(DataType.Date)]
        public DateTime BOOKING_DATE { get; set; }

        [Required(ErrorMessage = "Inserir numero de pessoas")]
        public int TOTAL_PERSONS_NUMBER { get; set; }

        public bool BOOKED { get; set; }
        public bool PAYMENT_STATUS { get; set; }


         

        public ClientModel? Client { get; set; }




        public bool CanDeleteOrUpdate()
        {
            if(BOOKING_DATE.AddHours(1) > DateTime.Now) return true;
            return false;
        }
        public bool ValidDates(string action)
        {
            if ((CHECKIN_DATE.ToDateTime(TimeOnly.MinValue) - DateTime.Now).TotalDays < 0) return false;
            if ((CHECKOUT_DATE.ToDateTime(TimeOnly.MinValue) - CHECKIN_DATE.ToDateTime(TimeOnly.MinValue)).TotalDays < 0) return false;

            return true;
        }



    }
}

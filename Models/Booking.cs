using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "Client ID is required.")]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Check-in date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format for Check-in date.")]
        public DateTime Checkin_date { get; set; }

        [Required(ErrorMessage = "Check-out date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format for Check-out date.")]
        public DateTime Checkout_date { get; set; }

        [Required(ErrorMessage = "Booking date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format for Booking date.")]
        public DateTime Booking_Date { get; set; }

        [Required(ErrorMessage = "Booking status is required.")]
        public bool Booked { get; set; }

        [Required(ErrorMessage = "Total number of persons is required.")]
        [Range(1, 10, ErrorMessage = "The number of persons must be between 1 and 10.")]
        public int Total_Persons_Number { get; set; }

        [Required(ErrorMessage = "Payment status is required.")]
        public bool Payment_Status { get; set; }

        public ICollection<Client> clients { get; set; }
    }
}

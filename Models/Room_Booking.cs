using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Room_Booking
    {
        [Key]
        public int RoomBookingId { get; set; }
        public int BookingId { get; set; }
        public Booking ? booking { get; set; }
        public int RoomId { get; set; }
        public Room ? room { get; set; }

        [Required(ErrorMessage = "Number of persons is required.")]
        [Range(1, 10, ErrorMessage = "The number of persons must be between 1 and 10.")]
        public int Persons_Number { get; set; }

        public ICollection<Booking> ? bookings { get; set; }
    }
}
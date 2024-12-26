using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Room_Booking
    {
        public int RoomBookingId { get; set; }

        [Required(ErrorMessage = "Booking ID is required.")]
        public int BookingId { get; set; }

        [Required(ErrorMessage = "Room ID is required.")]
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Number of persons is required.")]
        [Range(1, 10, ErrorMessage = "The number of persons must be between 1 and 10.")]
        public int Persons_Number { get; set; }

        public ICollection<Booking> bookings { get; set; }
    }
}
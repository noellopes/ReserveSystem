using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Room Type ID is required.")]
        public int RoomTypeId { get; set; }

        public ICollection<Room_Booking> room_Bookings { get; set; }
    }
}

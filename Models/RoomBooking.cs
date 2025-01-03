using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomBooking
    {
        [Key]
        [Required]
        public int ID_ROOM_BOOKING { get; set; }

        [Required]
        [ForeignKey("Booking")]
        public int ID_BOOKING { get; set; }

        [Required]
        [ForeignKey("RoomModel")]
        public int ID_ROOM { get; set; }

        [Required]
        public int PERSON_NUMBER { get; set; }

        public Booking Booking { get; set; }
        public RoomModel RoomModel { get; set; }
    }
}
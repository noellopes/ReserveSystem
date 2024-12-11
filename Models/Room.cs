using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Room
    {
        [Required, Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INTEGER")]
        public int Id { get; set; }

        [Required, MaxLength(10)]
        [Column(TypeName = "VARCHAR(10)")]
        public required string RoomNumber { get; set; }

        [Required, MaxLength(100)]
        [Column(TypeName = "VARCHAR(100)")]
        public required string Type { get; set; }

        // Navigation property for related RoomServiceBookings
        public ICollection<RoomServiceBooking>? RoomServiceBookings { get; set; }
    }
}
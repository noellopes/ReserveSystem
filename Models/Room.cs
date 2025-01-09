using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace ReserveSystem.Models
{
    [Index(nameof(Number), IsUnique = true)]
    public class Room
    {
    
        [Required, Key, Display(Name = "Room Id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INTEGER")]
        public int Id { get; set; }

        [Required, Display(Name = "Room Number"), StringLength(4), MinLength(1), MaxLength(5)]
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR(5)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[1-4][0-9]{2}$", ErrorMessage = "Room number must be in format: floor (1-4) + room number (01-99)")]
        public required string Number { get; set; }

        [Required, Display(Name = "Room Type"), StringLength(50), MinLength(1), MaxLength(50)]
        [DataType(DataType.Text)]
        [Column(TypeName = "VARCHAR(50)")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Room type must be alphabetic")]
        public required string Type { get; set; }

        public List<RoomServiceBooking>? Bookings { get; set; }
    }
}
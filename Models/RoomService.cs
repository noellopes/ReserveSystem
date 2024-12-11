using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomService
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INTEGER")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Job")]
        [Column(TypeName = "INTEGER(11)")]
        public int JobId { get; set; }
        public required Job Job { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        [Display(Name = "Service Name")]
        [Column(TypeName = "VARCHAR(100)")]
        public required string Name { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        [Display(Name = "Service Description")]
        [Column(TypeName = "VARCHAR(500)")]
        public required string Description { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C}"), Range(0, 999999.99)]
        [Display(Name = "Price")]
        [Column(TypeName = "decimal(8, 2)")]
        public required decimal Price { get; set; }

        [Required]
        [Display(Name = "Active")]
        [Column(TypeName = "bit")]
        public required bool Active { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Duration")]
        [Column(TypeName = "time")]
        public required TimeSpan LimitHour { get; set; }

        // Navigation property for related RoomServiceBookings
        public ICollection<RoomServiceBooking> RoomServiceBookings { get; set; } = [];
    }
}
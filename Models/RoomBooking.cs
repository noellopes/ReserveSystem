using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomBooking
    {
        // Primary Key
        // RoomBookingID: INT
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomBookingID { get; set; }

        // Foreign Keys
        // BookingID: INT
        // RoomID: INT

        [Required]
        public int BookingID { get; set; }

        [ForeignKey("BookingID")]
        public required virtual Booking Booking { get; set; }

        [Required]
        public int RoomID { get; set; }

        [ForeignKey("RoomID")]
        public required virtual Room Room { get; set; }

        // Attributes
        // NumberOfGuests: INT
        [Required]
        [Range(1, 10)]
        [Display(Name = "Number of Guests")]
        [Column(TypeName = "INTEGER")]
        [DisplayFormat(DataFormatString = "{0:0}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please enter a valid number.")]
        public int NumberOfGuests { get; set; }

        // Methods for reference only, business logic should be in the controller
        // ConsultRoomBooking()
    }
}
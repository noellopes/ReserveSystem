using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Booking
    {
        // Primary Key
        // BookingId: INT
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingId { get; set; }

        // Foreign Keys
        // Id_Client: INT
        [Required]
        public required int ClientId { get; set; }

        [ForeignKey("ClientID")]
        public required virtual Client Client { get; set; }

        // Attributes
        // Chek_In_Date: DATE
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Check-In Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(TypeName = "DATE")]
        public required DateTime CheckInDate { get; set; }

        // Check_Out_Date: DATE
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Check-Out Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(TypeName = "DATE")]
        public required DateTime CheckOutDate { get; set; }

        // Booking_Date: DATE
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Booking Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(TypeName = "DATE")]
        public required DateTime BookingDate { get; set; }

        // Booked_State: Boolean
        [Required]
        [Display(Name = "Booked State")]
        [Column(TypeName = "BOOLEAN")]
        public required Boolean BookedState { get; set; }
        
        // Number_Of_Guests: INT
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Number of Guests")]
        [DisplayFormat(NullDisplayText = "No Guests, guests is null!")]
        [Column(TypeName = "INTEGER")]
        [MinLength(1)]
        [StringLength(2)]
        [MaxLength(2)]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use numbers only please")]
        public required string NumberOfGuests { get; set; }

        // Payment: Boolean
        [Required]
        [Display(Name = "Payment")]
        [Column(TypeName = "BOOLEAN")]
        public required Boolean Payment { get; set; }

        // Methods for reference only, business logic should be in the controller
        // Consult_Booking()

        /* public void Consult_Booking(int BookingID)
        {
            // Consult the booking with the given BookingID

            // If the booking does not exist, return null
            
            // Else return the booking
        }  */
    }
}

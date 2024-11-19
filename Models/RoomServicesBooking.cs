using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomServicesBooking
    {
        // Primary Key
        // RoomServiceBookingId: INT
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int RoomServiceBookingId { get; set; }

        // Foreign Keys
        // RoomServiceId: INT
        // StaffId: INT
        // ClientId: INT
        // RoomId: INT
        [Required]
        public required int RoomServiceId { get; set; }

        [ForeignKey("RoomServiceId")]
        public required virtual RoomService RoomService { get; set; }

        [Required]
        public required int StaffId { get; set; }

        [ForeignKey("StaffId")]
        public required virtual Staff Staff { get; set; }

        [Required]
        public required int ClientId { get; set; }

        [ForeignKey("ClientId")]
        public required virtual Client Client { get; set; }

        [Required]
        public required int RoomId { get; set; }

        [ForeignKey("RoomId")]
        public required virtual Room Room { get; set; }

        // Attributes
        // DateTime: SYSDATE
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        [Column(TypeName = "DATETIME")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // Computed at the database
        public required DateTime DateTime { get; set; }

        // StartDate: DATE
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(TypeName = "DATE")]
        public required DateTime StartDate { get; set; }

        // EndDate: DATE
        [DataType(DataType.Date)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [Column(TypeName = "DATE")]
        public required DateTime EndDate { get; set; }

        // BookedState: BOOLEAN
        [Required]
        [Display(Name = "Booked State")]
        [Column(TypeName = "BOOLEAN")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // Computed at the database
        public required bool BookedState { get; set; } = true;

        // StaffConfirmation: BOOLEAN
        [Required]
        [Display(Name = "Staff Confirmation")]
        [Column(TypeName = "BOOLEAN")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // Computed at the database
        public required bool StaffConfirmation { get; set; } = false;

        // ClientFeedback: INT
        [DataType(DataType.Text)]
        [Range(1, 5)]
        [Display(Name = "Client Feedback")]
        [Column(TypeName = "INTEGER")]
        [DisplayFormat(NullDisplayText = "No feedback, feedback is null!")]
        [RegularExpression(@"^[1-5]{1}$", ErrorMessage = "Feedback must be between 1 and 5.")]
        public int? ClientFeedback { get; set; }

        // AmountToPay: DOUBLE
        [Required]
        [DataType(DataType.Currency)]
        [Range(0.01, 999999.99)]
        [Display(Name = "Amount to Pay")]
        [Column(TypeName = "DECIMAL{10,2}")]
        [DisplayFormat(NullDisplayText = "No amount, amount is null!")]
        [RegularExpression(@"^[0-9]{1,10}\.[0-9]{2}$", ErrorMessage = "Amount must be in the format of 0.00.")]
        public required decimal AmountToPay { get; set; }

        // PaymentMade: BOOLEAN
        [Required]
        [Display(Name = "Payment Made")]
        [Column(TypeName = "payment_made")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)] // Computed at the database
        public required bool PaymentMade { get; set; } = false;

        // Custom Validation for DateRange
        [NotMapped]
        public bool IsValidDateRange => StartDate <= EndDate;

        // Methods for reference only, business logic should be in the controller
        // ConsultRoomServiceBookings()
        // AddRoomServiceBooking()
        // UpdateRoomServiceBooking()
        // CancelRoomServiceBooking()
        // UpdateBookedState()
        // SelectRoomServiceBooking()
        // UpdateStaffConfirmation()
    }
}

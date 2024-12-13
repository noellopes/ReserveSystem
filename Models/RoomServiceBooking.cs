using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomServiceBooking
    {
        [Required, Key, Display(Name = "Booking ID"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INTEGER")]
        public int Id { get; set; }
        
        [Required, ForeignKey("RoomServiceId"), Display(Name = "Service ID")]
        [Column(TypeName = "INTEGER(11)")]
        public int RoomServiceId { get; set; }

        [Required, ForeignKey("StaffId"), Display(Name = "Staff ID")]
        [Column(TypeName = "INTEGER(11)")]
        public int StaffId { get; set; }

        [Required, ForeignKey("ClientId"), Display(Name = "Client ID")]
        [Column(TypeName = "INTEGER(11)")]
        public int ClientId { get; set; }

        [Required, ForeignKey("RoomId"), Display(Name = "Room ID")]
        public int RoomId { get; set; }

        [DataType(DataType.DateTime), Display(Name = "Reservation Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }

        [DataType(DataType.Date), Display(Name = "Start Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateOnly StartDate { get; set; }

        [DataType(DataType.Date), Display(Name = "End Date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateOnly EndDate { get; set; }
        // TODO: Add Cancel date and a new table for the cancellation history

        [Display(Name = "Service Status")]
        [Column(TypeName = "bit")]
        public bool BookedState { get; set; } = true;

        [Display(Name = "Staff Confirmation")]
        [Column(TypeName = "bit")]
        public bool StaffConfirmation { get; set; } = false;

        [Range(1, 5), Display(Name = "Client Feedback")]
        [Column(TypeName = "INTEGER(1)")]
        public int? ClientFeedback { get; set; } = null;

        [Required, DataType(DataType.Currency), Display(Name = "Price"), DisplayFormat(DataFormatString = "{0:C}"), Range(0, 999999.99)]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal ValueToPay { get; set; } = 0;

        [Display(Name = "Payment Status")]
        [Column(TypeName = "bit")]
        public bool PaymentDone { get; set; } = false;

        // Navigation properties
        public Staff? Staff { get; set; }
        public Room? Room { get; set; }
        public Client? Client { get; set; }
        public RoomService? RoomService { get; set; }
    }
}
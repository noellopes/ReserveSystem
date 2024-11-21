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

        [DataType(DataType.DateTime), Display(Name = "Sys Date & Time"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }

        [DataType(DataType.Date), Display(Name = "Service Start Date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateOnly StartDate { get; set; }

        [DataType(DataType.Date), Display(Name = "Service End Date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateOnly EndDate { get; set; }

        [Display(Name = "Service Booked")]
        [Column(TypeName = "bit")]
        public bool BookedState { get; set; }

        [Display(Name = "Staff Confirmed")]
        [Column(TypeName = "bit")]
        public bool StaffConfirmation { get; set; }

        [Range(1, 5), Display(Name = "Client Feedback")]
        [Column(TypeName = "INTEGER(1)")]
        public int ClientFeedback { get; set; }

        [Required, DataType(DataType.Currency), Display(Name = "Price"), DisplayFormat(DataFormatString = "{0:C}"), Range(0, 999999.99)]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal ValueToPay { get; set; }

        [Display(Name = "Is Paid")]
        [Column(TypeName = "bit")]
        public bool PaymentDone { get; set; }

    }
}
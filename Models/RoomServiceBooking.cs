using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomServiceBooking
    {
        [Required, Key, Display(Name = "Room Service Booking ID"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INTEGER")]
        public int Id { get; set; }
        
        [Required, ForeignKey("RoomServiceId"), Display(Name = "Room Service ID"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "INTEGER(11)")]
        public int RoomServiceId { get; set; }

        [Required, ForeignKey("StaffId"), Display(Name = "Staff ID"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "INTEGER(11)")]
        public int StaffId { get; set; }

        [Required, ForeignKey("ClientId"), Display(Name = "Client ID"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "INTEGER(11)")]
        public int ClientId { get; set; }

        [Required, ForeignKey("RoomId"), Display(Name = "Room ID"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int RoomId { get; set; }

        [DataType(DataType.DateTime), Display(Name = "System Date and Time"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }

        [DataType(DataType.Date), Display(Name = "Service start Date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateOnly StartDate { get; set; }

        [DataType(DataType.Date), Display(Name = "Service End Date"), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateOnly EndDate { get; set; }

        [Display(Name = "Room Service Booking Status")]
        [Column(TypeName = "bit")]
        public bool BookedState { get; set; }

        [Display(Name = "Staff Service Confirmation")]
        [Column(TypeName = "bit")]
        public bool StaffConfirmation { get; set; }

        [Range(1, 5), Display(Name = "Client Feedback")]
        [Column(TypeName = "INTEGER(1)")]
        public int ClientFeedback { get; set; }

        [Required, DataType(DataType.Currency), Display(Name = "Value To Pay"), DisplayFormat(DataFormatString = "{0:C}"), Range(0, 999999.99), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "decimal(8, 2)")]
        public decimal ValueToPay { get; set; }

        [Display(Name = "Is Payment Done"), DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Column(TypeName = "bit")]
        public bool PaymentDone { get; set; }

    }
}
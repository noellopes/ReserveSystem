using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomServiceBooking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INTEGER")]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("RoomService")]
        [Column(TypeName = "INTEGER(11)")]
        public int RoomServiceId { get; set; }
        public required RoomService RoomService { get; set; }

        [Required]
        [ForeignKey("Staff")]
        [Column(TypeName = "INTEGER(11)")]
        public int StaffId { get; set; }
        public required Staff Staff { get; set; }

        [Required]
        [ForeignKey("Client")]
        [Column(TypeName = "INTEGER(11)")]
        public int ClientId { get; set; }
        public required Client Client { get; set; }

        [Required]
        [ForeignKey("Room")]
        [Column(TypeName = "INTEGER(11)")]
        public int RoomId { get; set; }
        public required Room Room { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Sys Date & Time")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "datetime")]
        public required DateTime DateTime { get; set; } = DateTime.Now;

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Service Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public required DateOnly StartDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Service End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public required DateOnly EndDate { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [Required]
        [Display(Name = "Service Booked")]
        [Column(TypeName = "bit")]
        public required bool BookedState { get; set; } = true;

        [Display(Name = "Staff Confirmed")]
        [Column(TypeName = "bit")]
        public required bool StaffConfirmation { get; set; } = false;

        [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
        [Display(Name = "Client Feedback")]
        [Column(TypeName = "INTEGER(1)")]
        public int? ClientFeedback { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [Range(0, 999999.99, ErrorMessage = "Inserted value isn't valid, positive number required")]
        [Column(TypeName = "decimal(8, 2)")]
        public required decimal ValueToPay { get; set; }

        [Required]
        [Display(Name = "Payment Done")]
        [Column(TypeName = "bit")]
        public bool PaymentDone { get; set; } = false;
    }
}
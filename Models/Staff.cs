using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Staff
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
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Staff Name must be between 2 and 50 characters.")]
        [Display(Name = "Staff Name")]
        public required string StaffName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        [Display(Name = "Staff Email")]
        public required string StaffEmail { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [StringLength(15, ErrorMessage = "Phone number cannot be longer than 15 characters.")]
        [Display(Name = "Staff Phone")]
        public required string StaffPhone { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [DataType(DataType.Password)]
        [Display(Name = "Staff Password")]
        public required string StaffPassword { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public required DateTime StartFunctionsDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true)]
        public DateTime? EndFunctionsDate { get; set; }

        [Range(0, 366, ErrorMessage = "Days Off/Vacation must be between 0 and 366.")]
        [Display(Name = "Days Off/Vacation")]
        public required int DaysOffVacation { get; set; }

        // Navigation property for related RoomServiceBookings
        public ICollection<RoomServiceBooking>? RoomServiceBookings { get; set; }
        // Navigation property for related Schedules
        public ICollection<Schedule>? Schedules { get; set; }
    }
}
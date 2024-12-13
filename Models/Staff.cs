using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Staff
    {

        [Required, Key, Display(Name = "Staff Id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INTEGER")]
        public int Id { get; set; }

        // Fk Job Id
        [Required, ForeignKey("Job Id"), Display(Name = "Job Id")]
        [Column(TypeName = "INTEGER")]
        public int JobId { get; set; }

        // Fk Schedule Id
        [Required, ForeignKey("Schedule Id"), Display(Name = "Schedule Id")]
        [Column(TypeName = "INTEGER")]
        public int ScheduleId { get; set; }
 
        [Required]
        [StringLength(256), MinLength(2), MaxLength(256)]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(256)")]
        [Display(Name = "Name")]
        [DisplayFormat(DataFormatString = "{2,256}")]
        [RegularExpression(@"^[\w\s]{2,256}$", ErrorMessage = "Name must be between 2 and 256 characters")]
        public required string Name { get; set; }

        /* Email format allowed:
            string@domain.com
        */
        [Required]
        [StringLength(256), MinLength(5), MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "varchar(256)")]
        [Display(Name = "Email")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email format")]
        public required string Email { get; set; }

        /* Phone number formats allowed:
            +351 123 456 789
            +351-123-456-789
            123 456 789
            123-456-789
            123456789
        */
        [Required]
        [StringLength(16), MinLength(9), MaxLength(16)]
        [DataType(DataType.PhoneNumber)]
        [Column(TypeName = "varchar(16)")]
        [Display(Name = "Phone")]
        [DisplayFormat(DataFormatString = "{+351-000-000-000}")]
        [RegularExpression(
            @"^(
                \+351\s\d{3}\s\d{3}\s\d{3}|\d{3}\s\d{3}\s\d{3}|\d{9}|\d{3}-\d{3}-\d{3}|\+351-\d{3}-\d{3}-\d{3})$",
                ErrorMessage = "Invalid phone number format"
        )]
        public required string Phone { get; set; }

        [Required]
        [StringLength(512), MinLength(8), MaxLength(512)]
        [DataType(DataType.Password)]
        [Column(TypeName = "varchar(512)")]
        [Display(Name = "Password")]
        [DisplayFormat(DataFormatString = "{8,512}")]
        [RegularExpression(@"^[\w\s]{8,512}$", ErrorMessage = "Password must be between 8 and 512 characters")]
        public required string Password { get; set; }

        // ContractStartDate, date only
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [Display(Name = "Contract Start Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [RegularExpression(@"^\d{2}\/\d{2}\/\d{4}$", ErrorMessage = "Invalid date format")]
        public required DateOnly ContractStartDate { get; set; }
        
        // ContractExpiryDate, date only
        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "date")]
        [Display(Name = "Contract Expiry Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [RegularExpression(@"^\d{2}\/\d{2}\/\d{4}$", ErrorMessage = "Invalid date format")]
        public required DateOnly ContractExpiryDate { get; set; }
        
        // VacationDays
        [Required]
        [Column(TypeName = "INTEGER")]
        [Display(Name = "Vacation Days")]
        [DisplayFormat(DataFormatString = "{0}")]
        [RegularExpression(@"^\d{1,3}$", ErrorMessage = "Vacation Days must be a number")]
        public required int VacationDays { get; set; }

        // Navigation properties
        public Job? Job { get; set; }

        public List<Schedule>? Schedules { get; set; }

        public List<RoomServiceBooking>? Bookings { get; set; }
    }
}
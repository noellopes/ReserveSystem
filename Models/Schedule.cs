using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Schedule
    {
        // Primary Key
        // ScheduleId: INT
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScheduleId { get; set; }

        // Foreign Keys
        // StaffId: INT
        [Required]
        public required int StaffId { get; set; }

        [ForeignKey("StaffId")]
        public required virtual Staff Staff { get; set; }

        // Attributes
        // TypeOfSchedule: INT
        [Required]
        [Range(0, 3)]
        [Display(Name = "Type of Schedule")]
        [Column(TypeName = "INTEGER")]
        [RegularExpression(@"^[0-3]*$", ErrorMessage = "Type of Schedule must be a number between 0 and 3")]
        public int TypeOfSchedule { get; set; }

        // Date: DATE
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [Column(TypeName = "DATE")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$", ErrorMessage = "Date must be in the format yyyy-MM-dd")]
        public DateTime Date { get; set; }

        // ShiftStartTime: DATETIME
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Shift Start Time")]
        [Column(TypeName = "TIME")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^\d{2}:\d{2}$", ErrorMessage = "Shift Start Time must be in the format HH:mm")]
        public DateTime ShiftStartTime { get; set; }

        // ShiftEndTime: DATETIME
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Shift End Time")]
        [Column(TypeName = "TIME")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^\d{2}:\d{2}$", ErrorMessage = "Shift End Time must be in the format HH:mm")]
        public DateTime ShiftEndTime { get; set; }

        // Available: BOOLEAN
        [Required]
        [Display(Name = "Available")]
        [Column(TypeName = "BOOLEAN")]
        public bool Available { get; set; }

        // Present: BOOLEAN
        [Required]
        [Display(Name = "Present")]
        [Column(TypeName = "BOOLEAN")]
        public bool Present { get; set; }

        // Methods for reference only, business logic should be in the controller
        // ConsultStaff()
        // SelectStaff()
    }
}

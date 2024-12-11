using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Schedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INTEGER")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Staff")]
        [Column(TypeName = "INTEGER(11)")]
        public int StaffId { get; set; }
        public required Staff Staff { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public required DateOnly Date { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "time")]
        public required TimeSpan StartShiftTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        [DisplayFormat(DataFormatString = "{0:HH:mm}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "time")]
        public required TimeSpan EndShiftTime { get; set; }

        [Required]
        [Display(Name = "Available")]
        [Column(TypeName = "bit")]
        public required bool Available { get; set; } = true;

        [Required]
        [Display(Name = "Present")]
        [Column(TypeName = "bit")]
        public required bool Present { get; set; } = false;

        /* [Required]
        [StringLength(100, ErrorMessage = "Task description cannot be longer than 100 characters.")]
        [Display(Name = "Task Description")]
        [Column(TypeName = "VARCHAR(100)")]
        public required string Task { get; set; }

        [Required]
        [Display(Name = "Location")]
        [StringLength(100, ErrorMessage = "Location cannot be longer than 100 characters.")]
        [Column(TypeName = "VARCHAR(100)")]
        public required string Location { get; set; } */
    }
}
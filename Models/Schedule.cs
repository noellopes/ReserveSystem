using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Schedule
    {
        [Required, Key, Display(Name = "Schedule Id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INTEGER")]
        public int Id { get; set; }

        // Fk Staff Id
        [Required, ForeignKey("Staff Id"), Display(Name = "Staff Id")]
        [Column(TypeName = "INTEGER")]
        public int StaffId { get; set; }

        [Required, Display(Name = "Date")]
        [Column(TypeName = "DATE")]
        public DateOnly Date { get; set; }

        [Required, Display(Name = "Shift Start")]
        [Column(TypeName = "TIME")]
        public TimeSpan ShiftStart { get; set; }

        [Required, Display(Name = "Shift End")]
        [Column(TypeName = "TIME")]
        public TimeSpan ShiftEnd { get; set; }

        [Required, Display(Name = "Available")]
        [Column(TypeName = "BIT")]
        public bool Available { get; set; }

        [Required, Display(Name = "Attended")]
        [Column(TypeName = "BIT")]
        public bool Present { get; set; }

        // Navigation properties
        public Staff? Staff { get; set; }
    }
}
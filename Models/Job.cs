using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Job
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INTEGER")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Job Title must be between 2 and 100 characters.")]
        [Display(Name = "Job Title")]
        [Column(TypeName = "VARCHAR(100)")]
        public required string Title { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        [Display(Name = "Job Description")]
        [Column(TypeName = "VARCHAR(500)")]
        public required string Description { get; set; }

        // Navigation property for related Staff
        public ICollection<Staff>? Staffs { get; set; } = [];

        // Navigation property for related RoomService
        public ICollection<RoomService>? RoomServices { get; set; } = [];
    }
}
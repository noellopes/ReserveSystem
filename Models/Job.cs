using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [Required(ErrorMessage = "JobName is required.")]
        [StringLength(100, ErrorMessage = "JobName must be 100 chars max.")]
        public required string JobName { get; set; }

        [Required(ErrorMessage = "JobDescription is required.")]
        [StringLength(500, ErrorMessage = "JobDescription must be 500 chars max.")]
        public required string JobDescription { get; set; }

        public ICollection<Staff> ? staffMembers { get; set; }
    }
}

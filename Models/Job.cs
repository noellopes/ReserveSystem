using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [Required]
        public string JobName { get; set; }
        public string JobDescription { get; set; }

    }
}

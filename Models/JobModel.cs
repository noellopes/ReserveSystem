using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class JobModel
    {
        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int jobID { get; set; }

        [Required(ErrorMessage = "Job name is required")]
        public required List<JobModel> jobname { get; set; }

        [Required(ErrorMessage = "Job description is required")]
        public required String jobDescription { get; set; }
    }
}

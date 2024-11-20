using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class JobModel
    {
        [Key]
        [Required(ErrorMessage = "ID is required")]
        [Display(Name = "Job ID")]
        public int jobID { get; set; }

        [Required(ErrorMessage = "Job name is required")]
        [Display(Name = "Job")]
        public required String jobName { get; set; }

        [Required(ErrorMessage = "Job description is required")]
        [Display(Name = "Description")]
        public required String jobDescription { get; set; }
    }
}

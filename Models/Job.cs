using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Job
    {
        // Primary Key
        // JobId: INT
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public required int JobId { get; set; }
        
        // Attributes
        // JobName: STRING
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Job Name")]
        [DisplayFormat(NullDisplayText = "No job name, job name is null!")]
        [Column(TypeName = "VARCHAR")]
        [MinLength(1)]
        [StringLength(50)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Job Name must only contain letters")]
        public required string JobName { get; set; }

        // JobDescription: STRING
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Job Description")]
        [DisplayFormat(NullDisplayText = "No job description, job description is null!")]
        [Column(TypeName = "VARCHAR")]
        [MinLength(1)]
        [StringLength(50)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Job Description must only contain letters")]
        public required string JobDescription { get; set; }

        // Methods for reference only, business logic should be in the controller
        
        /* public void consultJob()
        {
            // Consults the job
        }

        public void selectJob()
        {
            // Selects the job
        } */
    }
}
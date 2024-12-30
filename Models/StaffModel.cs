    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Mvc.Rendering;

    namespace ReserveSystem.Models
    {
        public class StaffModel
        {
            [Key]
            [Required]
            [Display(Name = "ID")]
            public int Staff_Id { get; set; }

            [Required]
            [StringLength(100)]
            [Display(Name = "Name")]
            public string Staff_Name { get; set; }


            [Required]
            [Display(Name = "Birthdate")]
            public DateTime BirthDate { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Staff_Email { get; set; }
            
            [Required]
            [StringLength(9, ErrorMessage = "O número de telemóvel deve conter exatamente 9 dígitos.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "O número de telemóvel deve conter apenas números e ter exatamente 9 dígitos.")]
        [Display(Name = "Phone")]
            public string Staff_Phone { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Staff_Password { get; set; } = "defaultpassword";

            [Display(Name = "Job")]
            public int jobID_FK { get; set; }
        
        
            [ForeignKey("jobID_FK ")]
            public JobModel? Job { get; set; }
        
            public List<string>? DrivingLicenseGrades { get; set; }
            
            public DateTime DriverLicenseExpirationDate { get; set; }
        }
    
    }


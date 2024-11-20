    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Mvc.Rendering;

    namespace ReserveSystem.Models
    {
        public class StaffModel
        {
                [Key]
                [Required]
                public int Staff_Id { get; set; }

                [Required]
                [StringLength(100)]
                public string Staff_Name { get; set; }
                [Required]
                public DateTime BirthDate { get; set; }

                [Required]
                [EmailAddress]
                public string Staff_Email { get; set; }
            
            [Required]
            [StringLength(9)]
                public string Staff_Phone { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Staff_Password { get; set; } = "defaultpassword";

            [Required]
                public int Job_Id { get; set; }

        
            public List<string>? DrivingLicenseGrades { get; set; }
            
                public DateTime DriverLicenseExpirationDate { get; set; }
        }
    
    }


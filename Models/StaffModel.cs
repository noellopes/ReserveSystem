using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
            [EmailAddress]
            public string Staff_Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Staff_Password { get; set; }

            [ForeignKey("Department")]
            public int Department_Id { get; set; }

            [ForeignKey("Job")]
            public int Job_Id { get; set; }
    }
    
}


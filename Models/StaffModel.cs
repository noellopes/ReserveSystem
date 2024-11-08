using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class StaffModel
    {
   
            [Required]
            public int Id { get; set; }

            [Required]
            [StringLength(100)]
            public string Name { get; set; }

            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    
}


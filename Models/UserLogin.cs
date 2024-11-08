using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class UserLogin
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdPrivilegio { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}

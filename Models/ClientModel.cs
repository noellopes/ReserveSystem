using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    // Modelo Cliente (simplificado)
    public class ClientModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string Phone { get; set; }
    }
}

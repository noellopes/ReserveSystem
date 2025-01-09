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
        public required string Name { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [StringLength(15)]
        public string? Phone { get; set; }

        [Required]
        public bool isClientHotel { get; set; }
}
}

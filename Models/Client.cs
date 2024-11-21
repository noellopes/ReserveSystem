using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Invalid Name")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [Phone(ErrorMessage = "Invalid phone number format.")]
        [StringLength(9, ErrorMessage = "Invalid Phone Number(9 chars only)")]
        public required string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [StringLength(256, ErrorMessage = "Invalid Email Address.")]
        public required string Email { get; set; }

        public int QuartoId { get; set; }

        public Quarto Quarto { get; set; }

    }
}

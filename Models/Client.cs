using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Client name is required.")]
        [StringLength(100, ErrorMessage = "Client name must not exceed 100 characters.")]
        public required string Client_Name { get; set; }

        [Required(ErrorMessage = "Client phone number is required.")]
        [RegularExpression(@"^\+?[0-9]{9,15}$", ErrorMessage = "Client phone number must be valid, with 9 to 15 digits.")]
        public required string Client_Phone { get; set; }

        [Required(ErrorMessage = "Client address is required.")]
        [StringLength(200, ErrorMessage = "Client address must not exceed 200 characters.")]
        public required string Client_Adress { get; set; }

        [Required(ErrorMessage = "Client email is required.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
        public required string Client_Email { get; set; }

        [Required(ErrorMessage = "Client NIF is required.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Client NIF must contain exactly 9 digits.")]
        public required string Client_Nif { get; set; }

        [Required(ErrorMessage = "Client login status is required.")]
        public bool Client_Login { get; set; }

        [Required(ErrorMessage = "Client status is required.")]
        public bool Client_Status { get; set; }

        public ICollection<Cleaning_Schedule> ? cleaningSchedules { get; set; }
    }
}

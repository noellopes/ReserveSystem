using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class ClientModel
    {
        [Key][Required]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Name is mandatory")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Name must be between 4 and 30 characters.")]
        public string Name { get;set; }

        [Required(ErrorMessage = "Phone number is mandatory")]
        [StringLength(16, MinimumLength = 5, ErrorMessage = "Invalid phone number length")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is mandatory")]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Address cannot be less than 4 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "NIF/Identification is mandatory")]
        public string NIF  { get; set; }
        [Required(ErrorMessage = "Please select an identification type.")]
        public string IdentificationType { get; set; }
        public bool Login { get; set; }
        public bool Status { get; set; }
        public ICollection<Booking>? Booking { get; set; }


    }
}

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
        public string Phone { get; set; }

        [Required(ErrorMessage = "Address is mandatory")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email is mandatory")]
        [EmailAddress(ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Identification is mandatory")]
        public string Identification { get; set; }


        [Required(ErrorMessage = "Password is mandatory")]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password {  get; set; }

        [Required(ErrorMessage = "Identification type is mandatory")]
        public string IdentificationType { get; set; }

        public ICollection<BookingModel>? Booking { get; set; }


    }
}

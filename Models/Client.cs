using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INTEGER")]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        [Display(Name = "Name")]
        [Column(TypeName = "VARCHAR(100)")]
        public required string Name { get; set; }

        [Required]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [StringLength(15, ErrorMessage = "Phone number cannot be longer than 15 characters.")]
        [Display(Name = "Phone")]
        [Column(TypeName = "VARCHAR(15)")]
        public required string Phone { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Address cannot be longer than 200 characters.")]
        [Display(Name = "Address")]
        [Column(TypeName = "VARCHAR(200)")]
        public required string Address { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        [Display(Name = "Email")]
        [Column(TypeName = "VARCHAR(100)")]
        public required string Email { get; set; }

        [Required]
        [StringLength(9, ErrorMessage = "NIF must be 9 characters long.")]
        [Display(Name = "NIF")]
        [Column(TypeName = "VARCHAR(9)")]
        public required string Nif { get; set; }

        [Required]
        [Display(Name = "Login")]
        [Column(TypeName = "bit")]
        public required bool Login { get; set; } = false;

        [Required]
        [Display(Name = "Booking Status")]
        [Column(TypeName = "bit")]
        public required bool Status { get; set; } = true;

        // Navigation property for related RoomServiceBookings
        public ICollection<RoomServiceBooking>? RoomServiceBookings { get; set; } = [];
    }
}
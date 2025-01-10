using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Client
    {
        [Required, Key, Display(Name = "Client Id"), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(TypeName = "INTEGER")]
        public int Id { get; set; }
 
        [Required]
        [StringLength(256), MinLength(2), MaxLength(256)]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(256)")]
        [Display(Name = "Name")]
        [DisplayFormat(DataFormatString = "{2,256}")]
        [RegularExpression(@"^[\w\s]{2,256}$", ErrorMessage = "Name must be between 2 and 256 characters")]
        public required string Name { get; set; }

        /* Email format allowed:
            string@domain.com
        */
        [Required]
        [StringLength(256), MinLength(5), MaxLength(256)]
        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "varchar(256)")]
        [Display(Name = "Email")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Invalid email format")]
        public required string Email { get; set; }

        /* Phone number formats allowed:
            +351 123 456 789
            +351-123-456-789
            123 456 789
            123-456-789
            123456789
        */
        [Required]
        [StringLength(16), MinLength(9), MaxLength(16)]
        [DataType(DataType.PhoneNumber)]
        [Column(TypeName = "varchar(16)")]
        [Display(Name = "Phone")]
        [DisplayFormat(DataFormatString = "{+351-000-000-000}")]
        [RegularExpression(
            @"^(
                \+351\s\d{3}\s\d{3}\s\d{3}|\d{3}\s\d{3}\s\d{3}|\d{9}|\d{3}-\d{3}-\d{3}|\+351-\d{3}-\d{3}-\d{3})$",
                ErrorMessage = "Invalid phone number format"
        )]
        public required string Phone { get; set; }

        /* Address format allowed (Portuguese addresses):
            Rua da Alegria, 123
            Rua da Alegria, 123, 1º Esq.
            Rua da Alegria, 123, 1º Esq., Sala 2
            Rua da Alegria, 123, 1º Esq., Sala 2, 1234-567 Lisboa
        */
        [Required]
        [StringLength(256), MinLength(10), MaxLength(256)]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(256)")]
        [Display(Name = "Address")]
        [RegularExpression(
            @"^[\w\s\d\.\,\-]+(\,\s\d{1,4}(\w{2})?(\,\s\w{1,4})?(\,\s\d{4}-\d{3}\s\w{4})?)?$",
            ErrorMessage = "Invalid address format"
        )]
        public required string Address { get; set; }

        /* NIF format allowed:
            123456789
        */
        [Required]
        [StringLength(9), MinLength(9), MaxLength(9)]
        [DataType(DataType.Text)]
        [Column(TypeName = "varchar(9)")]
        [Display(Name = "NIF")]
        [DisplayFormat(DataFormatString = "{000-000-000}")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Invalid NIF format")]
        public required string Nif { get; set; }
 
        public List<RoomServiceBooking>? Bookings { get; set; }
    }
}
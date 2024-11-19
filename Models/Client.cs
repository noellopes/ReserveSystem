using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Client
    {
        // Primary Key
        // ClientId: INT
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClientId { get; set; }

        // Foreign Keys
        // NONE

        // Attributes
        // Client_Name: STRING
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Client Name")]
        [Column(TypeName = "VARCHAR")]
        [DisplayFormat(NullDisplayText = "No name, name is null!")]
        [MinLength(1)]
        [StringLength(50)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed in the name.")]
        public required string Client_Name { get; set; }

        // Client_Phone: STRING
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Client Phone")]
        [Column(TypeName = "VARCHAR")]
        [DisplayFormat(NullDisplayText = "No phone, phone is null!")]
        [MinLength(1)]
        [StringLength(50)]
        [MaxLength(50)]
        [RegularExpression(@"^[0-9]{1,40}$", ErrorMessage = "Letters and special characters are not allowed in the phone number.")]
        public required string Client_Phone { get; set; }

        // Client_Address: STRING
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Client Address")]
        [Column(TypeName = "VARCHAR")]
        [DisplayFormat(NullDisplayText = "No address, address is null!")]
        [MinLength(1)]
        [StringLength(50)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessage = "Numbers and special characters are not allowed in the address.")]
        public required string Client_Address { get; set; }

        // Client_Email: STRING
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Client Email")]
        [Column(TypeName = "VARCHAR")]
        [DisplayFormat(NullDisplayText = "No email, email is null!")]
        [MinLength(1)]
        [StringLength(50)]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z0-9''-'\s@]{1,40}$", ErrorMessage = "Special characters are not allowed in the email.")]
        public required string Client_Email { get; set; }

        // Client_Tax_Id: STRING
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Client Tax Id")]
        [Column(TypeName = "VARCHAR")]
        [DisplayFormat(NullDisplayText = "No tax id, tax id is null!")]
        // Portuguese NIF (Número de Identificação Fiscal) validation 'aka' tax id number.
        [MinLength(9)]
        [StringLength(9)]
        [MaxLength(9)]
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Letters and special characters are not allowed in the tax id.")]
        public required string Client_Tax_Id { get; set; }

        // Client_Login: BOOLEAN
        [Required]
        [Display(Name = "Client Login")]
        [Column(TypeName = "BOOLEAN")]
        [DisplayFormat(NullDisplayText = "No login, login is null!")]
        public required bool Client_Login { get; set; }

        // Client_Status(Active_Booking): BOOLEAN
        [Required]
        [Display(Name = "Client Status")]
        [DisplayFormat(NullDisplayText = "No status, status is null!")]
        [Column(TypeName = "BOOLEAN")]
        public required bool Client_Status { get; set; }

        // Methods for reference only, business logic should be in the controller
        
        // ViewClientServices()
        /* public void ViewClientServices()
        {
            // View Client Services
        } */

        // EditClient()
        /* public void EditClient()
        {
            // Edit Client
        } */
    }
}
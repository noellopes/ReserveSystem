using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class ClientModel
    {
        [Key][Required]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get;set; }

        [Required(ErrorMessage = "Telefone obrigatório")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Endereço obrigatório")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage = "Formato do email invalido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Identificação obrigatório")]
        public string Identification { get; set; }


        [Required(ErrorMessage ="Password obrigatório")]
        [StringLength(20, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password {  get; set; }

        [Required(ErrorMessage = "Tipo de identificação obrigatório")]
        public string IdentificationType { get; set; }

        public ICollection<BookingModel>? Booking { get; set; }


    }
}

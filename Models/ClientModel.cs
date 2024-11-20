using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class ClientModel
    {
        [Key][Required]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public String Name { get;set; }

        [Required(ErrorMessage = "Telefone obrigatório")]
        public String Phone { get; set; }

        [Required(ErrorMessage = "Endereço obrigatório")]
        public String Address { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage = "Formato do email invalido")]
        public String Email { get; set; }

        [Required(ErrorMessage = "NIF obrigatorio")]
        public String NIF { get; set; }

        public ICollection<BookingModel>? Booking { get; set; }


    }
}

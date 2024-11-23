using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class ClienteModel
    {
        [Key]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "Nome do Cliente é Obrigatorio")]
        [MaxLength(800)]

        public string NomeCliente { get; set; }
        [Required(ErrorMessage = "A Morrada do Cliente é Obrigatorio")]
        [MaxLength(800)]

        public string MoradaCliente { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email do Cliente Obrigatorio")]
        [MaxLength(800)]

        public string Email { get; set; }
        [Required(ErrorMessage = "Password Errado")]
        [MaxLength(800)]

        public string Password { get; set; }
        [Required(ErrorMessage = "Telefone é Obrigatorio")]
        [MaxLength(800)]

        public string Telefone { get; set; }
        public ICollection<ReservaModel>? Reserva { get; set; }

    }
}
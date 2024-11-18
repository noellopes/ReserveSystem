using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Cliente
    {
        [Key][Required]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public String Nome { get;set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage = "Formato do email invalido")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Telefone obrigatório")]
        public String Telefone { get; set; }


        [Required]
        public bool Login { get; set; }

        [Required(ErrorMessage = "NIF obrigatorio")]
        public String Nif  { get; set; }
        public ICollection<Reserva> Reserva { get; set; }


    }
}

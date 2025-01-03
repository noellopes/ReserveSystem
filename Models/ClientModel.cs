using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class ClientModel
    {
            [Key]
            public int ClienteId { get; set; }
            [Required(ErrorMessage = "Nome do Cliente é Obrigatorio")]
             [Display(Name = "Full Name")]

             public string NomeCliente { get; set; }
            [Required(ErrorMessage = "A Morrada do Cliente é Obrigatorio")]
            [Display(Name = "Address")]

            public string MoradaCliente { get; set; }
            [EmailAddress]
            [Required(ErrorMessage = "Email do Cliente Obrigatorio")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Password Errado")]
            public string Password { get; set; }
            [Required(ErrorMessage = "Telefone é Obrigatorio")]
            public string Telefone { get; set; }

            [Required(ErrorMessage = "NIF é obrigatorio")]
            public int NIF { get; set; }

            // [Required]
            //[StringLength(9, MinimumLength = 9, ErrorMessage = "O NIF deve ter exatamente 9 dígitos.")]
            //[RegularExpression(@"^\d+$", ErrorMessage = "O NIF deve conter apenas números.")]

            public ICollection<Reserva>? Reserva { get; set; }
        }
    }


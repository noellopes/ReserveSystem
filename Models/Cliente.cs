using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Cliente
    {
        [Key]
        public int ClienteId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        [EmailAddress]
        [Display(Name = "Endereço de E-mail")]
        public string Email { get; set; }

        [StringLength(200)]
        [Display(Name = "Morada")]
        public string Morada { get; set; }

        [StringLength(20)]
        [Display(Name = "NIF")]
        public string NIF { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }
        public ICollection<Cliente>? ReserveSystem { get; set; }
    }

}


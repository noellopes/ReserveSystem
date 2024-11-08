using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Cliente
    {
        [Key][Required]
        public int ClienteId { get; set; }

        [Required]
        public String Nome { get;set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Telefone { get; set; }

        [Required]
        public bool Login { get; set; }

        [Required]
        public String Nif  { get; set; }

    }
}

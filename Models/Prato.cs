using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Prato
    {
        public int PratoId { get; set; }

        [Required(ErrorMessage = "O nome do Prato é obrigatório"), StringLength(100)]
        public string Nome { get; set; }

        [Required, StringLength(500)]
        public string Descricao { get; set; }

    }
}

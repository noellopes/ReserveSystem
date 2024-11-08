using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Pratos
    {
        public int IdPrato {  get; set; }
        [Required]

        public string PratoNome { get; set; }
        [Required]
        public string Descrição { get; set; }
        [Required]


    }
}


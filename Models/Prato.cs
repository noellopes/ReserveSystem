using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Prato
    {
        [Key]
        public int IdPrato { get; set; }

        [Required]
        public string PratoNome { get; set; }

        [Required]
        public string Descricao { get; set; }

        public ICollection<Reserva>? Reservas { get; set; }
    }
}


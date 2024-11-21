using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class ItemQuarto
    {
        public int ItemQuartoId { get; set; }

        [Required(ErrorMessage = "Quantidade is required.")]
        [Range(1, 20, ErrorMessage = "A Quantidade de items deve ser de 1 a 20.")]
        public int QuantidadeQuarto { get; set; }

        public ICollection<Items> Items { get; set; } = new List<Items>();

    }
}

using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Consumos
    {
        public int ConsumosId { get; set; }

        public ICollection<ItemQuarto> ItemQuartos { get; set; } = new List<ItemQuarto>();

        [Required(ErrorMessage = "Quantidade is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Quantidade consumida tem de ser maior ou igual que 0.")]
        public int QuantidadeConsumida { get; set; }

        [Required(ErrorMessage = "DataConsumo is required.")]
        public DateTime DataConsumo { get; set; }
    }
}

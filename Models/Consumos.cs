namespace ReserveSystem.Models
{
    public class Consumos
    {
        public int ConsumosId { get; set; }

        public ICollection<ItemQuarto> ItemQuartos { get; set; } = new List<ItemQuarto>();

        public int QuantidadeConsumida { get; set; }

        public DateTime DataConsumo { get; set; }
    }
}

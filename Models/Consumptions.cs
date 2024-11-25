namespace ReserveSystem.Models
{
    public class Consumptions
    {
        public int ConsumptionsId { get; set; }
        public int ItemRoomId { get; set; }
        public ItemRoom itemRoom { get; set; }

        public int QuantityConsumed { get; set; }
        public DateTime ConsumedDate { get; set; }

        public int ClientId { get; set; }
        public Client client { get; set; }
    }
}

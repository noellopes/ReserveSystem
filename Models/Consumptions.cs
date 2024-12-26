namespace ReserveSystem.Models
{
    public class Consumptions
    {
        public int ConsumptionId { get; set; } 
        public int RoomId { get; set; } 
        public int ItemId { get; set; }

        public int QuantityConsumed { get; set; }
        public DateTime ConsumedDate { get; set; }
    }
}

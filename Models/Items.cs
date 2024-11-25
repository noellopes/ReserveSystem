namespace ReserveSystem.Models
{
    public class Items
    {
        public int ItemsId { get; set; }
        public string Name { get; set; }
        public int QuantityStock { get; set; }
        public int MinimumStock { get; set; }
        public ICollection<ItemRoom> itemRooms { get; set; }
    }
}

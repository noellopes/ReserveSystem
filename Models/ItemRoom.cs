namespace ReserveSystem.Models
{
    public class ItemRoom
    {
        public int ItemRoomId { get; set; }
        public int AvailableQuantity { get; set; }
        public DateTime LastRestockedDate { get; set; }

        public int RoomBookingId { get; set; }
        public RoomBooking roomBooking { get; set; }

        public int ItemId { get; set; }
        public Items item { get; set; }

        public ICollection<Consumptions> consumptions { get; set; }
    }
}

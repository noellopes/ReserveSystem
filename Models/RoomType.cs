namespace ReserveSystem.Models
{
    public class RoomType
    {
        public int RoomTypeId { get; set; }
        public bool HasView { get; set; }
        public required string Type { get; set; }
        public int Capacity { get; set; }
        public int RoomCapacity { get; set; }
        public bool AccessibilityRoom { get; set; }

        public ICollection<Room> rooms { get; set; }
    }
}

namespace ReserveSystem.Models
{
    public class Room_Type
    {
        public int RoomTypeId { get; set; }

        public bool HasView { get; set; }

        public required string Type { get; set; }

        public int Capacity { get; set; }

        public int RoomCapacity { get; set; }

        public bool AcessibilityRoom { get; set; }

        public ICollection<Room> rooms { get; set; }

    }
}

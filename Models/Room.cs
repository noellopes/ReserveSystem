namespace ReserveSystem.Models
{
    public class Room
    {
        public int RoomId { get; set; }

        public int RoomTypeId { get; set; }

        public ICollection<Room_Booking> room_Bookings { get; set; }

    }
}

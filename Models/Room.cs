namespace ReserveSystem.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType roomType { get; set; }

        public ICollection<RoomBooking> roomBookings { get; set; }
        public ICollection<Cleaning> cleanings { get; set; }
    }
}

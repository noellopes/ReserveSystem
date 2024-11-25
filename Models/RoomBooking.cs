namespace ReserveSystem.Models
{
    public class RoomBooking
    {
        public int RoomBookingId { get; set; }
        public int PersonsNumber { get; set; }
        public bool CleaningOption { get; set; }

        public int BookingId { get; set; }
        public Booking booking { get; set; }

        public int RoomId { get; set; }
        public Room room { get; set; }

        public ICollection<ItemRoom> itemRooms { get; set; }
        public ICollection<CleaningShedule> cleaningSchedules { get; set; }
    }
}

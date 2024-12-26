namespace ReserveSystem.Models
{
    public class Room_Booking
    {
        public int RoomBookingId { get; set; }

        public int BookingId { get; set; }

        public int RoomId { get; set; }

        public int Persons_Number { get; set; }

        public ICollection<Booking> bookings { get; set; }

    }
}

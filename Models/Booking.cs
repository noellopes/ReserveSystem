namespace ReserveSystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime BookingDate { get; set; }
        public bool IsBooked { get; set; }
        public int TotalPersonsNumber { get; set; }
        public bool PaymentStatus { get; set; }

        public int ClientId { get; set; }
        public Client client { get; set; }

        public ICollection<RoomBooking> roomBookings { get; set; }
    }
}

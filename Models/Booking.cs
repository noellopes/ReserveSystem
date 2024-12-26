namespace ReserveSystem.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public int ClientId { get; set; }

        public DateTime Checkin_date { get; set; }

        public DateTime Checkout_date { get; set; }

        public DateTime Booking_Date { get; set; }

        public bool Booked { get; set; }

        public int Total_Persons_Number { get; set; }

        public bool Payment_Status { get; set; }

        public ICollection<Client> clients { get; set; }

    }
}

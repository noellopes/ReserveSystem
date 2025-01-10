namespace ReserveSystem.Models
{
    public class BookingViewModel
    {
        public IEnumerable<Booking> Bookings { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public DateOnly? BeginDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}

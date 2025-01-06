using Microsoft.AspNetCore.Mvc.Rendering;

namespace ReserveSystem.Models
{
    public class BookingViewModel
    {
        public IEnumerable<Booking>? Bookings { get; set; }
        public PagingInfo BookingsIds { get; set; }
        public int? RoomServiceId { get; set; }
    }
}

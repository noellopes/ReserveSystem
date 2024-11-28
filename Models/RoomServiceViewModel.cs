using Microsoft.AspNetCore.Mvc.Rendering;

namespace ReserveSystem.Models
{
    public class RoomServiceViewModel
    {
        public IEnumerable<RoomServiceBooking>? RoomServiceBookings { get; set; }
        public SelectList? RoomServicesIds { get; set; }
        public int? RoomServiceId { get; set; }
        public int? SearchInt { get; set; }
        public PagingInfo? PagingInfo { get; set; }
    }
}

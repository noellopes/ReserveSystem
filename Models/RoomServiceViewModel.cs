using Microsoft.AspNetCore.Mvc.Rendering;

namespace ReserveSystem.Models
{
    public class RoomServiceViewModel
    {
        public IEnumerable<RoomServiceBooking>? RoomServiceBookings { get; set; }
        
        public SelectList? RoomServices { get; set; }
        
        public SelectList? Rooms { get; set; }
        
        public int? RoomServiceId { get; set; }
        
        public int? RoomId { get; set; }
        
        public PagingInfo? PagingInfo { get; set; }
        
    }
}

using Microsoft.AspNetCore.Mvc.Rendering;

namespace ReserveSystem.Models
{
    public class RoomServiceViewModel
    {
        public IEnumerable<RoomServiceBooking>? RoomServiceBookings { get; set; }
        
        public PagingInfo? PagingInfo { get; set; }
        
        public SelectList? RoomServices { get; set; }
        
        public SelectList? Rooms { get; set; }
        
        public string? SearchService { get; set; }
        
        public string? SearchRoom { get; set; }
    }
}
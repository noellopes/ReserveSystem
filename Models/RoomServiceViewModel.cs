using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ReserveSystem.Models
{
    public class RoomServiceViewModel
    {
        public List<RoomServiceBooking>? RoomServiceBookings { get; set; }
        public SelectList? RoomServicesIds { get; set; }
        public int? RoomServiceId { get; set; }
        public int? SearchInt { get; set; }
    }
}

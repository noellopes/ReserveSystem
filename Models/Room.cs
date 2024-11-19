using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Room
    {
        public required int RoomID { get; set; }
        public required int RoomType { get; set; }

        public required ICollection<RoomBooking> RoomBookings { get; set; }
        public required ICollection<RoomServicesBooking> RoomServicesBookings { get; set; }

        // Methods for reference only, business logic should be in the controller
        
        // public void consultRoomNumber()
        
        // public void selectRoomNumber()
    }

}

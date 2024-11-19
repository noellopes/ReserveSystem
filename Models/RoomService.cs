using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomService
    {
        public required int RoomServiceID { get; set; }
        public required int JobID { get; set; }
        public required string RoomServiceName { get; set; }
        public required string RoomServiceDescription { get; set; }
        public required double RoomServicePrice { get; set; }
        public required bool RoomServiceActive { get; set; }
        public required int RoomServiceDuration { get; set; }

        public required ICollection<RoomServicesBooking> RoomServicesBookings { get; set; }
        public required Job Job { get; set; } 

        // Methods for reference only, business logic should be in the controller
        // ConsultRoomService()
        // InsertRoomService()
        // UpdateRoomService()
        // DeactivateRoomService()
        // SelectRoomService()
    }
}
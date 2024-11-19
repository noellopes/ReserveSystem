using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomBooking
    {
        public required int RoomBookingID { get; set; }
        public required int BookingID { get; set; }
        public required int RoomID { get; set; }
        public required int NumberOfGuests { get; set; }

        public required Booking Booking { get; set; }
        public required Room Room { get; set; }

        // Methods for reference only, business logic should be in the controller
        // ConsultRoomBooking()
    }
}
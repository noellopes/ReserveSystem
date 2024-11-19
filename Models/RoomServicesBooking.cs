using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomServicesBooking
    {
        public required int RoomServicesBookingID { get; set; }
        public required int RoomServiceID { get; set; }
        public required int StaffID { get; set; }
        public required int ClientID { get; set; }
        public required int RoomID { get; set; }
        public required DateTime DateTime { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public required bool BookedState { get; set; } = true;
        public required bool StaffConfirmation { get; set; } = false;
        public int? ClientFeedback { get; set; }
        public required decimal AmountToPay { get; set; }
        public required bool PaymentMade { get; set; } = false;
        // Custom Validation for DateRange
        [NotMapped]
        public bool IsValidDateRange => StartDate <= EndDate;

        public required RoomService RoomService { get; set; }
        public required Staff Staff { get; set; }
        public required Client Client { get; set; }
        public required Room Room { get; set; }

        // Methods for reference only, business logic should be in the controller
        // ConsultRoomServiceBookings()
        // AddRoomServiceBooking()
        // UpdateRoomServiceBooking()
        // CancelRoomServiceBooking()
        // UpdateBookedState()
        // SelectRoomServiceBooking()
        // UpdateStaffConfirmation()
    }
}

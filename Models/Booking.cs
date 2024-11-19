using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReserveSystem.Models
{
    public class Booking
    {
        public required int BookingID { get; set; }
        public required int ClientID { get; set; }
        public required DateTime CheckInDate { get; set; }
        public required DateTime CheckOutDate { get; set; }
        public required DateTime BookingDate { get; set; }
        public required bool BookedState { get; set; }
        public required int NumberOfGuests { get; set; }
        public required Boolean Payment { get; set; }

        public required Client Client { get; set; }
        public required ICollection<RoomBooking> RoomBookings { get; set; }

        // Methods for reference only, business logic should be in the controller
        // Consult_Booking()

        /* public void Consult_Booking(int BookingID)
        {
            // Consult the booking with the given BookingID

            // If the booking does not exist, return null
            
            // Else return the booking
        }  */
    }
}

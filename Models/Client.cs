using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Client
    {
        public int ClientID { get; set; }
        public required string Client_Name { get; set; }
        public required string Client_Phone { get; set; }
        public required string Client_Address { get; set; }
        public required string Client_Email { get; set; }
        public required string Client_Tax_Id { get; set; }
        public required bool Client_Login { get; set; }
        public required bool Client_Status { get; set; }

        public required ICollection<Booking> Bookings { get; set; }
        public ICollection<RoomServicesBooking>? RoomServicesBookings { get; set; }
        // Methods for reference only, business logic should be in the controller
        
        // ViewClientServices()
        /* public void ViewClientServices()
        {
            // View Client Services
        } */

        // EditClient()
        /* public void EditClient()
        {
            // Edit Client
        } */
    }
}
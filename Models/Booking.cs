using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Booking
    {
        
            [Key]
            public int ID_Booking { get; set; }

            [Required]
            public int ID_Client { get; set; } // Asumiendo una relación con el cliente

            [Required]
            public DateTime CheckinDate { get; set; }

            [Required]
            public DateTime CheckoutDate { get; set; }

            [Required]
            public DateTime BookingDate { get; set; }

            [Required]
            [MaxLength(50)]
            public string BookingCode { get; set; }

            [Required]
            public int TotalPersonsNumber { get; set; }

            [Required]
            public bool PaymentStatus { get; set; }

            [Required]
            public bool Breakfast { get; set; }

            public ICollection<RoomBooking> RoomBookings { get; set; } // Relación 1:N con RoomBooking
        }
}

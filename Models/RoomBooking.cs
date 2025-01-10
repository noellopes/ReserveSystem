using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomBooking
    {
        [Key]
        public int ID_RoomBooking { get; set; }

        [Required]
        public int ID_Booking { get; set; }

        [ForeignKey("ID_Booking")]
        public Booking Booking { get; set; }

        [Required]
        public int ID_Room { get; set; }

        [ForeignKey("ID_Room")]
        public Room Room { get; set; }
    }
}

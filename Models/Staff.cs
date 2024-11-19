using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        public required int JobID { get; set; }
        public required string StaffName { get; set; }
        public required string StaffEmail { get; set; }
        public required string StaffPhone { get; set; }
        public required string StaffPassword { get; set; }
        public required DateTime HireDate { get; set; }
        public required DateTime DismissalDate { get; set; }
        public required int VacationDays { get; set; }

        // Navigation properties
        public required Job Job { get; set; }
        public required ICollection<Schedule> Schedules { get; set; }
        public ICollection<RoomServicesBooking>? RoomServicesBookings { get; set; }

        // Methods for reference only, business logic should be in the controller
        // ConsultStaff()
        // SelectStaff()
    }
}
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public int StaffID { get; set; }
        public int TypeOfSchedule { get; set; }
        public DateTime Date { get; set; }
        public DateTime ShiftStartTime { get; set; }
        public DateTime ShiftEndTime { get; set; }
        public bool Available { get; set; }
        public bool Present { get; set; }

        // Navigation properties
        public required Staff Staff { get; set; }

        // Methods for reference only, business logic should be in the controller
        // ConsultStaff()
        // SelectStaff()
    }
}

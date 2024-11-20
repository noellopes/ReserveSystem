using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; }
        public required TimeSpan WorkSchedule { get; set; }
    }
}

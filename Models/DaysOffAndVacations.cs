using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class DaysOffAndVacations
    {
        [Key]
        public int DayOffVacationId { get; set; } // Primary Key

        [ForeignKey("Staff")]
        public int StaffId { get; set; } // Foreign Key for Staff

        [Required]
        public DateTime StartDate { get; set; } // Start date of day off or vacation

        [Required]
        public DateTime EndDate { get; set; } // End date of day off or vacation

        [Required]
        public string Reason { get; set; }



        [Required]
        [MaxLength(500)]
        public string Status { get; set; } // Status for the request



        // Navigation Property
       // public virtual Staff Staff { get; set; }



        // Helper Method
        public bool IsValidRequest()
        {
            return EndDate > StartDate;
        }

        // Methods
        public void CreateDayOffRequest()
        {
            // Creating permission requests
            Console.WriteLine("Day off/vacation request created.");
        }

        public void ConfirmRequest()
        {
            // Request approval operations
            Console.WriteLine("Request confirmed.");
        }

        public void DenyRequest()
        {
            // Request rejection operations
            Console.WriteLine("Request denied.");
        }
    }
}

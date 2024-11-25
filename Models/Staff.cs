using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models

{
    public class Staff
    {
        [Key]
        [Required]
        public int StaffID { get; set; }
        [Required]
        public int JobId { get; set; }

        [Required]
        [StringLength(50)]
        public string StaffName { get; set; }
        [Required]
        public string StaffEmail { get; set; }

        [StringLength(50)]

        public string StaffPhone { get; set; }

        [Required]
        [MinLength(8)]
        public string StaffPassword { get; set; }

        [Required]
        public DateTime StartFunctionsDate { get; set; }
        public DateTime? EndFunctionsDate { get; set; }
        public int DaysOffVacation { get; set; }

    }
}
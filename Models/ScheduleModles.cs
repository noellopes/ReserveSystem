using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Schedule
    {
        [Key]
        [Required]
        public int ScheduleId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public DateTime StartShiftTime { get; set; }

        [Required]
        public DateTime EndShiftTime { get; set; }

        // Chave estrangeira
        [Required]
        public int StaffId { get; set; }

        // Propriedade de navegação
        [ForeignKey("StaffId")]
        public String Staff { get; set; }

        public bool IsValidShiftTime()
        {
            return EndShiftTime > StartShiftTime;
        }
    }
}

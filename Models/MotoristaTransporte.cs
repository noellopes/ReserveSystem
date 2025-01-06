using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class MotoristaTransporte
    {
        [Key]
        public int MotoristaTransporteId { get; set; }
        [Required]
        public int StaffId { get; set; }
        
        [Required]
        public int TransporteId { get; set; }
    }
}

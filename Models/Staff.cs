using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Staff
    {
        [Key]

        public int StaffId { get; set; }
        [Required, Display(Name = "Nome do Staff")]

        public string Staff_Name { get; set; }

        [Required, Display(Name = "Serviço")]
        public string Job_Name { get; set; }

        public string? TipoCarta { get; set; }

        public virtual ICollection<MotoristaTransporte>? MotoristaTransporte { get; set; }
    }
}

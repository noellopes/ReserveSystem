using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Staff
    {
        [Key]

        public int StaffId { get; set; }
        [Required, Display(Name = "Staff Name")]

        public string Staff_Name { get; set; }

        public string Job_Name { get; set; }

        public string? TipoCarta { get; set; }

        public virtual ICollection<MotoristaTransporte>? MotoristaTransporte { get; set; }
    }
}

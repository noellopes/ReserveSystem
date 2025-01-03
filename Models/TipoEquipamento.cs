using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class TipoEquipamento
    {
        [Key]
        public long IdTipoEquipamento { get; set; }
        [Required]
        public string? NomeTipoEquipamento { get; set;}

        public ICollection<Equipamento>? Equipamento{ get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Equipamento
    {
        [Key]
        public long IdEquipamento { get; set; }

        [Required]
        public string? NomeEquipamento { get; set; }

        
        [Required]
        public int Quantidade { get; set; }

        [Required]
        [ForeignKey(nameof(IdTipoEquipamento))]
        public long IdTipoEquipamento { get; set; }
        public TipoEquipamento? TipoEquipamento { get; set; }
    }
}
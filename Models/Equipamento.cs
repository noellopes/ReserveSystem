using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Equipamento
    {
        [Key]
        public int IdEquipamento { get; set; }
        [MaxLength(800)]

        public string NomeEquipamento { get; set; }
        [MaxLength(800)]

        public string TipoEquipamento { get; set; }
        public int Quantidade { get; set; }
    }
}
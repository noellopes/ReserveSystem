using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Equipamento
    {
        [Key]
        public int IdEquipamento { get; set; }
        public string NomeEquipamento { get; set; }
        public string TipoEquipamento { get; set; }
        public int Quantidade { get; set; }
    }
}
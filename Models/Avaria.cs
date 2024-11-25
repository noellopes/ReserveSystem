using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Avaria
    {
        [Key] public long IdAvaria { get; set; }
        
        [ForeignKey("TipoAvaria")]
        public string TipoAvaria { get; set; }
        [ForeignKey("IdEquipamento")]
        public int IdEquipamento { get; set; }
        /*[ForeignKey("STAFF_ID")]
        public int STAFF_ID { get; set; }*/

        public DateTime DataAvaria { get; set; }
        public DateTime DataAvariaResolvida { get; set; }
        public string Descrição { get; set; }
        public string EstadoAvaria { get; set; }
    }
}

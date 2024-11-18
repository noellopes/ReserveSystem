using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class ReservaModel
    {
        [Key]
        public int ReservaID { get; set; }
   
        public string TipoReserva { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Partcipantes { get; set; }
        public double PrecoTotal { get; set; }

        public int ClienteId { get; set; }
        public ClienteModel? Cliente { get; set; }

        [ForeignKey("Equipamento")]
        public int IdEquipamento { get; set; }  // Foreign key to Equipamento
        public Equipamento Equipamento { get; set; }  // Navigation property
    }
}
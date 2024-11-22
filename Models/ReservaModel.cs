using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class ReservaModel
    {
        [Key]
        public int ReservaID { get; set; }

        public string TipoReserva { get; set; }// fica como um dropdown - select tag 
        public DateTime DataReserva { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Partcipantes { get; set; }
        public double PrecoTotal { get; set; }
        public int ClienteId { get; set; }
        public ClientModel? ClienteModel { get; set; }
        //public int IdEquipamento { get; set; }
        //public Equipamento? Equipamento { get; internal set; }
    }
}
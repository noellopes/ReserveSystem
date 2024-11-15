using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class ReservaModel

    {
        [Key]
        public int ReservaID { get; set; }
   
        public string TipoReserva { get; set; }// fica como um dropdown//select tag 
        public DateTime DataReserva { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int Partcipantes { get; set; }
        public double PrecoTotal { get; set; }
        public int ClienteId { get; set; }
        public ClienteModel? Cliente { get; set; }


    }
}

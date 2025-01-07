using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Reserva
    {
        [Key]
        public long IdReserva { get; set; }

        [ForeignKey(nameof(IdEquipamento))]
        public long IdEquipamento { get; set; }
        public Equipamento? Equipamento { get; set; }
        
        [ForeignKey(nameof(TipoReserva))]
        public long IdTipoReserva { get; set; }
        public TipoReserva? TipoReserva { get; set; }

        [ForeignKey(nameof(NumeroCliente))]
        public long NumeroCliente { get; set; }
        public ClientModel? Client { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime DataReserva { get; set; }
        public DateTime DataEstado { get; set; }
        public double PrecoTotal { get; set; }
        public string Estado { get; set; }
        public int TotalParticipantes { get; set; }

    }
}

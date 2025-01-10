using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Reserva
    {
        [Key]
        public long IdReserva { get; set; }

        [Required(ErrorMessage = "O campo 'IdEquipamento' é obrigatório.")]
        [ForeignKey(nameof(Equipamento))]
        public long IdEquipamento { get; set; }
        public Equipamento? Equipamento { get; set; }

        [Required(ErrorMessage = "O campo 'IdTipoReserva' é obrigatório.")]
        [ForeignKey(nameof(TipoReserva))]
        public long IdTipoReserva { get; set; }
        public TipoReserva? TipoReserva { get; set; }

        [Required(ErrorMessage = "O campo 'IdSala' é obrigatório.")]
        [ForeignKey(nameof(Sala))]
        public long IdSala { get; set; }
        public Sala? Sala { get; set; }

        [Required(ErrorMessage = "O campo 'NumeroCliente' é obrigatório.")]
        public long NumeroCliente { get; set; }
        public ClientModel? Client { get; set; }

        [Required(ErrorMessage = "O campo 'DataInicio' é obrigatório.")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "O campo 'DataFim' é obrigatório.")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "O campo 'DataReserva' é obrigatório.")]
        public DateTime DataReserva { get; set; }

        [Required(ErrorMessage = "O campo 'DataEstado' é obrigatório.")]
        public DateTime DataEstado { get; set; }

        [Required(ErrorMessage = "O campo 'PrecoTotal' é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O valor de 'PrecoTotal' deve ser maior ou igual a zero.")]
        public double PrecoTotal { get; set; }

        [Required(ErrorMessage = "O campo 'Estado' é obrigatório.")]
        [StringLength(100, ErrorMessage = "O campo 'Estado' pode ter no máximo 100 caracteres.")]
        public string Estado { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo 'TotalParticipantes' é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O valor de 'TotalParticipantes' deve ser maior ou igual a zero.")]
        public int TotalParticipantes { get; set; }
    }
}

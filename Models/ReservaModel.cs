using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class ReservaModel
    {
        [Key]
        public int Id { get; set; } // Identificador único da reserva

        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime Data { get; set; } // Data da reserva

        [Required(ErrorMessage = "O horário é obrigatório.")]
        public TimeSpan Horario { get; set; } // Horário da reserva

        public bool Status { get; set; } // Status da reserva (Ativa, Cancelada)

        public int ClienteId { get; set; } // Relacionamento com um cliente

        public int PersonalTrainer {  get; set; }

        public int Maquinas { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models

{
    public enum StatusType
    {
        COMPLETED,
        FREE,
        PENDING
    }
    public class ReservaModel
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Espaço é obrigatório.")]
        [ForeignKey("Space")]
        public int SpaceId { get; set; }
        public SpaceModel? Space { get; set; } // Relacionamento com o espaço

        [Required(ErrorMessage = "O Cliente é obrigatório.")]
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public ClientModel? Client { get; set; } // Relacionamento com o cliente

        [ForeignKey("PersonalTrainer")]
        public int? PersonalTrainerId { get; set; } // PT é opcional
        public PersonalTrainerModel? PersonalTrainer { get; set; } // Agora permite valores nulos

        public DateTime ReservationDate { get; set; } // Apenas o dia

        [Required]
        public TimeSpan StartTime { get; set; } // Horário de abertura

        [Required]
        public TimeSpan EndTime { get; set; } // Horário de fechamento//[Required]

        [Required(ErrorMessage = "A data e o horário são obrigatórios.")]
        public DateTime Hour { get; set; } // Horário do treino

        [Required]
        public StatusType Status { get; set; } // true para reservado, false para cancelado

        //Feedback
        public DateTime? FeedbackTime { get; set; }

        [Range(0, 100, ErrorMessage = "O valor deve estar entre 0 e 100.")]
        public int? FeedbackValue { get; set; }

        public string? FeedBackComment { get; set; }
    }
}

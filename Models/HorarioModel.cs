using ReserveSystem.Data.Migrations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class HorarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O espaço é obrigatório")]
        [ForeignKey("space")]
        public int spaceId { get; set; }
        public required SpaceModel space { get; set; } // Relacionamento com o espaço

        [Required]
        public DayOfWeek Day { get; set; } // Dia da semana

        [Required]
        public TimeSpan OpenTime { get; set; } // Horário de abertura

        [Required]
        public TimeSpan CloseTime { get; set; } // Horário de fechamento
    }
}

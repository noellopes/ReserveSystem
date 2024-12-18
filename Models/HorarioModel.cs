using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class HorarioModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O spaceId é obrigatório")]
        [ForeignKey("Space")]
        public int spaceId { get; set; } // Relacionamento com o espaço
        public SpaceModel? Space { get; set; } // Referência para o espaço associado

        [Required]
        public DayOfWeek Day { get; set; } // Dia da semana (segunda a domingo)

        public TimeSpan OpenTime { get; set; } // Horário de abertura

        public TimeSpan CloseTime { get; set; } // Horário de fechamento

        [Required]
        public bool IsClosed { get; set; } // Indica se o espaço está fechado nesse dia

        // Validador customizado para garantir que CloseTime seja maior que OpenTime
        public bool ValidateCloseTime()
        {
            // Se o espaço estiver fechado, retorna verdadeiro
            if (IsClosed)
                return true;
            return CloseTime > OpenTime;
        }
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class AlocacaoModel
    {

        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "O espaço é obrigatório")]
        [ForeignKey("space")]
        public int SpaceId { get; set; }
        public required SpaceModel Space { get; set; } // Relacionamento com o espaço

        [Required]
        public TimeSpan StartTime { get; set; } // Horário de abertura

        [Required]
        public TimeSpan EndTime { get; set; } // Horário de fechamento

        [Required]
        [Range(0, 100, ErrorMessage = "O valor deve estar entre 0 e 100.")]
        public int Percentage { get; set; }
    }
}

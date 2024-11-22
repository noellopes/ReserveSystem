using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class ReservaModel
    {

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Cliente é obrigatório.")]
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public required ClientModel Client { get; set; } // Relacionamento com o cliente

        [ForeignKey("PersonalTrainer")]
        public int? PersonalTrainerId { get; set; } // PT é opcional
        public PersonalTrainerModel? PersonalTrainer { get; set; } // Agora permite valores nulos

        //[Required]
        //[ForeignKey("MuscleGroup")]
        //public int MuscleGroupId { get; set; }
        //public MuscleGroupModel MuscleGroup { get; set; } // Relacionamento com o Grupo Muscular

        [Required(ErrorMessage = "A data e o horário são obrigatórios.")]
        public DateTime Hour { get; set; } // Horário do treino

        [Required]
        public bool Status { get; set; } // true para reservado, false para cancelado
    }
}

using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{

    public enum SpaceType
    {
        GYM,
        POOL
    }

    public class SpaceModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; } // nome do espaço (ginásio/piscina)

        [Required]
        public required int Capacity { get; set; } //Capacidade maxima do espaço

        [Required]
        [Range(0, 100, ErrorMessage = "A percentagem de vagas tem que estar no intervalo de 0-100")]
        public required int ReservedPercentage { get; set; } // Percentual de vagas reservadas para clientes
        [Required]
        public required SpaceType Type { get; set; } //Tipo de espaço (ginásio/piscina)

    }
}

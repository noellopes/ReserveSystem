using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class ReservaModel

    {
        [Key]
        public int ReservaID { get; set; }

        [Required(ErrorMessage = "O tipo de reserva é obrigatório.")]
        public string TipoReserva { get; set; } 

        [Required(ErrorMessage = "A data da reserva é obrigatória.")]
        public DateTime DataReserva { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória.")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data de fim é obrigatória.")]
        public DateTime DataFim { get; set; }

        [Required(ErrorMessage = "O número de participantes é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Deve haver pelo menos um participante.")]
        public int Partcipantes { get; set; }

        [Required(ErrorMessage = "O preço total é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public double PrecoTotal { get; set; }

        public int ClienteId { get; set; }
        public ClienteModel Cliente { get; set; }
    }
}

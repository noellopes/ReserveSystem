using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{

    public class ReservaExcursaoModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Nome do Cliente")]
        [Required(ErrorMessage = "O cliente é obrigatório.")]
        public int ClienteId { get; set; }
        [Display(Name = "Excursão")]
        [Required(ErrorMessage = "A excursão é obrigatória.")]
        public int ExcursaoId { get; set; }

        [Display(Name = "Data da Reserva")]
        [Column(TypeName = "DATETIME")]
        [Required(ErrorMessage = "A data da reserva é obrigatória.")]
        public DateTime DataReserva { get; set; }

        [Display(Name = "Numero de Pessoas")]
        [Range(1, int.MaxValue, ErrorMessage = "O número de pessoas deve ser pelo menos 1.")]
        public int NumPessoas { get; set; }

        [Display(Name = "Valor Total")]

        public float ValorTotal { get; set; }

        // Navigation properties
        public virtual ClienteTestModel? Cliente { get; set; }
        public virtual ExcursaoModel? Excursao { get; set; }
    }

}


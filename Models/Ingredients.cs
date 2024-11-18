using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Ingrediente
    {
        public int IngredienteId { get; set; }

        [Required(ErrorMessage = "O nome do ingrediente é obrigatório."), StringLength(300)]
        public string Nome { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O valor deve ser maior ou igual a 0.")]
        public double QuantidadeDisponivel { get; set; }

        [Required(ErrorMessage = "A unidade de medida é obrigatória."), StringLength(10)]
        public string UnidadeMedida { get; set; }
    }
}

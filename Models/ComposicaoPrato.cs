using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class ComposiçãoPrato
    {
        public int ComposicaoId { get; set; }

        public int PratoId { get; set; }

        public int IngredienteId { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Quantidade do ingrediente tem de ser maior ou que 0.")]
        public double QuantidadeIngrediente { get; set; }

    }
}

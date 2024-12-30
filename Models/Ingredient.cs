using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Ingredient
    {
        // Primary Key
        public int IngredientID { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome do ingrediente é obrigatório"), StringLength(300)]
        public string Name { get; set; }

        [Display(Name = "Unidade de Medida")]
        [Required(ErrorMessage = "A unidade de medida é obrigatória"), StringLength(10)]
        public string UnityMeasure { get; set; }

        [Display(Name = "Unidade a Usar nas Receitas")]
        [Required(ErrorMessage = "A unidade a usar nas receitas é obrigatória"), StringLength(10)]
        public string UnityRecipe { get; set; }

        [Display(Name = "Stock Mínimo")]
        [Range(0, int.MaxValue, ErrorMessage = "O stock mínimo deve ser maior ou igual a 0.")]
        public int StockMin { get; set; }

        [Display(Name = "Quantidade Disponível")]
        [Required(ErrorMessage = "A quantidade disponível é obrigatória")]
        [Range(0, int.MaxValue, ErrorMessage = "A quantidade disponível deve ser maior ou igual a 0.")]
        public int QuantityAvailable { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de Última Modificação")]
        public DateTime LastModificationDate { get; set; } = DateTime.Now;

    }
}

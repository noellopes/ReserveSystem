using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Ingredient
    {
        
        public int IngredientID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Ingredient Name is required"), StringLength(300)]
        public string Name { get; set; }

        [Display(Name = "Unidade de Medida")]
        [Required(ErrorMessage = "Unidade de medida é obrigatória"), StringLength(10)]
        public string UnityMeasure { get; set; }

        public ICollection<Stock> Stocks { get; set; }

    }
}

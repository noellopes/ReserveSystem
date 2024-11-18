using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Ingredient
    {
        
        public int IngredientID { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Ingredient Name is required"), StringLength(300)]
        public string Name { get; set; }

        [Display(Name = "Unity Of Measure")]
        [Required(ErrorMessage = "Unity of measure is required"), StringLength(10)]
        public string UnityMeasure { get; set; }

        public ICollection<Stock> Stocks { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Ingredient
    {
        
        public int IngredientID { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome do ingrediente é obrigatório"), StringLength(300)]
        public string Name { get; set; }

        [Display(Name = "Unidade de Medida")]
        [Required(ErrorMessage = "Unidade de medida é obrigatória"), StringLength(10)]
        public string UnityMeasure { get; set; }

    }
}

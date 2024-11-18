using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Stock
    {
        //Primary Key
        public int StockID {  get; set; }

        //Foreign Key
        [Required]
        public int IngredientID { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "A quantidade deve ser maior ou igual a 0.")]
        public double AvailableQuantity { get; set; }

        public DateTime LastModificationDate { get; set; }

        public Ingredient? Ingredient { get; set; }
    }
}

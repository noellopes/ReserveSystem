namespace ReserveSystem.Models
{
    public class ComposicaoPrato
    {
        //Primary Key
        public int ComposicaoPratoID { get; set; }

        //Foreign Key Ingredient
        public int IngredientID { get; set; }
        public Ingredient Ingredient { get; set; }

        //Foreign Key Prato
        public int PratoID { get; set; }
        public Prato Prato { get; set; }

        public double IngredientQuantity { get; set; }
    }
}

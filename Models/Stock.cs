using System.ComponentModel.DataAnnotations;


namespace ReserveSystem.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        public string IngredienteId { get; set; }
        public double QuantityAvailable { get; set; }
        public string LastModificationDate { get; set; }

    }
}

using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class SeedData
    {
        internal static void Populate(ReserveSystemContext? db)
        {
            if (db == null) throw new ArgumentNullException(nameof(db));

            db.Database.EnsureCreated();
            PopulateIngredients(db);
        }

        private static void PopulateIngredients(ReserveSystemContext db)
        {
            if (db.Ingredient.Any()) return;

            db.Ingredient.AddRange(new List<Ingredient>{
                new Ingredient { Name = "Tomates", UnityMeasure = "kg", StockMin = 10, QuantityAvailable = 50, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Ovos", UnityMeasure = "Unidade", StockMin = 30, QuantityAvailable = 120, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Cebolas", UnityMeasure = "kg", StockMin = 5, QuantityAvailable = 25, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Alho", UnityMeasure = "kg", StockMin = 3, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Batatas", UnityMeasure = "kg", StockMin = 20, QuantityAvailable = 60, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Arroz", UnityMeasure = "kg", StockMin = 15, QuantityAvailable = 45, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Massas", UnityMeasure = "kg", StockMin = 10, QuantityAvailable = 40, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Pão", UnityMeasure = "Unidade", StockMin = 20, QuantityAvailable = 80, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Leite", UnityMeasure = "litro", StockMin = 10, QuantityAvailable = 35, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Queijo", UnityMeasure = "kg", StockMin = 8, QuantityAvailable = 20, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Presunto", UnityMeasure = "kg", StockMin = 5, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Frango", UnityMeasure = "kg", StockMin = 12, QuantityAvailable = 25, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Carne de vaca", UnityMeasure = "kg", StockMin = 10, QuantityAvailable = 22, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Peixe", UnityMeasure = "kg", StockMin = 8, QuantityAvailable = 18, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Camarão", UnityMeasure = "kg", StockMin = 6, QuantityAvailable = 10, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Brócolos", UnityMeasure = "kg", StockMin = 4, QuantityAvailable = 12, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Cenoura", UnityMeasure = "kg", StockMin = 5, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Espinafre", UnityMeasure = "kg", StockMin = 3, QuantityAvailable = 9, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Alface", UnityMeasure = "kg", StockMin = 5, QuantityAvailable = 18, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Tomilho", UnityMeasure = "Unidade", StockMin = 5, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Manjericão", UnityMeasure = "Unidade", StockMin = 5, QuantityAvailable = 12, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Pimenta", UnityMeasure = "Unidade", StockMin = 10, QuantityAvailable = 30, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Azeite", UnityMeasure = "litro", StockMin = 10, QuantityAvailable = 20, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Vinagre", UnityMeasure = "litro", StockMin = 5, QuantityAvailable = 10, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Mel", UnityMeasure = "kg", StockMin = 4, QuantityAvailable = 8, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Açúcar", UnityMeasure = "kg", StockMin = 12, QuantityAvailable = 35, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Sal", UnityMeasure = "kg", StockMin = 8, QuantityAvailable = 20, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Bicarbonato de sódio", UnityMeasure = "kg", StockMin = 3, QuantityAvailable = 8, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Farinha", UnityMeasure = "kg", StockMin = 10, QuantityAvailable = 25, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Chocolate", UnityMeasure = "kg", StockMin = 5, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Café", UnityMeasure = "kg", StockMin = 8, QuantityAvailable = 20, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Iogurte", UnityMeasure = "litro", StockMin = 5, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Manteiga", UnityMeasure = "kg", StockMin = 3, QuantityAvailable = 10, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Limões", UnityMeasure = "kg", StockMin = 4, QuantityAvailable = 12, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Maçãs", UnityMeasure = "kg", StockMin = 6, QuantityAvailable = 20, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Bananas", UnityMeasure = "kg", StockMin = 6, QuantityAvailable = 18, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Laranjas", UnityMeasure = "kg", StockMin = 7, QuantityAvailable = 21, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Peras", UnityMeasure = "kg", StockMin = 6, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Uvas", UnityMeasure = "kg", StockMin = 5, QuantityAvailable = 18, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Abacaxi", UnityMeasure = "Unidade", StockMin = 3, QuantityAvailable = 9, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Morangos", UnityMeasure = "kg", StockMin = 4, QuantityAvailable = 10, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Kiwi", UnityMeasure = "kg", StockMin = 3, QuantityAvailable = 12, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Pêssego", UnityMeasure = "kg", StockMin = 4, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Melancia", UnityMeasure = "Unidade", StockMin = 2, QuantityAvailable = 5, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Coco", UnityMeasure = "Unidade", StockMin = 3, QuantityAvailable = 7, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Abóbora", UnityMeasure = "kg", StockMin = 5, QuantityAvailable = 20, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Berinjela", UnityMeasure = "kg", StockMin = 4, QuantityAvailable = 16, LastModificationDate = DateTime.Now }
            });
            db.SaveChanges();
        }
    }
}

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
                new Ingredient { Name = "Tomates", UnityMeasure = "kg" },
                new Ingredient { Name = "Ovos", UnityMeasure = "Unidade" },
                new Ingredient { Name = "Cebolas", UnityMeasure = "kg" },
                new Ingredient { Name = "Alho", UnityMeasure = "kg" },
                new Ingredient { Name = "Batatas", UnityMeasure = "kg" },
                new Ingredient { Name = "Arroz", UnityMeasure = "kg" },
                new Ingredient { Name = "Massas", UnityMeasure = "kg" },
                new Ingredient { Name = "Pão", UnityMeasure = "Unidade" },
                new Ingredient { Name = "Leite", UnityMeasure = "litro" },
                new Ingredient { Name = "Queijo", UnityMeasure = "kg" },
                new Ingredient { Name = "Presunto", UnityMeasure = "kg" },
                new Ingredient { Name = "Frango", UnityMeasure = "kg" },
                new Ingredient { Name = "Carne de vaca", UnityMeasure = "kg" },
                new Ingredient { Name = "Peixe", UnityMeasure = "kg" },
                new Ingredient { Name = "Camarão", UnityMeasure = "kg" },
                new Ingredient { Name = "Brócolos", UnityMeasure = "kg" },
                new Ingredient { Name = "Cenoura", UnityMeasure = "kg" },
                new Ingredient { Name = "Espinafre", UnityMeasure = "kg" },
                new Ingredient { Name = "Alface", UnityMeasure = "kg" },
                new Ingredient { Name = "Tomilho", UnityMeasure = "Unidade" },
                new Ingredient { Name = "Manjericão", UnityMeasure = "Unidade" },
                new Ingredient { Name = "Pimenta", UnityMeasure = "Unidade" },
                new Ingredient { Name = "Azeite", UnityMeasure = "litro" },
                new Ingredient { Name = "Vinagre", UnityMeasure = "litro" },
                new Ingredient { Name = "Mel", UnityMeasure = "kg" },
                new Ingredient { Name = "Açúcar", UnityMeasure = "kg" },
                new Ingredient { Name = "Sal", UnityMeasure = "kg" },
                new Ingredient { Name = "Bicarbonato de sódio", UnityMeasure = "kg" },
                new Ingredient { Name = "Farinha", UnityMeasure = "kg" },
                new Ingredient { Name = "Chocolate", UnityMeasure = "kg" },
                new Ingredient { Name = "Café", UnityMeasure = "kg" }
            });
            db.SaveChanges();
        }
    }
}

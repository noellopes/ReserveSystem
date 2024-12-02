
using ReserveSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ReserveSystem.Data
{
    public class SeedData
    {
        internal static void Populate(ReserveSystemContext? db)
        {
            if (db == null) throw new ArgumentNullException(nameof(db));

            PopulateIngredients(db);
        }

        private static void PopulateIngredients(ReserveSystemContext db)
        {
            db.Ingredient.AddRange(new List<Ingredient>{
                new Ingredient { Name = "Ovos", UnityMeasure = "Unidade" },
                new Ingredient { Name = "Arroz", UnityMeasure = "Kg" },
                new Ingredient { Name = "Batata", UnityMeasure = "Kg" },
                new Ingredient { Name = "Frango", UnityMeasure = "Kg" },
                new Ingredient { Name = "Carne de Porco", UnityMeasure = "Kg" },
                new Ingredient { Name = "Tomate", UnityMeasure = "Unidade" },
                new Ingredient { Name = "Cenoura", UnityMeasure = "Kg" },
                new Ingredient { Name = "Cebola", UnityMeasure = "Kg" },
                new Ingredient { Name = "Alho", UnityMeasure = "Dente" },
                new Ingredient { Name = "Pão", UnityMeasure = "Unidade" },
                new Ingredient { Name = "Leite", UnityMeasure = "Litro" },
                new Ingredient { Name = "Queijo", UnityMeasure = "Kg" },
                new Ingredient { Name = "Manteiga", UnityMeasure = "Kg" },
                new Ingredient { Name = "Azeite", UnityMeasure = "Litro" },
                new Ingredient { Name = "Óleo", UnityMeasure = "Litro" },
                new Ingredient { Name = "Farinha", UnityMeasure = "Kg" },
                new Ingredient { Name = "Açúcar", UnityMeasure = "Kg" },
                new Ingredient { Name = "Sal", UnityMeasure = "Kg" },
                new Ingredient { Name = "Pimenta", UnityMeasure = "Kg" },
                new Ingredient { Name = "Maçã", UnityMeasure = "Kg" },
                new Ingredient { Name = "Banana", UnityMeasure = "Kg" },
                new Ingredient { Name = "Laranja", UnityMeasure = "Kg" },
                new Ingredient { Name = "Melancia", UnityMeasure = "Kg" },
                new Ingredient { Name = "Uva", UnityMeasure = "Kg" },
                new Ingredient { Name = "Morango", UnityMeasure = "Kg" },
                new Ingredient { Name = "Limão", UnityMeasure = "Kg" },
                new Ingredient { Name = "Coentro", UnityMeasure = "Molho" },
                new Ingredient { Name = "Salsa", UnityMeasure = "Molho" },
                new Ingredient { Name = "Hortelã", UnityMeasure = "Molho" },
                new Ingredient { Name = "Alecrim", UnityMeasure = "Molho" },
                new Ingredient { Name = "Manjericão", UnityMeasure = "Molho" },
                new Ingredient { Name = "Louro", UnityMeasure = "Folha" },
                new Ingredient { Name = "Pimenta do Reino", UnityMeasure = "Kg" },
                new Ingredient { Name = "Canela", UnityMeasure = "Kg" },
                new Ingredient { Name = "Cravo", UnityMeasure = "Kg" },
                new Ingredient { Name = "Noz-moscada", UnityMeasure = "Kg" },
                new Ingredient { Name = "Gengibre", UnityMeasure = "Kg" },
                new Ingredient { Name = "Mel", UnityMeasure = "Kg" },
                new Ingredient { Name = "Vinagre", UnityMeasure = "Litro" },
                new Ingredient { Name = "Iogurte", UnityMeasure = "Unidade" },
                new Ingredient { Name = "Chocolate", UnityMeasure = "Kg" },
                new Ingredient { Name = "Cacau", UnityMeasure = "Kg" },
                new Ingredient { Name = "Creme de Leite", UnityMeasure = "Kg" },
                new Ingredient { Name = "Leite Condensado", UnityMeasure = "Kg" },
                new Ingredient { Name = "Feijão", UnityMeasure = "Kg" },
                new Ingredient { Name = "Lentilha", UnityMeasure = "Kg" },
                new Ingredient { Name = "Ervilha", UnityMeasure = "Kg" },
                new Ingredient { Name = "Grão de Bico", UnityMeasure = "Kg" },
                new Ingredient { Name = "Abóbora", UnityMeasure = "Kg" },
                new Ingredient { Name = "Beterraba", UnityMeasure = "Kg" },
            });
            db.SaveChanges();
        }
    }
}

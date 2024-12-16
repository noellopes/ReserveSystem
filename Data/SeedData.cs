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
            PopulatePratos(db);
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
        private static void PopulatePratos(ReserveSystemContext db)
        {
            if (db.Prato.Any()) return;

            db.Prato.AddRange(new List<Prato>{
                new Prato { Nome = "Lasanha", Descricao = "Lasanha à bolonhesa com queijo gratinado.", Preco = 12.50M },
                new Prato { Nome = "Pizza Margherita", Descricao = "Pizza clássica com tomate, queijo e manjericão.", Preco = 9.90M },
                new Prato { Nome = "Risoto de Camarão", Descricao = "Risoto cremoso com camarões frescos.", Preco = 15.00M },
                new Prato { Nome = "Frango à Parmegiana", Descricao = "Frango empanado com molho de tomate e queijo gratinado.", Preco = 14.20M },
                new Prato { Nome = "Salada Caesar", Descricao = "Salada com alface, frango, croutons e molho Caesar.", Preco = 8.50M },
                new Prato { Nome = "Arroz de Marisco", Descricao = "Arroz com diversos mariscos frescos, temperado com ervas.", Preco = 18.50M },
                new Prato { Nome = "Bife à Portuguesa", Descricao = "Bife de vaca com presunto, batatas fritas e ovo estrelado.", Preco = 16.90M },
                new Prato { Nome = "Sopa de Legumes", Descricao = "Sopa caseira com legumes frescos.", Preco = 4.50M },
                new Prato { Nome = "Peixe Grelhado", Descricao = "Peixe grelhado com legumes ao vapor.", Preco = 13.80M },
                new Prato { Nome = "Espaguete à Carbonara", Descricao = "Espaguete com molho cremoso de ovos, queijo e bacon.", Preco = 10.00M },
                new Prato { Nome = "Bacalhau à Brás", Descricao = "Bacalhau desfiado com batata palha, ovos e salsa.", Preco = 14.90M },
                new Prato { Nome = "Hambúrguer Artesanal", Descricao = "Hambúrguer gourmet com carne suculenta e acompanhamentos.", Preco = 11.50M },
                new Prato { Nome = "Taco de Carne", Descricao = "Taco mexicano recheado com carne, alface e molho picante.", Preco = 8.00M },
                new Prato { Nome = "Curry de Frango", Descricao = "Frango ao curry com leite de coco e arroz basmati.", Preco = 12.00M },
                new Prato { Nome = "Sushi Variado", Descricao = "Prato de sushi com seleção variada.", Preco = 20.00M },
                new Prato { Nome = "Picanha na Brasa", Descricao = "Picanha fatiada com acompanhamento de farofa e vinagrete.", Preco = 22.00M },
                new Prato { Nome = "Tiramisu", Descricao = "Sobremesa italiana feita com café, mascarpone e cacau.", Preco = 6.50M },
                new Prato { Nome = "Pavlova", Descricao = "Sobremesa de merengue com chantilly e frutas frescas.", Preco = 7.00M }

            });
            db.SaveChanges();
        }
    }
}

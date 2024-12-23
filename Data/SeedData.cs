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
            PopulateSuppliers(db);
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

        private static void PopulateSuppliers(ReserveSystemContext db)
        {
            if (db.Supplier.Any()) return;

            db.Supplier.AddRange(new List<Supplier>{
                new Supplier { SupplierName = "Alimentos do Mar", SupplierAddress = "Avenida Atlântica, 200", SupplierPhone = "912345678", SupplierEmail = "contato@alimentosdomar.com" },
                new Supplier { SupplierName = "Distribuidora Verde", SupplierAddress = "Rua das Flores, 80", SupplierPhone = "913456789", SupplierEmail = "atendimento@distribuidoraverde.com" },
                new Supplier { SupplierName = "Carnes Premium", SupplierAddress = "Estrada do Campo, 150", SupplierPhone = "914567890", SupplierEmail = "vendas@carnespremium.com" },
                new Supplier { SupplierName = "Frutalândia", SupplierAddress = "Rua das Frutas, 45", SupplierPhone = "915678901", SupplierEmail = "suporte@frutalandia.com" },
                new Supplier { SupplierName = "Delícias da Horta", SupplierAddress = "Rua do Sol, 110", SupplierPhone = "916789012", SupplierEmail = "contato@deliciasdahorta.com" },
                new Supplier { SupplierName = "Pão & Cia", SupplierAddress = "Rua do Trigo, 98", SupplierPhone = "917890123", SupplierEmail = "vendas@paoecompany.com" },
                new Supplier { SupplierName = "Café Saboroso", SupplierAddress = "Avenida do Café, 75", SupplierPhone = "918901234", SupplierEmail = "suporte@cafesaboroso.com" },
                new Supplier { SupplierName = "Azeite Real", SupplierAddress = "Rua do Azeite, 33", SupplierPhone = "919012345", SupplierEmail = "atendimento@azeite.com" },
                new Supplier { SupplierName = "Sabores do Campo", SupplierAddress = "Rua do Verde, 220", SupplierPhone = "920123456", SupplierEmail = "sac@saboresdocampo.com" },
                new Supplier { SupplierName = "Frutos do Brasil", SupplierAddress = "Avenida Brasil, 400", SupplierPhone = "921234567", SupplierEmail = "vendas@frutosdobrasil.com" },
                new Supplier { SupplierName = "Gourmet & Cia", SupplierAddress = "Rua Gourmet, 78", SupplierPhone = "922345678", SupplierEmail = "contato@gourmetecia.com" },
                new Supplier { SupplierName = "Hortaliças do Sertão", SupplierAddress = "Rua Sertão, 56", SupplierPhone = "923456789", SupplierEmail = "atendimento@hortalicasdosterao.com" },
                new Supplier { SupplierName = "Peixes & Frutos do Mar", SupplierAddress = "Rua do Mar, 110", SupplierPhone = "924567890", SupplierEmail = "vendas@peixesefrutosdomar.com" },
                new Supplier { SupplierName = "Cereais Premium", SupplierAddress = "Avenida dos Cereais, 150", SupplierPhone = "925678901", SupplierEmail = "suporte@cereaispremium.com" },
                new Supplier { SupplierName = "Vinhos & Sabores", SupplierAddress = "Rua dos Vinhos, 90", SupplierPhone = "926789012", SupplierEmail = "vendas@vinhosesabores.com" },
                new Supplier { SupplierName = "Pescados da Costa", SupplierAddress = "Rua da Costa, 300", SupplierPhone = "927890123", SupplierEmail = "contato@pescadosdacosta.com" },
                new Supplier { SupplierName = "Fazenda Natural", SupplierAddress = "Rua da Fazenda, 200", SupplierPhone = "928901234", SupplierEmail = "atendimento@fazendanatural.com" },
                new Supplier { SupplierName = "Temperos & Sabor", SupplierAddress = "Avenida dos Temperos, 65", SupplierPhone = "929012345", SupplierEmail = "suporte@temperosesabor.com" },
                new Supplier { SupplierName = "Casa dos Doces", SupplierAddress = "Rua do Açúcar, 80", SupplierPhone = "930123456", SupplierEmail = "vendas@casadosdoces.com" },
                new Supplier { SupplierName = "Legumes & Hortas", SupplierAddress = "Rua do Legume, 120", SupplierPhone = "931234567", SupplierEmail = "contato@legumeshortas.com" }
            });
            db.SaveChanges();
        }
    }
}

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
            PopulateBuffet(db);
            PopulatePratoComposicao(db);
        }

        private static void PopulateIngredients(ReserveSystemContext db)
        {
            if (db.Ingredient.Any()) return;

            db.Ingredient.AddRange(new List<Ingredient>{
                new Ingredient { Name = "Tomates", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 10, QuantityAvailable = 50, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Ovos", UnityMeasure = "Unidade", UnityRecipe = "Unidade", StockMin = 30, QuantityAvailable = 120, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Cebolas", UnityMeasure = "kg", UnityRecipe = "Unidade", StockMin = 5, QuantityAvailable = 25, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Alho", UnityMeasure = "kg", UnityRecipe = "Unidade", StockMin = 3, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Batatas", UnityMeasure = "kg", UnityRecipe = "Unidade", StockMin = 20, QuantityAvailable = 60, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Arroz", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 15, QuantityAvailable = 45, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Massas", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 10, QuantityAvailable = 40, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Pão", UnityMeasure = "Unidade", UnityRecipe = "Unidade", StockMin = 20, QuantityAvailable = 80, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Leite", UnityMeasure = "litro", UnityRecipe = "ml", StockMin = 10, QuantityAvailable = 35, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Queijo", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 8, QuantityAvailable = 20, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Presunto", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 5, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Frango", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 12, QuantityAvailable = 25, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Carne de vaca", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 10, QuantityAvailable = 22, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Peixe", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 8, QuantityAvailable = 18, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Camarão", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 6, QuantityAvailable = 10, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Brócolos", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 4, QuantityAvailable = 12, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Cenoura", UnityMeasure = "kg", UnityRecipe = "Unidade", StockMin = 5, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Espinafre", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 3, QuantityAvailable = 9, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Alface", UnityMeasure = "kg", UnityRecipe = "Unidade", StockMin = 5, QuantityAvailable = 18, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Tomilho", UnityMeasure = "Unidade", UnityRecipe = "Unidade", StockMin = 5, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Manjericão", UnityMeasure = "Unidade", UnityRecipe = "Unidade", StockMin = 5, QuantityAvailable = 12, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Pimenta", UnityMeasure = "Unidade", UnityRecipe = "g", StockMin = 10, QuantityAvailable = 30, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Azeite", UnityMeasure = "litro", UnityRecipe = "ml", StockMin = 10, QuantityAvailable = 20, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Vinagre", UnityMeasure = "litro", UnityRecipe = "ml", StockMin = 5, QuantityAvailable = 10, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Mel", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 4, QuantityAvailable = 8, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Açúcar", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 12, QuantityAvailable = 35, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Sal", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 8, QuantityAvailable = 20, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Bicarbonato de sódio", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 3, QuantityAvailable = 8, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Farinha", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 10, QuantityAvailable = 25, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Chocolate", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 5, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Café", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 8, QuantityAvailable = 20, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Iogurte", UnityMeasure = "litro", UnityRecipe = "ml", StockMin = 5, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Manteiga", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 3, QuantityAvailable = 10, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Limões", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 4, QuantityAvailable = 12, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Maçãs", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 6, QuantityAvailable = 20, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Bananas", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 6, QuantityAvailable = 18, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Laranjas", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 7, QuantityAvailable = 21, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Peras", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 6, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Uvas", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 5, QuantityAvailable = 18, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Abacaxi", UnityMeasure = "Unidade", UnityRecipe = "g", StockMin = 3, QuantityAvailable = 9, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Morangos", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 4, QuantityAvailable = 10, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Kiwi", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 3, QuantityAvailable = 12, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Pêssego", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 4, QuantityAvailable = 15, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Melancia", UnityMeasure = "Unidade", UnityRecipe = "g", StockMin = 2, QuantityAvailable = 5, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Coco", UnityMeasure = "Unidade", UnityRecipe = "g", StockMin = 3, QuantityAvailable = 7, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Abóbora", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 5, QuantityAvailable = 20, LastModificationDate = DateTime.Now },
                new Ingredient { Name = "Berinjela", UnityMeasure = "kg", UnityRecipe = "g", StockMin = 4, QuantityAvailable = 16, LastModificationDate = DateTime.Now }
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
                new Prato { Nome = "Pavlova", Descricao = "Sobremesa de merengue com chantilly e frutas frescas.", Preco = 7.00M },
                new Prato { Nome = "Espetada Madeirense", Descricao = "Espetada de carne bovina temperada e assada na brasa.", Preco = 17.00M },
                new Prato { Nome = "Ceviche", Descricao = "Peixe marinado no limão com cebola roxa e coentro.", Preco = 12.50M },
                new Prato { Nome = "Paella Valenciana", Descricao = "Prato típico espanhol com arroz, frutos do mar e açafrão.", Preco = 19.00M },
                new Prato { Nome = "Ratatouille", Descricao = "Prato vegetariano com legumes assados em camadas.", Preco = 10.50M },
                new Prato { Nome = "Caril de Legumes", Descricao = "Curry de legumes variados com arroz basmati.", Preco = 9.80M },
                new Prato { Nome = "Cordeiro ao Vinho Tinto", Descricao = "Pernil de cordeiro cozido com vinho tinto e ervas.", Preco = 24.00M },
                new Prato { Nome = "Panqueca de Espinafre", Descricao = "Panqueca recheada com espinafre e queijo ricota.", Preco = 8.90M },
                new Prato { Nome = "Feijoada Brasileira", Descricao = "Prato típico com feijão preto, carnes e acompanhamentos.", Preco = 16.00M },
                new Prato { Nome = "Gnocchi ao Pesto", Descricao = "Nhoque de batata com molho de manjericão e parmesão.", Preco = 12.00M },
                new Prato { Nome = "Polenta Cremosa", Descricao = "Polenta cremosa com ragu de carne.", Preco = 11.50M },
                new Prato { Nome = "Moussaka", Descricao = "Prato grego com berinjela, carne e molho bechamel.", Preco = 13.50M },
                new Prato { Nome = "Quiche Lorraine", Descricao = "Quiche francesa com bacon e queijo.", Preco = 9.50M },
                new Prato { Nome = "Pad Thai", Descricao = "Macarrão tailandês com camarão, amendoim e molho agridoce.", Preco = 14.50M },
                new Prato { Nome = "Tagine de Frango", Descricao = "Prato marroquino de frango cozido com especiarias e legumes.", Preco = 15.50M },
                new Prato { Nome = "Calzone", Descricao = "Pizza fechada recheada com queijo, presunto e tomate.", Preco = 10.90M },
                new Prato { Nome = "Pato no Tucupi", Descricao = "Prato típico do Pará com pato e molho de tucupi.", Preco = 18.50M },
                new Prato { Nome = "Bobó de Camarão", Descricao = "Camarão cozido com mandioca, leite de coco e dendê.", Preco = 19.00M },
                new Prato { Nome = "Costelinha ao Barbecue", Descricao = "Costelinha de porco assada com molho barbecue.", Preco = 17.90M },
                new Prato { Nome = "Yakissoba de Frango", Descricao = "Macarrão oriental com frango e legumes.", Preco = 11.00M },
                new Prato { Nome = "Polvo à Lagareiro", Descricao = "Polvo assado com batatas ao murro e azeite.", Preco = 21.00M },
                new Prato { Nome = "Fajitas de Carne", Descricao = "Tiras de carne grelhada com pimentões e cebola.", Preco = 12.50M },
                new Prato { Nome = "Robalo ao Molho de Alcaparras", Descricao = "Filé de robalo grelhado com molho de alcaparras.", Preco = 20.50M },
                new Prato { Nome = "Tortellini ao Molho Alfredo", Descricao = "Massa recheada com molho cremoso de queijo.", Preco = 13.90M },
                new Prato { Nome = "Crepe de Nutella", Descricao = "Crepe recheado com creme de avelã e frutas frescas.", Preco = 7.50M },
                new Prato { Nome = "Brownie com Sorvete", Descricao = "Brownie de chocolate servido com sorvete de baunilha.", Preco = 8.00M },


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
        private static void PopulateBuffet(ReserveSystemContext db)
        {
            if (db.Buffet.Any()) return;

            db.Buffet.AddRange(new List<Buffet>{
                new Buffet { Nome = "Buffet Temático Asiático", Descricao = "Uma seleção de pratos autênticos da culinária asiática, incluindo sushi, noodles e dim sum.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet de Doces Gourmet", Descricao = "Uma variedade de doces sofisticados, incluindo macarons, tortas e mousses.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet de Comida Nordestina", Descricao = "Pratos tradicionais do Nordeste, como carne de sol, feijão verde e macaxeira.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet Vegano", Descricao = "Pratos 100% veganos, com ingredientes frescos e receitas criativas.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet de Sopas e Caldos", Descricao = "Uma seleção de sopas e caldos para aquecer, com opções vegetarianas e tradicionais.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet de Massas Artesanais", Descricao = "Massas preparadas artesanalmente com molhos variados, inspirados na culinária italiana.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet de Tapas Espanholas", Descricao = "Pequenos pratos típicos da Espanha, como tortillas, croquetes e pimentões recheados.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet de Carnes Premium", Descricao = "Carnes nobres grelhadas e assadas, com acompanhamentos especiais.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet Temático Francês", Descricao = "Pratos clássicos da culinária francesa, como quiches, ratatouille e sobremesas refinadas.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet Internacional", Descricao = "Pratos de diversas partes do mundo, ideal para quem gosta de explorar novos sabores.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet à Inglesa", Descricao = "Buffet à Inglesa: Uma refeição onde os pratos são servidos diretamente à mesa, promovendo praticidade e elegância.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet Pequeno Almoço", Descricao = "Este tipo de buffet é oferecido em refeições matinais, com uma variedade de pães, frutas, sucos e opções quentes.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet de Frutos do Mar", Descricao = "Este buffet é especializado em frutos do mar frescos, incluindo camarões, ostras e peixes variados.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet Vegetariano", Descricao = "Focado em pratos sem ingredientes de origem animal, com opções saudáveis e nutritivas.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet de Churrasco (BBQ)", Descricao = "Este buffet é centrado em carnes grelhadas e acompanhamentos típicos de churrasco.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet Temático Italiano", Descricao = "Um festival de sabores da culinária italiana, onde massas e pizzas são os protagonistas.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet Temático Mexicano", Descricao = "Uma explosão de cores e sabores inspirados na culinária mexicana, com tacos, guacamole e nachos.", Data = DateTime.Now },
                new Buffet { Nome = "Buffet Temático Mediterrâneo", Descricao = "Uma viagem aos sabores frescos e saudáveis do Mediterrâneo, com azeites, queijos e frutos do mar.", Data = DateTime.Now }
            });
            db.SaveChanges();
        }

        private static void PopulatePratoComposicao(ReserveSystemContext db)
        {
            if (db.ComposicaoPrato.Any()) return;

            var pratos = db.Prato.ToDictionary(p => p.Nome);
            var ingredientes = db.Ingredient.ToDictionary(i => i.Name);

            db.ComposicaoPrato.AddRange(new List<ComposicaoPrato>
        {
            new ComposicaoPrato { PratoID = pratos["Lasanha"].PratoId, IngredientID = ingredientes["Tomates"].IngredientID, IngredientQuantity = 200 },
            new ComposicaoPrato { PratoID = pratos["Lasanha"].PratoId, IngredientID = ingredientes["Queijo"].IngredientID, IngredientQuantity = 150 },
            new ComposicaoPrato { PratoID = pratos["Pizza Margherita"].PratoId, IngredientID = ingredientes["Tomates"].IngredientID, IngredientQuantity = 100 },
            new ComposicaoPrato { PratoID = pratos["Pizza Margherita"].PratoId, IngredientID = ingredientes["Queijo"].IngredientID, IngredientQuantity = 150 },
            new ComposicaoPrato { PratoID = pratos["Pizza Margherita"].PratoId, IngredientID = ingredientes["Manjericão"].IngredientID, IngredientQuantity = 5 },
            new ComposicaoPrato { PratoID = pratos["Risoto de Camarão"].PratoId, IngredientID = ingredientes["Camarão"].IngredientID, IngredientQuantity = 200 },
            new ComposicaoPrato { PratoID = pratos["Risoto de Camarão"].PratoId, IngredientID = ingredientes["Arroz"].IngredientID, IngredientQuantity = 150 },
            new ComposicaoPrato { PratoID = pratos["Risoto de Camarão"].PratoId, IngredientID = ingredientes["Alho"].IngredientID, IngredientQuantity = 10 },
        });

            db.SaveChanges();
        }
    }
}

using ReserveSystem.Data;

namespace ReserveSystem.Models
{
    internal class SeedDataCliente
    {
        internal static void Populate(ReserveSystemContext? db)
        {
            if (db == null)
                return;

            db.Database.EnsureCreated();

            PopulateCliente(db);
        }

        private static void PopulateCliente(ReserveSystemContext db)
        {
            if (db.Cliente.Any()) return;
            db.Cliente.AddRange(
                new List<ClienteModel>
                {
                new ClienteModel { Nome = "Ana Silva", Email = "ana.silva@example.com", Telefone = "+351912345678", Login = true, Nif = "123456789" },
                new ClienteModel { Nome = "Bruno Costa", Email = "bruno.costa@example.com", Telefone = "+351922345678", Login = false, Nif = "234567890" },
                new ClienteModel { Nome = "Carla Sousa", Email = "carla.sousa@example.com", Telefone = "+351932345678", Login = true, Nif = "345678901" },
                new ClienteModel { Nome = "Daniel Rocha", Email = "daniel.rocha@example.com", Telefone = "+351942345678", Login = false, Nif = "456789012" },
                new ClienteModel { Nome = "Elisa Mendes", Email = "elisa.mendes@example.com", Telefone = "+351952345678", Login = true, Nif = "567890123" },
                new ClienteModel { Nome = "Fábio Silva", Email = "fabio.silva@example.com", Telefone = "+351962345678", Login = false, Nif = "678901234" },
                new ClienteModel { Nome = "Gabriela Torres", Email = "gabriela.torres@example.com", Telefone = "+351972345678", Login = true, Nif = "789012345" },
                new ClienteModel { Nome = "Henrique Lima", Email = "henrique.lima@example.com", Telefone = "+351982345678", Login = false, Nif = "890123456" },
                new ClienteModel { Nome = "Inês Carvalho", Email = "ines.carvalho@example.com", Telefone = "+351992345678", Login = true, Nif = "901234567" },
                new ClienteModel { Nome = "João Almeida", Email = "joao.almeida@example.com", Telefone = "+351912345679", Login = false, Nif = "012345678" },
                new ClienteModel { Nome = "Karina Matos", Email = "karina.matos@example.com", Telefone = "+351922345679", Login = true, Nif = "123450987" },
                new ClienteModel { Nome = "Lucas Pereira", Email = "lucas.pereira@example.com", Telefone = "+351932345679", Login = false, Nif = "234560876" },
                new ClienteModel { Nome = "Marta Fernandes", Email = "marta.fernandes@example.com", Telefone = "+351942345679", Login = true, Nif = "345670765" },
                new ClienteModel { Nome = "Nelson Ribeiro", Email = "nelson.ribeiro@example.com", Telefone = "+351952345679", Login = false, Nif = "456780654" },
                new ClienteModel { Nome = "Olivia Cardoso", Email = "olivia.cardoso@example.com", Telefone = "+351962345679", Login = true, Nif = "567890543" },
                new ClienteModel { Nome = "Pedro Santos", Email = "pedro.santos@example.com", Telefone = "+351972345679", Login = false, Nif = "678900432" },
                new ClienteModel { Nome = "Quinta Oliveira", Email = "quinta.oliveira@example.com", Telefone = "+351982345679", Login = true, Nif = "789010321" },
                new ClienteModel { Nome = "Ricardo Lopes", Email = "ricardo.lopes@example.com", Telefone = "+351992345679", Login = false, Nif = "890120210" },
                new ClienteModel { Nome = "Sofia Correia", Email = "sofia.correia@example.com", Telefone = "+351912345680", Login = true, Nif = "901230109" },
                new ClienteModel { Nome = "Tomás Ferreira", Email = "tomas.ferreira@example.com", Telefone = "+351922345680", Login = false, Nif = "012340098" }
                }
                );
            db.SaveChanges();
        }
    }
}

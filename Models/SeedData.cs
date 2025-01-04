using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;

namespace ReserveSystem.Models
{
    public class SeedData
    {
        internal static void Populate(ReserveSystemContext? reserveSystemContext)
        {
            if (reserveSystemContext == null) return;
            reserveSystemContext.Database.EnsureCreated();

            PopulateClient(reserveSystemContext);
        }

        private static void PopulateClient(ReserveSystemContext reserveSystemContext)
        {
            if (reserveSystemContext.ClientModel.Any()) return;
            reserveSystemContext.ClientModel.AddRange(
                new List<ClientModel>
                {
                    new ClientModel {NomeCliente = "João Silva", MoradaCliente = "Rua das Flores, 123", Email = "joao.silva@example.com", Password = "senha123", Telefone = "912345678", NIF = 123456789 },
                    new ClientModel {NomeCliente = "Maria Oliveira", MoradaCliente = "Avenida Central, 456", Email = "maria.oliveira@example.com", Password = "senha456", Telefone = "923456789", NIF = 234567890 },
                    new ClientModel{NomeCliente = "Carlos Souza", MoradaCliente = "Praça da Liberdade, 789", Email = "carlos.souza@example.com", Password = "senha789", Telefone = "934567890", NIF = 345678901 },
                    new ClientModel {NomeCliente = "Ana Santos", MoradaCliente = "Rua das Palmeiras, 101", Email = "ana.santos@example.com", Password = "senha101", Telefone = "945678901", NIF = 456789012 },
                    new ClientModel {NomeCliente = "Pedro Lima", MoradaCliente = "Estrada Velha, 202", Email = "pedro.lima@example.com", Password = "senha202", Telefone = "956789012", NIF = 567890123 },
                    new ClientModel {NomeCliente = "Fernanda Costa", MoradaCliente = "Travessa do Sol, 303", Email = "fernanda.costa@example.com", Password = "senha303", Telefone = "967890123", NIF = 678901234 },
                    new ClientModel {NomeCliente = "Rafael Nascimento", MoradaCliente = "Largo do Mercado, 404", Email = "rafael.nascimento@example.com", Password = "senha404", Telefone = "978901234", NIF = 789012345 },
                    new ClientModel {NomeCliente = "Juliana Alves", MoradaCliente = "Bairro da Paz, 505", Email = "juliana.alves@example.com", Password = "senha505", Telefone = "989012345", NIF = 890123456 },
                    new ClientModel {NomeCliente = "Bruno Pereira", MoradaCliente = "Rua Nova, 606", Email = "bruno.pereira@example.com", Password = "senha606", Telefone = "991234567", NIF = 901234567 },
                    new ClientModel {NomeCliente = "Patrícia Fernandes", MoradaCliente = "Vila Bela, 707", Email = "patricia.fernandes@example.com", Password = "senha707", Telefone = "992345678", NIF = 012345678 }
                }
                );           
            reserveSystemContext.SaveChanges();
        }
    }
}

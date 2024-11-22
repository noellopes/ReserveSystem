using System;
using System.Linq;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ReserveSystemContext context)
        {
            // Verifica se o banco de dados já existe
            context.Database.EnsureCreated();

            // Se já há dados no banco, não faz nada
            if (context.Clients.Any()) return;

            // Criação de dados iniciais (seed data)
            var clients = new[]
            {
                    new Client { ClientName = "João Silva", ClientEmail = "joao1@example.com", ClientAddress = "Rua 1", ClientNIF = "123456781", ClientStatus = true, ClientLogin = false, ClientPhone = "912345678" },
                    new Client { ClientName = "Maria Santos", ClientEmail = "maria2@example.com", ClientAddress = "Rua 2", ClientNIF = "123456782", ClientStatus = false, ClientLogin = true, ClientPhone = "912345679" },
                    new Client { ClientName = "Carlos Ferreira", ClientEmail = "carlos3@example.com", ClientAddress = "Rua 3", ClientNIF = "123456783", ClientStatus = true, ClientLogin = true, ClientPhone = "912345680" },
                    new Client { ClientName = "Ana Pereira", ClientEmail = "ana4@example.com", ClientAddress = "Rua 4", ClientNIF = "123456784", ClientStatus = false, ClientLogin = false, ClientPhone = "912345681" },
                    new Client { ClientName = "Pedro Rocha", ClientEmail = "pedro5@example.com", ClientAddress = "Rua 5", ClientNIF = "123456785", ClientStatus = true, ClientLogin = true, ClientPhone = "912345682" },
                    new Client { ClientName = "Sofia Costa", ClientEmail = "sofia6@example.com", ClientAddress = "Rua 6", ClientNIF = "123456786", ClientStatus = false, ClientLogin = true, ClientPhone = "912345683" },
                    new Client { ClientName = "Miguel Sousa", ClientEmail = "miguel7@example.com", ClientAddress = "Rua 7", ClientNIF = "123456787", ClientStatus = true, ClientLogin = false, ClientPhone = "912345684" },
                    new Client { ClientName = "Rita Oliveira", ClientEmail = "rita8@example.com", ClientAddress = "Rua 8", ClientNIF = "123456788", ClientStatus = false, ClientLogin = true, ClientPhone = "912345685" },
                    new Client { ClientName = "Luís Martins", ClientEmail = "luis9@example.com", ClientAddress = "Rua 9", ClientNIF = "123456789", ClientStatus = true, ClientLogin = false, ClientPhone = "912345686" },
                    new Client { ClientName = "Carla Almeida", ClientEmail = "carla10@example.com", ClientAddress = "Rua 10", ClientNIF = "123456790", ClientStatus = true, ClientLogin = true, ClientPhone = "912345687" },
                    new Client { ClientName = "André Lima", ClientEmail = "andre11@example.com", ClientAddress = "Rua 11", ClientNIF = "123456791", ClientStatus = true, ClientLogin = false, ClientPhone = "912345688" },
                    new Client { ClientName = "Paula Ferreira", ClientEmail = "paula12@example.com", ClientAddress = "Rua 12", ClientNIF = "123456792", ClientStatus = false, ClientLogin = true, ClientPhone = "912345689" },
                    new Client { ClientName = "Fernando Rocha", ClientEmail = "fernando13@example.com", ClientAddress = "Rua 13", ClientNIF = "123456793", ClientStatus = true, ClientLogin = false, ClientPhone = "912345690" },
                    new Client { ClientName = "Beatriz Costa", ClientEmail = "beatriz14@example.com", ClientAddress = "Rua 14", ClientNIF = "123456794", ClientStatus = false, ClientLogin = true, ClientPhone = "912345691" },
                    new Client { ClientName = "Gustavo Pinto", ClientEmail = "gustavo15@example.com", ClientAddress = "Rua 15", ClientNIF = "123456795", ClientStatus = true, ClientLogin = true, ClientPhone = "912345692" },
                    new Client { ClientName = "Juliana Silva", ClientEmail = "juliana16@example.com", ClientAddress = "Rua 16", ClientNIF = "123456796", ClientStatus = false, ClientLogin = false, ClientPhone = "912345693" },
                    new Client { ClientName = "Ricardo Alves", ClientEmail = "ricardo17@example.com", ClientAddress = "Rua 17", ClientNIF = "123456797", ClientStatus = true, ClientLogin = false, ClientPhone = "912345694" },
                    new Client { ClientName = "Cláudia Martins", ClientEmail = "claudia18@example.com", ClientAddress = "Rua 18", ClientNIF = "123456798", ClientStatus = false, ClientLogin = true, ClientPhone = "912345695" },
                    new Client { ClientName = "Fábio Pinto", ClientEmail = "fabio19@example.com", ClientAddress = "Rua 19", ClientNIF = "123456799", ClientStatus = true, ClientLogin = true, ClientPhone = "912345696" },
                    new Client { ClientName = "Isabela Costa", ClientEmail = "isabela20@example.com", ClientAddress = "Rua 20", ClientNIF = "123456800", ClientStatus = false, ClientLogin = true, ClientPhone = "912345697" }

            };

            // Adiciona os clientes ao banco de dados
            context.Clients.AddRange(clients);

            // Salva as alterações no banco
            context.SaveChanges();
        }
    }
}




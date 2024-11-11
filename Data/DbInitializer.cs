using ReserveSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReserveSystem.Data
{
    internal class DbInitializer
    {
        internal static void Initialize(ReserveSystemUsersDbContext db)
        {
            // Verifica se o contexto é nulo
            if (db == null) return;

            // Assegura que o banco de dados foi criado
            db.Database.EnsureCreated();

            // Chama o método para popular os clientes
            PopulateClients(db);
        }

        private static void PopulateClients(ReserveSystemUsersDbContext db)
        {
            // Verifica se já existem clientes na base de dados
            if (db.Cliente.Any()) return;

            // Adiciona uma lista de clientes à base de dados
            db.Cliente.AddRange(
                new List<Cliente>
                {
                    new Cliente { Nome = "João Silva", Email = "joao1@example.com", Morada = "Rua 1", NIF = "123456781", DataNascimento = new DateTime(1990, 1, 1) },
                    new Cliente { Nome = "Maria Santos", Email = "maria2@example.com", Morada = "Rua 2", NIF = "123456782", DataNascimento = new DateTime(1992, 2, 2) },
                    new Cliente { Nome = "Carlos Ferreira", Email = "carlos3@example.com", Morada = "Rua 3", NIF = "123456783", DataNascimento = new DateTime(1988, 3, 3) },
                    new Cliente { Nome = "Ana Pereira", Email = "ana4@example.com", Morada = "Rua 4", NIF = "123456784", DataNascimento = new DateTime(1985, 4, 4) },
                    new Cliente { Nome = "Pedro Rocha", Email = "pedro5@example.com", Morada = "Rua 5", NIF = "123456785", DataNascimento = new DateTime(1993, 5, 5) },
                    new Cliente { Nome = "Sofia Costa", Email = "sofia6@example.com", Morada = "Rua 6", NIF = "123456786", DataNascimento = new DateTime(1989, 6, 6) },
                    new Cliente { Nome = "Miguel Sousa", Email = "miguel7@example.com", Morada = "Rua 7", NIF = "123456787", DataNascimento = new DateTime(1991, 7, 7) },
                    new Cliente { Nome = "Rita Oliveira", Email = "rita8@example.com", Morada = "Rua 8", NIF = "123456788", DataNascimento = new DateTime(1994, 8, 8) },
                    new Cliente { Nome = "Luís Martins", Email = "luis9@example.com", Morada = "Rua 9", NIF = "123456789", DataNascimento = new DateTime(1987, 9, 9) },
                    new Cliente { Nome = "Carla Almeida", Email = "carla10@example.com", Morada = "Rua 10", NIF = "123456790", DataNascimento = new DateTime(1995, 10, 10) },
                    new Cliente { Nome = "André Lima", Email = "andre11@example.com", Morada = "Rua 11", NIF = "123456791", DataNascimento = new DateTime(1986, 11, 11) },
                    new Cliente { Nome = "Paula Ferreira", Email = "paula12@example.com", Morada = "Rua 12", NIF = "123456792", DataNascimento = new DateTime(1990, 12, 12) },
                    new Cliente { Nome = "Fernando Rocha", Email = "fernando13@example.com", Morada = "Rua 13", NIF = "123456793", DataNascimento = new DateTime(1992, 1, 13) },
                    new Cliente { Nome = "Beatriz Costa", Email = "beatriz14@example.com", Morada = "Rua 14", NIF = "123456794", DataNascimento = new DateTime(1989, 2, 14) },
                    new Cliente { Nome = "Gustavo Pinto", Email = "gustavo15@example.com", Morada = "Rua 15", NIF = "123456795", DataNascimento = new DateTime(1993, 3, 15) },
                    new Cliente { Nome = "Juliana Silva", Email = "juliana16@example.com", Morada = "Rua 16", NIF = "123456796", DataNascimento = new DateTime(1994, 4, 16) },
                    new Cliente { Nome = "Ricardo Alves", Email = "ricardo17@example.com", Morada = "Rua 17", NIF = "123456797", DataNascimento = new DateTime(1987, 5, 17) },
                    new Cliente { Nome = "Cláudia Martins", Email = "claudia18@example.com", Morada = "Rua 18", NIF = "123456798", DataNascimento = new DateTime(1995, 6, 18) },
                    new Cliente { Nome = "Fábio Pinto", Email = "fabio19@example.com", Morada = "Rua 19", NIF = "123456799", DataNascimento = new DateTime(1988, 7, 19) },
                    new Cliente { Nome = "Isabela Costa", Email = "isabela20@example.com", Morada = "Rua 20", NIF = "123456800", DataNascimento = new DateTime(1991, 8, 20) }
                });

            // Salva as alterações no banco de dados
            db.SaveChanges();
        }
    }
}

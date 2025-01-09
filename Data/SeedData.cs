using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ReserveSystem.Data
{
    public static class SeedData
    {
        internal static async Task PopulateAsync(ReserveSystemContext? db, RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            if (db == null) return;
            await db.Database.EnsureCreatedAsync();
            await SeedRolesAndUsersAsync(roleManager, userManager);
            await SeedTipoEquipamentoAsync(db);
            await SeedEquipamentoAsync(db);
            await SeedTipoReservaAsync(db);
            await SeedClientModelAsync(db);
            await SeedTipoSalaAsync(db);
            await SeedSalaAsync(db);
            await SeedReservaAsync(db);
        }

        private static async Task SeedRolesAndUsersAsync(RoleManager<IdentityRole> roleManager,
            UserManager<IdentityUser> userManager)
        {
            var roles = new[] { "Reservationist", "Manager", "Client" };

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            await EnsureUserWithRoleAsync(userManager, "manager@example.com", "Manager@123", "Manager");

            await EnsureUserWithRoleAsync(userManager, "reservationist@example.com", "Reservationist@123",
                "Reservationist");

            await EnsureUserWithRoleAsync(userManager, "client@example.com", "Client@123", "Client");
        }

        private static async Task EnsureUserWithRoleAsync(UserManager<IdentityUser> userManager, string email,
            string password, string role)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new IdentityUser { UserName = email, Email = email, EmailConfirmed = true };
                await userManager.CreateAsync(user, password);
            }

            if (!await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
            }
        }

        private static async Task SeedTipoEquipamentoAsync(ReserveSystemContext context)
        {
            if (await context.TipoEquipamento.AnyAsync()) return;

            var equipmentTypes = new[]
            {
                    new TipoEquipamento { NomeTipoEquipamento = "Electronic" },
                    new TipoEquipamento { NomeTipoEquipamento = "Furniture" },
                    new TipoEquipamento { NomeTipoEquipamento = "Lighting" },
                    new TipoEquipamento { NomeTipoEquipamento = "Kitchen Equipment" },
                    new TipoEquipamento { NomeTipoEquipamento = "Accessories" }
                };

            await context.TipoEquipamento.AddRangeAsync(equipmentTypes);
            await context.SaveChangesAsync();
        }

        private static async Task SeedEquipamentoAsync(ReserveSystemContext context)
        {
            if (await context.Equipamento.AnyAsync()) return;

            var equipment = new[]
            {
                new Equipamento { NomeEquipamento = "Projector", IdTipoEquipamento = 1, Quantidade = 3 },
                new Equipamento { NomeEquipamento = "Sound System", IdTipoEquipamento = 1, Quantidade = 8 },
                new Equipamento { NomeEquipamento = "Microphone", IdTipoEquipamento = 1, Quantidade = 30 },
                new Equipamento { NomeEquipamento = "Whiteboard", IdTipoEquipamento = 2, Quantidade = 7 },
                new Equipamento { NomeEquipamento = "Conference Table", IdTipoEquipamento = 2, Quantidade = 10 },
                new Equipamento { NomeEquipamento = "Chairs", IdTipoEquipamento = 2, Quantidade = 500 },
                new Equipamento { NomeEquipamento = "Podium", IdTipoEquipamento = 2, Quantidade = 5 },
                new Equipamento { NomeEquipamento = "Video Conferencing System", IdTipoEquipamento = 1, Quantidade = 2 },
                new Equipamento { NomeEquipamento = "Stage Lighting", IdTipoEquipamento = 3, Quantidade = 10 },
                new Equipamento { NomeEquipamento = "Sound Mixer", IdTipoEquipamento = 1, Quantidade = 1 },
                new Equipamento { NomeEquipamento = "Projection Screen", IdTipoEquipamento = 2, Quantidade = 5 },
                new Equipamento { NomeEquipamento = "Flipcharts", IdTipoEquipamento = 2, Quantidade = 4 },
                new Equipamento { NomeEquipamento = "Wi-Fi Router", IdTipoEquipamento = 1, Quantidade = 5 },
                new Equipamento { NomeEquipamento = "Laptop", IdTipoEquipamento = 1, Quantidade = 10 },
                new Equipamento { NomeEquipamento = "Power Strips", IdTipoEquipamento = 5, Quantidade = 10 },
                new Equipamento { NomeEquipamento = "HDMI Cables", IdTipoEquipamento = 5, Quantidade = 13 },
                new Equipamento { NomeEquipamento = "Portable Speaker", IdTipoEquipamento = 1, Quantidade = 3 },
                new Equipamento { NomeEquipamento = "Laser Pointer", IdTipoEquipamento = 5, Quantidade = 5 },
                new Equipamento { NomeEquipamento = "Coffee Maker", IdTipoEquipamento = 4, Quantidade = 11 },
                new Equipamento { NomeEquipamento = "Thermos", IdTipoEquipamento = 4, Quantidade = 5 }
            };

            await context.Equipamento.AddRangeAsync(equipment);
            await context.SaveChangesAsync();
        }

        private static async Task SeedTipoReservaAsync(ReserveSystemContext context)
        {
            if (await context.TipoReserva.AnyAsync()) return;

            var tipoReservas = new[]
            {
                    new TipoReserva { NomeReserva = "Conference" },
                    new TipoReserva { NomeReserva = "Meeting" },
                    new TipoReserva { NomeReserva = "Workshop" },
                    new TipoReserva { NomeReserva = "Seminar" },
                    new TipoReserva { NomeReserva = "Training" }
                };

            await context.TipoReserva.AddRangeAsync(tipoReservas);
            await context.SaveChangesAsync();
        }

        private static async Task SeedClientModelAsync(ReserveSystemContext context)
        {
            if (await context.ClientModel.AnyAsync()) return;

            var clients = new[]
            {
                new ClientModel
                {
                    NomeCliente = "John Doe", MoradaCliente = "123 Main St", Email = "john.doe@example.com",
                    Password = "password", Telefone = "1234567890", NIF = 123456789
                },
                new ClientModel
                {
                    NomeCliente = "Jane Smith", MoradaCliente = "456 Elm St", Email = "jane.smith@example.com",
                    Password = "password", Telefone = "0987654321", NIF = 987654321
                },
                new ClientModel
                {
                    NomeCliente = "João Silva", MoradaCliente = "Rua das Flores, 123", Email = "joao.silva@example.com",
                    Password = "senha123", Telefone = "912345678", NIF = 123456789
                },
                new ClientModel
                {
                    NomeCliente = "Maria Oliveira", MoradaCliente = "Avenida Central, 456",
                    Email = "maria.oliveira@example.com", Password = "senha456", Telefone = "923456789", NIF = 234567890
                },
                new ClientModel
                {
                    NomeCliente = "Carlos Souza", MoradaCliente = "Praça da Liberdade, 789",
                    Email = "carlos.souza@example.com", Password = "senha789", Telefone = "934567890", NIF = 345678901
                },
                new ClientModel
                {
                    NomeCliente = "Ana Santos", MoradaCliente = "Rua das Palmeiras, 101",
                    Email = "ana.santos@example.com", Password = "senha101", Telefone = "945678901", NIF = 456789012
                },
                new ClientModel
                {
                    NomeCliente = "Pedro Lima", MoradaCliente = "Estrada Velha, 202", Email = "pedro.lima@example.com",
                    Password = "senha202", Telefone = "956789012", NIF = 567890123
                },
                new ClientModel
                {
                    NomeCliente = "Fernanda Costa", MoradaCliente = "Travessa do Sol, 303",
                    Email = "fernanda.costa@example.com", Password = "senha303", Telefone = "967890123", NIF = 678901234
                },
                new ClientModel
                {
                    NomeCliente = "Rafael Nascimento", MoradaCliente = "Largo do Mercado, 404",
                    Email = "rafael.nascimento@example.com", Password = "senha404", Telefone = "978901234",
                    NIF = 789012345
                },
                new ClientModel
                {
                    NomeCliente = "Juliana Alves", MoradaCliente = "Bairro da Paz, 505",
                    Email = "juliana.alves@example.com", Password = "senha505", Telefone = "989012345", NIF = 890123456
                },
                new ClientModel
                {
                    NomeCliente = "Bruno Pereira", MoradaCliente = "Rua Nova, 606", Email = "bruno.pereira@example.com",
                    Password = "senha606", Telefone = "991234567", NIF = 901234567
                },
                new ClientModel
                {
                    NomeCliente = "Patrícia Fernandes", MoradaCliente = "Vila Bela, 707",
                    Email = "patricia.fernandes@example.com", Password = "senha707", Telefone = "992345678",
                    NIF = 012345678
                }
            };

            await context.ClientModel.AddRangeAsync(clients);
            await context.SaveChangesAsync();
        }

        private static async Task SeedTipoSalaAsync(ReserveSystemContext context)
        {
            if (await context.TipoSala.AnyAsync()) return;

            var tipoSalas = new[]
            {
                new TipoSala { NomeSala = "Conference Room", TamanhoSala = 50, Capacidade = 25, PreçoHora = 120 },
                new TipoSala { NomeSala = "Training Room", TamanhoSala = 40, Capacidade = 20, PreçoHora = 100 },
                new TipoSala { NomeSala = "Meeting Room", TamanhoSala = 30, Capacidade = 15, PreçoHora = 80 },
                new TipoSala { NomeSala = "Seminar Hall", TamanhoSala = 100, Capacidade = 50, PreçoHora = 200 },
                new TipoSala { NomeSala = "Boardroom", TamanhoSala = 60, Capacidade = 30, PreçoHora = 150 },
                new TipoSala { NomeSala = "Classroom", TamanhoSala = 45, Capacidade = 22, PreçoHora = 90 },
                new TipoSala { NomeSala = "Event Hall", TamanhoSala = 120, Capacidade = 60, PreçoHora = 300 },
                new TipoSala { NomeSala = "Coworking Space", TamanhoSala = 35, Capacidade = 10, PreçoHora = 70 },
                new TipoSala { NomeSala = "Private Office", TamanhoSala = 20, Capacidade = 5, PreçoHora = 50 },
                new TipoSala { NomeSala = "Open Space", TamanhoSala = 80, Capacidade = 40, PreçoHora = 180 }
            };

            await context.TipoSala.AddRangeAsync(tipoSalas);
            await context.SaveChangesAsync();
        }

        private static async Task SeedSalaAsync(ReserveSystemContext context)
        {
            if (await context.Sala.AnyAsync()) return;

            var salas = new HashSet<Sala>();
            var random = new Random();
            var horaInicio = new TimeOnly(8, 0);

            while (salas.Count < 100)
            {
                int floor = random.Next(1, 6);

                int roomNumber = floor * 100 + random.Next(1, 10) * 10 + random.Next(0, 10);

                var newSala = new Sala
                {
                    IdTipoSala = random.Next(1, 11),
                    TempoPreparação = TimeSpan.FromMinutes(random.Next(15, 61)),
                    HoraInicio = horaInicio,
                    HoraFim = horaInicio.AddHours(random.Next(8, 11)),
                    Floor = floor,
                    RoomNumber = roomNumber
                };

                if (!salas.Any(s => s.Floor == newSala.Floor && s.RoomNumber == newSala.RoomNumber))
                {
                    salas.Add(newSala);
                }
            }

            await context.Sala.AddRangeAsync(salas);
            await context.SaveChangesAsync();
        }


        private static async Task SeedReservaAsync(ReserveSystemContext context)
        {
            if (await context.Reserva.AnyAsync()) return;

            var reservas = new[]
            {
                    new Reserva { DataReserva = DateTime.Now, DataInicio = DateTime.Now.AddDays(1), DataFim = DateTime.Now.AddDays(1).AddHours(2), TotalParticipantes = 10, PrecoTotal = 100, Estado = "Pending", DataEstado = DateTime.Now, IdTipoReserva = 1, NumeroCliente = 1 },
                    new Reserva { DataReserva = DateTime.Now, DataInicio = DateTime.Now.AddDays(2), DataFim = DateTime.Now.AddDays(2).AddHours(3), TotalParticipantes = 20, PrecoTotal = 200, Estado = "Pending", DataEstado = DateTime.Now, IdTipoReserva = 2, NumeroCliente = 2 }
                };

            await context.Reserva.AddRangeAsync(reservas);
            await context.SaveChangesAsync();
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReserveSystem.Data;
using ReserveSystem.Models;
using System;
using System.Linq;

namespace ReserveSystem.Models
{
    public static class SeedData
    {
        internal static void Populate(ReserveSystemContext? db) {
            if (db == null) return;
            db.Database.EnsureCreated();

            PopulateCliente(db);
            PopulateRoom(db);
        }

        internal static void PopulateUsers(UserManager<IdentityUser> userManager) {
            EnsureUserIsCreatedAsync(userManager, "john@ipg.pt", "Secret$123", "client").Wait();
        }

        internal static void PopulateDefaultAdmin(UserManager<IdentityUser> userManager) {
            EnsureUserIsCreatedAsync(userManager, "admin@ipg.pt", "Secret$123", "admin").Wait();
        }

        private static async Task EnsureUserIsCreatedAsync(UserManager<IdentityUser> userManager, string username, string password, string roleName) {
            var user = await userManager.FindByNameAsync(username);

            if (user == null) {
                user = new IdentityUser(username);
                await userManager.CreateAsync(user, password);
            }

            if (user != null) {
                var isInRole = await userManager.IsInRoleAsync(user, roleName);
                if (!isInRole) {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

        internal static void PopulateRoles(RoleManager<IdentityRole> roleManager) {
            EnsureRoleIsCreatedAsync(roleManager, "admin").Wait();
            EnsureRoleIsCreatedAsync(roleManager, "client").Wait();

            // ...
        }

        private static async Task EnsureRoleIsCreatedAsync(RoleManager<IdentityRole> roleManager, string roleName) {
            var role = await roleManager.FindByNameAsync(roleName);

            if (role == null) {
                role = new IdentityRole(roleName);
                await roleManager.CreateAsync(role);
            }
        }

        private static void PopulateCliente(ReserveSystemContext db)
        {
            if (db.Client.Any()) return;
            db.Client.AddRange(
                new List<ClientModel>
                {
                    new ClientModel { Name = "Ana Silva", Phone = "+351912345678", Address = "Rua da Alegria, 123", Email = "ana.silva@example.com", Identification = "123456789", Password = "Password123" },
                    new ClientModel { Name = "Bruno Costa", Phone = "+351922345678", Address = "Avenida da Liberdade, 456", Email = "bruno.costa@example.com", Identification = "234567890", Password = "Password123" },
                    new ClientModel { Name = "Carla Sousa", Phone = "+351932345678", Address = "Praça do Comércio, 789", Email = "carla.sousa@example.com", Identification = "345678901", Password = "Password123" },
                    new ClientModel { Name = "Daniel Rocha", Phone = "+351942345678", Address = "Rua da Sé, 101", Email = "daniel.rocha@example.com", Identification = "456789012", Password = "Password123" },
                    new ClientModel { Name = "Elisa Mendes", Phone = "+351952345678", Address = "Rua São João, 202", Email = "elisa.mendes@example.com", Identification = "567890123", Password = "Password123" },
                    new ClientModel { Name = "Fábio Silva", Phone = "+351962345678", Address = "Avenida do Mar, 303", Email = "fabio.silva@example.com", Identification = "678901234", Password = "Password123" },
                    new ClientModel { Name = "Gabriela Torres", Phone = "+351972345678", Address = "Rua das Flores, 404", Email = "gabriela.torres@example.com", Identification = "789012345", Password = "Password123" },
                    new ClientModel { Name = "Henrique Lima", Phone = "+351982345678", Address = "Rua da Liberdade, 505", Email = "henrique.lima@example.com", Identification = "890123456", Password = "Password123" },
                    new ClientModel { Name = "Inês Carvalho", Phone = "+351992345678", Address = "Praça da República, 606", Email = "ines.carvalho@example.com", Identification = "901234567", Password = "Password123" },
                    new ClientModel { Name = "João Almeida", Phone = "+351912345679", Address = "Rua do Porto, 707", Email = "joao.almeida@example.com", Identification = "012345678", Password = "Password123" },
                    new ClientModel { Name = "Karina Matos", Phone = "+351922345679", Address = "Rua das Margaridas, 808", Email = "karina.matos@example.com", Identification = "123450987", Password = "Password123" },
                    new ClientModel { Name = "Lucas Pereira", Phone = "+351932345679", Address = "Avenida das Américas, 909", Email = "lucas.pereira@example.com", Identification = "234560876", Password = "Password123" },
                    new ClientModel { Name = "Marta Fernandes", Phone = "+351942345679", Address = "Rua do Sol, 1010", Email = "marta.fernandes@example.com", Identification = "345670765", Password = "Password123" },
                    new ClientModel { Name = "Nelson Ribeiro", Phone = "+351952345679", Address = "Avenida Beira Mar, 1111", Email = "nelson.ribeiro@example.com", Identification = "456780654", Password = "Password123" },
                    new ClientModel { Name = "Olivia Cardoso", Phone = "+351962345679", Address = "Rua do Norte, 1212", Email = "olivia.cardoso@example.com", Identification = "567890543", Password = "Password123" },
                    new ClientModel { Name = "Pedro Santos", Phone = "+351972345679", Address = "Avenida Central, 1313", Email = "pedro.santos@example.com", Identification = "678900432", Password = "Password123" },
                    new ClientModel { Name = "Quinta Oliveira", Phone = "+351982345679", Address = "Rua da Paz, 1414", Email = "quinta.oliveira@example.com", Identification = "789010321", Password = "Password123" },
                    new ClientModel { Name = "Ricardo Lopes", Phone = "+351992345679", Address = "Praça do Carmo, 1515", Email = "ricardo.lopes@example.com", Identification = "890120210", Password = "Password123" },
                    new ClientModel { Name = "Sofia Correia", Phone = "+351912345680", Address = "Rua das Acácias, 1616", Email = "sofia.correia@example.com", Identification = "901230109", Password = "Password123" },
                    new ClientModel { Name = "Tomás Ferreira", Phone = "+351922345680", Address = "Avenida das Palmeiras, 1717", Email = "tomas.ferreira@example.com", Identification = "012340098", Password = "Password123" }
                }
                );
            db.SaveChanges();
        }

        private static void PopulateRoom(ReserveSystemContext db)
        {
            // Verificar se já existem quartos na base de dados
            if (db.Room.Any()) return;

            db.Room.AddRange(
                new List<RoomModel>
                {
            new RoomModel { RoomType = "Standard", Capacity = 2, NumberOfRooms = 10, HasView = true, AdaptedRoom = false },
            new RoomModel { RoomType = "Standard", Capacity = 2, NumberOfRooms = 8, HasView = false, AdaptedRoom = true },
            new RoomModel { RoomType = "Suite", Capacity = 4, NumberOfRooms = 7, HasView = true, AdaptedRoom = false },
            new RoomModel { RoomType = "Suite", Capacity = 4, NumberOfRooms = 5, HasView = false, AdaptedRoom = true },
            new RoomModel { RoomType = "Deluxe", Capacity = 3, NumberOfRooms = 6, HasView = true, AdaptedRoom = true },
            new RoomModel { RoomType = "Deluxe", Capacity = 3, NumberOfRooms = 8, HasView = false, AdaptedRoom = false },
            new RoomModel { RoomType = "Executive", Capacity = 2, NumberOfRooms = 5, HasView = true, AdaptedRoom = false },
            new RoomModel { RoomType = "Executive", Capacity = 2, NumberOfRooms = 4, HasView = false, AdaptedRoom = true },
            new RoomModel { RoomType = "Family", Capacity = 5, NumberOfRooms = 3, HasView = true, AdaptedRoom = true },
            new RoomModel { RoomType = "Family", Capacity = 5, NumberOfRooms = 4, HasView = false, AdaptedRoom = false },
            new RoomModel { RoomType = "Presidential", Capacity = 6, NumberOfRooms = 2, HasView = true, AdaptedRoom = false },
            new RoomModel { RoomType = "Presidential", Capacity = 6, NumberOfRooms = 1, HasView = false, AdaptedRoom = true },
            new RoomModel{ RoomType = "Penthouse", Capacity = 4, NumberOfRooms = 2, HasView = true, AdaptedRoom = true },
            new RoomModel { RoomType = "Studio", Capacity = 2, NumberOfRooms = 10, HasView = false, AdaptedRoom = false },
            new RoomModel { RoomType = "Loft", Capacity = 3, NumberOfRooms = 3, HasView = true, AdaptedRoom = false },
            new RoomModel { RoomType = "Loft", Capacity = 3, NumberOfRooms = 4, HasView = false, AdaptedRoom = true },
            new RoomModel { RoomType = "Villa", Capacity = 8, NumberOfRooms = 2, HasView = true, AdaptedRoom = false },
            new RoomModel { RoomType = "Villa", Capacity = 8, NumberOfRooms = 3, HasView = false, AdaptedRoom = true },
            new RoomModel { RoomType = "Bungalow", Capacity = 4, NumberOfRooms = 5, HasView = true, AdaptedRoom = false },
            new RoomModel { RoomType = "Bungalow", Capacity = 4, NumberOfRooms = 6, HasView = false, AdaptedRoom = true },
            new RoomModel { RoomType = "Single", Capacity = 1, NumberOfRooms = 15, HasView = false, AdaptedRoom = false },
            new RoomModel { RoomType = "Single", Capacity = 1, NumberOfRooms = 12, HasView = true, AdaptedRoom = true },
            new RoomModel { RoomType = "Double", Capacity = 2, NumberOfRooms = 20, HasView = false, AdaptedRoom = false },
            new RoomModel { RoomType = "Double", Capacity = 2, NumberOfRooms = 15, HasView = true, AdaptedRoom = true },
            new RoomModel { RoomType = "Cottage", Capacity = 5, NumberOfRooms = 4, HasView = true, AdaptedRoom = false },
            new RoomModel { RoomType = "Cottage", Capacity = 5, NumberOfRooms = 3, HasView = false, AdaptedRoom = true },
            new RoomModel { RoomType = "Cabin", Capacity = 3, NumberOfRooms = 7, HasView = true, AdaptedRoom = false },
            new RoomModel { RoomType = "Cabin", Capacity = 3, NumberOfRooms = 6, HasView = false, AdaptedRoom = true }
                }
            );

            db.SaveChanges();
        }
    }
}

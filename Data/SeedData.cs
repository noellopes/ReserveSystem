using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReserveSystem.Models;
using System;
using System.Linq;

namespace ReserveSystem.Data
{
    public static class SeedData
    {
        internal static void Populate(ReserveSystemContext? db)
        {
            if (db == null) return;
            db.Database.EnsureCreated();

            //PopulateCliente(db);
            PopulateRoom(db);
            PopulateRoomType(db);
            PopulateCliente(db);
            PopulateBookings(db);
        }

        internal static void PopulateUsers(UserManager<IdentityUser> userManager)
        {
            //EnsureUserIsCreatedAsync(userManager, "john@ipg.pt", "Secret$123", "client").Wait();
        }

        internal static void PopulateDefaultAdmin(UserManager<IdentityUser> userManager)
        {
            //EnsureUserIsCreatedAsync(userManager, "admin@ipg.pt", "Secret$123", "admin").Wait();
        }

        private static async Task EnsureUserIsCreatedAsync(UserManager<IdentityUser> userManager, string username, string password, string roleName)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                user = new IdentityUser(username);
                await userManager.CreateAsync(user, password);
            }

            if (user != null)
            {
                var isInRole = await userManager.IsInRoleAsync(user, roleName);
                if (!isInRole)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

        internal static void PopulateRoles(RoleManager<IdentityRole> roleManager)
        {
            //EnsureRoleIsCreatedAsync(roleManager, "admin").Wait();
            //EnsureRoleIsCreatedAsync(roleManager, "client").Wait();

            // ...
        }

        private static async Task EnsureRoleIsCreatedAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);

            if (role == null)
            {
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

        private static void PopulateRoomType(ReserveSystemContext db)
        {
            if (db.RoomType.Any()) return;

            db.RoomType.AddRange(
                new List<RoomType>
                {
            new RoomType { HasView = false, Type = "Standard", RoomCapacity = 2, AcessibilityRoom = false },
            new RoomType { HasView = false, Type = "Salamalecom", RoomCapacity = 2, AcessibilityRoom = false },
            new RoomType { HasView = true, Type = "Deluxe", RoomCapacity = 3, AcessibilityRoom = false },
            new RoomType { HasView = true, Type = "Suite", RoomCapacity = 4, AcessibilityRoom = true },
            new RoomType { HasView = false, Type = "Economy", RoomCapacity = 1, AcessibilityRoom = true }
                });
            db.SaveChanges();
        }

        private static void PopulateBookings(ReserveSystemContext db)
        {
            if (db.Booking.Any()) return;

            db.Booking.AddRange(
                new List<Booking>
                {
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 1, 10), CHECKOUT_DATE = new DateTime(2025, 1, 15), BOOKING_DATE = new DateTime(2024, 12, 15), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 2, 5), CHECKOUT_DATE = new DateTime(2025, 2, 10), BOOKING_DATE = new DateTime(2025, 1, 20), TOTAL_PERSONS_NUMBER = 1, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 3, 12), CHECKOUT_DATE = new DateTime(2025, 3, 18), BOOKING_DATE = new DateTime(2025, 2, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 4, 1), CHECKOUT_DATE = new DateTime(2025, 4, 5), BOOKING_DATE = new DateTime(2025, 3, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 5, 10), CHECKOUT_DATE = new DateTime(2025, 5, 15), BOOKING_DATE = new DateTime(2025, 4, 12), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 6, 20), CHECKOUT_DATE = new DateTime(2025, 6, 25), BOOKING_DATE = new DateTime(2025, 5, 25), TOTAL_PERSONS_NUMBER = 1, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 7, 15), CHECKOUT_DATE = new DateTime(2025, 7, 20), BOOKING_DATE = new DateTime(2025, 6, 10), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 8, 5), CHECKOUT_DATE = new DateTime(2025, 8, 12), BOOKING_DATE = new DateTime(2025, 7, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 9, 1), CHECKOUT_DATE = new DateTime(2025, 9, 7), BOOKING_DATE = new DateTime(2025, 8, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 10, 10), CHECKOUT_DATE = new DateTime(2025, 10, 17), BOOKING_DATE = new DateTime(2025, 9, 12), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 1, 10), CHECKOUT_DATE = new DateTime(2025, 1, 15), BOOKING_DATE = new DateTime(2024, 12, 15), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 2, 5), CHECKOUT_DATE = new DateTime(2025, 2, 10), BOOKING_DATE = new DateTime(2025, 1, 20), TOTAL_PERSONS_NUMBER = 1, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 3, 12), CHECKOUT_DATE = new DateTime(2025, 3, 18), BOOKING_DATE = new DateTime(2025, 2, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 4, 1), CHECKOUT_DATE = new DateTime(2025, 4, 5), BOOKING_DATE = new DateTime(2025, 3, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 5, 10), CHECKOUT_DATE = new DateTime(2025, 5, 15), BOOKING_DATE = new DateTime(2025, 4, 12), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 6, 20), CHECKOUT_DATE = new DateTime(2025, 6, 25), BOOKING_DATE = new DateTime(2025, 5, 25), TOTAL_PERSONS_NUMBER = 1, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 7, 15), CHECKOUT_DATE = new DateTime(2025, 7, 20), BOOKING_DATE = new DateTime(2025, 6, 10), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 8, 5), CHECKOUT_DATE = new DateTime(2025, 8, 12), BOOKING_DATE = new DateTime(2025, 7, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 9, 1), CHECKOUT_DATE = new DateTime(2025, 9, 7), BOOKING_DATE = new DateTime(2025, 8, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 10, 10), CHECKOUT_DATE = new DateTime(2025, 10, 17), BOOKING_DATE = new DateTime(2025, 9, 12), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 1, 10), CHECKOUT_DATE = new DateTime(2025, 1, 15), BOOKING_DATE = new DateTime(2024, 12, 15), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 2, 5), CHECKOUT_DATE = new DateTime(2025, 2, 10), BOOKING_DATE = new DateTime(2025, 1, 20), TOTAL_PERSONS_NUMBER = 1, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 3, 12), CHECKOUT_DATE = new DateTime(2025, 3, 18), BOOKING_DATE = new DateTime(2025, 2, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 4, 1), CHECKOUT_DATE = new DateTime(2025, 4, 5), BOOKING_DATE = new DateTime(2025, 3, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 5, 10), CHECKOUT_DATE = new DateTime(2025, 5, 15), BOOKING_DATE = new DateTime(2025, 4, 12), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 6, 20), CHECKOUT_DATE = new DateTime(2025, 6, 25), BOOKING_DATE = new DateTime(2025, 5, 25), TOTAL_PERSONS_NUMBER = 1, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 7, 15), CHECKOUT_DATE = new DateTime(2025, 7, 20), BOOKING_DATE = new DateTime(2025, 6, 10), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 8, 5), CHECKOUT_DATE = new DateTime(2025, 8, 12), BOOKING_DATE = new DateTime(2025, 7, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 9, 1), CHECKOUT_DATE = new DateTime(2025, 9, 7), BOOKING_DATE = new DateTime(2025, 8, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 10, 10), CHECKOUT_DATE = new DateTime(2025, 10, 17), BOOKING_DATE = new DateTime(2025, 9, 12), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 1, 10), CHECKOUT_DATE = new DateTime(2025, 1, 15), BOOKING_DATE = new DateTime(2024, 12, 15), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 2, 5), CHECKOUT_DATE = new DateTime(2025, 2, 10), BOOKING_DATE = new DateTime(2025, 1, 20), TOTAL_PERSONS_NUMBER = 1, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 3, 12), CHECKOUT_DATE = new DateTime(2025, 3, 18), BOOKING_DATE = new DateTime(2025, 2, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 4, 1), CHECKOUT_DATE = new DateTime(2025, 4, 5), BOOKING_DATE = new DateTime(2025, 3, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 5, 10), CHECKOUT_DATE = new DateTime(2025, 5, 15), BOOKING_DATE = new DateTime(2025, 4, 12), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 6, 20), CHECKOUT_DATE = new DateTime(2025, 6, 25), BOOKING_DATE = new DateTime(2025, 5, 25), TOTAL_PERSONS_NUMBER = 1, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 7, 15), CHECKOUT_DATE = new DateTime(2025, 7, 20), BOOKING_DATE = new DateTime(2025, 6, 10), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 8, 5), CHECKOUT_DATE = new DateTime(2025, 8, 12), BOOKING_DATE = new DateTime(2025, 7, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 9, 1), CHECKOUT_DATE = new DateTime(2025, 9, 7), BOOKING_DATE = new DateTime(2025, 8, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 10, 30), CHECKOUT_DATE = new DateTime(2025, 11, 30), BOOKING_DATE = new DateTime(2025, 9, 12), TOTAL_PERSONS_NUMBER = 20, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 1, 10), CHECKOUT_DATE = new DateTime(2025, 1, 15), BOOKING_DATE = new DateTime(2024, 12, 15), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 2, 5), CHECKOUT_DATE = new DateTime(2025, 2, 10), BOOKING_DATE = new DateTime(2025, 1, 20), TOTAL_PERSONS_NUMBER = 1, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 3, 12), CHECKOUT_DATE = new DateTime(2025, 3, 18), BOOKING_DATE = new DateTime(2025, 2, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 4, 1), CHECKOUT_DATE = new DateTime(2025, 4, 5), BOOKING_DATE = new DateTime(2025, 3, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 5, 10), CHECKOUT_DATE = new DateTime(2025, 5, 15), BOOKING_DATE = new DateTime(2025, 4, 12), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 6, 20), CHECKOUT_DATE = new DateTime(2025, 6, 25), BOOKING_DATE = new DateTime(2025, 5, 25), TOTAL_PERSONS_NUMBER = 1, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 7, 15), CHECKOUT_DATE = new DateTime(2025, 7, 20), BOOKING_DATE = new DateTime(2025, 6, 10), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 8, 5), CHECKOUT_DATE = new DateTime(2025, 8, 12), BOOKING_DATE = new DateTime(2025, 7, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 9, 1), CHECKOUT_DATE = new DateTime(2025, 9, 7), BOOKING_DATE = new DateTime(2025, 8, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 10, 10), CHECKOUT_DATE = new DateTime(2025, 10, 17), BOOKING_DATE = new DateTime(2025, 9, 12), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 1, 10), CHECKOUT_DATE = new DateTime(2025, 1, 15), BOOKING_DATE = new DateTime(2024, 12, 15), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 2, 5), CHECKOUT_DATE = new DateTime(2025, 2, 10), BOOKING_DATE = new DateTime(2025, 1, 20), TOTAL_PERSONS_NUMBER = 1, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 3, 12), CHECKOUT_DATE = new DateTime(2025, 3, 18), BOOKING_DATE = new DateTime(2025, 2, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 4, 1), CHECKOUT_DATE = new DateTime(2025, 4, 5), BOOKING_DATE = new DateTime(2025, 3, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 5, 10), CHECKOUT_DATE = new DateTime(2025, 5, 15), BOOKING_DATE = new DateTime(2025, 4, 12), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 6, 20), CHECKOUT_DATE = new DateTime(2025, 6, 25), BOOKING_DATE = new DateTime(2025, 5, 25), TOTAL_PERSONS_NUMBER = 1, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 7, 15), CHECKOUT_DATE = new DateTime(2025, 7, 20), BOOKING_DATE = new DateTime(2025, 6, 10), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 8, 5), CHECKOUT_DATE = new DateTime(2025, 8, 12), BOOKING_DATE = new DateTime(2025, 7, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 1, 10), CHECKOUT_DATE = new DateTime(2025, 1, 15), BOOKING_DATE = new DateTime(2024, 12, 15), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 2, 5), CHECKOUT_DATE = new DateTime(2025, 2, 10), BOOKING_DATE = new DateTime(2025, 1, 20), TOTAL_PERSONS_NUMBER = 1, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 3, 12), CHECKOUT_DATE = new DateTime(2025, 3, 18), BOOKING_DATE = new DateTime(2025, 2, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 4, 1), CHECKOUT_DATE = new DateTime(2025, 4, 5), BOOKING_DATE = new DateTime(2025, 3, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 5, 10), CHECKOUT_DATE = new DateTime(2025, 5, 15), BOOKING_DATE = new DateTime(2025, 4, 12), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 6, 20), CHECKOUT_DATE = new DateTime(2025, 6, 25), BOOKING_DATE = new DateTime(2025, 5, 25), TOTAL_PERSONS_NUMBER = 1, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 7, 15), CHECKOUT_DATE = new DateTime(2025, 7, 20), BOOKING_DATE = new DateTime(2025, 6, 10), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 8, 5), CHECKOUT_DATE = new DateTime(2025, 8, 12), BOOKING_DATE = new DateTime(2025, 7, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 9, 1), CHECKOUT_DATE = new DateTime(2025, 9, 7), BOOKING_DATE = new DateTime(2025, 8, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 10, 10), CHECKOUT_DATE = new DateTime(2025, 10, 17), BOOKING_DATE = new DateTime(2025, 9, 12), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 1, 10), CHECKOUT_DATE = new DateTime(2025, 1, 15), BOOKING_DATE = new DateTime(2024, 12, 15), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 2, 5), CHECKOUT_DATE = new DateTime(2025, 2, 10), BOOKING_DATE = new DateTime(2025, 1, 20), TOTAL_PERSONS_NUMBER = 1, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 3, 12), CHECKOUT_DATE = new DateTime(2025, 3, 18), BOOKING_DATE = new DateTime(2025, 2, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 4, 1), CHECKOUT_DATE = new DateTime(2025, 4, 5), BOOKING_DATE = new DateTime(2025, 3, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 5, 10), CHECKOUT_DATE = new DateTime(2025, 5, 15), BOOKING_DATE = new DateTime(2025, 4, 12), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 6, 20), CHECKOUT_DATE = new DateTime(2025, 6, 25), BOOKING_DATE = new DateTime(2025, 5, 25), TOTAL_PERSONS_NUMBER = 1, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 7, 15), CHECKOUT_DATE = new DateTime(2025, 7, 20), BOOKING_DATE = new DateTime(2025, 6, 10), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 8, 5), CHECKOUT_DATE = new DateTime(2025, 8, 12), BOOKING_DATE = new DateTime(2025, 7, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 9, 1), CHECKOUT_DATE = new DateTime(2025, 9, 7), BOOKING_DATE = new DateTime(2025, 8, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 10, 10), CHECKOUT_DATE = new DateTime(2025, 10, 17), BOOKING_DATE = new DateTime(2025, 9, 12), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 1, 10), CHECKOUT_DATE = new DateTime(2025, 1, 15), BOOKING_DATE = new DateTime(2024, 12, 15), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 2, 5), CHECKOUT_DATE = new DateTime(2025, 2, 10), BOOKING_DATE = new DateTime(2025, 1, 20), TOTAL_PERSONS_NUMBER = 1, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 3, 12), CHECKOUT_DATE = new DateTime(2025, 3, 18), BOOKING_DATE = new DateTime(2025, 2, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 4, 1), CHECKOUT_DATE = new DateTime(2025, 4, 5), BOOKING_DATE = new DateTime(2025, 3, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 5, 10), CHECKOUT_DATE = new DateTime(2025, 5, 15), BOOKING_DATE = new DateTime(2025, 4, 12), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 6, 20), CHECKOUT_DATE = new DateTime(2025, 6, 25), BOOKING_DATE = new DateTime(2025, 5, 25), TOTAL_PERSONS_NUMBER = 1, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 7, 15), CHECKOUT_DATE = new DateTime(2025, 7, 20), BOOKING_DATE = new DateTime(2025, 6, 10), TOTAL_PERSONS_NUMBER = 2, BOOKED = true, PAYMENT_STATUS = true },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 8, 5), CHECKOUT_DATE = new DateTime(2025, 8, 12), BOOKING_DATE = new DateTime(2025, 7, 10), TOTAL_PERSONS_NUMBER = 3, BOOKED = true, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 9, 1), CHECKOUT_DATE = new DateTime(2025, 9, 7), BOOKING_DATE = new DateTime(2025, 8, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false },
                        new Booking {ID_CLIENT = 1, CHECKIN_DATE = new DateTime(2025, 9, 1), CHECKOUT_DATE = new DateTime(2025, 9, 7), BOOKING_DATE = new DateTime(2025, 8, 15), TOTAL_PERSONS_NUMBER = 4, BOOKED = false, PAYMENT_STATUS = false }



                });
            db.SaveChanges();
        }

        private static void PopulateRoom(ReserveSystemContext db)
        {
            if (!db.Room.Any())
            {
                var requiredTypes = new[] { "Standard", "Deluxe", "Suite", "Economy" };
                var existingRoomTypes = db.RoomType.ToDictionary(rt => rt.Type, rt => rt.RoomTypeId);

                // Adiciona tipos de quarto ausentes
                foreach (var type in requiredTypes)
                {
                    if (!existingRoomTypes.ContainsKey(type))
                    {
                        var newRoomType = new RoomType { Type = type, RoomCapacity = 2, HasView = false, AcessibilityRoom = false };
                        db.RoomType.Add(newRoomType);
                        db.SaveChanges();

                        // Atualiza o dicionário com o novo tipo de quarto
                        existingRoomTypes[type] = newRoomType.RoomTypeId;
                    }
                }

                db.Room.AddRange(
                    new List<RoomModel>
                    {
                new RoomModel { RoomTypeId = existingRoomTypes["Standard"] },
                new RoomModel { RoomTypeId = existingRoomTypes["Deluxe"] },
                new RoomModel { RoomTypeId = existingRoomTypes["Suite"] },
                new RoomModel { RoomTypeId = existingRoomTypes["Economy"] }
                    });

                db.SaveChanges();
            }
        }
    }
}
 



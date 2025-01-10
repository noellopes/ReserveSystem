using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class SeedData
    {
        public static void Populate(ReserveSystemUsersDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (db == null)
            {
                Console.WriteLine("Banco de dados não foi inicializado.");
                return;
            }

            // Assegura que o banco de dados esteja criado
            db.Database.EnsureCreated();
            Console.WriteLine("Banco de dados foi criado com sucesso.");

            // Popula os dados para as tabelas de eventos
            PopulateSeasonality(db);
            PopulateEvents(db);
            PopulateRoomTypes(db); // Popula os tipos de quarto
            PopulateUsers(userManager, roleManager);
        }

        private static void PopulateUsers(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Cria roles, se ainda não existirem
            CreateRoleIfNotExists(roleManager, "Admin");
            CreateRoleIfNotExists(roleManager, "User");

            // Verifica se o usuário admin já existe
            var adminUser = userManager.FindByEmailAsync("admin@reserve.com").Result;
            if (adminUser == null)
            {
                var newAdmin = new IdentityUser
                {
                    UserName = "admin@reserve.com",
                    Email = "admin@reserve.com",
                    EmailConfirmed = true // Certifique-se de que o email é confirmado
                };

                var result = userManager.CreateAsync(newAdmin, "Admin@123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(newAdmin, "Admin").Wait();
                }
            }

            var commonUser = userManager.FindByEmailAsync("user@reserve.com").Result;
            if (commonUser == null)
            {
                var newUser = new IdentityUser
                {
                    UserName = "user@reserve.com",
                    Email = "user@reserve.com",
                    EmailConfirmed = true // Certifique-se de que o email é confirmado
                };

                var result = userManager.CreateAsync(newUser, "User@123").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(newUser, "User").Wait();
                }
            }
        }

        private static void CreateRoleIfNotExists(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var role = roleManager.FindByNameAsync(roleName).Result;
            if (role == null)
            {
                roleManager.CreateAsync(new IdentityRole(roleName)).Wait();
            }
        }

        private static void PopulateEvents(ReserveSystemUsersDbContext db)
        {
            if (db.Events.Any()) return;

            db.Events.AddRange(new List<Events> {
                new Events {nameEv = "Spring Festival", startDate = new DateTime(2024, 3, 20), endDate = new DateTime(2024, 3, 25), fee = 15.50f, anual = true, municipal = true, national = false, inUse = true },
                new Events {nameEv = "National Tech Conference", startDate = new DateTime(2024, 5, 10), endDate = new DateTime(2024, 5, 12), fee = 120.00f, anual = true, municipal = false, national = true , inUse = true},
                new Events {nameEv = "Local Farmers' Market", startDate = new DateTime(2024, 7, 1), endDate = new DateTime(2024, 7, 1), fee = 0.00f, anual = false, municipal = true, national = false , inUse = true},
                new Events {nameEv = "Independence Day Parade", startDate = new DateTime(2024, 9, 7), endDate = new DateTime(2024, 9, 7), fee = 5.00f, anual = true, municipal = false, national = true, inUse = true },
                new Events {nameEv = "Winter Gala", startDate = new DateTime(2024, 12, 15), endDate = new DateTime(2024, 12, 15), fee = 50.00f, anual = true, municipal = true, national = false , inUse = true},
                new Events {nameEv = "Summer Carnival", startDate = new DateTime(2024, 8, 5), endDate = new DateTime(2024, 8, 10), fee = 25.00f, anual = true, municipal = true, national = false , inUse = true},
                new Events {nameEv = "Art Expo", startDate = new DateTime(2024, 4, 20), endDate = new DateTime(2024, 4, 22), fee = 30.00f, anual = false, municipal = true, national = true , inUse = true},
                new Events {nameEv = "Music Festival", startDate = new DateTime(2024, 6, 15), endDate = new DateTime(2024, 6, 18), fee = 60.00f, anual = true, municipal = false, national = true , inUse = true},
                new Events {nameEv = "Science Fair", startDate = new DateTime(2024, 10, 10), endDate = new DateTime(2024, 10, 12), fee = 10.00f, anual = false, municipal = true, national = false , inUse = true},
                new Events {nameEv = "Wine Tasting", startDate = new DateTime(2024, 11, 5), endDate = new DateTime(2024, 11, 6), fee = 45.00f, anual = true, municipal = false, national = false , inUse = true},
                new Events {nameEv = "Food Truck Rally", startDate = new DateTime(2024, 9, 20), endDate = new DateTime(2024, 9, 20), fee = 5.00f, anual = true, municipal = true, national = false , inUse = false},
                new Events {nameEv = "Halloween Party", startDate = new DateTime(2024, 10, 31), endDate = new DateTime(2024, 10, 31), fee = 20.00f, anual = true, municipal = false, national = false , inUse = true},
                new Events {nameEv = "Marathon Run", startDate = new DateTime(2024, 5, 15), endDate = new DateTime(2024, 5, 15), fee = 30.00f, anual = true, municipal = false, national = true , inUse = true},
                new Events {nameEv = "Book Fair", startDate = new DateTime(2024, 7, 10), endDate = new DateTime(2024, 7, 12), fee = 10.00f, anual = false, municipal = true, national = false, inUse = true},
                new Events {nameEv = "Charity Gala", startDate = new DateTime(2024, 12, 5), endDate = new DateTime(2024, 12, 5), fee = 100.00f, anual = true, municipal = false, national = true , inUse = true},
                new Events {nameEv = "Craft Workshop", startDate = new DateTime(2024, 2, 20), endDate = new DateTime(2024, 2, 20), fee = 15.00f, anual = false, municipal = true, national = false , inUse = true},
                new Events {nameEv = "Open Mic Night", startDate = new DateTime(2024, 3, 10), endDate = new DateTime(2024, 3, 10), fee = 10.00f, anual = true, municipal = true, national = false , inUse = true},
                new Events {nameEv = "Antique Show", startDate = new DateTime(2024, 6, 25), endDate = new DateTime(2024, 6, 27), fee = 25.00f, anual = false, municipal = false, national = true , inUse = true},
                new Events {nameEv = "Startup Pitch Night", startDate = new DateTime(2024, 5, 30), endDate = new DateTime(2024, 5, 30), fee = 50.00f, anual = false, municipal = false, national = true , inUse = true},
                new Events {nameEv = "History Lecture Series", startDate = new DateTime(2024, 11, 15), endDate = new DateTime(2024, 11, 17), fee = 0.00f, anual = false, municipal = true, national = false , inUse = true }
                
            });

            db.SaveChanges();
        }

        private static void PopulateSeasonality(ReserveSystemUsersDbContext db)
        {
            if (db.Sazonalidade.Any()) return;

            db.Sazonalidade.AddRange(new List<Sazonalidade> {
        new Sazonalidade { NameSeason = "New Year Celebration", DateBegin = new DateTime(2024, 1, 1), DateEnd = new DateTime(2024, 1, 15), InUse = true, SeasonFee = 0.25f },
        new Sazonalidade { NameSeason = "Winter Bliss", DateBegin = new DateTime(2024, 1, 20), DateEnd = new DateTime(2024, 2, 5), InUse = true, SeasonFee = 0.35f },
        new Sazonalidade { NameSeason = "Valentine's Warmth", DateBegin = new DateTime(2024, 2, 10), DateEnd = new DateTime(2024, 2, 25), InUse = true, SeasonFee = 0.45f },
        new Sazonalidade { NameSeason = "Spring Awakening", DateBegin = new DateTime(2024, 3, 1), DateEnd = new DateTime(2024, 3, 15), InUse = true, SeasonFee = 0.30f },
        new Sazonalidade { NameSeason = "Cherry Blossom Festival", DateBegin = new DateTime(2024, 3, 20), DateEnd = new DateTime(2024, 4, 5), InUse = true, SeasonFee = 0.20f },
        new Sazonalidade { NameSeason = "April Showers", DateBegin = new DateTime(2024, 4, 10), DateEnd = new DateTime(2024, 4, 25), InUse = true, SeasonFee = 0.50f },
        new Sazonalidade { NameSeason = "May Flowers", DateBegin = new DateTime(2024, 5, 1), DateEnd = new DateTime(2024, 5, 15), InUse = true, SeasonFee = 0.40f },
        new Sazonalidade { NameSeason = "Summer Kickoff", DateBegin = new DateTime(2024, 5, 20), DateEnd = new DateTime(2024, 6, 5), InUse = true, SeasonFee = 0.55f },
        new Sazonalidade { NameSeason = "June Solstice", DateBegin = new DateTime(2024, 6, 10), DateEnd = new DateTime(2024, 6, 25), InUse = true, SeasonFee = 0.35f },
        new Sazonalidade { NameSeason = "July Fireworks", DateBegin = new DateTime(2024, 7, 1), DateEnd = new DateTime(2024, 7, 15), InUse = true, SeasonFee = 0.45f },
        new Sazonalidade { NameSeason = "Mid-Summer Festivities", DateBegin = new DateTime(2024, 7, 20), DateEnd = new DateTime(2024, 8, 5), InUse = true, SeasonFee = 0.60f },
        new Sazonalidade { NameSeason = "August Retreat", DateBegin = new DateTime(2024, 8, 10), DateEnd = new DateTime(2024, 8, 25), InUse = true, SeasonFee = 0.30f },
        new Sazonalidade { NameSeason = "Harvest Season", DateBegin = new DateTime(2024, 9, 1), DateEnd = new DateTime(2024, 9, 15), InUse = true, SeasonFee = 0.50f },
        new Sazonalidade { NameSeason = "Autumn Colors", DateBegin = new DateTime(2024, 9, 20), DateEnd = new DateTime(2024, 10, 5), InUse = true, SeasonFee = 0.70f },
        new Sazonalidade { NameSeason = "October Festivities", DateBegin = new DateTime(2024, 10, 10), DateEnd = new DateTime(2024, 10, 25), InUse = true, SeasonFee = 0.25f },
        new Sazonalidade { NameSeason = "Thanksgiving Preparations", DateBegin = new DateTime(2024, 11, 1), DateEnd = new DateTime(2024, 11, 15), InUse = true, SeasonFee = 0.55f },
        new Sazonalidade { NameSeason = "Holiday Shopping Rush", DateBegin = new DateTime(2024, 11, 20), DateEnd = new DateTime(2024, 12, 5), InUse = true, SeasonFee = 0.65f },
        new Sazonalidade { NameSeason = "Christmas Cheer", DateBegin = new DateTime(2024, 12, 10), DateEnd = new DateTime(2024, 12, 25), InUse = true, SeasonFee = 0.45f },
        new Sazonalidade { NameSeason = "New Beginnings", DateBegin = new DateTime(2025, 1, 1), DateEnd = new DateTime(2025, 1, 15), InUse = true, SeasonFee = 0.35f },
        new Sazonalidade { NameSeason = "Snowfall Adventures", DateBegin = new DateTime(2025, 1, 20), DateEnd = new DateTime(2025, 2, 5), InUse = true, SeasonFee = 0.50f },

        new Sazonalidade { NameSeason = "Valentine's Warmth25", DateBegin = new DateTime(2025, 2, 10), DateEnd = new DateTime(2025, 2, 25), InUse = true, SeasonFee = 0.45f },
        new Sazonalidade { NameSeason = "Spring Awakening25", DateBegin = new DateTime(2025, 3, 1), DateEnd = new DateTime(2025, 3, 15), InUse = true, SeasonFee = 0.30f },
        new Sazonalidade { NameSeason = "Cherry Blossom Festival25", DateBegin = new DateTime(2025, 3, 20), DateEnd = new DateTime(2025, 4, 5), InUse = true, SeasonFee = 0.20f },
        new Sazonalidade { NameSeason = "April Showers25", DateBegin = new DateTime(2025, 4, 10), DateEnd = new DateTime(2025, 4, 25), InUse = true, SeasonFee = 0.50f },
        new Sazonalidade { NameSeason = "May Flowers25", DateBegin = new DateTime(2025, 5, 1), DateEnd = new DateTime(2025, 5, 15), InUse = false, SeasonFee = 0.40f },
        new Sazonalidade { NameSeason = "Summer Kickoff25", DateBegin = new DateTime(2025, 5, 20), DateEnd = new DateTime(2025, 6, 5), InUse = true, SeasonFee = 0.55f },
        new Sazonalidade { NameSeason = "June Solstice25", DateBegin = new DateTime(2025, 6, 10), DateEnd = new DateTime(2025, 6, 25), InUse = true, SeasonFee = 0.35f },
        new Sazonalidade { NameSeason = "July Fireworks25", DateBegin = new DateTime(2025, 7, 1), DateEnd = new DateTime(2025, 7, 15), InUse = false, SeasonFee = 0.45f },
        new Sazonalidade { NameSeason = "Mid-Summer Festivities25", DateBegin = new DateTime(2025, 7, 20), DateEnd = new DateTime(2025, 8, 5), InUse = true, SeasonFee = 0.60f },
        new Sazonalidade { NameSeason = "August Retreat25", DateBegin = new DateTime(2025, 8, 10), DateEnd = new DateTime(2025, 8, 25), InUse = true, SeasonFee = 0.30f },
        new Sazonalidade { NameSeason = "Harvest Season25", DateBegin = new DateTime(2025, 9, 1), DateEnd = new DateTime(2025, 9, 15), InUse = true, SeasonFee = 0.50f },
        new Sazonalidade { NameSeason = "Autumn Colors25", DateBegin = new DateTime(2025, 9, 20), DateEnd = new DateTime(2025, 10, 5), InUse = true, SeasonFee = 0.70f },
        new Sazonalidade { NameSeason = "October Festivities25", DateBegin = new DateTime(2025, 10, 10), DateEnd = new DateTime(2025, 10, 25), InUse = true, SeasonFee = 0.25f },
        new Sazonalidade { NameSeason = "Thanksgiving Preparations", DateBegin = new DateTime(2025, 11, 1), DateEnd = new DateTime(2025, 11, 15), InUse = true, SeasonFee = 0.55f },
        new Sazonalidade { NameSeason = "Holiday Shopping Rush25", DateBegin = new DateTime(2025, 11, 20), DateEnd = new DateTime(2025, 12, 5), InUse = true, SeasonFee = 0.65f },
        new Sazonalidade { NameSeason = "Christmas Cheer25", DateBegin = new DateTime(2025, 12, 10), DateEnd = new DateTime(2025, 12, 25), InUse = true, SeasonFee = 0.45f }
    });

            db.SaveChanges();
        }



        private static void PopulateRoomTypes(ReserveSystemUsersDbContext db)
        {
            if (db.TQePreco.Any()) return;

            db.TQePreco.AddRange(new List<TQePreco> {
        new TQePreco{type = "Single Room",capacity = 1,RoomQuantity = 10,AcessibilityRoom = true,View = false,BasePrice = 0,AdicionalBeds = 20.0f,InUse = false},
        new TQePreco{type = "Double Room",capacity = 2,RoomQuantity = 15,AcessibilityRoom = false,View = true,BasePrice = 0,AdicionalBeds = 25.0f,InUse = false},
        new TQePreco{type = "Suite",capacity = 4,RoomQuantity = 5,AcessibilityRoom = true,View = true,BasePrice = 350.0f,AdicionalBeds = 50.0f,InUse = true},
        new TQePreco{type = "Economy Room",capacity = 1,RoomQuantity = 20,AcessibilityRoom = false,View = false,BasePrice = 80.0f,AdicionalBeds = 10.0f,InUse = true},
        new TQePreco{type = "Deluxe Room",capacity = 3,RoomQuantity = 8,AcessibilityRoom = true,View = true,BasePrice = 300.0f,AdicionalBeds = 40.0f,InUse = true},
        new TQePreco{type = "Family Suite",capacity = 6,RoomQuantity = 3,AcessibilityRoom = true,View = true,BasePrice = 0,AdicionalBeds = 60.0f,InUse = false},
        new TQePreco{type = "Presidential Suite",capacity = 8,RoomQuantity = 2,AcessibilityRoom = true,View = true,BasePrice = 1000.0f,AdicionalBeds = 100.0f,InUse = true},
        new TQePreco{type = "Studio Room",capacity = 2,RoomQuantity = 12,AcessibilityRoom = false,View = true,BasePrice = 0,AdicionalBeds = 15.0f,InUse = false},
        new TQePreco{type = "Penthouse",capacity = 5,RoomQuantity = 1,AcessibilityRoom = false,View = true,BasePrice = 1200.0f,AdicionalBeds = 75.0f,InUse = true},
        new TQePreco{type = "Cabin Room",capacity = 3,RoomQuantity = 6,AcessibilityRoom = true,View = false,BasePrice = 0,AdicionalBeds = 30.0f,InUse = false},
        ////NOVO SEED DATA ADICIONADO
        new TQePreco{type = "Ocean View Room",capacity = 2,RoomQuantity = 8,AcessibilityRoom = false,View = true,BasePrice = 200.0f,AdicionalBeds = 20.0f,InUse = false}, 
        new TQePreco{type = "Garden Room",capacity = 3,RoomQuantity = 5,AcessibilityRoom = true,View = false,BasePrice = 150.0f,AdicionalBeds = 25.0f,InUse = true}, 
        new TQePreco{type = "Luxury Suite",capacity = 4,RoomQuantity = 4,AcessibilityRoom = true,View = true,BasePrice = 500.0f,AdicionalBeds = 50.0f,InUse = true}, 
        new TQePreco{type = "Penthouse Suite",capacity = 6,RoomQuantity = 2,AcessibilityRoom = false,View = true,BasePrice = 1000.0f,AdicionalBeds = 75.0f,InUse = false}, 
        new TQePreco{type = "Standard Room",capacity = 2,RoomQuantity = 18,AcessibilityRoom = true,View = false,BasePrice = 120.0f,AdicionalBeds = 20.0f,InUse = true},
        new TQePreco{type = "Superior Room",capacity = 4,RoomQuantity = 7,AcessibilityRoom = false,View = true,BasePrice = 200.0f,AdicionalBeds = 40.0f,InUse = true},
        new TQePreco{type = "Grand Suite",capacity = 8,RoomQuantity = 1,AcessibilityRoom = true,View = true,BasePrice = 800.0f,AdicionalBeds = 100.0f,InUse = false}, 
        new TQePreco{type = "Business Room",capacity = 1,RoomQuantity = 10,AcessibilityRoom = false,View = false,BasePrice = 100.0f,AdicionalBeds = 15.0f,InUse = true}, 
        new TQePreco{type = "Honeymoon Suite",capacity = 2,RoomQuantity = 5,AcessibilityRoom = true,View = true,BasePrice = 600.0f,AdicionalBeds = 50.0f,InUse = true},
        new TQePreco{type = "Classic Room",capacity = 2,RoomQuantity = 10,AcessibilityRoom = true,View = false,BasePrice = 120.0f,AdicionalBeds = 15.0f,InUse = true},
        new TQePreco{type = "Executive Room",capacity = 3,RoomQuantity = 9,AcessibilityRoom = true,View = true,BasePrice = 400.0f,AdicionalBeds = 30.0f,InUse = false},
        new TQePreco{type = "Premium Room",capacity = 2,RoomQuantity = 6,AcessibilityRoom = false,View = true,BasePrice = 350.0f,AdicionalBeds = 25.0f,InUse = true},
        new TQePreco{type = "Penthouse Suite Deluxe",capacity = 5,RoomQuantity = 2,AcessibilityRoom = false,View = true,BasePrice = 1200.0f,AdicionalBeds = 100.0f,InUse = true},
        new TQePreco{type = "Cozy Room",capacity = 1,RoomQuantity = 15,AcessibilityRoom = true,View = false,BasePrice = 80.0f,AdicionalBeds = 10.0f,InUse = false},
        new TQePreco{type = "Terrace Suite",capacity = 4,RoomQuantity = 3,AcessibilityRoom = true,View = true,BasePrice = 500.0f,AdicionalBeds = 50.0f,InUse = true},
        new TQePreco{type = "Courtyard Room",capacity = 2,RoomQuantity = 8,AcessibilityRoom = false,View = false,BasePrice = 180.0f,AdicionalBeds = 20.0f,InUse = false},
        new TQePreco{type = "Elite Room",capacity = 3,RoomQuantity = 6,AcessibilityRoom = true,View = true,BasePrice = 250.0f,AdicionalBeds = 35.0f,InUse = true},
        new TQePreco{type = "Skyline Suite",capacity = 5,RoomQuantity = 1,AcessibilityRoom = false,View = true,BasePrice = 1500.0f,AdicionalBeds = 75.0f,InUse = true},
        new TQePreco{type = "Urban Room",capacity = 2,RoomQuantity = 10,AcessibilityRoom = true,View = true,BasePrice = 150.0f,AdicionalBeds = 20.0f,InUse = false},
        new TQePreco{type = "Retreat Room",capacity = 3,RoomQuantity = 7,AcessibilityRoom = true,View = false,BasePrice = 220.0f,AdicionalBeds = 30.0f,InUse = true},
        new TQePreco{type = "Mountain View Room",capacity = 2,RoomQuantity = 9,AcessibilityRoom = false,View = true,BasePrice = 250.0f,AdicionalBeds = 20.0f,InUse = true},
        new TQePreco{type = "Studio Suite",capacity = 4,RoomQuantity = 5,AcessibilityRoom = true,View = false,BasePrice = 300.0f,AdicionalBeds = 40.0f,InUse = false},
        new TQePreco{type = "Penthouse Loft",capacity = 6,RoomQuantity = 2,AcessibilityRoom = false,View = true,BasePrice = 2000.0f,AdicionalBeds = 100.0f,InUse = true},
        new TQePreco{type = "VIP Suite",capacity = 8,RoomQuantity = 1,AcessibilityRoom = true,View = true,BasePrice = 2000.0f,AdicionalBeds = 100.0f,InUse = true}, 
        new TQePreco{type = "Loft Room",capacity = 4,RoomQuantity = 6,AcessibilityRoom = true,View = true,BasePrice = 350.0f,AdicionalBeds = 40.0f,InUse = false}, 
        new TQePreco{type = "Studio Loft",capacity = 3,RoomQuantity = 7,AcessibilityRoom = false,View = true,BasePrice = 300.0f,AdicionalBeds = 35.0f,InUse = true},
        new TQePreco{type = "Patio Suite",capacity = 5,RoomQuantity = 4,AcessibilityRoom = true,View = false,BasePrice = 450.0f,AdicionalBeds = 50.0f,InUse = true},
        new TQePreco{type = "Duplex Room",capacity = 2,RoomQuantity = 8,AcessibilityRoom = false,View = true,BasePrice = 400.0f,AdicionalBeds = 20.0f,InUse = false},
        new TQePreco{type = "Junior Suite",capacity = 4,RoomQuantity = 5,AcessibilityRoom = true,View = true,BasePrice = 300.0f,AdicionalBeds = 45.0f,InUse = false},
        new TQePreco{type = "Bungalow Room",capacity = 3,RoomQuantity = 6,AcessibilityRoom = true,View = false,BasePrice = 200.0f,AdicionalBeds = 30.0f,InUse = true}, 
        new TQePreco{type = "Countryside Suite",capacity = 4,RoomQuantity = 3,AcessibilityRoom = false,View = true,BasePrice = 450.0f,AdicionalBeds = 40.0f,InUse = true},
        new TQePreco{type = "City View Room",capacity = 2,RoomQuantity = 9,AcessibilityRoom = true,View = true,BasePrice = 250.0f,AdicionalBeds = 20.0f,InUse = false}, 
        new TQePreco{type = "Corner Suite",capacity = 4,RoomQuantity = 4,AcessibilityRoom = false,View = true,BasePrice = 350.0f,AdicionalBeds = 45.0f,InUse = true},
        new TQePreco{type = "Penthouse Suite Classic",capacity = 6,RoomQuantity = 1,AcessibilityRoom = true,View = true,BasePrice = 1500.0f,AdicionalBeds = 100.0f,InUse = false},
        new TQePreco{type = "Rooftop Room",capacity = 2,RoomQuantity = 5,AcessibilityRoom = false,View = true,BasePrice = 300.0f,AdicionalBeds = 25.0f,InUse = true},
        new TQePreco{type = "Tower Suite",capacity = 3,RoomQuantity = 7,AcessibilityRoom = true,View = true,BasePrice = 500.0f,AdicionalBeds = 35.0f,InUse = false},
        new TQePreco{type = "Balcony Room",capacity = 1,RoomQuantity = 10,AcessibilityRoom = true,View = true,BasePrice = 150.0f,AdicionalBeds = 15.0f,InUse = true},
        new TQePreco{type = "Eco Room",capacity = 2,RoomQuantity = 8,AcessibilityRoom = false,View = false,BasePrice = 100.0f,AdicionalBeds = 20.0f,InUse = false},
        new TQePreco{type = "River View Suite",capacity = 4,RoomQuantity = 4,AcessibilityRoom = true,View = true,BasePrice = 400.0f,AdicionalBeds = 50.0f,InUse = true},
        new TQePreco{type = "Skylight Room",capacity = 3,RoomQuantity = 6,AcessibilityRoom = false,View = true,BasePrice = 200.0f,AdicionalBeds = 30.0f,InUse = false},
        new TQePreco{type = "Panoramic Suite",capacity = 5,RoomQuantity = 3,AcessibilityRoom = true,View = true,BasePrice = 500.0f,AdicionalBeds = 60.0f,InUse = true},
        new TQePreco{type = "Alcove Room",capacity = 2,RoomQuantity = 7,AcessibilityRoom = false,View = true,BasePrice = 120.0f,AdicionalBeds = 20.0f,InUse = true},
        new TQePreco{type = "Atrium Suite",capacity = 6,RoomQuantity = 2,AcessibilityRoom = true,View = true,BasePrice = 600.0f,AdicionalBeds = 70.0f,InUse = false},
        new TQePreco{type = "Pier Room",capacity = 3,RoomQuantity = 9,AcessibilityRoom = true,View = true,BasePrice = 180.0f,AdicionalBeds = 25.0f,InUse = true},
        new TQePreco{type = "Courtyard Suite",capacity = 4,RoomQuantity = 5,AcessibilityRoom = false,View = true,BasePrice = 350.0f,AdicionalBeds = 45.0f,InUse = false},
        new TQePreco{type = "Hilltop Room",capacity = 2,RoomQuantity = 8,AcessibilityRoom = true,View = true,BasePrice = 220.0f,AdicionalBeds = 20.0f,InUse = true},
        new TQePreco{type = "Poolside Suite",capacity = 5,RoomQuantity = 4,AcessibilityRoom = false,View = true,BasePrice = 450.0f,AdicionalBeds = 50.0f,InUse = false},
        new TQePreco{type = "Cabana Room",capacity = 2,RoomQuantity = 10,AcessibilityRoom = true,View = true,BasePrice = 200.0f,AdicionalBeds = 20.0f,InUse = true},
        new TQePreco{type = "Horizon Suite",capacity = 4,RoomQuantity = 3,AcessibilityRoom = false,View = true,BasePrice = 550.0f,AdicionalBeds = 60.0f,InUse = true},
        new TQePreco{type = "Seaview Room",capacity = 2,RoomQuantity = 7,AcessibilityRoom = true,View = true,BasePrice = 300.0f,AdicionalBeds = 25.0f,InUse = false},
        new TQePreco{type = "Penthouse Suite Modern",capacity = 6,RoomQuantity = 2,AcessibilityRoom = true,View = true,BasePrice = 1600.0f,AdicionalBeds = 100.0f,InUse = true},
        new TQePreco{type = "Heritage Room",capacity = 3,RoomQuantity = 6,AcessibilityRoom = false,View = true,BasePrice = 250.0f,AdicionalBeds = 30.0f,InUse = true},
        new TQePreco{type = "Seaside Suite",capacity = 4,RoomQuantity = 3,AcessibilityRoom = true,View = true,BasePrice = 450.0f,AdicionalBeds = 55.0f,InUse = true},
        new TQePreco{type = "Lakeside Room",capacity = 2,RoomQuantity = 8,AcessibilityRoom = true,View = true,BasePrice = 200.0f,AdicionalBeds = 20.0f,InUse = false},
        new TQePreco{type = "Forest Suite",capacity = 5,RoomQuantity = 4,AcessibilityRoom = true,View = true,BasePrice = 500.0f,AdicionalBeds = 60.0f,InUse = true},
        new TQePreco{type = "Urban Loft",capacity = 3,RoomQuantity = 7,AcessibilityRoom = true,View = true,BasePrice = 300.0f,AdicionalBeds = 35.0f,InUse = false}

            });

            db.SaveChanges();
        }

    }
}

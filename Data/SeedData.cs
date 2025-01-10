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
            PopulatePricePerDate(db);
            PopulatePromos(db);
            PopulateUsers(userManager, roleManager);
            PopulateBookings(db);
 
            PopulateRooms(db);
            PopulateRoomBookings(db);
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

        private static void PopulatePromos(ReserveSystemUsersDbContext db)
        {
            if (db.Promos.Any()) return;

            db.Promos.AddRange(new List<Promos> {
            new Promos { event_id = 1, evCode = "SUMMER25", discount = -0.10f, promState = true },
            new Promos { event_id = 2, evCode = "WINTER25", discount = -0.15f, promState = true },
            new Promos { event_id = 3, evCode = "SPRING25", discount = -0.12f, promState = true },
            new Promos { event_id = 4, evCode = "FALL25", discount = -0.08f, promState = true },
            new Promos { event_id = 5, evCode = "HOLIDAY25", discount = -0.20f, promState = true },
            new Promos { event_id = 6, evCode = "BLACKFRIDAY25", discount = -0.25f, promState = true },
            new Promos { event_id = 7, evCode = "CYBERMONDAY25", discount = -0.22f, promState = true },
            new Promos { event_id = 8, evCode = "NEWYEAR25", discount = -0.18f, promState = false },
            new Promos { event_id = 9, evCode = "EASTER25", discount = -0.10f, promState = true },
            new Promos { event_id = 10, evCode = "SUMMERHOLIDAY25", discount = -0.15f, promState = true },
            });

            db.SaveChanges();
        }

        private static void PopulatePricePerDate(ReserveSystemUsersDbContext db)
        {
            if (db.PricePerDate.Any()) return;

            db.PricePerDate.AddRange(new List<PricePerDate> {
            new PricePerDate { RoomTypeId = 1, dateBegin = new DateTime(2025, 1, 1), dateEnd = new DateTime(2025, 1, 31), newPricePerDate = 100.0f, actState = true },
            new PricePerDate { RoomTypeId = 2, dateBegin = new DateTime(2025, 2, 1), dateEnd = new DateTime(2025, 2, 28), newPricePerDate = 110.0f, actState = true },
            new PricePerDate { RoomTypeId = 3, dateBegin = new DateTime(2025, 3, 1), dateEnd = new DateTime(2025, 3, 31), newPricePerDate = 120.0f, actState = false },
            new PricePerDate { RoomTypeId = 4, dateBegin = new DateTime(2025, 4, 1), dateEnd = new DateTime(2025, 4, 30), newPricePerDate = 115.0f, actState = true },
            new PricePerDate { RoomTypeId = 5, dateBegin = new DateTime(2025, 5, 1), dateEnd = new DateTime(2025, 5, 31), newPricePerDate = 125.0f, actState = true },
            new PricePerDate { RoomTypeId = 6, dateBegin = new DateTime(2025, 6, 1), dateEnd = new DateTime(2025, 6, 30), newPricePerDate = 130.0f, actState = true },
            new PricePerDate { RoomTypeId = 7, dateBegin = new DateTime(2025, 7, 1), dateEnd = new DateTime(2025, 7, 31), newPricePerDate = 135.0f, actState = false },
            new PricePerDate { RoomTypeId = 8, dateBegin = new DateTime(2025, 8, 1), dateEnd = new DateTime(2025, 8, 31), newPricePerDate = 140.0f, actState = true },
            new PricePerDate { RoomTypeId = 9, dateBegin = new DateTime(2025, 9, 1), dateEnd = new DateTime(2025, 9, 30), newPricePerDate = 145.0f, actState = true },
            new PricePerDate { RoomTypeId = 10, dateBegin = new DateTime(2025, 10, 1), dateEnd = new DateTime(2025, 10, 31), newPricePerDate = 150.0f, actState = true },
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

        private static void PopulateRoomBookings(ReserveSystemUsersDbContext db)
        {
            if (db.RoomBooking.Any()) return;

            db.RoomBooking.AddRange(new List<RoomBooking>
    {
        new RoomBooking { ID_Booking = 1, ID_Room = 1 },
        new RoomBooking { ID_Booking = 1, ID_Room = 2 },
        new RoomBooking { ID_Booking = 2, ID_Room = 3 },
        new RoomBooking { ID_Booking = 2, ID_Room = 4 },
        new RoomBooking { ID_Booking = 3, ID_Room = 5 },
        new RoomBooking { ID_Booking = 3, ID_Room = 6 },
        new RoomBooking { ID_Booking = 4, ID_Room = 7 },
        new RoomBooking { ID_Booking = 4, ID_Room = 8 },
        new RoomBooking { ID_Booking = 5, ID_Room = 9 },
        new RoomBooking { ID_Booking = 5, ID_Room = 10 },
        new RoomBooking { ID_Booking = 6, ID_Room = 11 },
        new RoomBooking { ID_Booking = 6, ID_Room = 12 },
        new RoomBooking { ID_Booking = 7, ID_Room = 13 },
        new RoomBooking { ID_Booking = 7, ID_Room = 14 },
        new RoomBooking { ID_Booking = 8, ID_Room = 15 },
        new RoomBooking { ID_Booking = 8, ID_Room = 16 },
        new RoomBooking { ID_Booking = 9, ID_Room = 17 },
        new RoomBooking { ID_Booking = 9, ID_Room = 18 },
        new RoomBooking { ID_Booking = 10, ID_Room = 19 },
        new RoomBooking { ID_Booking = 10, ID_Room = 20 },
        new RoomBooking { ID_Booking = 11, ID_Room = 21 },
        new RoomBooking { ID_Booking = 11, ID_Room = 22 },
        new RoomBooking { ID_Booking = 12, ID_Room = 23 },
        new RoomBooking { ID_Booking = 12, ID_Room = 24 },
        new RoomBooking { ID_Booking = 13, ID_Room = 25 },
        new RoomBooking { ID_Booking = 13, ID_Room = 26 },
        new RoomBooking { ID_Booking = 14, ID_Room = 27 },
        new RoomBooking { ID_Booking = 14, ID_Room = 28 },
        new RoomBooking { ID_Booking = 15, ID_Room = 29 },
        new RoomBooking { ID_Booking = 15, ID_Room = 30 },
        new RoomBooking { ID_Booking = 16, ID_Room = 31 },
        new RoomBooking { ID_Booking = 16, ID_Room = 32 },
        new RoomBooking { ID_Booking = 17, ID_Room = 33 },
        new RoomBooking { ID_Booking = 17, ID_Room = 34 },
        new RoomBooking { ID_Booking = 18, ID_Room = 35 },
        new RoomBooking { ID_Booking = 18, ID_Room = 36 },
        new RoomBooking { ID_Booking = 19, ID_Room = 37 },
        new RoomBooking { ID_Booking = 19, ID_Room = 38 },
        new RoomBooking { ID_Booking = 20, ID_Room = 39 },
        new RoomBooking { ID_Booking = 20, ID_Room = 40 }

    });

            db.SaveChanges();
        }

        private static void PopulateBookings(ReserveSystemUsersDbContext db)
        {
            if (db.Booking.Any()) return;

            db.Booking.AddRange(new List<Booking>
    {
                new Booking { ID_Client = 1, CheckinDate = new DateTime(2025, 1, 10), CheckoutDate = new DateTime(2025, 1, 15), BookingDate = new DateTime(2025, 1, 1), BookingCode = "BK001", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 2, CheckinDate = new DateTime(2025, 2, 1), CheckoutDate = new DateTime(2025, 2, 5), BookingDate = new DateTime(2025, 1, 15), BookingCode = "BK002", TotalPersonsNumber = 4, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 3, CheckinDate = new DateTime(2025, 3, 20), CheckoutDate = new DateTime(2025, 3, 25), BookingDate = new DateTime(2025, 2, 20), BookingCode = "BK003", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 4, CheckinDate = new DateTime(2025, 4, 10), CheckoutDate = new DateTime(2025, 4, 15), BookingDate = new DateTime(2025, 4, 1), BookingCode = "BK004", TotalPersonsNumber = 1, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 5, CheckinDate = new DateTime(2025, 5, 10), CheckoutDate = new DateTime(2025, 5, 15), BookingDate = new DateTime(2025, 5, 1), BookingCode = "BK005", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 6, CheckinDate = new DateTime(2025, 6, 10), CheckoutDate = new DateTime(2025, 6, 15), BookingDate = new DateTime(2025, 6, 1), BookingCode = "BK006", TotalPersonsNumber = 5, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 7, CheckinDate = new DateTime(2025, 7, 1), CheckoutDate = new DateTime(2025, 7, 5), BookingDate = new DateTime(2025, 6, 20), BookingCode = "BK007", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 8, CheckinDate = new DateTime(2025, 8, 5), CheckoutDate = new DateTime(2025, 8, 10), BookingDate = new DateTime(2025, 7, 15), BookingCode = "BK008", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = false },
                new Booking { ID_Client = 9, CheckinDate = new DateTime(2025, 9, 10), CheckoutDate = new DateTime(2025, 9, 15), BookingDate = new DateTime(2025, 8, 1), BookingCode = "BK009", TotalPersonsNumber = 1, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 10, CheckinDate = new DateTime(2025, 10, 5), CheckoutDate = new DateTime(2025, 10, 10), BookingDate = new DateTime(2025, 9, 20), BookingCode = "BK010", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 1, CheckinDate = new DateTime(2025, 1, 10), CheckoutDate = new DateTime(2025, 1, 15), BookingDate = new DateTime(2025, 1, 1), BookingCode = "BK001", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 2, CheckinDate = new DateTime(2025, 2, 1), CheckoutDate = new DateTime(2025, 2, 5), BookingDate = new DateTime(2025, 1, 15), BookingCode = "BK002", TotalPersonsNumber = 4, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 3, CheckinDate = new DateTime(2025, 3, 20), CheckoutDate = new DateTime(2025, 3, 25), BookingDate = new DateTime(2025, 2, 20), BookingCode = "BK003", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 4, CheckinDate = new DateTime(2025, 4, 10), CheckoutDate = new DateTime(2025, 4, 15), BookingDate = new DateTime(2025, 4, 1), BookingCode = "BK004", TotalPersonsNumber = 1, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 5, CheckinDate = new DateTime(2025, 5, 10), CheckoutDate = new DateTime(2025, 5, 15), BookingDate = new DateTime(2025, 5, 1), BookingCode = "BK005", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 6, CheckinDate = new DateTime(2025, 6, 10), CheckoutDate = new DateTime(2025, 6, 15), BookingDate = new DateTime(2025, 6, 1), BookingCode = "BK006", TotalPersonsNumber = 5, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 7, CheckinDate = new DateTime(2025, 7, 1), CheckoutDate = new DateTime(2025, 7, 5), BookingDate = new DateTime(2025, 6, 20), BookingCode = "BK007", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 8, CheckinDate = new DateTime(2025, 8, 5), CheckoutDate = new DateTime(2025, 8, 10), BookingDate = new DateTime(2025, 7, 15), BookingCode = "BK008", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = false },
                new Booking { ID_Client = 9, CheckinDate = new DateTime(2025, 9, 10), CheckoutDate = new DateTime(2025, 9, 15), BookingDate = new DateTime(2025, 8, 1), BookingCode = "BK009", TotalPersonsNumber = 1, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 10, CheckinDate = new DateTime(2025, 10, 5), CheckoutDate = new DateTime(2025, 10, 10), BookingDate = new DateTime(2025, 9, 20), BookingCode = "BK010", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 11, CheckinDate = new DateTime(2025, 11, 1), CheckoutDate = new DateTime(2025, 11, 5), BookingDate = new DateTime(2025, 10, 15), BookingCode = "BK011", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 12, CheckinDate = new DateTime(2025, 12, 10), CheckoutDate = new DateTime(2025, 12, 15), BookingDate = new DateTime(2025, 11, 20), BookingCode = "BK012", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 13, CheckinDate = new DateTime(2025, 1, 20), CheckoutDate = new DateTime(2025, 1, 25), BookingDate = new DateTime(2025, 1, 10), BookingCode = "BK013", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 14, CheckinDate = new DateTime(2025, 2, 15), CheckoutDate = new DateTime(2025, 2, 20), BookingDate = new DateTime(2025, 2, 1), BookingCode = "BK014", TotalPersonsNumber = 1, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 15, CheckinDate = new DateTime(2025, 3, 25), CheckoutDate = new DateTime(2025, 3, 30), BookingDate = new DateTime(2025, 3, 10), BookingCode = "BK015", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 16, CheckinDate = new DateTime(2025, 4, 10), CheckoutDate = new DateTime(2025, 4, 15), BookingDate = new DateTime(2025, 3, 25), BookingCode = "BK016", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 17, CheckinDate = new DateTime(2025, 5, 1), CheckoutDate = new DateTime(2025, 5, 5), BookingDate = new DateTime(2025, 4, 15), BookingCode = "BK017", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 18, CheckinDate = new DateTime(2025, 6, 10), CheckoutDate = new DateTime(2025, 6, 15), BookingDate = new DateTime(2025, 5, 20), BookingCode = "BK018", TotalPersonsNumber = 5, PaymentStatus = false, Breakfast = false },
                new Booking { ID_Client = 19, CheckinDate = new DateTime(2025, 7, 20), CheckoutDate = new DateTime(2025, 7, 25), BookingDate = new DateTime(2025, 6, 10), BookingCode = "BK019", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 20, CheckinDate = new DateTime(2025, 8, 15), CheckoutDate = new DateTime(2025, 8, 20), BookingDate = new DateTime(2025, 7, 5), BookingCode = "BK020", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 21, CheckinDate = new DateTime(2025, 9, 10), CheckoutDate = new DateTime(2025, 9, 15), BookingDate = new DateTime(2025, 8, 25), BookingCode = "BK021", TotalPersonsNumber = 1, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 22, CheckinDate = new DateTime(2025, 10, 1), CheckoutDate = new DateTime(2025, 10, 5), BookingDate = new DateTime(2025, 9, 15), BookingCode = "BK022", TotalPersonsNumber = 3, PaymentStatus = false, Breakfast = false },
                new Booking { ID_Client = 23, CheckinDate = new DateTime(2025, 11, 20), CheckoutDate = new DateTime(2025, 11, 25), BookingDate = new DateTime(2025, 10, 5), BookingCode = "BK023", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 24, CheckinDate = new DateTime(2025, 12, 15), CheckoutDate = new DateTime(2025, 12, 20), BookingDate = new DateTime(2025, 11, 1), BookingCode = "BK024", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 25, CheckinDate = new DateTime(2025, 1, 10), CheckoutDate = new DateTime(2025, 1, 15), BookingDate = new DateTime(2025, 1, 1), BookingCode = "BK025", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 26, CheckinDate = new DateTime(2024, 12, 15), CheckoutDate = new DateTime(2024, 12, 20), BookingDate = new DateTime(2024, 11, 10), BookingCode = "BK026", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 27, CheckinDate = new DateTime(2025, 2, 1), CheckoutDate = new DateTime(2025, 2, 5), BookingDate = new DateTime(2025, 1, 10), BookingCode = "BK027", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 28, CheckinDate = new DateTime(2025, 3, 15), CheckoutDate = new DateTime(2025, 3, 20), BookingDate = new DateTime(2025, 2, 25), BookingCode = "BK028", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 29, CheckinDate = new DateTime(2025, 4, 5), CheckoutDate = new DateTime(2025, 4, 10), BookingDate = new DateTime(2025, 3, 15), BookingCode = "BK029", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 30, CheckinDate = new DateTime(2025, 5, 10), CheckoutDate = new DateTime(2025, 5, 15), BookingDate = new DateTime(2025, 4, 25), BookingCode = "BK030", TotalPersonsNumber = 5, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 31, CheckinDate = new DateTime(2025, 6, 1), CheckoutDate = new DateTime(2025, 6, 5), BookingDate = new DateTime(2025, 5, 10), BookingCode = "BK031", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 32, CheckinDate = new DateTime(2025, 7, 1), CheckoutDate = new DateTime(2025, 7, 5), BookingDate = new DateTime(2025, 6, 15), BookingCode = "BK032", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 33, CheckinDate = new DateTime(2025, 8, 20), CheckoutDate = new DateTime(2025, 8, 25), BookingDate = new DateTime(2025, 7, 10), BookingCode = "BK033", TotalPersonsNumber = 3, PaymentStatus = false, Breakfast = false },
                new Booking { ID_Client = 34, CheckinDate = new DateTime(2025, 9, 5), CheckoutDate = new DateTime(2025, 9, 10), BookingDate = new DateTime(2025, 8, 1), BookingCode = "BK034", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 35, CheckinDate = new DateTime(2025, 10, 15), CheckoutDate = new DateTime(2025, 10, 20), BookingDate = new DateTime(2025, 9, 5), BookingCode = "BK035", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 36, CheckinDate = new DateTime(2025, 11, 10), CheckoutDate = new DateTime(2025, 11, 15), BookingDate = new DateTime(2025, 10, 20), BookingCode = "BK036", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 37, CheckinDate = new DateTime(2025, 12, 1), CheckoutDate = new DateTime(2025, 12, 5), BookingDate = new DateTime(2025, 11, 10), BookingCode = "BK037", TotalPersonsNumber = 1, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 38, CheckinDate = new DateTime(2025, 1, 5), CheckoutDate = new DateTime(2025, 1, 10), BookingDate = new DateTime(2025, 1, 1), BookingCode = "BK038", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 39, CheckinDate = new DateTime(2025, 2, 20), CheckoutDate = new DateTime(2025, 2, 25), BookingDate = new DateTime(2025, 2, 5), BookingCode = "BK039", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 40, CheckinDate = new DateTime(2025, 3, 10), CheckoutDate = new DateTime(2025, 3, 15), BookingDate = new DateTime(2025, 2, 15), BookingCode = "BK040", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 41, CheckinDate = new DateTime(2025, 4, 5), CheckoutDate = new DateTime(2025, 4, 10), BookingDate = new DateTime(2025, 3, 20), BookingCode = "BK041", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 42, CheckinDate = new DateTime(2025, 5, 5), CheckoutDate = new DateTime(2025, 5, 10), BookingDate = new DateTime(2025, 4, 25), BookingCode = "BK042", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 43, CheckinDate = new DateTime(2025, 6, 10), CheckoutDate = new DateTime(2025, 6, 15), BookingDate = new DateTime(2025, 5, 30), BookingCode = "BK043", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = false },
                new Booking { ID_Client = 44, CheckinDate = new DateTime(2025, 7, 15), CheckoutDate = new DateTime(2025, 7, 20), BookingDate = new DateTime(2025, 7, 1), BookingCode = "BK044", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 45, CheckinDate = new DateTime(2025, 8, 5), CheckoutDate = new DateTime(2025, 8, 10), BookingDate = new DateTime(2025, 7, 20), BookingCode = "BK045", TotalPersonsNumber = 1, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 46, CheckinDate = new DateTime(2025, 9, 1), CheckoutDate = new DateTime(2025, 9, 5), BookingDate = new DateTime(2025, 8, 15), BookingCode = "BK046", TotalPersonsNumber = 3, PaymentStatus = false, Breakfast = false },
                new Booking { ID_Client = 47, CheckinDate = new DateTime(2025, 10, 10), CheckoutDate = new DateTime(2025, 10, 15), BookingDate = new DateTime(2025, 9, 25), BookingCode = "BK047", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 48, CheckinDate = new DateTime(2025, 11, 5), CheckoutDate = new DateTime(2025, 11, 10), BookingDate = new DateTime(2025, 10, 20), BookingCode = "BK048", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 49, CheckinDate = new DateTime(2025, 12, 1), CheckoutDate = new DateTime(2025, 12, 5), BookingDate = new DateTime(2025, 11, 15), BookingCode = "BK049", TotalPersonsNumber = 3, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 50, CheckinDate = new DateTime(2025, 1, 15), CheckoutDate = new DateTime(2025, 1, 20), BookingDate = new DateTime(2025, 1, 5), BookingCode = "BK050", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 51, CheckinDate = new DateTime(2025, 2, 10), CheckoutDate = new DateTime(2025, 2, 15), BookingDate = new DateTime(2025, 1, 25), BookingCode = "BK051", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 52, CheckinDate = new DateTime(2025, 3, 25), CheckoutDate = new DateTime(2025, 3, 30), BookingDate = new DateTime(2025, 3, 1), BookingCode = "BK052", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = false },
                new Booking { ID_Client = 53, CheckinDate = new DateTime(2025, 4, 10), CheckoutDate = new DateTime(2025, 4, 15), BookingDate = new DateTime(2025, 3, 25), BookingCode = "BK053", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 54, CheckinDate = new DateTime(2025, 5, 15), CheckoutDate = new DateTime(2025, 5, 20), BookingDate = new DateTime(2025, 4, 30), BookingCode = "BK054", TotalPersonsNumber = 1, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 55, CheckinDate = new DateTime(2025, 6, 1), CheckoutDate = new DateTime(2025, 6, 5), BookingDate = new DateTime(2025, 5, 10), BookingCode = "BK055", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 56, CheckinDate = new DateTime(2025, 7, 1), CheckoutDate = new DateTime(2025, 7, 5), BookingDate = new DateTime(2025, 6, 10), BookingCode = "BK056", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 57, CheckinDate = new DateTime(2025, 8, 10), CheckoutDate = new DateTime(2025, 8, 15), BookingDate = new DateTime(2025, 7, 25), BookingCode = "BK057", TotalPersonsNumber = 3, PaymentStatus = false, Breakfast = false },
                new Booking { ID_Client = 58, CheckinDate = new DateTime(2025, 9, 20), CheckoutDate = new DateTime(2025, 9, 25), BookingDate = new DateTime(2025, 9, 1), BookingCode = "BK058", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 59, CheckinDate = new DateTime(2025, 10, 5), CheckoutDate = new DateTime(2025, 10, 10), BookingDate = new DateTime(2025, 9, 15), BookingCode = "BK059", TotalPersonsNumber = 5, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 60, CheckinDate = new DateTime(2025, 11, 1), CheckoutDate = new DateTime(2025, 11, 5), BookingDate = new DateTime(2025, 10, 20), BookingCode = "BK060", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 61, CheckinDate = new DateTime(2025, 12, 10), CheckoutDate = new DateTime(2025, 12, 15), BookingDate = new DateTime(2025, 11, 25), BookingCode = "BK061", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 62, CheckinDate = new DateTime(2025, 1, 20), CheckoutDate = new DateTime(2025, 1, 25), BookingDate = new DateTime(2025, 1, 15), BookingCode = "BK062", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 63, CheckinDate = new DateTime(2025, 2, 15), CheckoutDate = new DateTime(2025, 2, 20), BookingDate = new DateTime(2025, 2, 5), BookingCode = "BK063", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 64, CheckinDate = new DateTime(2025, 3, 5), CheckoutDate = new DateTime(2025, 3, 10), BookingDate = new DateTime(2025, 2, 28), BookingCode = "BK064", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 65, CheckinDate = new DateTime(2025, 4, 10), CheckoutDate = new DateTime(2025, 4, 15), BookingDate = new DateTime(2025, 3, 25), BookingCode = "BK065", TotalPersonsNumber = 3, PaymentStatus = false, Breakfast = false },
                new Booking { ID_Client = 66, CheckinDate = new DateTime(2025, 5, 15), CheckoutDate = new DateTime(2025, 5, 20), BookingDate = new DateTime(2025, 4, 30), BookingCode = "BK066", TotalPersonsNumber = 1, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 67, CheckinDate = new DateTime(2025, 6, 5), CheckoutDate = new DateTime(2025, 6, 10), BookingDate = new DateTime(2025, 5, 20), BookingCode = "BK067", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 68, CheckinDate = new DateTime(2025, 7, 1), CheckoutDate = new DateTime(2025, 7, 5), BookingDate = new DateTime(2025, 6, 15), BookingCode = "BK068", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 69, CheckinDate = new DateTime(2025, 8, 15), CheckoutDate = new DateTime(2025, 8, 20), BookingDate = new DateTime(2025, 8, 1), BookingCode = "BK069", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 70, CheckinDate = new DateTime(2025, 9, 5), CheckoutDate = new DateTime(2025, 9, 10), BookingDate = new DateTime(2025, 8, 15), BookingCode = "BK070", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 71, CheckinDate = new DateTime(2025, 10, 10), CheckoutDate = new DateTime(2025, 10, 15), BookingDate = new DateTime(2024, 9, 25), BookingCode = "BK071", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 72, CheckinDate = new DateTime(2025, 11, 1), CheckoutDate = new DateTime(2025, 11, 5), BookingDate = new DateTime(2024, 10, 15), BookingCode = "BK072", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 73, CheckinDate = new DateTime(2025, 12, 5), CheckoutDate = new DateTime(2025, 12, 10), BookingDate = new DateTime(2024, 11, 20), BookingCode = "BK073", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 74, CheckinDate = new DateTime(2025, 1, 15), CheckoutDate = new DateTime(2025, 1, 20), BookingDate = new DateTime(2024, 12, 5), BookingCode = "BK074", TotalPersonsNumber = 1, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 75, CheckinDate = new DateTime(2025, 2, 20), CheckoutDate = new DateTime(2025, 2, 25), BookingDate = new DateTime(2025, 1, 10), BookingCode = "BK075", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 76, CheckinDate = new DateTime(2025, 3, 15), CheckoutDate = new DateTime(2025, 3, 20), BookingDate = new DateTime(2025, 2, 5), BookingCode = "BK076", TotalPersonsNumber = 4, PaymentStatus = false, Breakfast = false },
                new Booking { ID_Client = 77, CheckinDate = new DateTime(2025, 4, 25), CheckoutDate = new DateTime(2025, 4, 30), BookingDate = new DateTime(2025, 3, 15), BookingCode = "BK077", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 78, CheckinDate = new DateTime(2025, 5, 5), CheckoutDate = new DateTime(2025, 5, 10), BookingDate = new DateTime(2025, 4, 20), BookingCode = "BK078", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 79, CheckinDate = new DateTime(2025, 6, 1), CheckoutDate = new DateTime(2025, 6, 5), BookingDate = new DateTime(2025, 5, 15), BookingCode = "BK079", TotalPersonsNumber = 4, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 80, CheckinDate = new DateTime(2025, 7, 1), CheckoutDate = new DateTime(2025, 7, 10), BookingDate = new DateTime(2025, 6, 25), BookingCode = "BK080", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 81, CheckinDate = new DateTime(2025, 8, 15), CheckoutDate = new DateTime(2025, 8, 20), BookingDate = new DateTime(2025, 7, 5), BookingCode = "BK081", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 82, CheckinDate = new DateTime(2025, 9, 10), CheckoutDate = new DateTime(2025, 9, 15), BookingDate = new DateTime(2025, 8, 25), BookingCode = "BK082", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 83, CheckinDate = new DateTime(2025, 10, 1), CheckoutDate = new DateTime(2025, 10, 5), BookingDate = new DateTime(2025, 9, 10), BookingCode = "BK083", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 84, CheckinDate = new DateTime(2025, 11, 10), CheckoutDate = new DateTime(2025, 11, 15), BookingDate = new DateTime(2025, 10, 1), BookingCode = "BK084", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 85, CheckinDate = new DateTime(2025, 12, 15), CheckoutDate = new DateTime(2025, 12, 20), BookingDate = new DateTime(2025, 11, 1), BookingCode = "BK085", TotalPersonsNumber = 3, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 86, CheckinDate = new DateTime(2024, 5, 15), CheckoutDate = new DateTime(2024, 5, 20), BookingDate = new DateTime(2024, 3, 10), BookingCode = "BK086", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 87, CheckinDate = new DateTime(2024, 6, 1), CheckoutDate = new DateTime(2024, 6, 5), BookingDate = new DateTime(2024, 4, 15), BookingCode = "BK087", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 88, CheckinDate = new DateTime(2024, 7, 5), CheckoutDate = new DateTime(2024, 7, 10), BookingDate = new DateTime(2024, 5, 20), BookingCode = "BK088", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 89, CheckinDate = new DateTime(2024, 8, 10), CheckoutDate = new DateTime(2024, 8, 15), BookingDate = new DateTime(2024, 6, 30), BookingCode = "BK089", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 90, CheckinDate = new DateTime(2024, 9, 1), CheckoutDate = new DateTime(2024, 9, 5), BookingDate = new DateTime(2024, 7, 10), BookingCode = "BK090", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 91, CheckinDate = new DateTime(2024, 10, 20), CheckoutDate = new DateTime(2024, 10, 25), BookingDate = new DateTime(2024, 8, 5), BookingCode = "BK091", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 92, CheckinDate = new DateTime(2024, 11, 5), CheckoutDate = new DateTime(2024, 11, 10), BookingDate = new DateTime(2024, 9, 1), BookingCode = "BK092", TotalPersonsNumber = 4, PaymentStatus = false, Breakfast = true },
                new Booking { ID_Client = 93, CheckinDate = new DateTime(2024, 12, 1), CheckoutDate = new DateTime(2024, 12, 5), BookingDate = new DateTime(2024, 10, 10), BookingCode = "BK093", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 94, CheckinDate = new DateTime(2025, 1, 10), CheckoutDate = new DateTime(2025, 1, 15), BookingDate = new DateTime(2024, 11, 5), BookingCode = "BK094", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 95, CheckinDate = new DateTime(2025, 2, 1), CheckoutDate = new DateTime(2025, 2, 5), BookingDate = new DateTime(2024, 12, 10), BookingCode = "BK095", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 96, CheckinDate = new DateTime(2023, 11, 15), CheckoutDate = new DateTime(2023, 11, 20), BookingDate = new DateTime(2023, 9, 5), BookingCode = "BK096", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 97, CheckinDate = new DateTime(2024, 1, 25), CheckoutDate = new DateTime(2024, 1, 30), BookingDate = new DateTime(2023, 11, 15), BookingCode = "BK097", TotalPersonsNumber = 3, PaymentStatus = false, Breakfast = false },
                new Booking { ID_Client = 98, CheckinDate = new DateTime(2024, 2, 15), CheckoutDate = new DateTime(2024, 2, 20), BookingDate = new DateTime(2023, 12, 5), BookingCode = "BK098", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 99, CheckinDate = new DateTime(2024, 3, 10), CheckoutDate = new DateTime(2024, 3, 15), BookingDate = new DateTime(2024, 1, 20), BookingCode = "BK099", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 100, CheckinDate = new DateTime(2024, 4, 5), CheckoutDate = new DateTime(2024, 4, 10), BookingDate = new DateTime(2024, 2, 10), BookingCode = "BK100", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 101, CheckinDate = new DateTime(2024, 5, 1), CheckoutDate = new DateTime(2024, 5, 6), BookingDate = new DateTime(2024, 3, 15), BookingCode = "BK101", TotalPersonsNumber = 4, PaymentStatus = false, Breakfast = false },
                new Booking { ID_Client = 102, CheckinDate = new DateTime(2024, 6, 10), CheckoutDate = new DateTime(2024, 6, 15), BookingDate = new DateTime(2024, 4, 5), BookingCode = "BK102", TotalPersonsNumber = 2, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 103, CheckinDate = new DateTime(2024, 7, 20), CheckoutDate = new DateTime(2024, 7, 25), BookingDate = new DateTime(2024, 5, 1), BookingCode = "BK103", TotalPersonsNumber = 3, PaymentStatus = true, Breakfast = false },
                new Booking { ID_Client = 104, CheckinDate = new DateTime(2024, 8, 15), CheckoutDate = new DateTime(2024, 8, 20), BookingDate = new DateTime(2024, 6, 10), BookingCode = "BK104", TotalPersonsNumber = 4, PaymentStatus = true, Breakfast = true },
                new Booking { ID_Client = 105, CheckinDate = new DateTime(2024, 9, 25), CheckoutDate = new DateTime(2024, 9, 30), BookingDate = new DateTime(2024, 7, 5), BookingCode = "BK105", TotalPersonsNumber = 2, PaymentStatus = false, Breakfast = true }
                        });

            db.SaveChanges();
        }

        private static void PopulateRooms(ReserveSystemUsersDbContext db)
        {
            if (db.Room.Any()) return;

            db.Room.AddRange(new List<Room>
       {
        new Room { RoomTypeId = 1 },
        new Room { RoomTypeId = 2 },
        new Room { RoomTypeId = 1 },
        new Room { RoomTypeId = 3 },
        new Room { RoomTypeId = 2 },
        new Room { RoomTypeId = 4 },
        new Room { RoomTypeId = 3 },
        new Room { RoomTypeId = 1 },
        new Room { RoomTypeId = 4 },
        new Room { RoomTypeId = 2 },
        new Room { RoomTypeId = 3 },
        new Room { RoomTypeId = 1 },
        new Room { RoomTypeId = 2 },
        new Room { RoomTypeId = 4 },
        new Room { RoomTypeId = 1 },
        new Room { RoomTypeId = 3 },
        new Room { RoomTypeId = 4 },
        new Room { RoomTypeId = 2 },
        new Room { RoomTypeId = 1 },
        new Room { RoomTypeId = 3 },
        new Room { RoomTypeId = 4 },
        new Room { RoomTypeId = 2 },
        new Room { RoomTypeId = 1 },
        new Room { RoomTypeId = 4 },
        new Room { RoomTypeId = 3 },
        new Room { RoomTypeId = 2 },
        new Room { RoomTypeId = 1 },
        new Room { RoomTypeId = 4 },
        new Room { RoomTypeId = 3 },
        new Room { RoomTypeId = 2 },
        new Room { RoomTypeId = 1 },
        new Room { RoomTypeId = 4 },
        new Room { RoomTypeId = 2 },
        new Room { RoomTypeId = 3 },
        new Room { RoomTypeId = 1 },
        new Room { RoomTypeId = 4 },
        new Room { RoomTypeId = 3 },
        new Room { RoomTypeId = 2 },
        new Room { RoomTypeId = 1 },
        new Room { RoomTypeId = 4 },
        new Room { RoomTypeId = 2 },
        new Room { RoomTypeId = 3 },
        new Room { RoomTypeId = 1 },
        new Room { RoomTypeId = 4 }

    });

            db.SaveChanges();
        }



    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReserveSystem.Data;
using ReserveSystem.Models;
using System;
using System.Linq;
using ReserveSystem.Utils;

namespace ReserveSystem.Models
{
    public static class SeedData
    {
        internal static void Populate(ReserveSystemContext? db) {
            // Check if database is already populated, if so, skip
            if (db != null) return;
            
            // Ensure database is created, if not, create it
            db!.Database.EnsureCreated();
            
            // Populate database with sample data
            PopulateJobs(db);
            PopulateStaffs(db);
            PopulateSchedules(db);
            PopulateClients(db);
            PopulateRooms(db);
            PopulateRoomServices(db);
            PopulateRoomServiceBookings(db);
        }

        internal static async void PopulateUsers(UserManager<IdentityUser> userManager) {
            await EnsureUserIsCreatedAsync(userManager, "john@ipg.pt", "Secret$123");
        }

        internal static void PopulateDefaultAdmin(UserManager<IdentityUser> userManager) {
            EnsureUserIsCreatedAsync(userManager, "admin@ipg.pt", "Secret$123").Wait();
        }

        private static async Task EnsureUserIsCreatedAsync(UserManager<IdentityUser> userManager, string username, string password) {
            var user = await userManager.FindByNameAsync(username);

            if (user == null) {
                user = new IdentityUser(username);
                await userManager.CreateAsync(user, password);
            }
        }

        private static void PopulateJobs(ReserveSystemContext context)
        {
            context.Job.AddRange(
                new Job { Name = "Room Cleaner", Description = "Maintains cleanliness and hygiene standards in guest rooms" },
                new Job { Name = "Room Service Attendant", Description = "Delivers food, beverages and amenities to guest rooms" },
                new Job { Name = "Maintenance Technician", Description = "Performs repairs and preventive maintenance" },
                new Job { Name = "Housekeeping Supervisor", Description = "Manages cleaning staff and quality assurance" },
                new Job { Name = "Food Service Manager", Description = "Oversees room service kitchen and menu planning" },
                new Job { Name = "Laundry Specialist", Description = "Handles guest laundry and linen services" },
                new Job { Name = "Mini Bar Attendant", Description = "Restocks and maintains room mini bars" },
                new Job { Name = "Guest Services Coordinator", Description = "Coordinates special requests and VIP services" }
            );
            context.SaveChanges();
        }

        private static void PopulateStaffs(ReserveSystemContext context)
        {
            var jobs = context.Job.ToList();
            if (jobs.Count != 0)
            {
                var staffList = new List<Staff>();
                var random = new Random();

                // First names and last names for generating combinations
                string[] firstNames = [ "James", "Mary", "John", "Patricia", "Robert", "Jennifer", "Michael", "Linda", "William", "Elizabeth", 
                                    "David", "Barbara", "Richard", "Susan", "Joseph", "Jessica", "Thomas", "Sarah", "Charles", "Karen",
                                    "Ana", "João", "Maria", "Pedro", "Sofia", "Miguel", "Inês", "André", "Beatriz", "Tiago" ];
                
                string[] lastNames = [ "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
                                    "Silva", "Santos", "Ferreira", "Pereira", "Costa", "Carvalho", "Almeida", "Rodrigues", "Ribeiro", "Pinto" ];

                for (int i = 0; i < 20; i++)
                {
                    var startDate = DateOnly.FromDateTime(DateTime.Today.AddYears(random.Next(-5, 0)).AddMonths(random.Next(-11, 0)));
                    var contractLength = random.Next(1, 4); // 1-3 year contracts
                    var name = $"{firstNames[random.Next(firstNames.Length)]} {lastNames[random.Next(lastNames.Length)]}";

                    staffList.Add(new Staff
                    {
                        Name = name,
                        JobId = jobs[random.Next(jobs.Count)].Id,
                        Email = $"{name}{i + 1}@hotel.com",
                        Phone = $"+351 9{random.Next(10, 99)} {random.Next(100, 999)} {random.Next(100, 999)}",
                        Password = PasswordGenerator.GenerateSecurePassword(),
                        ContractStartDate = startDate,
                        ContractExpiryDate = startDate.AddYears(contractLength),
                        VacationDays = random.Next(15, 26)  // 15-25 vacation days
                    });
                }
                context.Staff.AddRange(staffList);
                context.SaveChanges();
            }
        }

        private static void PopulateSchedules(ReserveSystemContext context)
        {
            // Get first staff member for demo
            var staff = context.Staff.FirstOrDefault();
            if (staff != null)
            {
                context.Schedule.AddRange(
                    new Schedule
                    {
                        StaffId = staff.Id,
                        Date = DateOnly.FromDateTime(DateTime.Today),
                        ShiftStart = new TimeSpan(9, 0, 0),
                        ShiftEnd = new TimeSpan(17, 0, 0),
                        Available = true,
                        Present = true
                    },
                    new Schedule
                    {
                        StaffId = staff.Id,
                        Date = DateOnly.FromDateTime(DateTime.Today.AddDays(1)),
                        ShiftStart = new TimeSpan(9, 0, 0),
                        ShiftEnd = new TimeSpan(17, 0, 0),
                        Available = true,
                        Present = false
                    }
                );
                context.SaveChanges();
            }
        }

        private static void PopulateClients(ReserveSystemContext context)
        {
            var clientList = new List<Client>();
            var random = new Random();

            string[] firstNames = [ "Oliver", "Emma", "Lucas", "Ava", "Liam", "Sophia", "Noah", "Isabella", "Ethan", "Mia",
                                "Mason", "Charlotte", "Logan", "Amelia", "Elijah", "Harper", "James", "Evelyn", "Alexander", "Abigail",
                                "António", "Mariana", "Francisco", "Carolina", "Guilherme", "Diana", "Duarte", "Catarina", "Eduardo", "Leonor" ];

            string[] lastNames = [ "Anderson", "Wilson", "Taylor", "Moore", "Jackson", "Martin", "Lee", "Thompson", "White", "Harris",
                                "Oliveira", "Sousa", "Fernandes", "Martins", "Gonçalves", "Gomes", "Lopes", "Marques", "Correia", "Nunes" ];

            string[] streets = [ "Main St", "Oak Avenue", "Pine Road", "Maple Lane", "Cedar Street", "Elm Court", "River Road", "Lake Drive",
                                "Rua Augusta", "Avenida da Liberdade", "Rua do Carmo", "Avenida Roma", "Rua Castilho", "Avenida Almirante Reis" ];

            string[] cities = ["Lisbon", "Porto", "Coimbra", "Braga", "Faro", "Aveiro", "Évora", "Funchal", "Lagos", "Cascais"];

            for (int i = 0; i < 30; i++)
            {
                var streetNum = random.Next(1, 999);
                var streetName = streets[random.Next(streets.Length)];
                var city = cities[random.Next(cities.Length)];

                clientList.Add(new Client
                {
                    Name = $"{firstNames[random.Next(firstNames.Length)]} {lastNames[random.Next(lastNames.Length)]}",
                    Email = $"client{i + 1}@email.com",
                    Phone = $"+351 9{random.Next(10, 99)} {random.Next(100, 999)} {random.Next(100, 999)}",
                    Address = $"{streetNum} {streetName}, {city}",
                    Nif = random.Next(100000000, 999999999).ToString()
                });
            }
            context.Client.AddRange(clientList);
            context.SaveChanges();
        }

        private static void PopulateRooms(ReserveSystemContext context)
        {
            var roomList = new List<Room>();
            string[] roomTypes = [ "Standard Single", "Standard Double", "Deluxe Single", "Deluxe Double", 
                                "Junior Suite", "Executive Suite", "Family Suite", "Presidential Suite" ];

            // Generate rooms for 4 floors (1-4), 10 rooms per floor
            for (int floor = 1; floor <= 4; floor++)
            {
                for (int room = 1; room <= 10; room++)
                {
                    roomList.Add(new Room
                    {
                        Number = $"{floor}{room:D2}", // This ensures unique room numbers like 101, 102, etc.
                        Type = roomTypes[(floor * room - 1) % roomTypes.Length]
                    });
                }
            }
            context.Room.AddRange(roomList);
            context.SaveChanges();
        }

        private static void PopulateRoomServices(ReserveSystemContext context)
        {
            var jobs = context.Job.ToList();
            if (jobs.Count != 0)
            {
                context.RoomService.AddRange(
                    // Cleaning Services
                    new RoomService
                    {
                        Name = "Standard Room Cleaning",
                        Description = "Daily cleaning service including bed making and bathroom sanitization",
                        JobId = jobs[jobs.FindIndex(j => j.Name.Contains("Cleaner"))].Id,
                        Price = 30.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 1
                    },
                    new RoomService
                    {
                        Name = "Deep Cleaning",
                        Description = "Thorough cleaning including upholstery, carpets, and windows",
                        JobId = jobs[jobs.FindIndex(j => j.Name.Contains("Cleaner"))].Id,
                        Price = 75.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 3
                    },
                    // Food Services
                    new RoomService
                    {
                        Name = "Breakfast Service",
                        Description = "Continental or American breakfast delivered to room",
                        JobId = jobs[jobs.FindIndex(j => j.Name.Contains("Service"))].Id,
                        Price = 25.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 1
                    },
                    new RoomService
                    {
                        Name = "Lunch Service",
                        Description = "Lunch menu with local and international options",
                        JobId = jobs[jobs.FindIndex(j => j.Name.Contains("Service"))].Id,
                        Price = 35.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 1
                    },
                    new RoomService
                    {
                        Name = "Dinner Service",
                        Description = "Fine dining experience in your room",
                        JobId = jobs[jobs.FindIndex(j => j.Name.Contains("Service"))].Id,
                        Price = 45.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 2
                    },
                    // Maintenance Services
                    new RoomService
                    {
                        Name = "Basic Maintenance",
                        Description = "Quick fixes and minor repairs",
                        JobId = jobs[jobs.FindIndex(j => j.Name.Contains("Technician"))].Id,
                        Price = 40.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 1
                    },
                    new RoomService
                    {
                        Name = "Technical Support",
                        Description = "TV, Wi-Fi, and electronic device assistance",
                        JobId = jobs[jobs.FindIndex(j => j.Name.Contains("Technician"))].Id,
                        Price = 35.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 1
                    },
                    // Additional Services
                    new RoomService
                    {
                        Name = "Laundry Service",
                        Description = "Same-day laundry and pressing service",
                        JobId = jobs[jobs.FindIndex(j => j.Name.Contains("Specialist"))].Id,
                        Price = 50.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 4
                    },
                    new RoomService
                    {
                        Name = "Mini Bar Restock",
                        Description = "Replenishment of mini bar items",
                        JobId = jobs[jobs.FindIndex(j => j.Name.Contains("Mini Bar Attendant"))].Id,
                        Price = 20.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 1
                    },
                    new RoomService
                    {
                        Name = "VIP Welcome Package",
                        Description = "Premium welcome amenities and personalized service",
                        JobId = jobs[jobs.FindIndex(j => j.Name.Contains("Coordinator"))].Id,
                        Price = 100.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 2
                    }
                );
                context.SaveChanges();
            }
        }

        private static void PopulateRoomServiceBookings(ReserveSystemContext context)
        {
            // First check if we have all required data
            if (!context.RoomService.Any() || !context.Staff.Any() || 
                !context.Client.Any() || !context.Room.Any())
            {
                return; // Can't create bookings without related data
            }

            // Load required data
            var services = context.RoomService.ToList();
            var staffs = context.Staff.ToList();
            var clients = context.Client.ToList();
            var rooms = context.Room.ToList();

            var random = new Random();
            var bookings = new List<RoomServiceBooking>();
            var now = DateTime.Now;
            var startDate = now.AddDays(-90); // 3 months ago
            var endDate = now.AddDays(30);    // 1 month in future
            var nBookings = 100; // Reduced from 1000 to prevent overload

            // Generate nBookings bookings over a 4-month period
            for (int i = 0; i < nBookings; i++)
            {
                // More frequent bookings for certain services
                var eligibleServices = services.Where(s => 
                    s.Name.Contains("Cleaning", StringComparison.OrdinalIgnoreCase) || 
                    s.Name.Contains("Service", StringComparison.OrdinalIgnoreCase)).ToList();

                if (eligibleServices.Count == 0)
                    eligibleServices = services; // Fallback if no eligible services found

                var service = random.Next(100) < 70 && eligibleServices.Any() ? 
                    eligibleServices[random.Next(eligibleServices.Count)] : 
                    services[random.Next(services.Count)];

                // Staff assignment based on job type
                var eligibleStaff = staffs.Where(s => s.JobId == service.JobId).ToList();
                if (eligibleStaff.Count == 0)
                    eligibleStaff = staffs; // Fallback if no eligible staff found
                
                var staff = eligibleStaff[random.Next(eligibleStaff.Count)];
                var client = clients[random.Next(clients.Count)];

                // Room assignment with floor patterns
                var roomFloor = random.Next(1, 5);
                var eligibleRooms = rooms.Where(r => r.Number.StartsWith(roomFloor.ToString())).ToList();
                if (eligibleRooms.Count == 0)
                    eligibleRooms = rooms; // Fallback if no eligible rooms found
                    
                var room = eligibleRooms[random.Next(eligibleRooms.Count)];

                // Rest of the booking generation logic...
                var timeSpan = endDate - startDate;
                var randomDays = random.Next((int)timeSpan.TotalDays);
                var bookingDate = startDate.AddDays(randomDays);
                
                var serviceDuration = service.ServiceLimitHours > 0 ? 
                    service.ServiceLimitHours : 
                    random.Next(1, 4);

                var serviceStartDate = bookingDate;
                var serviceEndDate = service.Name.Contains("Deep") || service.Name.Contains("VIP") ? 
                    bookingDate.AddDays(random.Next(2, 4)) : 
                    bookingDate.AddDays(random.Next(0, 2));

                var isInPast = serviceStartDate < now;
                var isHighPriority = service.Price > 50;
                var isConfirmed = isInPast || (isHighPriority ? random.Next(100) < 90 : random.Next(100) < 70);
                var isPaid = isInPast ? random.Next(100) < 95 : (isHighPriority ? random.Next(100) < 80 : random.Next(100) < 60);

                var hasFeedback = isInPast && isPaid && random.Next(100) < 70;
                var baseRating = isHighPriority ? 4 : 3;
                int? feedback = hasFeedback ? random.Next(baseRating, 6) : null;

                var basePrice = service.Price;
                var priceMultiplier = 1.0m;
                
                if (serviceEndDate > serviceStartDate)
                    priceMultiplier += 0.1m * (decimal)(serviceEndDate - serviceStartDate).TotalHours;
                if (isHighPriority)
                    priceMultiplier += 0.15m;
                if (room.Type.Contains("Suite"))
                    priceMultiplier += 0.2m;

                var finalPrice = basePrice * serviceDuration * priceMultiplier;

                bookings.Add(new RoomServiceBooking
                {
                    RoomServiceId = service.Id,
                    StaffId = staff.Id,
                    ClientId = client.Id,
                    RoomId = room.Id,
                    DateTime = bookingDate,
                    StartDate = serviceStartDate,
                    EndDate = serviceEndDate,
                    BookedState = true,
                    StaffConfirmation = isConfirmed,
                    ClientFeedback = feedback,
                    ValueToPay = Math.Round(finalPrice, 2),
                    PaymentDone = isPaid
                });
            }

            // Add all bookings in one batch
            context.RoomServiceBooking.AddRange(bookings);
            context.SaveChanges();
        }
    }
}
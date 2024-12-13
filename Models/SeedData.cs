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
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ReserveSystemContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ReserveSystemContext>>()))
            {
                // Look for any RoomServiceBookings.
                if (context.RoomServiceBooking.Any())
                {
                    return;   // DB has already been seeded
                }

                PopulateJobs(context);
                PopulateStaffs(context);
                PopulateSchedules(context);
                PopulateClients(context);
                PopulateRooms(context);
                PopulateRoomServices(context);
                PopulateRoomServiceBookings(context);
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
            if (jobs.Any())
            {
                var staffList = new List<Staff>();
                var random = new Random();

                // First names and last names for generating combinations
                string[] firstNames = { "James", "Mary", "John", "Patricia", "Robert", "Jennifer", "Michael", "Linda", "William", "Elizabeth", 
                                    "David", "Barbara", "Richard", "Susan", "Joseph", "Jessica", "Thomas", "Sarah", "Charles", "Karen",
                                    "Ana", "João", "Maria", "Pedro", "Sofia", "Miguel", "Inês", "André", "Beatriz", "Tiago" };
                
                string[] lastNames = { "Smith", "Johnson", "Williams", "Brown", "Jones", "Garcia", "Miller", "Davis", "Rodriguez", "Martinez",
                                    "Silva", "Santos", "Ferreira", "Pereira", "Costa", "Carvalho", "Almeida", "Rodrigues", "Ribeiro", "Pinto" };

                for (int i = 0; i < 20; i++)
                {
                    var startDate = DateOnly.FromDateTime(DateTime.Today.AddYears(random.Next(-5, 0)).AddMonths(random.Next(-11, 0)));
                    var contractLength = random.Next(1, 4); // 1-3 year contracts

                    staffList.Add(new Staff
                    {
                        Name = $"{firstNames[random.Next(firstNames.Length)]} {lastNames[random.Next(lastNames.Length)]}",
                        JobId = jobs[random.Next(jobs.Count)].Id,
                        Email = $"staff{i + 1}@hotel.com",
                        Phone = $"+351 9{random.Next(10, 99)} {random.Next(100, 999)} {random.Next(100, 999)}",
                        Password = "StaffPass123!",
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

            string[] firstNames = { "Oliver", "Emma", "Lucas", "Ava", "Liam", "Sophia", "Noah", "Isabella", "Ethan", "Mia",
                                "Mason", "Charlotte", "Logan", "Amelia", "Elijah", "Harper", "James", "Evelyn", "Alexander", "Abigail",
                                "António", "Mariana", "Francisco", "Carolina", "Guilherme", "Diana", "Duarte", "Catarina", "Eduardo", "Leonor" };

            string[] lastNames = { "Anderson", "Wilson", "Taylor", "Moore", "Jackson", "Martin", "Lee", "Thompson", "White", "Harris",
                                "Oliveira", "Sousa", "Fernandes", "Martins", "Gonçalves", "Gomes", "Lopes", "Marques", "Correia", "Nunes" };

            string[] streets = { "Main St", "Oak Avenue", "Pine Road", "Maple Lane", "Cedar Street", "Elm Court", "River Road", "Lake Drive",
                                "Rua Augusta", "Avenida da Liberdade", "Rua do Carmo", "Avenida Roma", "Rua Castilho", "Avenida Almirante Reis" };

            string[] cities = { "Lisbon", "Porto", "Coimbra", "Braga", "Faro", "Aveiro", "Évora", "Funchal", "Lagos", "Cascais" };

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
            string[] roomTypes = { "Standard Single", "Standard Double", "Deluxe Single", "Deluxe Double", 
                                "Junior Suite", "Executive Suite", "Family Suite", "Presidential Suite" };

            // Generate rooms for 4 floors (1-4), 10 rooms per floor
            for (int floor = 1; floor <= 4; floor++)
            {
                for (int room = 1; room <= 10; room++)
                {
                    var roomNumber = $"{floor}{room:D02}";  // Format: floor + room number (e.g., 101, 102...)
                    var roomType = roomTypes[room % 8];  // Cycle through room types

                    roomList.Add(new Room
                    {
                        Number = roomNumber,
                        Type = roomType
                    });
                }
            }
            context.Room.AddRange(roomList);
            context.SaveChanges();
        }

        private static void PopulateRoomServices(ReserveSystemContext context)
        {
            var jobs = context.Job.ToList();
            if (jobs.Any())
            {
                context.RoomService.AddRange(
                    // Cleaning Services
                    new RoomService
                    {
                        Name = "Standard Room Cleaning",
                        Description = "Daily cleaning service including bed making and bathroom sanitization",
                        JobId = jobs[0].Id,
                        Price = 30.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 1
                    },
                    new RoomService
                    {
                        Name = "Deep Cleaning",
                        Description = "Thorough cleaning including upholstery, carpets, and windows",
                        JobId = jobs[0].Id,
                        Price = 75.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 3
                    },
                    // Food Services
                    new RoomService
                    {
                        Name = "Breakfast Service",
                        Description = "Continental or American breakfast delivered to room",
                        JobId = jobs[1].Id,
                        Price = 25.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 1
                    },
                    new RoomService
                    {
                        Name = "Lunch Service",
                        Description = "Lunch menu with local and international options",
                        JobId = jobs[1].Id,
                        Price = 35.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 1
                    },
                    new RoomService
                    {
                        Name = "Dinner Service",
                        Description = "Fine dining experience in your room",
                        JobId = jobs[1].Id,
                        Price = 45.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 2
                    },
                    // Maintenance Services
                    new RoomService
                    {
                        Name = "Basic Maintenance",
                        Description = "Quick fixes and minor repairs",
                        JobId = jobs[2].Id,
                        Price = 40.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 1
                    },
                    new RoomService
                    {
                        Name = "Technical Support",
                        Description = "TV, Wi-Fi, and electronic device assistance",
                        JobId = jobs[2].Id,
                        Price = 35.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 1
                    },
                    // Additional Services
                    new RoomService
                    {
                        Name = "Laundry Service",
                        Description = "Same-day laundry and pressing service",
                        JobId = jobs[5].Id,
                        Price = 50.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 4
                    },
                    new RoomService
                    {
                        Name = "Mini Bar Restock",
                        Description = "Replenishment of mini bar items",
                        JobId = jobs[6].Id,
                        Price = 20.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 1
                    },
                    new RoomService
                    {
                        Name = "VIP Welcome Package",
                        Description = "Premium welcome amenities and personalized service",
                        JobId = jobs[7].Id,
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

            // Remove this check since we just dropped the database
            // var rsb = context.RoomServiceBooking.ToList();
            // if (rsb.Count != 0) return;

            var random = new Random();
            var bookings = new List<RoomServiceBooking>();
            var now = DateTime.Now;
            var startDate = now.AddDays(-90); // 3 months ago
            var endDate = now.AddDays(30);    // 1 month in future

            // Generate 100 bookings over a 4-month period
            for (int i = 0; i < 100; i++)
            {
                // More frequent bookings for certain services
                var service = random.Next(100) < 70 ? 
                    services.Where(s => s.Name.Contains("Cleaning") || s.Name.Contains("Service")).ElementAt(random.Next(3)) : 
                    services[random.Next(services.Count)];

                // Staff assignment based on job type
                var eligibleStaff = staffs.Where(s => s.JobId == service.JobId).ToList();
                var staff = eligibleStaff[random.Next(eligibleStaff.Count)];

                var client = clients[random.Next(clients.Count)];

                // Room assignment with floor patterns
                var roomFloor = random.Next(1, 5);
                var eligibleRooms = rooms.Where(r => r.Number.StartsWith(roomFloor.ToString())).ToList();
                var room = eligibleRooms[random.Next(eligibleRooms.Count)];

                // Booking date distribution
                var timeSpan = endDate - startDate;
                var randomDays = random.Next((int)timeSpan.TotalDays);
                var bookingDate = startDate.AddDays(randomDays);
                
                // Service duration logic
                var serviceDuration = service.ServiceLimitHours > 0 ? 
                    service.ServiceLimitHours : 
                    random.Next(1, 4);

                // More realistic date ranges based on service type
                var serviceStartDate = DateOnly.FromDateTime(bookingDate);
                var serviceEndDate = service.Name.Contains("Deep") || service.Name.Contains("VIP") ? 
                    serviceStartDate.AddDays(random.Next(2, 4)) : 
                    serviceStartDate.AddDays(random.Next(0, 2));

                // Status logic based on dates and service type
                var isInPast = serviceStartDate < DateOnly.FromDateTime(now);
                var isHighPriority = service.Price > 50;
                var isConfirmed = isInPast || (isHighPriority ? random.Next(100) < 90 : random.Next(100) < 70);
                var isPaid = isInPast ? random.Next(100) < 95 : (isHighPriority ? random.Next(100) < 80 : random.Next(100) < 60);

                // Feedback logic
                var hasFeedback = isInPast && isPaid && random.Next(100) < 70;
                var baseRating = isHighPriority ? 4 : 3;
                int? feedback = hasFeedback ? random.Next(baseRating, 6) : (int?)null;

                // Price calculation with service type consideration
                var basePrice = service.Price;
                var priceMultiplier = 1.0m;
                
                // Price adjustments
                if (serviceEndDate.DayNumber - serviceStartDate.DayNumber > 0)
                    priceMultiplier += 0.1m * (serviceEndDate.DayNumber - serviceStartDate.DayNumber);
                if (isHighPriority)
                    priceMultiplier += 0.15m;
                if (room.Type.Contains("Suite"))
                    priceMultiplier += 0.2m;

                var finalPrice = basePrice * serviceDuration * priceMultiplier;

                var booking = new RoomServiceBooking
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
                };

                bookings.Add(booking);
            }

            // Add all bookings in one batch
            context.RoomServiceBooking.AddRange(bookings);
            context.SaveChanges();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReserveSystem.Data;
using System;
using System.Linq;
using ReserveSystem.Models; // Ensure this namespace is correct

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
                // Look for any existing data.
                if (context.RoomServiceBooking.Any())
                {
                    return; // DB has been seeded
                }

                // Seed Jobs
                var jobs = new[]
                {
                    new Job { JobID = 1, JobName = "Housekeeping", JobDescription = "Maintains cleanliness of rooms and facilities" },
                    new Job { JobID = 2, JobName = "Reception", JobDescription = "Handles guest check-ins and inquiries" }
                };

                context.Job.AddRange(jobs);

                // Seed Staff
                var staff = new[]
                {
                    new Staff
                    {
                        JobID = 1,
                        Job = jobs[0],
                        StaffName = "Alice Johnson",
                        StaffEmail = "alice.johnson@example.com",
                        StaffPhone = "123-456-7890",
                        StaffPassword = "password123",
                        HireDate = DateTime.Now.AddYears(-2),
                        DismissalDate = DateTime.Now.AddYears(+2),
                        VacationDays = 20,
                        Schedules = []
                    },
                    new Staff
                    {
                        JobID = 2,
                        Job = jobs[1],
                        StaffName = "Bob Smith",
                        StaffEmail = "bob.smith@example.com",
                        StaffPhone = "987-654-3210",
                        StaffPassword = "password123",
                        HireDate = DateTime.Now.AddYears(-1),
                        DismissalDate = DateTime.Now.AddYears(+1),
                        VacationDays = 15,
                        Schedules = []
                    }
                };

                context.Staff.AddRange(staff);

                // Seed Clients
                var clients = new[]
                {
                    new Client
                    {
                        Client_Name = "John Doe",
                        Client_Phone = "555-123-4567",
                        Client_Address = "123 Main St, Anytown",
                        Client_Email = "john.doe@example.com",
                        Client_Tax_Id = "123456789",
                        Client_Login = true,
                        Client_Status = true,
                        Bookings = []
                    },
                    new Client
                    {
                        Client_Name = "Jane Smith",
                        Client_Phone = "555-987-6543",
                        Client_Address = "456 Elm St, Anytown",
                        Client_Email = "jane.smith@example.com",
                        Client_Tax_Id = "987654321",
                        Client_Login = true,
                        Client_Status = true,
                        Bookings = []
                    }
                };

                context.Client.AddRange(clients);

                // Seed Room Services
                var roomServices = new[]
                {
                    new RoomService
                    {
                        RoomServiceID = 1,
                        JobID = 1,
                        Job = jobs[0],
                        RoomServiceName = "Room Cleaning",
                        RoomServiceDescription = "Thorough cleaning of the room and bathroom",
                        RoomServicePrice = 30.0,
                        RoomServiceActive = true,
                        RoomServiceDuration = 1,
                        RoomServicesBookings = []
                    },
                    new RoomService
                    {
                        RoomServiceID = 2,
                        JobID = 2,
                        Job = jobs[1],
                        RoomServiceName = "Welcome Gift",
                        RoomServiceDescription = "Provides a welcome package for guests",
                        RoomServicePrice = 15.0,
                        RoomServiceActive = true,
                        RoomServiceDuration = 2,
                        RoomServicesBookings = []
                    }
                };

                context.RoomService.AddRange(roomServices);

                // Seed Rooms
                var rooms = new[]
                {
                    new Room { RoomID = 1, RoomType = 101, RoomBookings = [], RoomServicesBookings = [] },
                    new Room { RoomID = 2, RoomType = 102, RoomBookings = [], RoomServicesBookings = [] }
                };

                context.Room.AddRange(rooms);

                // Seed Room Service Bookings
                var roomServiceBookings = new[]
                {
                    new RoomServicesBooking
                    {
                        RoomServicesBookingID = 1,
                        RoomServiceID = 1,
                        StaffID = 1,
                        ClientID = 1,
                        RoomID = 1,
                        RoomService = roomServices[0],
                        Staff = staff[0],
                        Client = clients[0],
                        Room = rooms[0],
                        DateTime = DateTime.Now,
                        StartDate = DateTime.Today,
                        EndDate = DateTime.Today.AddDays(1),
                        BookedState = true,
                        StaffConfirmation = true,
                        AmountToPay = 50.00m,
                        PaymentMade = true,
                        ClientFeedback = 4
                    },
                    new RoomServicesBooking
                    {
                        RoomServicesBookingID = 2,
                        RoomServiceID = 2,
                        StaffID = 2,
                        ClientID = 2,
                        RoomID = 2,
                        RoomService = roomServices[1],
                        Staff = staff[1],
                        Client = clients[1],
                        Room = rooms[1],
                        DateTime = DateTime.Now,
                        StartDate = DateTime.Today,
                        EndDate = DateTime.Today.AddDays(2),
                        BookedState = true,
                        StaffConfirmation = false,
                        AmountToPay = 15.00m,
                        PaymentMade = false,
                        ClientFeedback = null
                    }
                };

                context.RoomServiceBooking.AddRange(roomServiceBookings);

                // Save all changes to the database
                context.SaveChanges();
            }
        }
    }
}

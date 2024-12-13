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
                new Job
                {
                    Name = "Room Cleaner",
                    Description = "Responsible for cleaning and maintaining guest rooms"
                },
                new Job
                {
                    Name = "Room Service Attendant",
                    Description = "Handles food and beverage delivery to rooms"
                },
                new Job
                {
                    Name = "Maintenance Technician",
                    Description = "Maintains and repairs hotel facilities and equipment"
                }
            );
            context.SaveChanges();
        }

        private static void PopulateStaffs(ReserveSystemContext context)
        {
            var job = context.Job.FirstOrDefault();
            if (job != null)
            {
                context.Staff.AddRange(
                    new Staff
                    {
                        Name = "Robert Anderson",
                        JobId = job.Id,
                        ContractStartDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-1)),
                        ContractExpiryDate = DateOnly.FromDateTime(DateTime.Today.AddYears(1)),
                        VacationDays = 21,
                        Email = "robert.anderson@email.com",
                        Phone = "555-0104",
                        Password = "p#ssW0rD19"
                    },
                    new Staff
                    {
                        Name = "Lisa Martinez",
                        JobId = job.Id,
                        ContractStartDate = DateOnly.FromDateTime(DateTime.Today.AddYears(-2)),
                        ContractExpiryDate = DateOnly.FromDateTime(DateTime.Today.AddMonths(6)),
                        VacationDays = 21,
                        Email = "lisa.martinez@email.com",
                        Phone = "555-0105",
                        Password = "p$wE2ord"
                    }
                );
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
            context.Client.AddRange(
                new Client { Name = "John Smith", Email = "john.smith@email.com", Phone = "555-0101", Address = "123 Main St", Nif = "123456789" },
                new Client { Name = "Emma Davis", Email = "emma.davis@email.com", Phone = "555-0102", Address = "456 Elm St", Nif = "987654321" },
                new Client { Name = "Michael Wilson", Email = "michael.w@email.com", Phone = "555-0103", Address = "789 Oak St", Nif = "456789123" }
            );
            context.SaveChanges();
        }

        private static void PopulateRooms(ReserveSystemContext context)
        {
            context.Room.AddRange(
                new Room { Number = "101", Type = "Standard" },
                new Room { Number = "201", Type = "Deluxe" },
                new Room { Number = "301", Type = "Suite" }
            );
            context.SaveChanges();
        }
        private static void PopulateRoomServices(ReserveSystemContext context)
        {
            var job = context.Job.FirstOrDefault();
            if (job != null)
            {
                context.RoomService.AddRange(
                    new RoomService
                    {
                        Name = "Room Cleaning",
                        Description = "Standard daily room cleaning service",
                        JobId = job.Id,
                        Price = 30.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 1
                    },
                    new RoomService
                    {
                        Name = "Room Service",
                        Description = "Food and beverage delivery",
                        JobId = job.Id,
                        Price = 0.00m,
                        ServiceActive = true,
                        ServiceLimitHours = 0
                    }
                );
                context.SaveChanges();
            }
        }

        private static void PopulateRoomServiceBookings(ReserveSystemContext context)
        {
            var service = context.RoomService.FirstOrDefault();
            var staff = context.Staff.FirstOrDefault();
            var client = context.Client.FirstOrDefault();
            var room = context.Room.FirstOrDefault();

            if (service != null && staff != null && client != null && room != null)
            {
                context.RoomServiceBooking.AddRange(
                    new RoomServiceBooking
                    {
                        RoomServiceId = service.Id,
                        StaffId = staff.Id,
                        ClientId = client.Id,
                        RoomId = room.Id,
                        DateTime = DateTime.Now,
                        StartDate = DateOnly.FromDateTime(DateTime.Today),
                        EndDate = DateOnly.FromDateTime(DateTime.Today),
                        BookedState = true,
                        StaffConfirmation = true,
                        ClientFeedback = 5,
                        ValueToPay = service.Price,
                        PaymentDone = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
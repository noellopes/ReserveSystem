using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReserveSystem.Models;
using System;
using System.Linq;

namespace ReserveSystem.Data
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

                // Add Room data
                context.Room.AddRange(
                    new Room { RoomNumber = "101", Type = "Single" },
                    new Room { RoomNumber = "102", Type = "Double" }
                );

                // Add Client data
                context.Client.AddRange(
                    new Client { Name = "John Doe", Email = "john@example.com", Phone = "123456789", Address = "123 Main St", Nif = "1234567890", Login = true, Status = true },
                    new Client { Name = "Jane Smith", Email = "jane@example.com", Phone = "987654321", Address = "456 Elm St", Nif = "0987654321", Login = false, Status = true }
                );

                // Add Job data
                context.Job.AddRange(
                    new Job { Title = "Manager", Description = "Manages the hotel" },
                    new Job { Title = "Cleaner", Description = "Cleans the rooms" }
                );
                
                // Save changes to ensure foreign key references are valid
                context.SaveChanges();

                // Add Staff data
                context.Staff.AddRange(
                    new Staff { StaffName = "Alice", StaffEmail = "alice@example.com", StaffPhone = "555123456", StaffPassword = "password123", StartFunctionsDate = DateTime.Now, Job = context.Job.FirstOrDefault(j => j.Id == 1)!, DaysOffVacation = 20 },
                    new Staff { StaffName = "Bob", StaffEmail = "bob@example.com", StaffPhone = "555654321", StaffPassword = "password123", StartFunctionsDate = DateTime.Now, Job = context.Job.FirstOrDefault(j => j.Id == 2)!, DaysOffVacation = 20 }
                );
                
                // Save changes to ensure foreign key references are valid
                context.SaveChanges();

                // Add Schedule data
                context.Schedule.AddRange(
                    new Schedule { StaffId = 1, Staff = context.Staff.FirstOrDefault(s => s.Id == 1)!, Date = DateOnly.FromDateTime(DateTime.Now), StartShiftTime = new TimeSpan(8, 0, 0), EndShiftTime = new TimeSpan(16, 0, 0), Available = true, Present = true },
                    new Schedule { StaffId = 2, Staff = context.Staff.FirstOrDefault(s => s.Id == 2)!, Date = DateOnly.FromDateTime(DateTime.Now), StartShiftTime = new TimeSpan(9, 0, 0), EndShiftTime = new TimeSpan(17, 0, 0), Available = true, Present = true }
                );

                // Add RoomService data
                context.RoomService.AddRange(
                    new RoomService { Name = "Breakfast", Description = "Continental breakfast", Price = 15.00m, Active = true, LimitHour = new TimeSpan(1, 0, 0), Job = context.Job.FirstOrDefault(j => j.Id == 1)! },
                    new RoomService { Name = "Laundry", Description = "Laundry service", Price = 10.00m, Active = true, LimitHour = new TimeSpan(2, 0, 0), Job = context.Job.FirstOrDefault(j => j.Id == 2)! }
                );

                // Save changes to ensure foreign key references are valid
                context.SaveChanges();

                // Add RoomServiceBooking data
                var staff1 = context.Staff.FirstOrDefault(s => s.Id == 1);
                var staff2 = context.Staff.FirstOrDefault(s => s.Id == 2);
                var client1 = context.Client.FirstOrDefault(c => c.Id == 1);
                var client2 = context.Client.FirstOrDefault(c => c.Id == 2);
                var room1 = context.Room.FirstOrDefault(r => r.Id == 1);
                var room2 = context.Room.FirstOrDefault(r => r.Id == 2);
                var roomService1 = context.RoomService.FirstOrDefault(rs => rs.Id == 1);
                var roomService2 = context.RoomService.FirstOrDefault(rs => rs.Id == 2);

                if (staff1 != null && staff2 != null && client1 != null && client2 != null && room1 != null && room2 != null && roomService1 != null && roomService2 != null)
                {
                    context.RoomServiceBooking.AddRange(
                        new RoomServiceBooking
                        {
                            RoomServiceId = roomService1.Id,
                            RoomService = roomService1,
                            StaffId = staff1.Id,
                            Staff = staff1,
                            ClientId = client1.Id,
                            Client = client1,
                            RoomId = room1.Id,
                            Room = room1,
                            DateTime = DateTime.Now,
                            StartDate = DateOnly.FromDateTime(DateTime.Now),
                            EndDate = DateOnly.FromDateTime(DateTime.Now),
                            BookedState = true,
                            StaffConfirmation = false,
                            ValueToPay = 15.00m
                        },
                        new RoomServiceBooking
                        {
                            RoomServiceId = roomService2.Id,
                            RoomService = roomService2,
                            StaffId = staff2.Id,
                            Staff = staff2,
                            ClientId = client2.Id,
                            Client = client2,
                            RoomId = room2.Id,
                            Room = room2,
                            DateTime = DateTime.Now,
                            StartDate = DateOnly.FromDateTime(DateTime.Now),
                            EndDate = DateOnly.FromDateTime(DateTime.Now),
                            BookedState = true,
                            StaffConfirmation = false,
                            ValueToPay = 10.00m
                        }
                    );
                }
                
                // Save changes to the context
                context.SaveChanges();
            }
        }
    }
}
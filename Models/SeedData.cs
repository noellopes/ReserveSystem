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

                // Add RoomServiceBooking data
                context.RoomServiceBooking.AddRange(
                    new RoomServiceBooking
                    {
                        RoomServiceId = 1,  // Breakfast Service
                        StaffId = 1,        // Staff member 1
                        ClientId = 1,       // Client 1
                        RoomId = 101,       // Room 101
                        DateTime = DateTime.Now.AddMinutes(-15),
                        StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                        EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                        BookedState = true,
                        StaffConfirmation = true,
                        ClientFeedback = 5,
                        ValueToPay = 45.00m,
                        PaymentDone = true
                    },
                    new RoomServiceBooking
                    {
                        RoomServiceId = 2,  // Dinner Service
                        StaffId = 2,        // Staff member 2
                        ClientId = 2,       // Client 2
                        RoomId = 102,       // Room 102
                        DateTime = DateTime.Now.AddHours(-1),
                        StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                        EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(2)),
                        BookedState = true,
                        StaffConfirmation = false,
                        ClientFeedback = 4,
                        ValueToPay = 120.50m,
                        PaymentDone = false
                    },
                    new RoomServiceBooking
                    {
                        RoomServiceId = 3,  // Spa Service
                        StaffId = 3,        // Staff member 3
                        ClientId = 3,       // Client 3
                        RoomId = 103,       // Room 103
                        DateTime = DateTime.Now.AddDays(-2),
                        StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
                        EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
                        BookedState = false,
                        StaffConfirmation = false,
                        ClientFeedback = 0,
                        ValueToPay = 180.00m,
                        PaymentDone = false
                    },
                    new RoomServiceBooking
                    {
                        RoomServiceId = 4,  // Housekeeping
                        StaffId = 4,        // Staff member 4
                        ClientId = 4,       // Client 4
                        RoomId = 104,       // Room 104
                        DateTime = DateTime.Now.AddMinutes(-30),
                        StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                        EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                        BookedState = true,
                        StaffConfirmation = true,
                        ClientFeedback = 3,
                        ValueToPay = 35.00m,
                        PaymentDone = true
                    },
                    new RoomServiceBooking
                    {
                        RoomServiceId = 5,  // Laundry Service
                        StaffId = 5,        // Staff member 5
                        ClientId = 5,       // Client 5
                        RoomId = 105,       // Room 105
                        DateTime = DateTime.Now.AddHours(-4),
                        StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                        EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(1)),
                        BookedState = true,
                        StaffConfirmation = true,
                        ClientFeedback = 5,
                        ValueToPay = 25.75m,
                        PaymentDone = true
                    },
                    new RoomServiceBooking
                    {
                        RoomServiceId = 6,  // Room Service (General)
                        StaffId = 6,        // Staff member 6
                        ClientId = 6,       // Client 6
                        RoomId = 106,       // Room 106
                        DateTime = DateTime.Now.AddMinutes(-45),
                        StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                        EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(5)),
                        BookedState = true,
                        StaffConfirmation = false,
                        ClientFeedback = 2,
                        ValueToPay = 50.00m,
                        PaymentDone = false
                    },
                    new RoomServiceBooking
                    {
                        RoomServiceId = 7,  // VIP Service
                        StaffId = 7,        // Staff member 7
                        ClientId = 7,       // Client 7
                        RoomId = 107,       // Room 107
                        DateTime = DateTime.Now.AddHours(-3),
                        StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(6)),
                        EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(6)),
                        BookedState = true,
                        StaffConfirmation = true,
                        ClientFeedback = 5,
                        ValueToPay = 250.00m,
                        PaymentDone = true
                    },
                    new RoomServiceBooking
                    {
                        RoomServiceId = 8,  // Breakfast in bed
                        StaffId = 8,        // Staff member 8
                        ClientId = 8,       // Client 8
                        RoomId = 108,       // Room 108
                        DateTime = DateTime.Now.AddMinutes(-10),
                        StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7)),
                        EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7)),
                        BookedState = true,
                        StaffConfirmation = false,
                        ClientFeedback = 3,
                        ValueToPay = 60.00m,
                        PaymentDone = false
                    }
                );

                // Save changes to the context
                context.SaveChanges();
            }
        }
    }
}

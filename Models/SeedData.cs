using System;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;

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
                // Look for any movies.
                if (context.RoomServiceBooking.Any())
                {
                    return;   // DB has been seeded
                }

                context.RoomServiceBooking.AddRange(
                    new RoomServicesBooking
                    {
                        RoomServiceBookingId = 1,
                        RoomService = new RoomService { RoomServiceId = 1, ServiceName = "Room Cleaning" },
                        Staff = new Staff { StaffId = 1, StaffName = "Mary Jane" },
                        Client = new Client { ClientId = 1, ClientName = "John Silva" },
                        Room = new Room { RoomId = 1, RoomNumber = 101 },
                        DateTime = DateTime.Parse("2021-01-01 12:00:00"),
                        StartDate = DateTime.Parse("2021-01-01"),
                        EndDate = DateTime.Parse("2021-01-01"),
                        BookedState = "Booked",
                        StaffConfirmation = true,
                        AmountToPay = 100.0m,
                        PaymentMade = true
                    },

                    new RoomServicesBooking
                    {
                        RoomServiceBookingId = 2,
                        RoomService = new RoomService { RoomServiceId = 2, ServiceName = "Service 2" },
                        Staff = new Staff { StaffId = 2, StaffName = "Staff 2" },
                        Client = new Client { Id = 2 },
                        Room = new Room { Id = 2 },
                        DateTime = DateTime.Parse("2021-01-02 12:00:00"),
                        StartDate = DateTime.Parse("2021-01-02"),
                        EndDate = DateTime.Parse("2021-01-02"),
                        BookedState = "Booked",
                        StaffConfirmation = true,
                        AmountToPay = 200.0m,
                        PaymentMade = true
                    },

                    new RoomServicesBooking
                    {
                        RoomServiceBookingId = 3,
                        RoomService = new RoomService { RoomServiceId = 3, ServiceName = "Service 3" },
                        Staff = new Staff { StaffId = 3, StaffName = "Staff 3" },
                        Client = new Client { Id = 3 },
                        Room = new Room { Id = 3 },
                        DateTime = DateTime.Parse("2021-01-03 12:00:00"),
                        StartDate = DateTime.Parse("2021-01-03"),
                        EndDate = DateTime.Parse("2021-01-03"),
                        BookedState = "Booked",
                        StaffConfirmation = true,
                        AmountToPay = 300.0m,
                        PaymentMade = true
                    },

                    new RoomServicesBooking
                    {
                        RoomServiceBookingId = 4,
                        RoomService = new RoomService { RoomServiceId = 4, ServiceName = "Service 4" },
                        Staff = new Staff { StaffId = 4, StaffName = "Staff 4" },
                        Client = new Client { Id = 4 },
                        Room = new Room { Id = 4 },
                        DateTime = DateTime.Parse("2021-01-04 12:00:00"),
                        StartDate = DateTime.Parse("2021-01-04"),
                        EndDate = DateTime.Parse("2021-01-04"),
                        BookedState = "Booked",
                        StaffConfirmation = true,
                        AmountToPay = 400.0m,
                        PaymentMade = true
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
using System;
using System.Linq;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public static class SeedData
    {
        public static void PopulateBooking(ReserveSystemContext db)
        {
            // Verifica se já existem registos na base de dados para evitar duplicação
            //if (db.Bookings.Any())
            {
                return; // Se há dados, não adiciona mais nada
            }

            var bookings = new[]
            {
                new Booking
                {
                    CheckInDate = new DateTime(2024, 12, 1),
                    CheckOutDate = new DateTime(2024, 12, 5),
                    BookingDate = new DateTime(2024, 11, 20),
                    IsBooked = true,
                    TotalPersonsNumber = 2,
                    PaymentStatus = true,
                    ClientId = 1
                },
                new Booking
                {
                    CheckInDate = new DateTime(2024, 12, 10),
                    CheckOutDate = new DateTime(2024, 12, 15),
                    BookingDate = new DateTime(2024, 11, 25),
                    IsBooked = true,
                    TotalPersonsNumber = 4,
                    PaymentStatus = true,
                    ClientId = 2
                },
                new Booking
                {
                    CheckInDate = new DateTime(2024, 11, 30),
                    CheckOutDate = new DateTime(2024, 12, 2),
                    BookingDate = new DateTime(2024, 11, 10),
                    IsBooked = true,
                    TotalPersonsNumber = 1,
                    PaymentStatus = false,
                    ClientId = 3
                },
                new Booking
                {
                    CheckInDate = new DateTime(2024, 12, 20),
                    CheckOutDate = new DateTime(2024, 12, 22),
                    BookingDate = new DateTime(2024, 11, 28),
                    IsBooked = true,
                    TotalPersonsNumber = 3,
                    PaymentStatus = true,
                    ClientId = 4
                },
                new Booking
                {
                    CheckInDate = new DateTime(2025, 1, 5),
                    CheckOutDate = new DateTime(2025, 1, 10),
                    BookingDate = new DateTime(2024, 12, 15),
                    IsBooked = true,
                    TotalPersonsNumber = 5,
                    PaymentStatus = true,
                    ClientId = 5
                },
                new Booking
                {
                    CheckInDate = new DateTime(2024, 11, 25),
                    CheckOutDate = new DateTime(2024, 11, 28),
                    BookingDate = new DateTime(2024, 11, 5),
                    IsBooked = true,
                    TotalPersonsNumber = 2,
                    PaymentStatus = true,
                    ClientId = 6
                },
                new Booking
                {
                    CheckInDate = new DateTime(2024, 12, 23),
                    CheckOutDate = new DateTime(2024, 12, 27),
                    BookingDate = new DateTime(2024, 11, 30),
                    IsBooked = true,
                    TotalPersonsNumber = 6,
                    PaymentStatus = false,
                    ClientId = 7
                },
                new Booking
                {
                    CheckInDate = new DateTime(2025, 1, 15),
                    CheckOutDate = new DateTime(2025, 1, 20),
                    BookingDate = new DateTime(2024, 12, 20),
                    IsBooked = true,
                    TotalPersonsNumber = 3,
                    PaymentStatus = true,
                    ClientId = 8
                },
                new Booking
                {
                    CheckInDate = new DateTime(2024, 12, 1),
                    CheckOutDate = new DateTime(2024, 12, 4),
                    BookingDate = new DateTime(2024, 11, 18),
                    IsBooked = true,
                    TotalPersonsNumber = 2,
                    PaymentStatus = true,
                    ClientId = 9
                },
                new Booking
                {
                    CheckInDate = new DateTime(2024, 12, 28),
                    CheckOutDate = new DateTime(2025, 1, 2),
                    BookingDate = new DateTime(2024, 11, 25),
                    IsBooked = true,
                    TotalPersonsNumber = 4,
                    PaymentStatus = false,
                    ClientId = 10
                }
            };

            // Adiciona as reservas a base de dados
            //db.Booking.AddRange(bookings);

            // Guarda as mudanças
            db.SaveChanges();
        }
    }
}


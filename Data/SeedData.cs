﻿using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class SeedData
    {
        public static void Populate(ReserveSystemUsersDbContext db)
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
            PopulateEvents(db);
            PopulateRoomTypes(db); // Popula os tipos de quarto
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

        private static void PopulateRoomTypes(ReserveSystemUsersDbContext db)
        {
            if (db.TQePreco.Any()) return;

            db.TQePreco.AddRange(new List<TQePreco> {
        new TQePreco
        {
            type = "Single Room",
            capacity = 1,
            RoomQuantity = 10,
            AcessibilityRoom = true,
            View = false,
            BasePrice = 0,
            AdicionalBeds = 20.0f,
            InUse = false
        },
        new TQePreco
        {
            type = "Double Room",
            capacity = 2,
            RoomQuantity = 15,
            AcessibilityRoom = false,
            View = true,
            BasePrice = 0,
            AdicionalBeds = 25.0f,
            InUse = false
        },
        new TQePreco
        {
            type = "Suite",
            capacity = 4,
            RoomQuantity = 5,
            AcessibilityRoom = true,
            View = true,
            BasePrice = 350.0f,
            AdicionalBeds = 50.0f,
            InUse = true
        },
        new TQePreco
        {
            type = "Economy Room",
            capacity = 1,
            RoomQuantity = 20,
            AcessibilityRoom = false,
            View = false,
            BasePrice = 80.0f,
            AdicionalBeds = 10.0f,
            InUse = true
        },
        new TQePreco
        {
            type = "Deluxe Room",
            capacity = 3,
            RoomQuantity = 8,
            AcessibilityRoom = true,
            View = true,
            BasePrice = 300.0f,
            AdicionalBeds = 40.0f,
            InUse = true
        },
        new TQePreco
        {
            type = "Family Suite",
            capacity = 6,
            RoomQuantity = 3,
            AcessibilityRoom = true,
            View = true,
            BasePrice = 0,
            AdicionalBeds = 60.0f,
            InUse = false
        },
        new TQePreco
        {
            type = "Presidential Suite",
            capacity = 8,
            RoomQuantity = 2,
            AcessibilityRoom = true,
            View = true,
            BasePrice = 1000.0f,
            AdicionalBeds = 100.0f,
            InUse = true
        },
        new TQePreco
        {
            type = "Studio Room",
            capacity = 2,
            RoomQuantity = 12,
            AcessibilityRoom = false,
            View = true,
            BasePrice = 0,
            AdicionalBeds = 15.0f,
            InUse = false
        },
        new TQePreco
        {
            type = "Penthouse",
            capacity = 5,
            RoomQuantity = 1,
            AcessibilityRoom = false,
            View = true,
            BasePrice = 1200.0f,
            AdicionalBeds = 75.0f,
            InUse = true
        },
        new TQePreco
        {
            type = "Cabin Room",
            capacity = 3,
            RoomQuantity = 6,
            AcessibilityRoom = true,
            View = false,
            BasePrice = 0,
            AdicionalBeds = 30.0f,
            InUse = false
        }
    });

            db.SaveChanges();
        }

    }
}

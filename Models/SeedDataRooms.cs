using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;
using System;
using System.Linq;
using ReserveSystem.Data;

internal class SeedDataRooms
{
    internal static void Populate(ReserveSystemContext? db)
    {
        if (db == null)
        {
            return; // Dados já foram adicionados
            db.Database.EnsureCreated();
            PopulateRooms(db);
        }
    }
    // Verificar se já existem quartos na base de dados

    private static void PopulateRooms(ReserveSystemContext db)
    {
        // Lista de quartos para inicializar a base de dados
        var rooms = new[]
        {
                new Rooms { RoomType = "Standard", Capacity = 2, NumberOfRooms = 10, HasView = true, AdaptedRoom = false },
                new Rooms { RoomType = "Standard", Capacity = 2, NumberOfRooms = 8, HasView = false, AdaptedRoom = true },
                new Rooms { RoomType = "Suite", Capacity = 4, NumberOfRooms = 7, HasView = true, AdaptedRoom = false },
                new Rooms { RoomType = "Suite", Capacity = 4, NumberOfRooms = 5, HasView = false, AdaptedRoom = true },
                new Rooms { RoomType = "Deluxe", Capacity = 3, NumberOfRooms = 6, HasView = true, AdaptedRoom = true },
                new Rooms { RoomType = "Deluxe", Capacity = 3, NumberOfRooms = 8, HasView = false, AdaptedRoom = false },
                new Rooms { RoomType = "Executive", Capacity = 2, NumberOfRooms = 5, HasView = true, AdaptedRoom = false },
                new Rooms { RoomType = "Executive", Capacity = 2, NumberOfRooms = 4, HasView = false, AdaptedRoom = true },
                new Rooms { RoomType = "Family", Capacity = 5, NumberOfRooms = 3, HasView = true, AdaptedRoom = true },
                new Rooms { RoomType = "Family", Capacity = 5, NumberOfRooms = 4, HasView = false, AdaptedRoom = false },
                new Rooms { RoomType = "Presidential", Capacity = 6, NumberOfRooms = 2, HasView = true, AdaptedRoom = false },
                new Rooms { RoomType = "Presidential", Capacity = 6, NumberOfRooms = 1, HasView = false, AdaptedRoom = true },
                new Rooms { RoomType = "Penthouse", Capacity = 4, NumberOfRooms = 2, HasView = true, AdaptedRoom = true },
                new Rooms { RoomType = "Studio", Capacity = 2, NumberOfRooms = 10, HasView = false, AdaptedRoom = false },
                new Rooms { RoomType = "Loft", Capacity = 3, NumberOfRooms = 3, HasView = true, AdaptedRoom = false },
                new Rooms { RoomType = "Loft", Capacity = 3, NumberOfRooms = 4, HasView = false, AdaptedRoom = true },
                new Rooms { RoomType = "Villa", Capacity = 8, NumberOfRooms = 2, HasView = true, AdaptedRoom = false },
                new Rooms { RoomType = "Villa", Capacity = 8, NumberOfRooms = 3, HasView = false, AdaptedRoom = true },
                new Rooms { RoomType = "Bungalow", Capacity = 4, NumberOfRooms = 5, HasView = true, AdaptedRoom = false },
                new Rooms { RoomType = "Bungalow", Capacity = 4, NumberOfRooms = 6, HasView = false, AdaptedRoom = true },
                new Rooms { RoomType = "Single", Capacity = 1, NumberOfRooms = 15, HasView = false, AdaptedRoom = false },
                new Rooms { RoomType = "Single", Capacity = 1, NumberOfRooms = 12, HasView = true, AdaptedRoom = true },
                new Rooms { RoomType = "Double", Capacity = 2, NumberOfRooms = 20, HasView = false, AdaptedRoom = false },
                new Rooms { RoomType = "Double", Capacity = 2, NumberOfRooms = 15, HasView = true, AdaptedRoom = true },
                new Rooms { RoomType = "Cottage", Capacity = 5, NumberOfRooms = 4, HasView = true, AdaptedRoom = false },
                new Rooms { RoomType = "Cottage", Capacity = 5, NumberOfRooms = 3, HasView = false, AdaptedRoom = true },
                new Rooms { RoomType = "Cabin", Capacity = 3, NumberOfRooms = 7, HasView = true, AdaptedRoom = false },
                new Rooms { RoomType = "Cabin", Capacity = 3, NumberOfRooms = 6, HasView = false, AdaptedRoom = true }
            };

        db.SaveChanges();
    }
}

  
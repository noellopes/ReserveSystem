using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class SeedData
    {
        internal static void Populate(ReserveSystemUsersDbContext? db)
        {
            if (db == null) return;
            db.Database.EnsureCreated();

            PopulateEvents(db);
        }

        private static void PopulateEvents(ReserveSystemUsersDbContext db)
        {
            if (db.Events.Any()) return;

            db.Events.AddRange(new List<Events> {
                new Events {nameEv = "Spring Festival", startDate = new DateTime(2024, 3, 20), endDate = new DateTime(2024, 3, 25), fee = 15.50f, anual = true, municipal = true, national = false },
                new Events {nameEv = "National Tech Conference", startDate = new DateTime(2024, 5, 10), endDate = new DateTime(2024, 5, 12), fee = 120.00f, anual = true, municipal = false, national = true },
                new Events {nameEv = "Local Farmers' Market", startDate = new DateTime(2024, 7, 1), endDate = new DateTime(2024, 7, 1), fee = 0.00f, anual = false, municipal = true, national = false },
                new Events {nameEv = "Independence Day Parade", startDate = new DateTime(2024, 9, 7), endDate = new DateTime(2024, 9, 7), fee = 5.00f, anual = true, municipal = false, national = true },
                new Events {nameEv = "Winter Gala", startDate = new DateTime(2024, 12, 15), endDate = new DateTime(2024, 12, 15), fee = 50.00f, anual = true, municipal = true, national = false },
                new Events {nameEv = "Summer Carnival", startDate = new DateTime(2024, 8, 5), endDate = new DateTime(2024, 8, 10), fee = 25.00f, anual = true, municipal = true, national = false },
                new Events {nameEv = "Art Expo", startDate = new DateTime(2024, 4, 20), endDate = new DateTime(2024, 4, 22), fee = 30.00f, anual = false, municipal = true, national = true },
                new Events {nameEv = "Music Festival", startDate = new DateTime(2024, 6, 15), endDate = new DateTime(2024, 6, 18), fee = 60.00f, anual = true, municipal = false, national = true },
                new Events {nameEv = "Science Fair", startDate = new DateTime(2024, 10, 10), endDate = new DateTime(2024, 10, 12), fee = 10.00f, anual = false, municipal = true, national = false },
                new Events {nameEv = "Wine Tasting", startDate = new DateTime(2024, 11, 5), endDate = new DateTime(2024, 11, 6), fee = 45.00f, anual = true, municipal = false, national = false },
                new Events {nameEv = "Food Truck Rally", startDate = new DateTime(2024, 9, 20), endDate = new DateTime(2024, 9, 20), fee = 5.00f, anual = true, municipal = true, national = false },
                new Events {nameEv = "Halloween Party", startDate = new DateTime(2024, 10, 31), endDate = new DateTime(2024, 10, 31), fee = 20.00f, anual = true, municipal = false, national = false },
                new Events {nameEv = "Marathon Run", startDate = new DateTime(2024, 5, 15), endDate = new DateTime(2024, 5, 15), fee = 30.00f, anual = true, municipal = false, national = true },
                new Events {nameEv = "Book Fair", startDate = new DateTime(2024, 7, 10), endDate = new DateTime(2024, 7, 12), fee = 10.00f, anual = false, municipal = true, national = false },
                new Events {nameEv = "Charity Gala", startDate = new DateTime(2024, 12, 5), endDate = new DateTime(2024, 12, 5), fee = 100.00f, anual = true, municipal = false, national = true },
                new Events {nameEv = "Craft Workshop", startDate = new DateTime(2024, 2, 20), endDate = new DateTime(2024, 2, 20), fee = 15.00f, anual = false, municipal = true, national = false },
                new Events {nameEv = "Open Mic Night", startDate = new DateTime(2024, 3, 10), endDate = new DateTime(2024, 3, 10), fee = 10.00f, anual = true, municipal = true, national = false },
                new Events {nameEv = "Antique Show", startDate = new DateTime(2024, 6, 25), endDate = new DateTime(2024, 6, 27), fee = 25.00f, anual = false, municipal = false, national = true },
                new Events {nameEv = "Startup Pitch Night", startDate = new DateTime(2024, 5, 30), endDate = new DateTime(2024, 5, 30), fee = 50.00f, anual = false, municipal = false, national = true },
                new Events {nameEv = "History Lecture Series", startDate = new DateTime(2024, 11, 15), endDate = new DateTime(2024, 11, 17), fee = 0.00f, anual = false, municipal = true, national = false }
                
            });

            db.SaveChanges();
        }
    }
}

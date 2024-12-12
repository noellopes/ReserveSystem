
using ReserveSystem.Models;

namespace ReserveSystem.Data {
    public class SeedData {
        internal static void Populate(ReserveSystemContext? db) {
            if (db == null) return;
            db.Database.EnsureCreated();

            PopulateClient(db);
            PopulateRoom(db);
            PopulateJob(db);
            PopulateRoomService(db);
            PopulateStaff(db);
            PopulateSchedule(db);
        }

        private static void PopulateClient(ReserveSystemContext db) {
            // TODO: Add client data
            //if (db.Client.Any()) return;
        }

        private static void PopulateRoom(ReserveSystemContext db) {
            // TODO: Add room data
            // if (db.Room.Any()) return;
        }

        private static void PopulateJob(ReserveSystemContext db) {
            // TODO: Add job data
            // if (db.Job.Any()) return;
        }

        private static void PopulateRoomService(ReserveSystemContext db) {
            // TODO: Add room service data
            // if (db.RoomService.Any()) return;
        }

        private static void PopulateStaff(ReserveSystemContext db) {
            // TODO: Add staff data
            // if (db.Staff.Any()) return;
        }

        private static void PopulateSchedule(ReserveSystemContext db) {
            // TODO: Add schedule data
            // if (db.Schedule.Any()) return;
        }
    }
}

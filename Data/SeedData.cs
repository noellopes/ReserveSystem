using Microsoft.AspNetCore.Identity;
using ReserveSystem.Data.Migrations;
using ReserveSystem.Data.UserMigrations;
using ReserveSystem.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReserveSystem.Data
{
    public static class SeedData
    {
        internal static void Populate(ReserveSystemContext? db)
        {
            if (db == null) return;
            db.Database.EnsureCreated();
            PopulateJobs(db);
            PopulateTypesOfSchedule(db);
            PopulateStaff(db);
            PopulateSchedules(db);
        }

        /*
         internal static void PopulateUsers(ReserveSystemUsersDbContext? dbUsers)
        {
            if (dbUsers == null) return;
            dbUsers.Database.EnsureCreated();
            PopulateRoles(dbUsers);

        }
         */

        internal static void PopulateUsers(UserManager<IdentityUser> userManager)
        {
            EnsureUserIsCreatedAsync(userManager, "john@ipg.pt", "Secret$123", "client").Wait();
            EnsureUserIsCreatedAsync(userManager, "mary@ipg.pt", "Secret$123", "client").Wait();
        }

        internal static void PopulateDefaultAdmin(UserManager<IdentityUser> userManager)
        {
            EnsureUserIsCreatedAsync(userManager, "admin@ipg.pt", "Secret$123", "admin").Wait();
        }

        private static async Task EnsureUserIsCreatedAsync(UserManager<IdentityUser> userManager, string username, string password, string roleName)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                user = new IdentityUser { UserName = username, Email = username, EmailConfirmed = true };
                await userManager.CreateAsync(user, password);
            }
            if (!await userManager.IsInRoleAsync(user, roleName))
            {
                await userManager.AddToRoleAsync(user, roleName);
            }
        }

        internal static void PopulateRoles(RoleManager<IdentityRole> roleManager)
        {
            EnsureRoleIsCreatedAsync(roleManager, "admin").Wait();
            EnsureRoleIsCreatedAsync(roleManager, "client").Wait();
        }

        private static async Task EnsureRoleIsCreatedAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        public static void PopulateJobs(ReserveSystemContext db)
        {
            if (!db.Job.Any())
            {
                db.Job.AddRange(
                    new Job { JobName = "Receptionist", JobDescription = "Responsible for attending to guests, checking them in and out, and managing reservations." },
                    new Job { JobName = "Cook", JobDescription = "Responsible for preparing meals in the hotel, following the menu and hygiene standards." },
                    new Job { JobName = "Housekeeper", JobDescription = "Responsible for cleaning and organizing rooms, hallways, and common areas of the hotel." },
                    new Job { JobName = "Manager", JobDescription = "Responsible for overseeing the entire hotel operation, managing staff, and ensuring customer satisfaction." },
                    new Job { JobName = "Administrative Assistant", JobDescription = "Responsible for administrative tasks such as document control, payments, and internal communication." }
                );
                db.SaveChanges();
            }
        }

        public static void PopulateTypesOfSchedule(ReserveSystemContext db)
        {
            if (!db.TypeOfSchedule.Any())
            {
                db.TypeOfSchedule.AddRange(
                    new TypeOfSchedule { TypeOfScheduleName = "Morning Shift", TypeOfScheduleDescription = "This shift starts in the morning and ends at noon." },
                    new TypeOfSchedule { TypeOfScheduleName = "Afternoon Shift", TypeOfScheduleDescription = "This shift starts after noon and ends in the evening." },
                    new TypeOfSchedule { TypeOfScheduleName = "Night Shift", TypeOfScheduleDescription = "This shift starts in the evening and ends at night." },
                    new TypeOfSchedule { TypeOfScheduleName = "Early Morning Shift", TypeOfScheduleDescription = "This shift starts early in the morning before sunrise." },
                    new TypeOfSchedule { TypeOfScheduleName = "Late Night Shift", TypeOfScheduleDescription = "This shift starts late at night and ends early morning." }
                );
                db.SaveChanges();
            }
        }

        public static void PopulateStaff(ReserveSystemContext db)
        {
            if (!db.Staff.Any())
            {
                db.Staff.AddRange(
                    new Staff
                    {
                        StaffName = "John Doe",
                        StaffEmail = "johndoe@example.com",
                        StaffPhone = "+1234567890",
                        StaffDriversLicense = "D123456789",
                        StaffDriversLicenseExpiringDate = new DateTime(2027, 12, 31),
                        StaffDateOfBirth = new DateTime(1990, 5, 15),
                        StaffPassword = "SecurePassword123",
                        StartFunctionsDate = new DateTime(2023, 6, 1),
                        EndFunctionsDate = new DateTime(2025, 6, 1),
                        DaysOfVacationCount = 15,
                        IsActive = true,
                        JobId = 1
                    },
                    new Staff
                    {
                        StaffName = "Jane Smith",
                        StaffEmail = "janesmith@example.com",
                        StaffPhone = "+1987654321",
                        StaffDriversLicense = "D987654321",
                        StaffDriversLicenseExpiringDate = new DateTime(2028, 12, 31),
                        StaffDateOfBirth = new DateTime(1985, 3, 22),
                        StaffPassword = "AnotherSecurePassword123",
                        StartFunctionsDate = new DateTime(2022, 7, 15),
                        EndFunctionsDate = new DateTime(2024, 7, 15),
                        DaysOfVacationCount = 20,
                        IsActive = true,
                        JobId = 2
                    }
                );
                db.SaveChanges();
            }
        }

        public static void PopulateSchedules(ReserveSystemContext db)
        {
            if (!db.Schedules.Any())
            {
                db.Schedules.AddRange(
                    new Schedules
                    {
                        StartShiftTime = new TimeSpan(8, 0, 0),
                        EndShiftTime = new TimeSpan(12, 0, 0),
                        isPrecense = true,
                        isAvailable = true,
                        StaffId = 1,
                        TypeOfScheduleId = db.TypeOfSchedule.First(ts => ts.TypeOfScheduleName == "Morning Shift").TypeOfScheduleId
                    }
                );
                db.SaveChanges();
            }
        }
    }
}

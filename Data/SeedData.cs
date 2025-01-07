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
            EnsureUserIsCreatedAsync(userManager, "john@gmail.com", "Secret$123","client").Wait();
        }

        internal static void PopulateManagers(UserManager<IdentityUser> userManager)
        {
            EnsureUserIsCreatedAsync(userManager, "manager@gmail.com", "Secret$123", "manager").Wait();
        }

        internal static void PopulateDefaultAdmin(UserManager<IdentityUser> userManager)
        {
            EnsureUserIsCreatedAsync(userManager, "admin@gmail.com", "Secret$123","admin").Wait();
        }

        private static async Task EnsureUserIsCreatedAsync(UserManager<IdentityUser> userManager, string username, string password, string roleName)
        {
            var user = await userManager.FindByNameAsync(username);

            if (user == null)
            {
                user = new IdentityUser(username);
                await userManager.CreateAsync(user, password);
            }

            if (user != null)
            {
                var isInRole = await userManager.IsInRoleAsync(user, roleName);
                if (!isInRole)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
        internal static void PopulateRoles(RoleManager<IdentityRole> roleManager)
        {
            EnsureRoleIsCreatedAsync(roleManager, "admin").Wait();
            EnsureRoleIsCreatedAsync(roleManager, "client").Wait();
            EnsureRoleIsCreatedAsync(roleManager, "manager").Wait();
            // ...

        }

        private static async Task EnsureRoleIsCreatedAsync(RoleManager<IdentityRole> roleManager, string roleName)
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                await roleManager.CreateAsync(role);
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
                    new Job { JobName = "Administrative Assistant", JobDescription = "Responsible for administrative tasks such as document control, payments, and internal communication." },
                    new Job { JobName = "Bartender", JobDescription = "Prepares and serves drinks to guests, ensuring high-quality service and maintaining cleanliness at the bar." },
                    new Job { JobName = "Maintenance Technician", JobDescription = "Handles repairs and maintenance of the hotel's infrastructure and facilities." },
                    new Job { JobName = "Event Coordinator", JobDescription = "Plans and coordinates events hosted at the hotel, ensuring client satisfaction and smooth operations." },
                    new Job { JobName = "Security Officer", JobDescription = "Ensures the safety and security of hotel guests, staff, and property." },
                    new Job { JobName = "Spa Therapist", JobDescription = "Provides spa treatments to guests, ensuring a relaxing and rejuvenating experience." }
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
                    new TypeOfSchedule { TypeOfScheduleName = "Late Night Shift", TypeOfScheduleDescription = "This shift starts late at night and ends early morning." },
                    new TypeOfSchedule { TypeOfScheduleName = "Weekend Shift", TypeOfScheduleDescription = "This shift covers work on weekends, typically Saturday and Sunday." },
                    new TypeOfSchedule { TypeOfScheduleName = "Split Shift", TypeOfScheduleDescription = "This shift involves working two separate periods in a day." },
                    new TypeOfSchedule { TypeOfScheduleName = "Holiday Shift", TypeOfScheduleDescription = "This shift is assigned during public holidays or festive seasons." },
                    new TypeOfSchedule { TypeOfScheduleName = "On-Call Shift", TypeOfScheduleDescription = "This shift requires employees to be on standby and available when needed." },
                    new TypeOfSchedule { TypeOfScheduleName = "Flexible Shift", TypeOfScheduleDescription = "This shift allows employees to choose their working hours within a given range." }
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
                    },
                    new Staff
                    {
                        StaffName = "Michael Brown",
                        StaffEmail = "michaelbrown@example.com",
                        StaffPhone = "+1111111111",
                        StaffDriversLicense = "D555555555",
                        StaffDriversLicenseExpiringDate = new DateTime(2026, 11, 30),
                        StaffDateOfBirth = new DateTime(1988, 2, 14),
                        StaffPassword = "PasswordMichael123",
                        StartFunctionsDate = new DateTime(2021, 9, 1),
                        EndFunctionsDate = new DateTime(2026, 9, 1),
                        DaysOfVacationCount = 25,
                        IsActive = true,
                        JobId = 3
                    },
                    new Staff
                    {
                        StaffName = "Emily White",
                        StaffEmail = "emilywhite@example.com",
                        StaffPhone = "+2222222222",
                        StaffDriversLicense = "D666666666",
                        StaffDriversLicenseExpiringDate = new DateTime(2029, 8, 15),
                        StaffDateOfBirth = new DateTime(1992, 6, 10),
                        StaffPassword = "EmilyPassword123",
                        StartFunctionsDate = new DateTime(2020, 5, 10),
                        EndFunctionsDate = new DateTime(2025, 5, 10),
                        DaysOfVacationCount = 18,
                        IsActive = true,
                        JobId = 4
                    },
                    new Staff
                    {
                        StaffName = "Sophia Taylor",
                        StaffEmail = "sophiataylor@example.com",
                        StaffPhone = "+3333333333",
                        StaffDriversLicense = "D777777777",
                        StaffDriversLicenseExpiringDate = new DateTime(2030, 4, 20),
                        StaffDateOfBirth = new DateTime(1987, 12, 1),
                        StaffPassword = "Taylor123Secure",
                        StartFunctionsDate = new DateTime(2018, 1, 1),
                        EndFunctionsDate = new DateTime(2024, 1, 1),
                        DaysOfVacationCount = 30,
                        IsActive = true,
                        JobId = 5
                    },
                    new Staff
                    {
                        StaffName = "David Wilson",
                        StaffEmail = "davidwilson@example.com",
                        StaffPhone = "+4444444444",
                        StaffDriversLicense = "D888888888",
                        StaffDriversLicenseExpiringDate = new DateTime(2025, 7, 1),
                        StaffDateOfBirth = new DateTime(1995, 4, 25),
                        StaffPassword = "DavidWilson123",
                        StartFunctionsDate = new DateTime(2022, 2, 15),
                        EndFunctionsDate = new DateTime(2027, 2, 15),
                        DaysOfVacationCount = 10,
                        IsActive = true,
                        JobId = 1
                    },
                    new Staff
                    {
                        StaffName = "Olivia Green",
                        StaffEmail = "oliviagreen@example.com",
                        StaffPhone = "+5555555555",
                        StaffDriversLicense = "D999999999",
                        StaffDriversLicenseExpiringDate = new DateTime(2026, 10, 10),
                        StaffDateOfBirth = new DateTime(1993, 9, 5),
                        StaffPassword = "OliviaGreen123",
                        StartFunctionsDate = new DateTime(2021, 11, 20),
                        EndFunctionsDate = new DateTime(2024, 11, 20),
                        DaysOfVacationCount = 12,
                        IsActive = true,
                        JobId = 2
                    },
                    new Staff
                    {
                        StaffName = "James Martin",
                        StaffEmail = "jamesmartin@example.com",
                        StaffPhone = "+6666666666",
                        StaffDriversLicense = "D101010101",
                        StaffDriversLicenseExpiringDate = new DateTime(2028, 6, 15),
                        StaffDateOfBirth = new DateTime(1991, 7, 30),
                        StaffPassword = "MartinJames123",
                        StartFunctionsDate = new DateTime(2020, 4, 15),
                        EndFunctionsDate = new DateTime(2026, 4, 15),
                        DaysOfVacationCount = 22,
                        IsActive = true,
                        JobId = 3
                    },
                    new Staff
                    {
                        StaffName = "Ella Brown",
                        StaffEmail = "ellabrown@example.com",
                        StaffPhone = "+7777777777",
                        StaffDriversLicense = "D121212121",
                        StaffDriversLicenseExpiringDate = new DateTime(2031, 1, 25),
                        StaffDateOfBirth = new DateTime(1989, 11, 12),
                        StaffPassword = "BrownElla123",
                        StartFunctionsDate = new DateTime(2019, 8, 1),
                        EndFunctionsDate = new DateTime(2025, 8, 1),
                        DaysOfVacationCount = 28,
                        IsActive = true,
                        JobId = 4
                    },
                    new Staff
                    {
                        StaffName = "Lucas Anderson",
                        StaffEmail = "lucasanderson@example.com",
                        StaffPhone = "+8888888888",
                        StaffDriversLicense = "D131313131",
                        StaffDriversLicenseExpiringDate = new DateTime(2027, 3, 18),
                        StaffDateOfBirth = new DateTime(1996, 3, 18),
                        StaffPassword = "LucasAnderson123",
                        StartFunctionsDate = new DateTime(2023, 1, 10),
                        EndFunctionsDate = new DateTime(2028, 1, 10),
                        DaysOfVacationCount = 16,
                        IsActive = true,
                        JobId = 5
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
                    },
                    new Schedules
                    {
                        StartShiftTime = new TimeSpan(12, 0, 0),
                        EndShiftTime = new TimeSpan(16, 0, 0),
                        isPrecense = true,
                        isAvailable = true,
                        StaffId = 2,
                        TypeOfScheduleId = db.TypeOfSchedule.First(ts => ts.TypeOfScheduleName == "Afternoon Shift").TypeOfScheduleId
                    },
                    new Schedules
                    {
                        StartShiftTime = new TimeSpan(20, 0, 0),
                        EndShiftTime = new TimeSpan(0, 0, 0),
                        isPrecense = true,
                        isAvailable = true,
                        StaffId = 3,
                        TypeOfScheduleId = db.TypeOfSchedule.First(ts => ts.TypeOfScheduleName == "Night Shift").TypeOfScheduleId
                    },
                    new Schedules
                    {
                        StartShiftTime = new TimeSpan(5, 0, 0),
                        EndShiftTime = new TimeSpan(9, 0, 0),
                        isPrecense = true,
                        isAvailable = true,
                        StaffId = 4,
                        TypeOfScheduleId = db.TypeOfSchedule.First(ts => ts.TypeOfScheduleName == "Early Morning Shift").TypeOfScheduleId
                    },
                    new Schedules
                    {
                        StartShiftTime = new TimeSpan(22, 0, 0),
                        EndShiftTime = new TimeSpan(2, 0, 0),
                        isPrecense = true,
                        isAvailable = true,
                        StaffId = 5,
                        TypeOfScheduleId = db.TypeOfSchedule.First(ts => ts.TypeOfScheduleName == "Late Night Shift").TypeOfScheduleId
                    },
                    new Schedules
                    {
                        StartShiftTime = new TimeSpan(9, 0, 0),
                        EndShiftTime = new TimeSpan(13, 0, 0),
                        isPrecense = false,
                        isAvailable = true,
                        StaffId = 6,
                        TypeOfScheduleId = db.TypeOfSchedule.First(ts => ts.TypeOfScheduleName == "Morning Shift").TypeOfScheduleId
                    },
                    new Schedules
                    {
                        StartShiftTime = new TimeSpan(13, 0, 0),
                        EndShiftTime = new TimeSpan(17, 0, 0),
                        isPrecense = true,
                        isAvailable = false,
                        StaffId = 7,
                        TypeOfScheduleId = db.TypeOfSchedule.First(ts => ts.TypeOfScheduleName == "Afternoon Shift").TypeOfScheduleId
                    },
                    new Schedules
                    {
                        StartShiftTime = new TimeSpan(23, 0, 0),
                        EndShiftTime = new TimeSpan(3, 0, 0),
                        isPrecense = false,
                        isAvailable = true,
                        StaffId = 8,
                        TypeOfScheduleId = db.TypeOfSchedule.First(ts => ts.TypeOfScheduleName == "Night Shift").TypeOfScheduleId
                    },
                    new Schedules
                    {
                        StartShiftTime = new TimeSpan(6, 0, 0),
                        EndShiftTime = new TimeSpan(10, 0, 0),
                        isPrecense = true,
                        isAvailable = true,
                        StaffId = 9,
                        TypeOfScheduleId = db.TypeOfSchedule.First(ts => ts.TypeOfScheduleName == "Early Morning Shift").TypeOfScheduleId
                    },
                    new Schedules
                    {
                        StartShiftTime = new TimeSpan(22, 30, 0),
                        EndShiftTime = new TimeSpan(2, 30, 0),
                        isPrecense = true,
                        isAvailable = false,
                        StaffId = 10,
                        TypeOfScheduleId = db.TypeOfSchedule.First(ts => ts.TypeOfScheduleName == "Late Night Shift").TypeOfScheduleId
                    }
                );
                db.SaveChanges();
            }
        }

    }
}

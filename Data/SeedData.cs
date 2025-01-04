using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReserveSystem.Data.Migrations;
using ReserveSystem.Models;
using System;
using System.Linq;

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

        internal static void PopulateUsers(UserManager<IdentityUser> userManager)
        {
            //EnsureUserIsCreatedAsync(userManager, "john@ipg.pt", "Secret$123", "client").Wait();
        }

        internal static void PopulateDefaultAdmin(UserManager<IdentityUser> userManager)
        {
            //EnsureUserIsCreatedAsync(userManager, "admin@ipg.pt", "Secret$123", "admin").Wait();
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
            //EnsureRoleIsCreatedAsync(roleManager, "admin").Wait();
            //EnsureRoleIsCreatedAsync(roleManager, "client").Wait();

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
                    new Job
                    {
                        JobName = "Receptionist",
                        JobDescription = "Responsible for attending to guests, checking them in and out, and managing reservations."
                    },
                    new Job
                    {
                        JobName = "Cook",
                        JobDescription = "Responsible for preparing meals in the hotel, following the menu and hygiene standards."
                    },
                    new Job
                    {
                        JobName = "Housekeeper",
                        JobDescription = "Responsible for cleaning and organizing rooms, hallways, and common areas of the hotel."
                    },
                    new Job
                    {
                        JobName = "Manager",
                        JobDescription = "Responsible for overseeing the entire hotel operation, managing staff, and ensuring customer satisfaction."
                    },
                    new Job
                    {
                        JobName = "Administrative Assistant",
                        JobDescription = "Responsible for administrative tasks such as document control, payments, and internal communication."
                    }
                );

                db.SaveChanges();
            }
        }

        public static void PopulateTypesOfSchedule(ReserveSystemContext db)
        {
            if (!db.TypeOfSchedule.Any())
            {
                db.TypeOfSchedule.AddRange(
                    new TypeOfSchedule
                    {
                        TypeOfScheduleName = "Morning Shift",
                        TypeOfScheduleDescription = "This shift starts in the morning and ends at noon."
                    },
                    new TypeOfSchedule
                    {
                        TypeOfScheduleName = "Afternoon Shift",
                        TypeOfScheduleDescription = "This shift starts after noon and ends in the evening."
                    },
                    new TypeOfSchedule
                    {
                        TypeOfScheduleName = "Night Shift",
                        TypeOfScheduleDescription = "This shift starts in the evening and ends at night."
                    },
                    new TypeOfSchedule
                    {
                        TypeOfScheduleName = "Early Morning Shift",
                        TypeOfScheduleDescription = "This shift starts early in the morning before sunrise."
                    },
                    new TypeOfSchedule
                    {
                        TypeOfScheduleName = "Late Night Shift",
                        TypeOfScheduleDescription = "This shift starts late at night and ends early morning."
                    }
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
                        JobId = 1 //JobId válido
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
                        JobId = 2 //JobId válido
                    },
                    new Staff
                    {
                        StaffName = "Alice Brown",
                        StaffEmail = "alicebrown@example.com",
                        StaffPhone = "+1122334455",
                        StaffDriversLicense = "D1122334455",
                        StaffDriversLicenseExpiringDate = new DateTime(2029, 12, 31),
                        StaffDateOfBirth = new DateTime(1988, 8, 9),
                        StaffPassword = "Password1234",
                        StartFunctionsDate = new DateTime(2021, 10, 10),
                        EndFunctionsDate = new DateTime(2024, 10, 10),
                        DaysOfVacationCount = 18,
                        IsActive = true,
                        JobId = 3 //JobId válido
                    },
                    new Staff
                    {
                        StaffName = "Bob White",
                        StaffEmail = "bobwhite@example.com",
                        StaffPhone = "+1777888999",
                        StaffDriversLicense = "D2233445566",
                        StaffDriversLicenseExpiringDate = new DateTime(2030, 11, 30),
                        StaffDateOfBirth = new DateTime(1992, 12, 1),
                        StaffPassword = "Secure123Password",
                        StartFunctionsDate = new DateTime(2023, 5, 20),
                        EndFunctionsDate = new DateTime(2025, 5, 20),
                        DaysOfVacationCount = 10,
                        IsActive = true,
                        JobId = 4 //JobId válido
                    },
                    new Staff
                    {
                        StaffName = "Carol Black",
                        StaffEmail = "carolblack@example.com",
                        StaffPhone = "+1999112233",
                        StaffDriversLicense = "D6677889900",
                        StaffDriversLicenseExpiringDate = new DateTime(2026, 5, 31),
                        StaffDateOfBirth = new DateTime(1995, 2, 18),
                        StaffPassword = "AnotherPassword123",
                        StartFunctionsDate = new DateTime(2024, 1, 10),
                        EndFunctionsDate = new DateTime(2026, 1, 10),
                        DaysOfVacationCount = 12,
                        IsActive = true,
                        JobId = 5 //JobId válido
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
                    // Morning Shift (Exemplo: 08:00 - 12:00)
                    new Schedules
                    {
                        StartShiftTime = new TimeSpan(8, 0, 0),  // 08:00 AM
                        EndShiftTime = new TimeSpan(12, 0, 0),   // 12:00 PM
                        isPrecense = true,
                        isAvailable = true,
                        StaffId = 1,
                        TypeOfScheduleId = db.TypeOfSchedule.First(ts => ts.TypeOfScheduleName == "Morning Shift").TypeOfScheduleId
                    },

                    // Afternoon Shift (Exemplo: 12:00 - 18:00)
                    new Schedules
                    {
                        StartShiftTime = new TimeSpan(12, 0, 0),  // 12:00 PM
                        EndShiftTime = new TimeSpan(18, 0, 0),    // 06:00 PM
                        isPrecense = true,
                        isAvailable = true,
                        StaffId = 2,
                        TypeOfScheduleId = db.TypeOfSchedule.First(ts => ts.TypeOfScheduleName == "Afternoon Shift").TypeOfScheduleId
                    },

                    // Night Shift (Exemplo: 18:00 - 00:00)
                    new Schedules
                    {
                        StartShiftTime = new TimeSpan(18, 0, 0),  // 06:00 PM
                        EndShiftTime = new TimeSpan(0, 0, 0),     // 12:00 AM (Meia-noite)
                        isPrecense = true,
                        isAvailable = true,
                        StaffId = 3,
                        TypeOfScheduleId = db.TypeOfSchedule.First(ts => ts.TypeOfScheduleName == "Night Shift").TypeOfScheduleId
                    },

                    // Early Morning Shift (Exemplo: 05:00 - 08:00)
                    new Schedules
                    {
                        StartShiftTime = new TimeSpan(5, 0, 0),   // 05:00 AM
                        EndShiftTime = new TimeSpan(8, 0, 0),     // 08:00 AM
                        isPrecense = true,
                        isAvailable = true,
                        StaffId = 4,
                        TypeOfScheduleId = db.TypeOfSchedule.First(ts => ts.TypeOfScheduleName == "Early Morning Shift").TypeOfScheduleId
                    },

                    // Late Night Shift (Exemplo: 22:00 - 05:00)
                    new Schedules
                    {
                        StartShiftTime = new TimeSpan(22, 0, 0),  // 10:00 PM
                        EndShiftTime = new TimeSpan(5, 0, 0),     // 05:00 AM
                        isPrecense = true,
                        isAvailable = true,
                        StaffId = 5,
                        TypeOfScheduleId = db.TypeOfSchedule.First(ts => ts.TypeOfScheduleName == "Late Night Shift").TypeOfScheduleId
                    }
                );

                db.SaveChanges();
            }
        }

    }
}




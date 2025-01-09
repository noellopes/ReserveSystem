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
            PopulateRoomType(db);
            PopulateRoom(db);
            PopulateBooking(db);
            PopulateRoomBooking(db);
            PopulateClient(db);
            PopulateCleaningSchedule(db);
            PopulateConsumptions(db);
            PopulateItems(db);
            PopulateItemRoom(db);
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
        public static void PopulateRoomType(ReserveSystemContext db)
        {
            if (!db.Room_Type.Any())
            {
                db.Room_Type.AddRange(
                    new Room_Type
                    {
                        HasView = true,
                        Type = "Single",
                        Capacity = 1,
                        RoomCapacity = 1,
                        AcessibilityRoom = false
                    },
                    new Room_Type
                    {
                        HasView = true,
                        Type = "Double",
                        Capacity = 2,
                        RoomCapacity = 2,
                        AcessibilityRoom = true
                    },
                    new Room_Type
                    {
                        HasView = false,
                        Type = "Suite",
                        Capacity = 4,
                        RoomCapacity = 4,
                        AcessibilityRoom = false
                    },
                    new Room_Type
                    {
                        HasView = true,
                        Type = "Family",
                        Capacity = 4,
                        RoomCapacity = 3,
                        AcessibilityRoom = true
                    },
                    new Room_Type
                    {
                        HasView = true,
                        Type = "Luxury",
                        Capacity = 2,
                        RoomCapacity = 2,
                        AcessibilityRoom = false
                    },
                    new Room_Type
                    {
                        HasView = false,
                        Type = "Penthouse",
                        Capacity = 6,
                        RoomCapacity = 5,
                        AcessibilityRoom = true
                    },
                    new Room_Type
                    {
                        HasView = true,
                        Type = "Standard",
                        Capacity = 2,
                        RoomCapacity = 2,
                        AcessibilityRoom = false
                    },
                    new Room_Type
                    {
                        HasView = false,
                        Type = "Economy",
                        Capacity = 1,
                        RoomCapacity = 1,
                        AcessibilityRoom = false
                    },
                    new Room_Type
                    {
                        HasView = true,
                        Type = "Business",
                        Capacity = 2,
                        RoomCapacity = 2,
                        AcessibilityRoom = true
                    },
                    new Room_Type
                    {
                        HasView = true,
                        Type = "Honeymoon Suite",
                        Capacity = 2,
                        RoomCapacity = 2,
                        AcessibilityRoom = false
                    }
                );
                db.SaveChanges();
            }
        }

        public static void PopulateRoom(ReserveSystemContext db)
        {
            if (!db.Room.Any())
            {
                db.Room.AddRange(
                    new Room { RoomTypeId = 1 },
                    new Room { RoomTypeId = 2 },
                    new Room { RoomTypeId = 3 },
                    new Room { RoomTypeId = 2 },
                    new Room { RoomTypeId = 5 },
                    new Room { RoomTypeId = 9 },
                    new Room { RoomTypeId = 7 },
                    new Room { RoomTypeId = 8 },
                    new Room { RoomTypeId = 4 },
                    new Room { RoomTypeId = 1 }
                );
                db.SaveChanges();
            }
        }

        public static void PopulateRoomBooking(ReserveSystemContext db)
        {
            if (!db.Room_Booking.Any())
            {
                db.Room_Booking.AddRange(
                    new Room_Booking { BookingId = 1, RoomId = 1, Persons_Number = 1 },
                    new Room_Booking { BookingId = 2, RoomId = 2, Persons_Number = 2 },
                    new Room_Booking { BookingId = 3, RoomId = 3, Persons_Number = 4 },
                    new Room_Booking { BookingId = 4, RoomId = 4, Persons_Number = 3 },
                    new Room_Booking { BookingId = 5, RoomId = 5, Persons_Number = 2 },
                    new Room_Booking { BookingId = 6, RoomId = 6, Persons_Number = 5 },
                    new Room_Booking { BookingId = 7, RoomId = 7, Persons_Number = 2 },
                    new Room_Booking { BookingId = 8, RoomId = 8, Persons_Number = 1 },
                    new Room_Booking { BookingId = 9, RoomId = 9, Persons_Number = 2 },
                    new Room_Booking { BookingId = 10, RoomId = 10, Persons_Number = 2 }
                );
                db.SaveChanges();
            }
        }

        public static void PopulateBooking(ReserveSystemContext db)
        {
            if (!db.Booking.Any())
            {
                db.Booking.AddRange(
                    new Booking
                    {
                        ClientId = 1,
                        Checkin_date = new DateTime(2025, 2, 1),
                        Checkout_date = new DateTime(2025, 2, 5),
                        Booking_Date = new DateTime(2024, 12, 15),
                        Booked = true,
                        Total_Persons_Number = 1,
                        Payment_Status = true
                    },
                    new Booking
                    {
                        ClientId = 2,
                        Checkin_date = new DateTime(2025, 3, 5),
                        Checkout_date = new DateTime(2025, 3, 10),
                        Booking_Date = new DateTime(2024, 11, 20),
                        Booked = true,
                        Total_Persons_Number = 2,
                        Payment_Status = true
                    },
                    new Booking
                    {
                        ClientId = 2,
                        Checkin_date = new DateTime(2025, 4, 10),
                        Checkout_date = new DateTime(2025, 4, 15),
                        Booking_Date = new DateTime(2024, 10, 10),
                        Booked = true,
                        Total_Persons_Number = 4,
                        Payment_Status = false
                    },
                    new Booking
                    {
                        ClientId = 4,
                        Checkin_date = new DateTime(2025, 5, 1),
                        Checkout_date = new DateTime(2025, 5, 7),
                        Booking_Date = new DateTime(2024, 12, 1),
                        Booked = true,
                        Total_Persons_Number = 3,
                        Payment_Status = true
                    },
                    new Booking
                    {
                        ClientId = 5,
                        Checkin_date = new DateTime(2025, 6, 20),
                        Checkout_date = new DateTime(2025, 6, 25),
                        Booking_Date = new DateTime(2024, 11, 5),
                        Booked = true,
                        Total_Persons_Number = 2,
                        Payment_Status = false
                    },
                    new Booking
                    {
                        ClientId = 5,
                        Checkin_date = new DateTime(2025, 7, 15),
                        Checkout_date = new DateTime(2025, 7, 20),
                        Booking_Date = new DateTime(2024, 10, 1),
                        Booked = true,
                        Total_Persons_Number = 5,
                        Payment_Status = true
                    },
                    new Booking
                    {
                        ClientId = 7,
                        Checkin_date = new DateTime(2025, 8, 1),
                        Checkout_date = new DateTime(2025, 8, 5),
                        Booking_Date = new DateTime(2024, 9, 15),
                        Booked = true,
                        Total_Persons_Number = 2,
                        Payment_Status = true
                    },
                    new Booking
                    {
                        ClientId = 8,
                        Checkin_date = new DateTime(2025, 9, 1),
                        Checkout_date = new DateTime(2025, 9, 5),
                        Booking_Date = new DateTime(2024, 12, 1),
                        Booked = false,
                        Total_Persons_Number = 1,
                        Payment_Status = false
                    },
                    new Booking
                    {
                        ClientId = 9,
                        Checkin_date = new DateTime(2025, 10, 10),
                        Checkout_date = new DateTime(2025, 10, 15),
                        Booking_Date = new DateTime(2024, 10, 5),
                        Booked = true,
                        Total_Persons_Number = 2,
                        Payment_Status = true
                    },
                    new Booking
                    {
                        ClientId = 10,
                        Checkin_date = new DateTime(2025, 11, 1),
                        Checkout_date = new DateTime(2025, 11, 5),
                        Booking_Date = new DateTime(2024, 11, 25),
                        Booked = true,
                        Total_Persons_Number = 2,
                        Payment_Status = true
                    }
                );
                db.SaveChanges();
            }
        }

        public static void PopulateClient(ReserveSystemContext db)
        {
            if (!db.Client.Any())
            {
                db.Client.AddRange(
                    new Client
                    {
                        Client_Name = "John Doe",
                        Client_Phone = "+1234567890",
                        Client_Adress = "123 Main St, City, Country",
                        Client_Email = "johndoe@example.com",
                        Client_Nif = "123456789",
                        Client_Login = true,
                        Client_Status = true
                    },
                    new Client
                    {
                        Client_Name = "Jane Smith",
                        Client_Phone = "+1987654321",
                        Client_Adress = "456 Oak Ave, City, Country",
                        Client_Email = "janesmith@example.com",
                        Client_Nif = "987654321",
                        Client_Login = true,
                        Client_Status = true
                    },
                    new Client
                    {
                        Client_Name = "Michael Brown",
                        Client_Phone = "+1122334455",
                        Client_Adress = "789 Pine Rd, City, Country",
                        Client_Email = "michaelbrown@example.com",
                        Client_Nif = "112233445",
                        Client_Login = true,
                        Client_Status = false
                    },
                    new Client
                    {
                        Client_Name = "Sarah Williams",
                        Client_Phone = "+2233445566",
                        Client_Adress = "321 Maple Dr, City, Country",
                        Client_Email = "sarahwilliams@example.com",
                        Client_Nif = "223344556",
                        Client_Login = false,
                        Client_Status = true
                    },
                    new Client
                    {
                        Client_Name = "David Johnson",
                        Client_Phone = "+3344556677",
                        Client_Adress = "654 Birch Blvd, City, Country",
                        Client_Email = "davidjohnson@example.com",
                        Client_Nif = "334455667",
                        Client_Login = true,
                        Client_Status = true
                    }
                );
                db.SaveChanges();
            }
        }

        public static void PopulateCleaningSchedule(ReserveSystemContext db)
        {
            if (!db.Cleaning_Schedule.Any())
            {
                db.Cleaning_Schedule.AddRange(
                    new Cleaning_Schedule
                    {
                        RoomBookingId = 1,
                        ClientId = 1,
                        StaffId = 1,
                        DateServices = new DateTime(2025, 1, 15),
                        StartTime = new DateTime(2025, 1, 15, 8, 0, 0),
                        EndTime = new DateTime(2025, 1, 15, 10, 0, 0),
                        CleaningDone = false,
                        CleaningDesired = true,
                        PreferredCleaningStartTime = new DateTime(2025, 1, 15, 7, 0, 0),
                        PreferredCleaningEndTime = new DateTime(2025, 1, 15, 9, 0, 0)
                    },
                    new Cleaning_Schedule
                    {
                        RoomBookingId = 2,
                        ClientId = 2,
                        StaffId = 2,
                        DateServices = new DateTime(2025, 1, 16),
                        StartTime = new DateTime(2025, 1, 16, 9, 0, 0),
                        EndTime = new DateTime(2025, 1, 16, 11, 0, 0),
                        CleaningDone = true,
                        CleaningDesired = true,
                        PreferredCleaningStartTime = null,
                        PreferredCleaningEndTime = null
                    },
                    new Cleaning_Schedule
                    {
                        RoomBookingId = 3,
                        ClientId = 3,
                        StaffId = 3,
                        DateServices = new DateTime(2025, 1, 17),
                        StartTime = new DateTime(2025, 1, 17, 10, 0, 0),
                        EndTime = new DateTime(2025, 1, 17, 12, 0, 0),
                        CleaningDone = false,
                        CleaningDesired = true,
                        PreferredCleaningStartTime = new DateTime(2025, 1, 17, 9, 0, 0),
                        PreferredCleaningEndTime = new DateTime(2025, 1, 17, 11, 0, 0)
                    },
                    new Cleaning_Schedule
                    {
                        RoomBookingId = 4,
                        ClientId = 4,
                        StaffId = 4,
                        DateServices = new DateTime(2025, 1, 18),
                        StartTime = new DateTime(2025, 1, 18, 7, 0, 0),
                        EndTime = new DateTime(2025, 1, 18, 9, 0, 0),
                        CleaningDone = true,
                        CleaningDesired = false,
                        PreferredCleaningStartTime = null,
                        PreferredCleaningEndTime = null
                    },
                    new Cleaning_Schedule
                    {
                        RoomBookingId = 5,
                        ClientId = 5,
                        StaffId = 5,
                        DateServices = new DateTime(2025, 1, 19),
                        StartTime = new DateTime(2025, 1, 19, 11, 0, 0),
                        EndTime = new DateTime(2025, 1, 19, 13, 0, 0),
                        CleaningDone = false,
                        CleaningDesired = true,
                        PreferredCleaningStartTime = new DateTime(2025, 1, 19, 10, 0, 0),
                        PreferredCleaningEndTime = new DateTime(2025, 1, 19, 12, 0, 0)
                    }
                );
                db.SaveChanges();
            }
        }

        public static void PopulateConsumptions(ReserveSystemContext db)
        {
            if (!db.Consumptions.Any())
            {
                db.Consumptions.AddRange(
                    new Consumptions
                    {
                        RoomId = 1,
                        ItemId = 1,
                        QuantityConsumed = 2,
                        ConsumedDate = new DateTime(2025, 1, 15)
                    },
                    new Consumptions
                    {
                        RoomId = 2,
                        ItemId = 2,
                        QuantityConsumed = 5,
                        ConsumedDate = new DateTime(2025, 1, 16)
                    },
                    new Consumptions
                    {
                        RoomId = 3,
                        ItemId = 3,
                        QuantityConsumed = 3,
                        ConsumedDate = new DateTime(2025, 1, 17)
                    },
                    new Consumptions
                    {
                        RoomId = 4,
                        ItemId = 4,
                        QuantityConsumed = 1,
                        ConsumedDate = new DateTime(2025, 1, 18)
                    },
                    new Consumptions
                    {
                        RoomId = 5,
                        ItemId = 5,
                        QuantityConsumed = 4,
                        ConsumedDate = new DateTime(2025, 1, 19)
                    }
                );
                db.SaveChanges();
            }
        }

        public static void PopulateItems(ReserveSystemContext db)
        {
            if (!db.Items.Any())
            {
                db.Items.AddRange(
                    new Items
                    {
                        Name = "Shampoo",
                        QuantityStock = 50
                    },
                    new Items
                    {
                        Name = "Soap",
                        QuantityStock = 100
                    },
                    new Items
                    {
                        Name = "Towel",
                        QuantityStock = 25
                    },
                    new Items
                    {
                        Name = "Toothpaste",
                        QuantityStock = 75
                    },
                    new Items
                    {
                        Name = "Conditioner",
                        QuantityStock = 30
                    }
                );
                db.SaveChanges();
            }
        }

        public static void PopulateItemRoom(ReserveSystemContext db)
        {
            if (!db.Item_Room.Any())
            {
                db.Item_Room.AddRange(
                    new Item_Room
                    {
                        RoomTypeId = 1,
                        ItemId = 1,
                        RoomQuantity = 10
                    },
                    new Item_Room
                    {
                        RoomTypeId = 2,
                        ItemId = 2,
                        RoomQuantity = 5
                    },
                    new Item_Room
                    {
                        RoomTypeId = 3,
                        ItemId = 3,
                        RoomQuantity = 8
                    },
                    new Item_Room
                    {
                        RoomTypeId = 4,
                        ItemId = 4,
                        RoomQuantity = 12
                    },
                    new Item_Room
                    {
                        RoomTypeId = 5,
                        ItemId = 5,
                        RoomQuantity = 15
                    }
                );
                db.SaveChanges();
            }
        }
    }
}

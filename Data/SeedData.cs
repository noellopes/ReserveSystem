using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
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
            // Verificar se a tabela já tem dados
            if (!db.TypeOfSchedule.Any())
            {
                // Adicionar dados de exemplo
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
                    }
                );

                // Salvar as alterações no banco de dados
                db.SaveChanges();
            }
        }

    }
}




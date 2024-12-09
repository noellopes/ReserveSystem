using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReserveSystem.Data;
using ReserveSystem.Models;
using System;
using System.Linq;

namespace ReserveSystem.Models
{
    public static class SeedData
    {
        internal static void Populate(ReserveSystemContext? db) {
            if (db == null) return;
            db.Database.EnsureCreated();

            // ...
        }

        internal static void PopulateUsers(UserManager<IdentityUser> userManager) {
            EnsureUserIsCreatedAsync(userManager, "john@ipg.pt", "Secret$123");
        }

        internal static void PopulateDefaultAdmin(UserManager<IdentityUser> userManager) {
            EnsureUserIsCreatedAsync(userManager, "admin@ipg.pt", "Secret$123").Wait();
        }

        private static async Task EnsureUserIsCreatedAsync(UserManager<IdentityUser> userManager, string username, string password) {
            var user = await userManager.FindByNameAsync(username);

            if (user == null) {
                user = new IdentityUser(username);
                await userManager.CreateAsync(user, password);
            }
        }
    }
}

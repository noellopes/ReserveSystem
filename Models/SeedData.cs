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
            EnsureUserIsCreatedAsync(userManager, "john@ipg.pt", "Secret$123", "client").Wait();
        }

        internal static void PopulateDefaultAdmin(UserManager<IdentityUser> userManager) {
            EnsureUserIsCreatedAsync(userManager, "admin@ipg.pt", "Secret$123", "admin").Wait();
        }

        private static async Task EnsureUserIsCreatedAsync(UserManager<IdentityUser> userManager, string username, string password, string roleName) {
            var user = await userManager.FindByNameAsync(username);

            if (user == null) {
                user = new IdentityUser(username);
                await userManager.CreateAsync(user, password);
            }

            if (user != null) {
                var isInRole = await userManager.IsInRoleAsync(user, roleName);
                if (!isInRole) {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }

        internal static void PopulateRoles(RoleManager<IdentityRole> roleManager) {
            EnsureRoleIsCreatedAsync(roleManager, "admin").Wait();
            EnsureRoleIsCreatedAsync(roleManager, "client").Wait();

            // ...
        }

        private static async Task EnsureRoleIsCreatedAsync(RoleManager<IdentityRole> roleManager, string roleName) {
            var role = await roleManager.FindByNameAsync(roleName);

            if (role == null) {
                role = new IdentityRole(roleName);
                await roleManager.CreateAsync(role);
            }
        }

    }
}

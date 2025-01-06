using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ReserveSystem.Data.UserMigrations
{
    public class ReserveSystemUsersDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public ReserveSystemUsersDbContext(DbContextOptions<ReserveSystemUsersDbContext> options)
            : base(options)
        {
        }
    }
}

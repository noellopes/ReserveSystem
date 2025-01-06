using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Data.Migrations;
using ReserveSystem.Data.UserMigrations;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

// Configure database connections
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    var connectionString = builder.Configuration.GetConnectionString("ReserveSystemsUsers")
        ?? throw new InvalidOperationException("Connection string 'ReserveSystemsUsers' not found.");
    builder.Services.AddDbContext<ReserveSystemUsersDbContext>(options =>
        options.UseSqlServer(connectionString));

    builder.Services.AddDbContext<ReserveSystemContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ReserveSystem")
            ?? throw new InvalidOperationException("Connection string 'ReserveSystem' not found.")));
}
else
{
    var connectionString = builder.Configuration.GetConnectionString("ReserveSystemsUsersSqlite")
        ?? throw new InvalidOperationException("Connection string 'ReserveSystemsUsersSqlite' not found.");
    builder.Services.AddDbContext<ReserveSystemUsersDbContext>(options =>
        options.UseSqlite(connectionString));

    builder.Services.AddDbContext<ReserveSystemContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("ReserveSystemSqlite")
            ?? throw new InvalidOperationException("Connection string 'ReserveSystemSqlite' not found.")));
}

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 8;
    options.Password.RequiredUniqueChars = 6;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 5;
})
.AddEntityFrameworkStores<ReserveSystemUsersDbContext>()
.AddDefaultTokenProviders()
.AddDefaultUI();

var app = builder.Build();

// Seed database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ReserveSystemContext>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    SeedData.Populate(context);
    SeedData.PopulateRoles(roleManager);
    SeedData.PopulateDefaultAdmin(userManager);
    SeedData.PopulateUsers(userManager);
}

app.Run();

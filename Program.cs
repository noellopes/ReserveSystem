using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    var connectionString = builder.Configuration.GetConnectionString("ReserveSystemsUsers") ?? throw new InvalidOperationException("Connection string 'ReserveSystemsUsers' not found.");
    builder.Services.AddDbContext<ReserveSystemUsersDbContext>(options =>
        options.UseSqlServer(connectionString));

    builder.Services.AddDbContext<ReserveSystemContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ReserveSystem") ?? throw new InvalidOperationException("Connection string 'ReserveSystem' not found.")));
}
else
{
    var connectionString = builder.Configuration.GetConnectionString("ReserveSystemsUsersSqlite") ?? throw new InvalidOperationException("Connection string 'ReserveSystemsUsersSqlite' not found.");
    builder.Services.AddDbContext<ReserveSystemUsersDbContext>(options =>
        options.UseSqlite(connectionString));

    builder.Services.AddDbContext<ReserveSystemContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("ReserveSystemSqlite") ?? throw new InvalidOperationException("Connection string 'ReserveSystemSqlite' not found.")));
}

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(
    options => {
        // sign in
        options.SignIn.RequireConfirmedAccount = false;

        // password
        options.Password.RequireDigit = true;
        options.Password.RequireLowercase = true;
        options.Password.RequiredLength = 8;
        options.Password.RequiredUniqueChars = 6;
        options.Password.RequireNonAlphanumeric = true;
        options.Password.RequireUppercase = true;

        // Lockout
        options.Lockout.AllowedForNewUsers = true;
        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
        options.Lockout.MaxFailedAccessAttempts = 5;
    }
)
.AddEntityFrameworkStores<ReserveSystemUsersDbContext>()
//.AddDefaultTokenProviders()
.AddDefaultUI();

builder.Services.AddControllersWithViews();

var app = builder.Build();

var isDevelopment = app.Environment.IsDevelopment();

// Configure the HTTP request pipeline.
if (isDevelopment) {
    app.UseMigrationsEndPoint();
} else { 
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var servicesScope = app.Services.CreateScope()) {
    // Seed Admin
    var userManager = servicesScope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
    SeedData.PopulateDefaultAdmin(userManager);

    if (isDevelopment) {
        // Seed users
        SeedData.PopulateUsers(userManager);

        // Seed the database
        var db = servicesScope.ServiceProvider.GetService<ReserveSystemContext>();
        SeedData.Populate(db);
    }
}


app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();

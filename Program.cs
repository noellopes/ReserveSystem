using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
{
    var connectionString = builder.Configuration.GetConnectionString("ReserveSystemsUsersSqlite") ?? throw new InvalidOperationException("Connection string 'ReserveSystemsUsersSqlite' not found.");
    builder.Services.AddDbContext<ReserveSystemUsersDbContext>(options =>
        options.UseSqlite(connectionString));

    builder.Services.AddDbContext<ReserveSystemContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("ReserveSystemSqlite") ?? throw new InvalidOperationException("Connection string 'ReserveSystemSqlite' not found.")));
}
else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
{
    var connectionString = builder.Configuration.GetConnectionString("ReserveSystemsUsersPostgres") ?? throw new InvalidOperationException("Connection string 'ReserveSystemsUsersPostgres' not found.");
    builder.Services.AddDbContext<ReserveSystemUsersDbContext>(options =>
        options.UseNpgsql(connectionString));

    builder.Services.AddDbContext<ReserveSystemContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("ReserveSystemPostgres") ?? throw new InvalidOperationException("Connection string 'ReserveSystemPostgres' not found.")));
}
else
{
    var connectionString = builder.Configuration.GetConnectionString("ReserveSystemsUsers") ?? throw new InvalidOperationException("Connection string 'ReserveSystemsUsers' not found.");
    builder.Services.AddDbContext<ReserveSystemUsersDbContext>(options =>
        options.UseSqlServer(connectionString));

    builder.Services.AddDbContext<ReserveSystemContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ReserveSystem") ?? throw new InvalidOperationException("Connection string 'ReserveSystem' not found.")));
}

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ReserveSystemUsersDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

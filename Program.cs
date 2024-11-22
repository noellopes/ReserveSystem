using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Data.Migration;
using ReserveSystem.Models;

var builder = WebApplication.CreateBuilder(args);

// Configure services into the DI container.
var connectionStringUsers = builder.Configuration.GetConnectionString("ReserveSystemsUsers")
                         ?? throw new InvalidOperationException("Connection string 'ReserveSystemsUsers' not found.");
builder.Services.AddDbContext<ReserveSystemUsersDbContext>(options =>
    options.UseSqlServer(connectionStringUsers));

var connectionStringSystem = builder.Configuration.GetConnectionString("ReserveSystem")
                           ?? throw new InvalidOperationException("Connection string 'ReserveSystem' not found.");
builder.Services.AddDbContext<ReserveSystemContext>(options =>
    options.UseSqlServer(connectionStringSystem));

// Configure identity settings.
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<ReserveSystemUsersDbContext>();

builder.Services.AddControllersWithViews();

// Build the application.
var app = builder.Build();

// Initialize the database.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        // Initialize ReserveSystem database.
        var systemContext = services.GetRequiredService<ReserveSystemContext>();
        DbInitializer.Initialize(systemContext); // Populates seed data if necessary.

        // Optionally, you could initialize the identity database here if needed.
        // var identityContext = services.GetRequiredService<ReserveSystemUsersDbContext>();
        // identityContext.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred during database initialization: {ex.Message}");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Map controllers and Razor pages.
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Run the application.
app.Run();

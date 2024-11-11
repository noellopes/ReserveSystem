using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ReserveSystemsUsers")
                        ?? throw new InvalidOperationException("Connection string 'ReserveSystemsUsers' not found.");
builder.Services.AddDbContext<ReserveSystemUsersDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReserveSystem")
                        ?? throw new InvalidOperationException("Connection string 'ReserveSystem' not found.")));
;

builder.Services.AddDbContext<ReserveSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReserveSystem")
                        ?? throw new InvalidOperationException("Connection string 'ReserveSystem' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ReserveSystemUsersDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Inicializar o banco de dados ao iniciar o aplicativo
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ReserveSystemUsersDbContext>();
        DbInitializer.Initialize(context); // Chama o inicializador aqui
    }
    catch (Exception ex)
    {
        // Log de erro caso algo falhe ao inicializar
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

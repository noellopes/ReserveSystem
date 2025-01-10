using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

ConfigureDatabases(builder);

ConfigureIdentity(builder);

ConfigureAuthenticationCookies(builder);

builder.Services.AddRazorPages();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Seed roles, users, and data
using (var scope = app.Services.CreateScope())
{
    var scopedServices = scope.ServiceProvider;

    try
    {
        var dbContext = scopedServices.GetRequiredService<ReserveSystemContext>();
        var roleManager = scopedServices.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = scopedServices.GetRequiredService<UserManager<IdentityUser>>();

        await SeedData.PopulateAsync(dbContext, roleManager, userManager);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while seeding data: {ex.Message}");
    }
}

// Middleware configuration
ConfigureMiddleware(app);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


void ConfigureDatabases(WebApplicationBuilder builder)
{
    var useSQLite = builder.Configuration.GetValue<bool>("UseSQLite", false);

    if (useSQLite)
    {
        builder.Services.AddDbContext<ReserveSystemContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")
                              ?? throw new InvalidOperationException(
                                  "Connection string 'SQLiteConnection' not found.")));

        builder.Services.AddDbContext<ReserveSystemUsersDbContext>(options =>
            options.UseSqlite(builder.Configuration.GetConnectionString("SqLiteUsersConnection")
                              ?? throw new InvalidOperationException(
                                  "Connection string 'SqLiteUsersConnection' not found.")));
    }
    else
    {
        builder.Services.AddDbContext<ReserveSystemContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ReserveSystem")
                                 ?? throw new InvalidOperationException(
                                     "Connection string 'ReserveSystem' not found.")));

        builder.Services.AddDbContext<ReserveSystemUsersDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ReserveSystemsUsers")
                                 ?? throw new InvalidOperationException(
                                     "Connection string 'ReserveSystemsUsers' not found.")));
    }
}

void ConfigureIdentity(WebApplicationBuilder builder)
{
    builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
        {
            // Password settings
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequiredLength = 8;
            options.Password.RequiredUniqueChars = 6;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;

            // Lockout settings
            options.Lockout.AllowedForNewUsers = true;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            options.Lockout.MaxFailedAccessAttempts = 5;

            // Sign-in settings
            options.SignIn.RequireConfirmedAccount = false;
        })
        .AddEntityFrameworkStores<ReserveSystemUsersDbContext>()
        .AddDefaultTokenProviders();
}

void ConfigureAuthenticationCookies(WebApplicationBuilder builder)
{
    builder.Services.ConfigureApplicationCookie(options =>
    {
        options.LoginPath = "/Identity/Account/Login";
        options.AccessDeniedPath = "/Identity/Account/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    });
}

void ConfigureMiddleware(WebApplication app)
{
    if (app.Environment.IsDevelopment())
    {
        app.UseMigrationsEndPoint();

        // Debug authentication status
        app.Use(async (context, next) =>
        {
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                Console.WriteLine($"Authenticated User: {context.User.Identity.Name}");
                Console.WriteLine(
                    $"Roles: {string.Join(", ", context.User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value))}");
            }
            else
            {
                Console.WriteLine("User is not authenticated");
            }

            await next();
        });
    }
    else
    {
        app.UseExceptionHandler("/Home/Error");
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseStaticFiles();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
}
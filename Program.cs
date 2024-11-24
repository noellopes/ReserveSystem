using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;

var builder = WebApplication.CreateBuilder(args);

// Check if SQLite should be used (local dev)
var useSQLite = builder.Configuration.GetValue<bool>("UseSQLite", false);

if (useSQLite)
{
    // SQLite for local development
    builder.Services.AddDbContext<ReserveSystemContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection") 
                          ?? throw new InvalidOperationException("Connection string 'SQLiteConnection' not found.")));
}
else
{
    // SQL Server for team
    builder.Services.AddDbContext<ReserveSystemContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ReserveSystem") 
                             ?? throw new InvalidOperationException("Connection string 'ReserveSystem' not found.")));
}

// Identity Configuration
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ReserveSystemContext>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
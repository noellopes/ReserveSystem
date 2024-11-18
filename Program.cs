using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;
using ReserveSystem.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ReserveSystemsUsers") ?? throw new InvalidOperationException("Connection string 'ReserveSystemsUsers' not found.");
builder.Services.AddDbContext<ReserveSystemUsersDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<ReserveSystemContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ReserveSystem") ?? throw new InvalidOperationException("Connection string 'ReserveSystem' not found.")));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();



builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ReserveSystemUsersDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

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



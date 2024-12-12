using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReserveSystem.Data;
using System.Runtime.InteropServices;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
{
    builder.Services.AddDbContext<ReserveSystemContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ReserveSystem") ?? throw new InvalidOperationException("Connection string 'ReserveSystem' not found.")));
}

else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
{
    builder.Services.AddDbContext<ReserveSystemContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("ReserveSystemSqlite") ?? throw new InvalidOperationException("Connection string 'ReserveSystemSqlite' not found.")));
}

/* // (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
else
{
    builder.Services.AddDbContext<ReserveSystemContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("ReserveSystemContextPostGres") ?? throw new InvalidOperationException("Connection string 'ReserveSystemContextPostGres' not found.")));
} */


// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
} else {
    using (var servicesScope = app.Services.CreateScope()) {
        var db = servicesScope.ServiceProvider.GetService<ReserveSystemContext>();
        SeedData.Populate(db);
    }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

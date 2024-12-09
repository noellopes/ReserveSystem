using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;

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
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
    {
        using (var servicesScope = app.Services.CreateScope())
        {
            var db = servicesScope.ServiceProvider.GetService<ReserveSystemContext>();
        // Adicionar tipos de quartos primeiro
        SeedData.PopulateRoomType(db);

        // Adicionar os quartos
        SeedData.PopulateRoom(db);

        // Adicionar itens antes de associá-los a quartos
        SeedData.PopulateItems(db);

        // Adicionar cargos dos funcionários antes dos funcionários
        SeedData.PopulateJob(db);

        // Adicionar os funcionários
        SeedData.PopulateStaff(db);

        // Adicionar clientes
        SeedData.PopulateClients(db);

        //Adicionar Bookings
        SeedData.PopulateBooking(db);

        // Adicionar as reservas de quartos
        SeedData.PopulateRoomBooking(db);

        // Adicionar itens em salas (associados a quartos)
        SeedData.PopulateItemRooms(db);

        // Adicionar serviços de limpeza
        SeedData.PopulateCleaning(db);

        // Agendar limpezas
        SeedData.PopulateCleaningShedule(db);
    }
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

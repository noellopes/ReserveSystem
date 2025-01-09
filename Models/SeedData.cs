using Microsoft.EntityFrameworkCore;
using ReserveSystem.Data;

namespace ReserveSystem.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ReserveSystemContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ReserveSystemContext>>()))
            {

                if (context.ReservaExcursaoModel.Any())
                {
                    return;   // DB has already been seeded
                }


                context.ReservaExcursaoModel.AddRange(
new ReservaExcursaoModel { Id = 221, ClienteId = 21, ExcursaoId = 5, DataReserva = DateTime.UtcNow.AddDays(2), NumPessoas = 2, ValorTotal = 120.00f },
new ReservaExcursaoModel { Id = 222, ClienteId = 22, ExcursaoId = 8, DataReserva = DateTime.UtcNow.AddDays(3), NumPessoas = 3, ValorTotal = 180.00f },
new ReservaExcursaoModel { Id = 223, ClienteId = 23, ExcursaoId = 10, DataReserva = DateTime.UtcNow.AddDays(4), NumPessoas = 4, ValorTotal = 200.00f },
new ReservaExcursaoModel { Id = 224, ClienteId = 24, ExcursaoId = 13, DataReserva = DateTime.UtcNow.AddDays(5), NumPessoas = 5, ValorTotal = 250.00f },
new ReservaExcursaoModel { Id = 225, ClienteId = 25, ExcursaoId = 6, DataReserva = DateTime.UtcNow.AddDays(6), NumPessoas = 3, ValorTotal = 150.00f },
new ReservaExcursaoModel { Id = 226, ClienteId = 26, ExcursaoId = 7, DataReserva = DateTime.UtcNow.AddDays(7), NumPessoas = 1, ValorTotal = 60.00f },
new ReservaExcursaoModel { Id = 227, ClienteId = 27, ExcursaoId = 9, DataReserva = DateTime.UtcNow.AddDays(8), NumPessoas = 7, ValorTotal = 350.00f },
new ReservaExcursaoModel { Id = 228, ClienteId = 28, ExcursaoId = 11, DataReserva = DateTime.UtcNow.AddDays(9), NumPessoas = 2, ValorTotal = 100.00f },
new ReservaExcursaoModel { Id = 229, ClienteId = 29, ExcursaoId = 14, DataReserva = DateTime.UtcNow.AddDays(10), NumPessoas = 3, ValorTotal = 150.00f },
new ReservaExcursaoModel { Id = 330, ClienteId = 30, ExcursaoId = 17, DataReserva = DateTime.UtcNow.AddDays(11), NumPessoas = 4, ValorTotal = 220.00f },
new ReservaExcursaoModel { Id = 331, ClienteId = 31, ExcursaoId = 20, DataReserva = DateTime.UtcNow.AddDays(12), NumPessoas = 2, ValorTotal = 110.00f },
new ReservaExcursaoModel { Id = 332, ClienteId = 32, ExcursaoId = 22, DataReserva = DateTime.UtcNow.AddDays(13), NumPessoas = 5, ValorTotal = 250.00f },
new ReservaExcursaoModel { Id = 333, ClienteId = 33, ExcursaoId = 23, DataReserva = DateTime.UtcNow.AddDays(14), NumPessoas = 4, ValorTotal = 200.00f },
new ReservaExcursaoModel { Id = 334, ClienteId = 34, ExcursaoId = 5, DataReserva = DateTime.UtcNow.AddDays(15), NumPessoas = 3, ValorTotal = 150.00f },
new ReservaExcursaoModel { Id = 335, ClienteId = 35, ExcursaoId = 8, DataReserva = DateTime.UtcNow.AddDays(16), NumPessoas = 2, ValorTotal = 110.00f },
new ReservaExcursaoModel { Id = 336, ClienteId = 36, ExcursaoId = 6, DataReserva = DateTime.UtcNow.AddDays(17), NumPessoas = 4, ValorTotal = 220.00f },
new ReservaExcursaoModel { Id = 337, ClienteId = 37, ExcursaoId = 9, DataReserva = DateTime.UtcNow.AddDays(18), NumPessoas = 6, ValorTotal = 300.00f },
new ReservaExcursaoModel { Id = 338, ClienteId = 38, ExcursaoId = 12, DataReserva = DateTime.UtcNow.AddDays(19), NumPessoas = 3, ValorTotal = 180.00f },
new ReservaExcursaoModel { Id = 339, ClienteId = 39, ExcursaoId = 13, DataReserva = DateTime.UtcNow.AddDays(20), NumPessoas = 5, ValorTotal = 250.00f },
new ReservaExcursaoModel { Id = 330, ClienteId = 40, ExcursaoId = 10, DataReserva = DateTime.UtcNow.AddDays(1), NumPessoas = 2, ValorTotal = 120.00f }
                );

                // Save changes to the context
                context.SaveChanges();
            }
        }
    }
}



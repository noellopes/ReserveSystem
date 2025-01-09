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
                    new ReservaExcursaoModel { Id = 91, ClienteId = 22, ExcursaoId = 1, DataReserva = DateTime.UtcNow.AddDays(2), NumPessoas = 1, ValorTotal = 50.00f },
                    new ReservaExcursaoModel { Id = 92, ClienteId = 33, ExcursaoId = 2, DataReserva = DateTime.UtcNow.AddDays(3), NumPessoas = 4, ValorTotal = 200.00f },
                    new ReservaExcursaoModel { Id = 93, ClienteId = 24, ExcursaoId = 5, DataReserva = DateTime.UtcNow.AddDays(4), NumPessoas = 3, ValorTotal = 150.00f },
                    new ReservaExcursaoModel { Id = 94, ClienteId = 35, ExcursaoId = 6, DataReserva = DateTime.UtcNow.AddDays(5), NumPessoas = 5, ValorTotal = 250.00f },
                    new ReservaExcursaoModel { Id = 95, ClienteId = 36, ExcursaoId = 14, DataReserva = DateTime.UtcNow.AddDays(6), NumPessoas = 2, ValorTotal = 120.00f },
                    new ReservaExcursaoModel { Id = 96, ClienteId = 27, ExcursaoId = 7, DataReserva = DateTime.UtcNow.AddDays(7), NumPessoas = 1, ValorTotal = 60.00f },
                    new ReservaExcursaoModel { Id = 97, ClienteId = 28, ExcursaoId = 8, DataReserva = DateTime.UtcNow.AddDays(8), NumPessoas = 6, ValorTotal = 300.00f },
                    new ReservaExcursaoModel { Id = 98, ClienteId = 29, ExcursaoId = 9, DataReserva = DateTime.UtcNow.AddDays(9), NumPessoas = 3, ValorTotal = 180.00f },
                    new ReservaExcursaoModel { Id = 99, ClienteId = 31, ExcursaoId = 3, DataReserva = DateTime.UtcNow.AddDays(10), NumPessoas = 2, ValorTotal = 110.00f },
                    new ReservaExcursaoModel { Id = 100, ClienteId = 21, ExcursaoId = 15, DataReserva = DateTime.UtcNow.AddDays(11), NumPessoas = 4, ValorTotal = 200.00f },
                    new ReservaExcursaoModel { Id = 101, ClienteId = 32, ExcursaoId = 19, DataReserva = DateTime.UtcNow.AddDays(12), NumPessoas = 1, ValorTotal = 50.00f },
                    new ReservaExcursaoModel { Id = 102, ClienteId = 33, ExcursaoId = 2, DataReserva = DateTime.UtcNow.AddDays(13), NumPessoas = 5, ValorTotal = 250.00f },
                    new ReservaExcursaoModel { Id = 103, ClienteId = 34, ExcursaoId = 16, DataReserva = DateTime.UtcNow.AddDays(14), NumPessoas = 2, ValorTotal = 120.00f },
                    new ReservaExcursaoModel { Id = 104, ClienteId = 35, ExcursaoId = 11, DataReserva = DateTime.UtcNow.AddDays(15), NumPessoas = 3, ValorTotal = 150.00f },
                    new ReservaExcursaoModel { Id = 105, ClienteId = 23, ExcursaoId = 12, DataReserva = DateTime.UtcNow.AddDays(16), NumPessoas = 2, ValorTotal = 100.00f },
                    new ReservaExcursaoModel { Id = 106, ClienteId = 21, ExcursaoId = 17, DataReserva = DateTime.UtcNow.AddDays(17), NumPessoas = 4, ValorTotal = 200.00f },
                    new ReservaExcursaoModel { Id = 107, ClienteId = 28, ExcursaoId = 19, DataReserva = DateTime.UtcNow.AddDays(18), NumPessoas = 6, ValorTotal = 300.00f },
                    new ReservaExcursaoModel { Id = 108, ClienteId = 29, ExcursaoId = 12, DataReserva = DateTime.UtcNow.AddDays(19), NumPessoas = 2, ValorTotal = 110.00f },
                    new ReservaExcursaoModel { Id = 109, ClienteId = 40, ExcursaoId = 13, DataReserva = DateTime.UtcNow.AddDays(20), NumPessoas = 3, ValorTotal = 150.00f },
                    new ReservaExcursaoModel { Id = 110, ClienteId = 21, ExcursaoId = 22, DataReserva = DateTime.UtcNow.AddDays(1), NumPessoas = 2, ValorTotal = 100.00f }
                );

                // Save changes to the context
                context.SaveChanges();
            }
        }
    }
}



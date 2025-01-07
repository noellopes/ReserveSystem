﻿using Microsoft.EntityFrameworkCore;
using ReserveSystem.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ReserveSystem.Data
{
    public static class SeedData
    {
        internal static async Task PopulateAsync(ReserveSystemContext? db)
        {
            if (db == null) return;
            await db.Database.EnsureCreatedAsync();
            await SeedTipoEquipamentoAsync(db);
            await SeedEquipamentoAsync(db);
            await SeedTipoReservaAsync(db);
            await SeedClientModelAsync(db);
            await SeedTipoSalaAsync(db);
            await SeedSalaAsync(db);
            await SeedReservaAsync(db);
        }

        private static async Task SeedTipoEquipamentoAsync(ReserveSystemContext context)
        {
            if (await context.TipoEquipamento.AnyAsync()) return;

            var equipmentTypes = new[]
            {
                    new TipoEquipamento { NomeTipoEquipamento = "Electronic" },
                    new TipoEquipamento { NomeTipoEquipamento = "Furniture" },
                    new TipoEquipamento { NomeTipoEquipamento = "Lighting" },
                    new TipoEquipamento { NomeTipoEquipamento = "Kitchen Equipment" },
                    new TipoEquipamento { NomeTipoEquipamento = "Accessories" }
                };

            await context.TipoEquipamento.AddRangeAsync(equipmentTypes);
            await context.SaveChangesAsync();
        }

        private static async Task SeedEquipamentoAsync(ReserveSystemContext context)
        {
            if (await context.Equipamento.AnyAsync()) return;

            var equipment = new[]
            {
                new Equipamento { NomeEquipamento = "Projector", IdTipoEquipamento = 1, Quantidade = 3 },
                new Equipamento { NomeEquipamento = "Sound System", IdTipoEquipamento = 1, Quantidade = 8 },
                new Equipamento { NomeEquipamento = "Microphone", IdTipoEquipamento = 1, Quantidade = 30 },
                new Equipamento { NomeEquipamento = "Whiteboard", IdTipoEquipamento = 2, Quantidade = 7 },
                new Equipamento { NomeEquipamento = "Conference Table", IdTipoEquipamento = 2, Quantidade = 10 },
                new Equipamento { NomeEquipamento = "Chairs", IdTipoEquipamento = 2, Quantidade = 500 },
                new Equipamento { NomeEquipamento = "Podium", IdTipoEquipamento = 2, Quantidade = 5 },
                new Equipamento { NomeEquipamento = "Video Conferencing System", IdTipoEquipamento = 1, Quantidade = 2 },
                new Equipamento { NomeEquipamento = "Stage Lighting", IdTipoEquipamento = 3, Quantidade = 10 },
                new Equipamento { NomeEquipamento = "Sound Mixer", IdTipoEquipamento = 1, Quantidade = 1 },
                new Equipamento { NomeEquipamento = "Projection Screen", IdTipoEquipamento = 2, Quantidade = 5 },
                new Equipamento { NomeEquipamento = "Flipcharts", IdTipoEquipamento = 2, Quantidade = 4 },
                new Equipamento { NomeEquipamento = "Wi-Fi Router", IdTipoEquipamento = 1, Quantidade = 5 },
                new Equipamento { NomeEquipamento = "Laptop", IdTipoEquipamento = 1, Quantidade = 10 },
                new Equipamento { NomeEquipamento = "Power Strips", IdTipoEquipamento = 5, Quantidade = 10 },
                new Equipamento { NomeEquipamento = "HDMI Cables", IdTipoEquipamento = 5, Quantidade = 13 },
                new Equipamento { NomeEquipamento = "Portable Speaker", IdTipoEquipamento = 1, Quantidade = 3 },
                new Equipamento { NomeEquipamento = "Laser Pointer", IdTipoEquipamento = 5, Quantidade = 5 },
                new Equipamento { NomeEquipamento = "Coffee Maker", IdTipoEquipamento = 4, Quantidade = 11 },
                new Equipamento { NomeEquipamento = "Thermos", IdTipoEquipamento = 4, Quantidade = 5 }
            };

            await context.Equipamento.AddRangeAsync(equipment);
            await context.SaveChangesAsync();
        }

        private static async Task SeedTipoReservaAsync(ReserveSystemContext context)
        {
            if (await context.TipoReserva.AnyAsync()) return;

            var tipoReservas = new[]
            {
                    new TipoReserva { NomeReserva = "Conference" },
                    new TipoReserva { NomeReserva = "Meeting" },
                    new TipoReserva { NomeReserva = "Workshop" },
                    new TipoReserva { NomeReserva = "Seminar" },
                    new TipoReserva { NomeReserva = "Training" }
                };

            await context.TipoReserva.AddRangeAsync(tipoReservas);
            await context.SaveChangesAsync();
        }

        private static async Task SeedClientModelAsync(ReserveSystemContext context)
        {
            if (await context.ClientModel.AnyAsync()) return;

            var clients = new[]
            {
                 new ClientModel {NomeCliente = "João Silva", MoradaCliente = "Rua das Flores, 123", Email = "joao.silva@example.com", Password = "senha123", Telefone = "912345678", NIF = 123456789 },
                    new ClientModel {NomeCliente = "Maria Oliveira", MoradaCliente = "Avenida Central, 456", Email = "maria.oliveira@example.com", Password = "senha456", Telefone = "923456789", NIF = 234567890 },
                    new ClientModel{NomeCliente = "Carlos Souza", MoradaCliente = "Praça da Liberdade, 789", Email = "carlos.souza@example.com", Password = "senha789", Telefone = "934567890", NIF = 345678901 },
                    new ClientModel {NomeCliente = "Ana Santos", MoradaCliente = "Rua das Palmeiras, 101", Email = "ana.santos@example.com", Password = "senha101", Telefone = "945678901", NIF = 456789012 },
                    new ClientModel {NomeCliente = "Pedro Lima", MoradaCliente = "Estrada Velha, 202", Email = "pedro.lima@example.com", Password = "senha202", Telefone = "956789012", NIF = 567890123 },
                    new ClientModel {NomeCliente = "Fernanda Costa", MoradaCliente = "Travessa do Sol, 303", Email = "fernanda.costa@example.com", Password = "senha303", Telefone = "967890123", NIF = 678901234 },
                    new ClientModel {NomeCliente = "Rafael Nascimento", MoradaCliente = "Largo do Mercado, 404", Email = "rafael.nascimento@example.com", Password = "senha404", Telefone = "978901234", NIF = 789012345 },
                    new ClientModel {NomeCliente = "Juliana Alves", MoradaCliente = "Bairro da Paz, 505", Email = "juliana.alves@example.com", Password = "senha505", Telefone = "989012345", NIF = 890123456 },
                    new ClientModel {NomeCliente = "Bruno Pereira", MoradaCliente = "Rua Nova, 606", Email = "bruno.pereira@example.com", Password = "senha606", Telefone = "991234567", NIF = 901234567 },
                    new ClientModel {NomeCliente = "Patrícia Fernandes", MoradaCliente = "Vila Bela, 707", Email = "patricia.fernandes@example.com", Password = "senha707", Telefone = "992345678", NIF = 012345678 }
                };

            await context.ClientModel.AddRangeAsync(clients);
            await context.SaveChangesAsync();
        }

        private static async Task SeedTipoSalaAsync(ReserveSystemContext context)
        {
            if (await context.TipoSala.AnyAsync()) return;

            var tipoSalas = new[]
            {
                    new TipoSala { NomeSala = "Small Room", TamanhoSala = 20, Capacidade = 10, PreçoHora = 50 },
                    new TipoSala { NomeSala = "Medium Room", TamanhoSala = 50, Capacidade = 25, PreçoHora = 100 },
                    new TipoSala { NomeSala = "Large Room", TamanhoSala = 100, Capacidade = 50, PreçoHora = 200 }
                };

            await context.TipoSala.AddRangeAsync(tipoSalas);
            await context.SaveChangesAsync();
        }

        private static async Task SeedSalaAsync(ReserveSystemContext context)
        {
            if (await context.Sala.AnyAsync()) return;

            var salas = new[]
            {
                    new Sala { IdTipoSala = 1, TempoPreparação = TimeSpan.FromMinutes(30), HoraInicio = new TimeOnly(8, 0), HoraFim = new TimeOnly(18, 0) },
                    new Sala { IdTipoSala = 2, TempoPreparação = TimeSpan.FromMinutes(45), HoraInicio = new TimeOnly(8, 0), HoraFim = new TimeOnly(18, 0) },
                    new Sala { IdTipoSala = 3, TempoPreparação = TimeSpan.FromMinutes(60), HoraInicio = new TimeOnly(8, 0), HoraFim = new TimeOnly(18, 0) }
                };

            await context.Sala.AddRangeAsync(salas);
            await context.SaveChangesAsync();
        }

        private static async Task SeedReservaAsync(ReserveSystemContext context)
        {
            if (await context.Reserva.AnyAsync()) return;

            var reservas = new[]
            {
                    new Reserva { DataReserva = DateTime.Now, DataInicio = DateTime.Now.AddDays(1), DataFim = DateTime.Now.AddDays(1).AddHours(2), TotalParticipantes = 10, PrecoTotal = 100, Estado = "Pending", DataEstado = DateTime.Now, IdTipoReserva = 1, NumeroCliente = 1 },
                    new Reserva { DataReserva = DateTime.Now, DataInicio = DateTime.Now.AddDays(2), DataFim = DateTime.Now.AddDays(2).AddHours(3), TotalParticipantes = 20, PrecoTotal = 200, Estado = "Pending", DataEstado = DateTime.Now, IdTipoReserva = 2, NumeroCliente = 2 }
                };

            await context.Reserva.AddRangeAsync(reservas);
            await context.SaveChangesAsync();
        }
    }
}

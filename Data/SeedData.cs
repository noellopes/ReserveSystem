using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public class SeedData
    {

        internal static void Populate(ReserveSystemUsersDbContext? db)
        {
            if (db == null) return;
            db.Database.EnsureCreated();

            PopulateClient(db);
            PopulatePersonalTrainers(db);
            PopulateSpacesAndHorarios(db);
        }


        private static void PopulateClient(ReserveSystemUsersDbContext db)
        {
            if (db.Client.Any()) return;
            db.Client.AddRange(
                new List<ClientModel>
                {
            new ClientModel { Name = "Alice Ribeiro", Phone = "+351912345001", isClientHotel = false, Email = "alice.ribeiro@example.com" },
            new ClientModel { Name = "Bruno Oliveira", Phone = "+351922345002", isClientHotel = true, Email = "bruno.oliveira@example.com" },
            new ClientModel { Name = "Carla Santos", Phone = "+351932345003", isClientHotel = false, Email = "carla.santos@example.com" },
            new ClientModel { Name = "Daniel Costa", Phone = "+351942345004", isClientHotel = true, Email = "daniel.costa@example.com" },
            new ClientModel { Name = "Elisa Cardoso", Phone = "+351952345005", isClientHotel = false, Email = "elisa.cardoso@example.com" },
            new ClientModel { Name = "Fábio Martins", Phone = "+351962345006", isClientHotel = true, Email = "fabio.martins@example.com" },
            new ClientModel { Name = "Gabriela Teixeira", Phone = "+351972345007", isClientHotel = false, Email = "gabriela.teixeira@example.com" },
            new ClientModel { Name = "Henrique Almeida", Phone = "+351982345008", isClientHotel = true, Email = "henrique.almeida@example.com" },
            new ClientModel { Name = "Inês Lopes", Phone = "+351992345009", isClientHotel = false, Email = "ines.lopes@example.com" },
            new ClientModel { Name = "João Ferreira", Phone = "+351912345010", isClientHotel = true, Email = "joao.ferreira@example.com" },
            new ClientModel { Name = "Karina Rodrigues", Phone = "+351922345011", isClientHotel = false, Email = "karina.rodrigues@example.com" },
            new ClientModel { Name = "Lucas Moreira", Phone = "+351932345012", isClientHotel = true, Email = "lucas.moreira@example.com" },
            new ClientModel { Name = "Marta Nunes", Phone = "+351942345013", isClientHotel = false, Email = "marta.nunes@example.com" },
            new ClientModel { Name = "Nelson Vieira", Phone = "+351952345014", isClientHotel = true, Email = "nelson.vieira@example.com" },
            new ClientModel { Name = "Olivia Mendes", Phone = "+351962345015", isClientHotel = false, Email = "olivia.mendes@example.com" },
            new ClientModel { Name = "Pedro Silva", Phone = "+351972345016", isClientHotel = true, Email = "pedro.silva@example.com" },
            new ClientModel { Name = "Quinta Batista", Phone = "+351982345017", isClientHotel = false, Email = "quinta.batista@example.com" },
            new ClientModel { Name = "Ricardo Correia", Phone = "+351992345018", isClientHotel = true, Email = "ricardo.correia@example.com" },
            new ClientModel { Name = "Sofia Faria", Phone = "+351912345019", isClientHotel = false, Email = "sofia.faria@example.com" },
            new ClientModel { Name = "Tomás Gonçalves", Phone = "+351922345020", isClientHotel = true, Email = "tomas.goncalves@example.com" }
                }
            );
            db.SaveChanges();
        }




        private static void PopulatePersonalTrainers(ReserveSystemUsersDbContext db)
        {
            if (db.PersonalTrainer.Any()) return;

            db.PersonalTrainer.AddRange(
                new List<PersonalTrainerModel>
                {
            new PersonalTrainerModel
            {
                Name = "João Silva",
                Email = "joao.silva@example.com",
                Phone = "912345678",
                Specialties = new List<TrainerSpecialty> { TrainerSpecialty.YOGA, TrainerSpecialty.MUSCLE }
            },
            new PersonalTrainerModel
            {
                Name = "Maria Oliveira",
                Email = "maria.oliveira@example.com",
                Phone = "923456789",
                Specialties = new List<TrainerSpecialty> { TrainerSpecialty.CROSSFIT }
            },
            new PersonalTrainerModel
            {
                Name = "Carlos Mendes",
                Email = "carlos.mendes@example.com",
                Phone = "934567890",
                Specialties = new List<TrainerSpecialty> { TrainerSpecialty.NATACAO, TrainerSpecialty.MUSCLE }
            },
            new PersonalTrainerModel
            {
                Name = "Ana Costa",
                Email = "ana.costa@example.com",
                Phone = "945678901",
                Specialties = new List<TrainerSpecialty> { TrainerSpecialty.YOGA }
            },
            new PersonalTrainerModel
            {
                Name = "Pedro Almeida",
                Email = "pedro.almeida@example.com",
                Phone = "956789012",
                Specialties = new List<TrainerSpecialty> { TrainerSpecialty.CROSSFIT, TrainerSpecialty.NATACAO }
            },
            new PersonalTrainerModel
            {
                Name = "Sara Faria",
                Email = "sara.faria@example.com",
                Phone = "967890123",
                Specialties = new List<TrainerSpecialty> { TrainerSpecialty.YOGA, TrainerSpecialty.CROSSFIT }
            }
                }
            );

            db.SaveChanges();
        }


        private static void PopulateSpacesAndHorarios(ReserveSystemUsersDbContext db)
        {
            // Verifica se já existem registros na tabela Spaces
            if (db.Spaces.Any()) return;

            // Adiciona uma lista de espaços (Ginásios e Piscinas)
            var spaces = new List<SpaceModel>
    {
        new SpaceModel
        {
            Name = "Ginásio Este",
            Capacity = 100,
            ReservedPercentage = 20,
            Type = SpaceType.GYM
        },
        new SpaceModel
        {
            Name = "Ginásio Sul",
            Capacity = 120,
            ReservedPercentage = 25,
            Type = SpaceType.GYM
        },
        new SpaceModel
        {
            Name = "Ginásio Norte",
            Capacity = 80,
            ReservedPercentage = 15,
            Type = SpaceType.GYM
        },
        new SpaceModel
        {
            Name = "Piscina",
            Capacity = 50,
            ReservedPercentage = 30,
            Type = SpaceType.POOL
        }
    };

            // Adiciona os espaços ao banco de dados
            db.Spaces.AddRange(spaces);
            db.SaveChanges(); // Salva para que os IDs dos espaços sejam gerados

            // Criar horários para cada espaço
            foreach (var space in spaces)
            {
                var horarios = new List<HorarioModel>
        {
            new HorarioModel { spaceId = space.Id, Day = DayOfWeek.Monday, OpenTime = new TimeSpan(8, 30, 0), CloseTime = new TimeSpan(17, 30, 0), IsClosed = false },
            new HorarioModel { spaceId = space.Id, Day = DayOfWeek.Tuesday, OpenTime = new TimeSpan(8, 30, 0), CloseTime = new TimeSpan(17, 30, 0), IsClosed = false },
            new HorarioModel { spaceId = space.Id, Day = DayOfWeek.Wednesday, OpenTime = new TimeSpan(8, 30, 0), CloseTime = new TimeSpan(17, 30, 0), IsClosed = false },
            new HorarioModel { spaceId = space.Id, Day = DayOfWeek.Thursday, OpenTime = new TimeSpan(8, 30, 0), CloseTime = new TimeSpan(17, 30, 0), IsClosed = false },
            new HorarioModel { spaceId = space.Id, Day = DayOfWeek.Friday, OpenTime = new TimeSpan(8, 30, 0), CloseTime = new TimeSpan(17, 30, 0), IsClosed = false },
            new HorarioModel { spaceId = space.Id, Day = DayOfWeek.Saturday, OpenTime = new TimeSpan(8, 30, 0), CloseTime = new TimeSpan(17, 30, 0), IsClosed = false },
            new HorarioModel { spaceId = space.Id, Day = DayOfWeek.Sunday, OpenTime = new TimeSpan(0, 0, 0), CloseTime = new TimeSpan(0, 0, 0), IsClosed = true } // Domingo fechado
        };

                // Adiciona os horários ao banco de dados
                db.HorarioModel.AddRange(horarios);
            }

            // Salva as alterações no banco de dados
            db.SaveChanges();
        }




    }
}

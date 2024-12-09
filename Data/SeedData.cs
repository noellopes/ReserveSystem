using System;
using System.Linq;
using ReserveSystem.Models;

namespace ReserveSystem.Data
{
    public static class SeedData
    {

        public static void PopulateJob(ReserveSystemContext context)
        {
            if (context.Job.Any())
            {
                return; // Seed já foi executado.
            }

            var jobs = new List<Job>
        {
            new Job
            {
                JobName = "Recepcionista",
                JobDescription = "Responsável por atender clientes no balcão, realizar check-ins e check-outs, e fornecer informações sobre os serviços do hotel.",
                Salary = 1500.00f
            },
            new Job
            {
                JobName = "Camareiro",
                JobDescription = "Responsável pela limpeza dos quartos e manutenção de um ambiente higienizado para os hóspedes.",
                Salary = 1200.00f
            },
            new Job
            {
                JobName = "Gerente de Hotel",
                JobDescription = "Responsável pela supervisão geral do hotel, coordenando as operações diárias e garantindo a satisfação dos hóspedes.",
                Salary = 3500.00f
            },
            new Job
            {
                JobName = "Coordenador de Eventos",
                JobDescription = "Responsável por planejar e coordenar eventos, incluindo conferências, festas e outras atividades no hotel.",
                Salary = 2500.00f
            },
            new Job
            {
                JobName = "Chef de Cozinha",
                JobDescription = "Responsável por supervisionar a cozinha, criar os cardápios e garantir a qualidade da comida servida aos clientes.",
                Salary = 2800.00f
            },
            new Job
            {
                JobName = "Segurança",
                JobDescription = "Responsável pela segurança do hotel, incluindo o monitoramento de áreas, realização de rondas e atendimento a emergências.",
                Salary = 1400.00f
            },
            new Job
            {
                JobName = "Recepcionista de Reservas",
                JobDescription = "Responsável por gerenciar as reservas de quartos, confirmando as informações dos clientes e fazendo ajustes nas reservas quando necessário.",
                Salary = 1600.00f
            },
            new Job
            {
                JobName = "Técnico de Manutenção",
                JobDescription = "Responsável pela manutenção dos sistemas elétricos, hidráulicos e outros equipamentos do hotel.",
                Salary = 2000.00f
            },
            new Job
            {
                JobName = "Estagiário",
                JobDescription = "Responsável por auxiliar nas várias áreas do hotel, com funções que variam de acordo com a necessidade do setor.",
                Salary = 800.00f
            },
            new Job
            {
                JobName = "Atendente de Bar",
                JobDescription = "Responsável por atender os clientes no bar, servir bebidas e manter o ambiente limpo e organizado.",
                Salary = 1300.00f
            }
        };

            context.Job.AddRange(jobs);
            context.SaveChanges();
        }

        public static void PopulateItems(ReserveSystemContext context)
        {
            if (context.Items.Any())
            {
                return; // Seed já foi executado.
            }

            var items = new List<Items>
        {
            new Items
            {
                Name = "Toalha de Banho",
                QuantityStock = 50,
                MinimumStock = 10
            },
            new Items
            {
                Name = "Almofada",
                QuantityStock = 30,
                MinimumStock = 5
            },
            new Items
            {
                Name = "Lençol",
                QuantityStock = 40,
                MinimumStock = 8
            },
            new Items
            {
                Name = "Cobertor",
                QuantityStock = 20,
                MinimumStock = 5
            },
            new Items
            {
                Name = "Champoo",
                QuantityStock = 100,
                MinimumStock = 20
            },
            new Items
            {
                Name = "Condicionador",
                QuantityStock = 100,
                MinimumStock = 20
            },
            new Items
            {
                Name = "Sabonete",
                QuantityStock = 200,
                MinimumStock = 50
            },
            new Items
            {
                Name = "Desinfetante",
                QuantityStock = 80,
                MinimumStock = 15
            },
            new Items
            {
                Name = "Copo de Plástico",
                QuantityStock = 150,
                MinimumStock = 30
            },
            new Items
            {
                Name = "Escova de Dente",
                QuantityStock = 75,
                MinimumStock = 10
            }
        };

            context.Items.AddRange(items);
            context.SaveChanges();
        }

        public static void PopulateRoomType(ReserveSystemContext context)
        {
            if (context.RoomType.Any())
            {
                return; // Seed já foi executado.
            }

            var roomTypes = new List<RoomType>
        {
            new RoomType
            {
                Type = "Single",
                Capacity = 1,
                RoomCapacity = 1,
                HasView = true,
                AccessibilityRoom = false
            },
            new RoomType
            {
                Type = "Double",
                Capacity = 2,
                RoomCapacity = 2,
                HasView = true,
                AccessibilityRoom = false
            },
            new RoomType
            {
                Type = "Triple",
                Capacity = 3,
                RoomCapacity = 3,
                HasView = false,
                AccessibilityRoom = false
            },
            new RoomType
            {
                Type = "Quadruple",
                Capacity = 4,
                RoomCapacity = 4,
                HasView = false,
                AccessibilityRoom = true
            },
            new RoomType
            {
                Type = "Suite",
                Capacity = 2,
                RoomCapacity = 5,
                HasView = true,
                AccessibilityRoom = true
            },
            new RoomType
            {
                Type = "Family",
                Capacity = 4,
                RoomCapacity = 4,
                HasView = false,
                AccessibilityRoom = true
            },
            new RoomType
            {
                Type = "Presidential Suite",
                Capacity = 2,
                RoomCapacity = 6,
                HasView = true,
                AccessibilityRoom = true
            },
            new RoomType
            {
                Type = "TestRoomType1",
                Capacity = 4,
                RoomCapacity = 4,
                HasView = false,
                AccessibilityRoom = true
            },
            new RoomType
            {
                Type = "TestRoomType2",
                Capacity = 4,
                RoomCapacity = 4,
                HasView = false,
                AccessibilityRoom = true
            },
            new RoomType
            {
                Type = "TestRoomType3",
                Capacity = 4,
                RoomCapacity = 4,
                HasView = false,
                AccessibilityRoom = true
            },
        };

            context.RoomType.AddRange(roomTypes);
            context.SaveChanges();
        }

        public static void PopulateRoom(ReserveSystemContext context)
        {
            if (context.Room.Any())
            {
                return; // Seed já foi executado.
            }

            // Verifique se a tabela RoomType contém os tipos de quarto necessários
            var roomTypes = context.RoomType.ToList();
            if (!roomTypes.Any())
            {
                throw new InvalidOperationException("Room types are missing. Please populate RoomType table first.");
            }

            var rooms = new List<Room>
    {
        new Room
        {
            RoomTypeId = roomTypes.First(rt => rt.Type == "Single").RoomTypeId,
            cleanings = new List<Cleaning>(),
            roomBookings = new List<RoomBooking>()
        },
        new Room
        {
            RoomTypeId = roomTypes.First(rt => rt.Type == "Double").RoomTypeId,
            cleanings = new List<Cleaning>(),
            roomBookings = new List<RoomBooking>()
        },
        new Room
        {
            RoomTypeId = roomTypes.First(rt => rt.Type == "Suite").RoomTypeId,
            cleanings = new List<Cleaning>(),
            roomBookings = new List<RoomBooking>()
        },
        new Room
        {
            RoomTypeId = roomTypes.First(rt => rt.Type == "Family").RoomTypeId,
            cleanings = new List<Cleaning>(),
            roomBookings = new List<RoomBooking>()
        },
        new Room
        {
            RoomTypeId = roomTypes.First(rt => rt.Type == "Presidential Suite").RoomTypeId,
            cleanings = new List<Cleaning>(),
            roomBookings = new List<RoomBooking>()
        },
        new Room
        {
            RoomTypeId = roomTypes.First(rt => rt.Type == "Triple").RoomTypeId,
            cleanings = new List<Cleaning>(),
            roomBookings = new List<RoomBooking>()
        },
        new Room
        {
            RoomTypeId = roomTypes.First(rt => rt.Type == "Quadruple").RoomTypeId,
            cleanings = new List<Cleaning>(),
            roomBookings = new List<RoomBooking>()
        },
        new Room
        {
            RoomTypeId = roomTypes.First(rt => rt.Type == "TestRoomType1").RoomTypeId,
            cleanings = new List<Cleaning>(),
            roomBookings = new List<RoomBooking>()
        },
        new Room
        {
            RoomTypeId = roomTypes.First(rt => rt.Type == "TestRoomType2").RoomTypeId,
            cleanings = new List<Cleaning>(),
            roomBookings = new List<RoomBooking>()
        },
        new Room
        {
            RoomTypeId = roomTypes.First(rt => rt.Type == "TestRoomType3").RoomTypeId,
            cleanings = new List<Cleaning>(),
            roomBookings = new List<RoomBooking>()
        }
    };

            context.Room.AddRange(rooms);
            context.SaveChanges();
        }


        public static void PopulateStaff(ReserveSystemContext context)
        {
            if (context.Staff.Any())
            {
                return; // Seed já foi executado.
            }

            var staffMembers = new List<Staff>
        {
            new Staff
            {
                StaffName = "Carlos Silva",
                StaffEmail = "carlos.silva@example.com",
                StaffPhone = "+351912345678",
                StaffDriverLicense = "AB123456",
                StaffDriverLicenseExpiringDate = new DateTime(2025, 12, 31),
                IsActive = true,
                JobId = 1 // Assume que o JobId 1 já existe
            },
            new Staff
            {
                StaffName = "Ana Costa",
                StaffEmail = "ana.costa@example.com",
                StaffPhone = "+351923456789",
                StaffDriverLicense = "CD654321",
                StaffDriverLicenseExpiringDate = new DateTime(2024, 6, 15),
                IsActive = true,
                JobId = 2 // Assume que o JobId 2 já existe
            },
            new Staff
            {
                StaffName = "João Ferreira",
                StaffEmail = "joao.ferreira@example.com",
                StaffPhone = "+351934567890",
                StaffDriverLicense = "EF987654",
                StaffDriverLicenseExpiringDate = new DateTime(2026, 5, 20),
                IsActive = false, // Inativo, por exemplo
                JobId = 3 // Assume que o JobId 3 já existe
            },
            new Staff
            {
                StaffName = "Jacinto",
                StaffEmail = "jacinto@gmail.com",
                StaffPhone = "+351923456789",
                StaffDriverLicense = "CD654321",
                StaffDriverLicenseExpiringDate = new DateTime(2024, 6, 15),
                IsActive = true,
                JobId = 4 // Assume que o JobId 2 já existe
            },
            new Staff
            {
                StaffName = "Fernando",
                StaffEmail = "ana.costa@example.com",
                StaffPhone = "+351923456789",
                StaffDriverLicense = "CD654321",
                StaffDriverLicenseExpiringDate = new DateTime(2024, 6, 15),
                IsActive = true,
                JobId = 5 // Assume que o JobId 2 já existe
            },
            new Staff
            {
                StaffName = "João",
                StaffEmail = "ana.costa@example.com",
                StaffPhone = "+351923456789",
                StaffDriverLicense = "CD654321",
                StaffDriverLicenseExpiringDate = new DateTime(2024, 6, 15),
                IsActive = true,
                JobId = 6 // Assume que o JobId 2 já existe
            },
            new Staff
            {
                StaffName = "Mario",
                StaffEmail = "ana.costa@example.com",
                StaffPhone = "+351923456789",
                StaffDriverLicense = "CD654321",
                StaffDriverLicenseExpiringDate = new DateTime(2024, 6, 15),
                IsActive = true,
                JobId = 7 // Assume que o JobId 2 já existe
            },
            new Staff
            {
                StaffName = "Zé",
                StaffEmail = "ana.costa@example.com",
                StaffPhone = "+351923456789",
                StaffDriverLicense = "CD654321",
                StaffDriverLicenseExpiringDate = new DateTime(2024, 6, 15),
                IsActive = true,
                JobId = 8 // Assume que o JobId 2 já existe
            },
            new Staff
            {
                StaffName = "Costa",
                StaffEmail = "ana.costa@example.com",
                StaffPhone = "+351923456789",
                StaffDriverLicense = "CD654321",
                StaffDriverLicenseExpiringDate = new DateTime(2024, 6, 15),
                IsActive = true,
                JobId = 9 // Assume que o JobId 2 já existe
            },
            new Staff
            {
                StaffName = "Costinha",
                StaffEmail = "ana.costa@example.com",
                StaffPhone = "+351923456789",
                StaffDriverLicense = "CD654321",
                StaffDriverLicenseExpiringDate = new DateTime(2024, 6, 15),
                IsActive = true,
                JobId = 10 // Assume que o JobId 2 já existe
            },
        };

            context.Staff.AddRange(staffMembers);
            context.SaveChanges();
        }

        public static void PopulateClients(ReserveSystemContext context)
        {
            if (context.Client.Any())
            {
                return; // Seed já foi executado.
            }

            var clients = new List<Client>
        {
            new Client
            {
                ClientName = "João Silva",
                ClientPhone = "+351912345678",
                ClientAddress = "Rua das Flores, 123, Lisboa",
                ClientEmail = "joao.silva@example.com",
                ClientNIF = "123456789",
                ClientLogin = "joaosilva",
                ClientStatus = true
            },
            new Client
            {
                ClientName = "Maria Santos",
                ClientPhone = "+351916543210",
                ClientAddress = "Av. da Liberdade, 45, Porto",
                ClientEmail = "maria.santos@example.com",
                ClientNIF = "987654321",
                ClientLogin = "mariasantos",
                ClientStatus = true
            },
            new Client
            {
                ClientName = "Carlos Pereira",
                ClientPhone = "+351931234567",
                ClientAddress = "Rua do Carmo, 56, Faro",
                ClientEmail = "carlos.pereira@example.com",
                ClientNIF = "192837465",
                ClientLogin = "carlospereira",
                ClientStatus = true
            },
            new Client
            {
                ClientName = "Ana Costa",
                ClientPhone = "+351938765432",
                ClientAddress = "Praça da República, 12, Coimbra",
                ClientEmail = "ana.costa@example.com",
                ClientNIF = "564738291",
                ClientLogin = "anacosta",
                ClientStatus = true
            },
            new Client
            {
                ClientName = "Luís Rodrigues",
                ClientPhone = "+351945612378",
                ClientAddress = "Travessa do Sol, 87, Braga",
                ClientEmail = "luis.rodrigues@example.com",
                ClientNIF = "847362910",
                ClientLogin = "luisrodrigues",
                ClientStatus = true
            },
            new Client
            {
                ClientName = "Helena Alves",
                ClientPhone = "+351926543789",
                ClientAddress = "Rua Nova, 34, Setúbal",
                ClientEmail = "helena.alves@example.com",
                ClientNIF = "102938475",
                ClientLogin = "helenaalves",
                ClientStatus = false
            },
            new Client
            {
                ClientName = "Tiago Mendes",
                ClientPhone = "+351965478321",
                ClientAddress = "Estrada da Serra, 98, Leiria",
                ClientEmail = "tiago.mendes@example.com",
                ClientNIF = "738291056",
                ClientLogin = "tiagomendes",
                ClientStatus = true
            },
            new Client
            {
                ClientName = "Sofia Monteiro",
                ClientPhone = "+351937654812",
                ClientAddress = "Rua dos Pássaros, 15, Évora",
                ClientEmail = "sofia.monteiro@example.com",
                ClientNIF = "384756102",
                ClientLogin = "sofiamonteiro",
                ClientStatus = true
            },
            new Client
            {
                ClientName = "Ricardo Nunes",
                ClientPhone = "+351914567890",
                ClientAddress = "Av. dos Oceanos, 78, Cascais",
                ClientEmail = "ricardo.nunes@example.com",
                ClientNIF = "756302948",
                ClientLogin = "ricardonunes",
                ClientStatus = true
            },
            new Client
            {
                ClientName = "Carla Ferreira",
                ClientPhone = "+351925647839",
                ClientAddress = "Largo da Igreja, 9, Vila Real",
                ClientEmail = "carla.ferreira@example.com",
                ClientNIF = "564920183",
                ClientLogin = "carlaferreira",
                ClientStatus = false
            }
        };

            context.Client.AddRange(clients);
            context.SaveChanges();
        }

        public static void PopulateBooking(ReserveSystemContext db)
        {
            // Verifica se já existem registos na base de dados para evitar duplicação
            if (db.Booking.Any())
            {
                return; // Se há dados, não adiciona mais nada
            }

            var bookings = new[]
            {
                new Booking
                {
                    CheckInDate = new DateTime(2024, 12, 1),
                    CheckOutDate = new DateTime(2024, 12, 5),
                    BookingDate = new DateTime(2024, 11, 20),
                    IsBooked = true,
                    TotalPersonsNumber = 2,
                    PaymentStatus = true,
                    ClientId = 1
                },
                new Booking
                {
                    CheckInDate = new DateTime(2024, 12, 10),
                    CheckOutDate = new DateTime(2024, 12, 15),
                    BookingDate = new DateTime(2024, 11, 25),
                    IsBooked = true,
                    TotalPersonsNumber = 4,
                    PaymentStatus = true,
                    ClientId = 2
                },
                new Booking
                {
                    CheckInDate = new DateTime(2024, 11, 30),
                    CheckOutDate = new DateTime(2024, 12, 2),
                    BookingDate = new DateTime(2024, 11, 10),
                    IsBooked = true,
                    TotalPersonsNumber = 1,
                    PaymentStatus = false,
                    ClientId = 3
                },
                new Booking
                {
                    CheckInDate = new DateTime(2024, 12, 20),
                    CheckOutDate = new DateTime(2024, 12, 22),
                    BookingDate = new DateTime(2024, 11, 28),
                    IsBooked = true,
                    TotalPersonsNumber = 3,
                    PaymentStatus = true,
                    ClientId = 4
                },
                new Booking
                {
                    CheckInDate = new DateTime(2025, 1, 5),
                    CheckOutDate = new DateTime(2025, 1, 10),
                    BookingDate = new DateTime(2024, 12, 15),
                    IsBooked = true,
                    TotalPersonsNumber = 5,
                    PaymentStatus = true,
                    ClientId = 5
                },
                new Booking
                {
                    CheckInDate = new DateTime(2024, 11, 25),
                    CheckOutDate = new DateTime(2024, 11, 28),
                    BookingDate = new DateTime(2024, 11, 5),
                    IsBooked = true,
                    TotalPersonsNumber = 2,
                    PaymentStatus = true,
                    ClientId = 6
                },
                new Booking
                {
                    CheckInDate = new DateTime(2024, 12, 23),
                    CheckOutDate = new DateTime(2024, 12, 27),
                    BookingDate = new DateTime(2024, 11, 30),
                    IsBooked = true,
                    TotalPersonsNumber = 6,
                    PaymentStatus = false,
                    ClientId = 7
                },
                new Booking
                {
                    CheckInDate = new DateTime(2025, 1, 15),
                    CheckOutDate = new DateTime(2025, 1, 20),
                    BookingDate = new DateTime(2024, 12, 20),
                    IsBooked = true,
                    TotalPersonsNumber = 3,
                    PaymentStatus = true,
                    ClientId = 8
                },
                new Booking
                {
                    CheckInDate = new DateTime(2024, 12, 1),
                    CheckOutDate = new DateTime(2024, 12, 4),
                    BookingDate = new DateTime(2024, 11, 18),
                    IsBooked = true,
                    TotalPersonsNumber = 2,
                    PaymentStatus = true,
                    ClientId = 9
                },
                new Booking
                {
                    CheckInDate = new DateTime(2024, 12, 28),
                    CheckOutDate = new DateTime(2025, 1, 2),
                    BookingDate = new DateTime(2024, 11, 25),
                    IsBooked = true,
                    TotalPersonsNumber = 4,
                    PaymentStatus = false,
                    ClientId = 10
                }
            };

            // Adiciona as reservas a base de dados
            db.Booking.AddRange(bookings);

            // Guarda as mudanças
            db.SaveChanges();
        }

        public static void PopulateRoomBooking(ReserveSystemContext context)
        {
            if (context.RoomBooking.Any())
            {
                return; // Seed já foi executado.
            }

            var bookings = context.Booking.ToList();
            var rooms = context.Room.ToList();

            if (!bookings.Any() || !rooms.Any())
            {
                throw new InvalidOperationException("A tabela de Booking ou Room está vazia. Certifique-se de que há dados nessas tabelas.");
            }

            var roomBookings = new List<RoomBooking>
    {
        new RoomBooking
        {
            BookingId = bookings.First(b => b.ClientId == 1).BookingId,
            RoomId = rooms.FirstOrDefault(r => r.RoomTypeId == 1)?.RoomId ?? throw new InvalidOperationException("RoomTypeId 1 não encontrado."),
            PersonsNumber = 1,
            CleaningOption = true,
            itemRooms = new List<ItemRoom>(),
            cleaningSchedules = new List<CleaningShedule>()
        },
        new RoomBooking
        {
            BookingId = bookings.First(b => b.ClientId == 2).BookingId,
            RoomId = rooms.FirstOrDefault(r => r.RoomTypeId == 2)?.RoomId ?? throw new InvalidOperationException("RoomTypeId 2 não encontrado."),
            PersonsNumber = 2,
            CleaningOption = false,
            itemRooms = new List<ItemRoom>(),
            cleaningSchedules = new List<CleaningShedule>()
        },
        new RoomBooking
        {
            BookingId = bookings.First(b => b.ClientId == 3).BookingId,
            RoomId = rooms.FirstOrDefault(r => r.RoomTypeId == 3)?.RoomId ?? throw new InvalidOperationException("RoomTypeId 3 não encontrado."),
            PersonsNumber = 4,
            CleaningOption = true,
            itemRooms = new List<ItemRoom>(),
            cleaningSchedules = new List<CleaningShedule>()
        },
        new RoomBooking
        {
            BookingId = bookings.First(b => b.ClientId == 4).BookingId,
            RoomId = rooms.FirstOrDefault(r => r.RoomTypeId == 4)?.RoomId ?? throw new InvalidOperationException("RoomTypeId 4 não encontrado."),
            PersonsNumber = 3,
            CleaningOption = true,
            itemRooms = new List<ItemRoom>(),
            cleaningSchedules = new List<CleaningShedule>()
        },
        new RoomBooking
        {
            BookingId = bookings.First(b => b.ClientId == 5).BookingId,
            RoomId = rooms.FirstOrDefault(r => r.RoomTypeId == 5)?.RoomId ?? throw new InvalidOperationException("RoomTypeId 5 não encontrado."),
            PersonsNumber = 2,
            CleaningOption = false,
            itemRooms = new List<ItemRoom>(),
            cleaningSchedules = new List<CleaningShedule>()
        },
        new RoomBooking
        {
            BookingId = bookings.First(b => b.ClientId == 6).BookingId,
            RoomId = rooms.FirstOrDefault(r => r.RoomTypeId == 6)?.RoomId ?? throw new InvalidOperationException("RoomTypeId 6 não encontrado."),
            PersonsNumber = 2,
            CleaningOption = false,
            itemRooms = new List<ItemRoom>(),
            cleaningSchedules = new List<CleaningShedule>()
        },
        new RoomBooking
        {
            BookingId = bookings.First(b => b.ClientId == 7).BookingId,
            RoomId = rooms.FirstOrDefault(r => r.RoomTypeId == 7)?.RoomId ?? throw new InvalidOperationException("RoomTypeId 7 não encontrado."),
            PersonsNumber = 2,
            CleaningOption = false,
            itemRooms = new List<ItemRoom>(),
            cleaningSchedules = new List<CleaningShedule>()
        },
        new RoomBooking
        {
            BookingId = bookings.First(b => b.ClientId == 8).BookingId,
            RoomId = rooms.FirstOrDefault(r => r.RoomTypeId == 8)?.RoomId ?? throw new InvalidOperationException("RoomTypeId 8 não encontrado."),
            PersonsNumber = 2,
            CleaningOption = false,
            itemRooms = new List<ItemRoom>(),
            cleaningSchedules = new List<CleaningShedule>()
        },
        new RoomBooking
        {
            BookingId = bookings.First(b => b.ClientId == 9).BookingId,
            RoomId = rooms.FirstOrDefault(r => r.RoomTypeId == 9)?.RoomId ?? throw new InvalidOperationException("RoomTypeId 9 não encontrado."),
            PersonsNumber = 2,
            CleaningOption = false,
            itemRooms = new List<ItemRoom>(),
            cleaningSchedules = new List<CleaningShedule>()
        },
        new RoomBooking
        {
            BookingId = bookings.First(b => b.ClientId == 10).BookingId,
            RoomId = rooms.FirstOrDefault(r => r.RoomTypeId == 10)?.RoomId ?? throw new InvalidOperationException("RoomTypeId 10 não encontrado."),
            PersonsNumber = 2,
            CleaningOption = false,
            itemRooms = new List<ItemRoom>(),
            cleaningSchedules = new List<CleaningShedule>()
        }
    };

            context.RoomBooking.AddRange(roomBookings);
            context.SaveChanges();
        }

        public static void PopulateItemRooms(ReserveSystemContext context)
        {
            if (context.ItemRoom.Any())
            {
                return; // Seed já foi executado.
            }

            var roomBookings = context.RoomBooking.ToList();
            if (!roomBookings.Any())
            {
                throw new InvalidOperationException("A tabela de RoomBooking está vazia. Certifique-se de que há dados na tabela RoomBooking antes de tentar inserir ItemRooms.");
            }

            var itemRooms = new List<ItemRoom>
    {
        new ItemRoom
        {
            AvailableQuantity = 10,
            LastRestockedDate = DateTime.Now.AddDays(-5),
            RoomBookingId = roomBookings.First(r => r.BookingId == 1).RoomBookingId,
            ItemId = 1,
        },
        new ItemRoom
        {
            AvailableQuantity = 20,
            LastRestockedDate = DateTime.Now.AddDays(-7),
            RoomBookingId = roomBookings.First(r => r.BookingId == 2).RoomBookingId,
            ItemId = 2,
        },
        new ItemRoom
        {
            AvailableQuantity = 15,
            LastRestockedDate = DateTime.Now.AddDays(-3),
            RoomBookingId = roomBookings.First(r => r.BookingId == 3).RoomBookingId,
            ItemId = 3,
        },
        new ItemRoom
        {
            AvailableQuantity = 8,
            LastRestockedDate = DateTime.Now.AddDays(-2),
            RoomBookingId = roomBookings.First(r => r.BookingId == 4).RoomBookingId,
            ItemId = 4,
        },
        new ItemRoom
        {
            AvailableQuantity = 12,
            LastRestockedDate = DateTime.Now.AddDays(-1),
            RoomBookingId = roomBookings.First(r => r.BookingId == 5).RoomBookingId,
            ItemId = 5,
        }
    };

            context.ItemRoom.AddRange(itemRooms);
            context.SaveChanges();
        }
         public static void PopulateCleaning(ReserveSystemContext context)
        {
            if (context.Cleaning.Any())
            {
                return; // Seed já foi executado.
            }

            // Verifique se a tabela Room contém os RoomId necessários
            var rooms = context.Room.ToList();
            if (rooms.Count < 10)
            {
                throw new InvalidOperationException("Not enough rooms available. Please populate the Room table first.");
            }

            var cleanings = new List<Cleaning>
    {
        new Cleaning { CleaningService = true, RoomId = rooms[0].RoomId },
        new Cleaning { CleaningService = false, RoomId = rooms[1].RoomId },
        new Cleaning { CleaningService = true, RoomId = rooms[2].RoomId },
        new Cleaning { CleaningService = true, RoomId = rooms[3].RoomId },
        new Cleaning { CleaningService = false, RoomId = rooms[4].RoomId },
        new Cleaning { CleaningService = true, RoomId = rooms[5].RoomId },
        new Cleaning { CleaningService = false, RoomId = rooms[6].RoomId },
        new Cleaning { CleaningService = true, RoomId = rooms[7].RoomId },
        new Cleaning { CleaningService = true, RoomId = rooms[8].RoomId },
        new Cleaning { CleaningService = false, RoomId = rooms[9].RoomId }
    };

            context.Cleaning.AddRange(cleanings);
            context.SaveChanges();
        }

        public static void PopulateCleaningShedule(ReserveSystemContext context)
        {
            if (context.CleaningShedule.Any())
            {
                return; // Seed já foi executado.
            }

            var staff = context.Staff.ToList();
            if (staff.Count < 10)
            {
                throw new InvalidOperationException("Não há registros suficientes em Staff. Certifique-se de que PopulateStaff foi executado.");
            }

            var cleaningSchedules = new List<CleaningShedule>
        {
            new CleaningShedule
            {
                DateServices = DateTime.Today.AddDays(1),
                StartTime = new TimeOnly(9, 0),
                EndTime = new TimeOnly(11, 0),
                CleaningId = 1,
                StaffId = 1,
                RoomBookingId = 1
            },
            new CleaningShedule
            {
                DateServices = DateTime.Today.AddDays(2),
                StartTime = new TimeOnly(10, 0),
                EndTime = new TimeOnly(12, 0),
                CleaningId = 2,
                StaffId = 2,
                RoomBookingId = 2
            },
            new CleaningShedule
            {
                DateServices = DateTime.Today.AddDays(3),
                StartTime = new TimeOnly(8, 30),
                EndTime = new TimeOnly(10, 30),
                CleaningId = 3,
                StaffId = 3,
                RoomBookingId = 3
            },
            new CleaningShedule
            {
                DateServices = DateTime.Today.AddDays(4),
                StartTime = new TimeOnly(14, 0),
                EndTime = new TimeOnly(16, 0),
                CleaningId = 4,
                StaffId = 4,
                RoomBookingId = 4
            },
            new CleaningShedule
            {
                DateServices = DateTime.Today.AddDays(5),
                StartTime = new TimeOnly(13, 0),
                EndTime = new TimeOnly(15, 0),
                CleaningId = 5,
                StaffId = 5,
                RoomBookingId = 5
            },
            new CleaningShedule
            {
                DateServices = DateTime.Today.AddDays(6),
                StartTime = new TimeOnly(9, 0),
                EndTime = new TimeOnly(11, 0),
                CleaningId = 6,
                StaffId = 6,
                RoomBookingId = 6
            },
            new CleaningShedule
            {
                DateServices = DateTime.Today.AddDays(7),
                StartTime = new TimeOnly(10, 0),
                EndTime = new TimeOnly(12, 0),
                CleaningId = 7,
                StaffId = 7,
                RoomBookingId = 7
            },
            new CleaningShedule
            {
                DateServices = DateTime.Today.AddDays(8),
                StartTime = new TimeOnly(15, 0),
                EndTime = new TimeOnly(17, 0),
                CleaningId = 8,
                StaffId = 8,
                RoomBookingId = 8
            },
            new CleaningShedule
            {
                DateServices = DateTime.Today.AddDays(9),
                StartTime = new TimeOnly(11, 0),
                EndTime = new TimeOnly(13, 0),
                CleaningId = 9,
                StaffId = 9,
                RoomBookingId = 9
            },
            new CleaningShedule
            {
                DateServices = DateTime.Today.AddDays(10),
                StartTime = new TimeOnly(14, 30),
                EndTime = new TimeOnly(16, 30),
                CleaningId = 10,
                StaffId = 10,
                RoomBookingId = 10
            }
        };

            context.CleaningShedule.AddRange(cleaningSchedules);
            context.SaveChanges();
        }
        
        public static void PopulateConsumptions(ReserveSystemContext context)
        {
            if (context.Consumptions.Any())
            {
                return; // Seed já foi executado.
            }

            var consumptions = new List<Consumptions>
        {
            new Consumptions
            {
                ItemRoomId = 1, // ID de exemplo para item disponível no quarto.
                QuantityConsumed = 2,
                ConsumedDate = DateTime.Now.AddDays(-1),
                ClientId = 1 // ID de exemplo de cliente.
            },
            new Consumptions
            {
                ItemRoomId = 2,
                QuantityConsumed = 1,
                ConsumedDate = DateTime.Now.AddDays(-2),
                ClientId = 2
            },
            new Consumptions
            {
                ItemRoomId = 3,
                QuantityConsumed = 4,
                ConsumedDate = DateTime.Now.AddDays(-3),
                ClientId = 3
            },
            new Consumptions
            {
                ItemRoomId = 4,
                QuantityConsumed = 3,
                ConsumedDate = DateTime.Now.AddDays(-4),
                ClientId = 4
            },
            new Consumptions
            {
                ItemRoomId = 5,
                QuantityConsumed = 5,
                ConsumedDate = DateTime.Now.AddDays(-5),
                ClientId = 5
            },
            new Consumptions
            {
                ItemRoomId = 1,
                QuantityConsumed = 2,
                ConsumedDate = DateTime.Now.AddDays(-6),
                ClientId = 6
            },
            new Consumptions
            {
                ItemRoomId = 3,
                QuantityConsumed = 1,
                ConsumedDate = DateTime.Now.AddDays(-7),
                ClientId = 7
            },
            new Consumptions
            {
                ItemRoomId = 2,
                QuantityConsumed = 3,
                ConsumedDate = DateTime.Now.AddDays(-8),
                ClientId = 8
            },
            new Consumptions
            {
                ItemRoomId = 4,
                QuantityConsumed = 2,
                ConsumedDate = DateTime.Now.AddDays(-9),
                ClientId = 9
            },
            new Consumptions
            {
                ItemRoomId = 5,
                QuantityConsumed = 4,
                ConsumedDate = DateTime.Now.AddDays(-10),
                ClientId = 10
            }
        };

            context.Consumptions.AddRange(consumptions);
            context.SaveChanges();
        }
    }
}


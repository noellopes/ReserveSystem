using ReserveSystem.Data;
using ReserveSystem.Models;

internal class SeedData
{
    internal static void Populate(ReserveSystemContext? db)
    {
        if (db == null) return;
        db.Database.EnsureCreated();
        PopulateJob(db);
        PopulateRoomService(db);


    }

    private static void PopulateJob(ReserveSystemContext db)
    {
        if (db.Job.Any()) return;
        var jobs = new List<Job>
        {
            new Job { Job_Name = "Cleaning", Job_Description = "Staff responsable for cleaning services" }, 
            new Job { Job_Name = "Laundry", Job_Description = "Staff responsable for laundry, iron and dry cleaning services" }, 
            new Job { Job_Name = "Kitchen", Job_Description = "Staff responsable for the preparation of meals" }, 
            new Job { Job_Name = "Receptionist", Job_Description = "Personalized services by the receptionist" }, 
            new Job { Job_Name = "Concierge", Job_Description = "Personal Assistance with reservations and recommendations" }, 
            new Job { Job_Name = "Spa staff", Job_Description = "Staff responsable for spa treatments" }, 
            new Job { Job_Name = "Valet", Job_Description = "Staff responsable for parking service" },
            new Job { Job_Name = "Pet Sitter", Job_Description = "Staff responsable for taking care of Pets and walking services" }, 
            new Job { Job_Name = "Baby Sitter", Job_Description = "Staff responsable for taking care of childrens" },
            new Job { Job_Name = "Room Service Attendant", Job_Description = "Staff responsable for delivering meals to rooms and taking care of the collection and delivery of clothes from the laundry room" }
        };
        db.Job.AddRange(jobs);
        db.SaveChanges();
    }

    private static void PopulateRoomService(ReserveSystemContext db)
    {
        // Verificar se RoomServices já foi populado
        if (db.RoomService.Any()) return;

        // Obter os Jobs existentes no banco de dados
        var jobs = db.Job.ToList();

        // Criar RoomServices com base nos Jobs
        var roomServices = new List<RoomService>
        {
            new RoomService
            {
                Job_ID = jobs.FirstOrDefault(j => j.Job_Name == "Cleaning")?.Job_ID ?? 0,
                Room_Service_Name = "Room Cleaning",
                Room_Service_Description = "Thorough cleaning of your room.",
                Room_Service_Active = true
            },
            new RoomService
            {
                Job_ID = jobs.FirstOrDefault(j => j.Job_Name == "Laundry")?.Job_ID ?? 0,
                Room_Service_Name = "Laundry Service",
                Room_Service_Description = "Professional laundry, ironing, and dry-cleaning services.", 
                Room_Service_Active = true
            },
            new RoomService
            {
                Job_ID = jobs.FirstOrDefault(j => j.Job_Name == "Kitchen")?.Job_ID ?? 0,
                Room_Service_Name = "In-Room Dining",
                Room_Service_Description = "Meals delivered to your room, freshly prepared.",
                Room_Service_Active = true
            },
            new RoomService
            {
                Job_ID = jobs.FirstOrDefault(j => j.Job_Name == "Concierge")?.Job_ID ?? 0,
                Room_Service_Name = "Concierge Assistance",
                Room_Service_Description = "Reservations and personalized recommendations.",
                Room_Service_Active = true
            },
            new RoomService
            {
                Job_ID = jobs.FirstOrDefault(j => j.Job_Name == "Spa Staff")?.Job_ID ?? 0,
                Room_Service_Name = "Spa Treatments",
                Room_Service_Description = "Relaxing spa treatments at your convenience.",
                Room_Service_Active = true
            },
            new RoomService
            {
                Job_ID = jobs.FirstOrDefault(j => j.Job_Name == "Valet")?.Job_ID ?? 0,
                Room_Service_Name = "Valet Parking",
                Room_Service_Description = "Professional parking service for your vehicle.",
                Room_Service_Active = true
            },
            new RoomService
            {
                Job_ID = jobs.FirstOrDefault(j => j.Job_Name == "Pet Sitter")?.Job_ID ?? 0,
                Room_Service_Name = "Pet Sitting",
                Room_Service_Description = "Care and walking services for your pets.",
                Room_Service_Active = true
            },
            new RoomService
            {
                Job_ID = jobs.FirstOrDefault(j => j.Job_Name == "Baby Sitter")?.Job_ID ?? 0,
                Room_Service_Name = "Child Care",
                Room_Service_Description = "Professional babysitting services.",
                Room_Service_Active = true
            },
            new RoomService
            {
                Job_ID = jobs.FirstOrDefault(j => j.Job_Name == "Room Service Attendant")?.Job_ID ?? 0,
                Room_Service_Name = "Room Service Delivery",
                Room_Service_Description = "Delivering meals to your room and managing laundry pickup and delivery.",
                Room_Service_Active = true
            }
        };

        // Filtrar RoomServices com Job_ID válido
        roomServices = roomServices.Where(rs => rs.Job_ID > 0).ToList();

        // Adicionar RoomServices ao banco de dados
        db.RoomService.AddRange(roomServices);
        db.SaveChanges();
    }

    private static void PopulateRoomServicePrice(ReserveSystemContext db)
    {
        // Verificar se RoomServicePrice já foi populado
        if (db.RoomServicePrice.Any()) return;

        // Obter RoomServices existentes no banco de dados
        var roomServices = db.RoomService.ToList();

        // Criar preços para cada RoomService
        var roomServicePrices = new List<RoomServicePrice>();
        var today = DateTime.Now.Date;


        foreach (var roomService in roomServices)
        {
            roomServicePrices.Add(new RoomServicePrice
            {
                ID_Room_Service = roomService.ID_Room_Service,
                Start_Date = today,
                End_Date = today.AddMonths(6), // Preço válido por 6 meses
                Room_Service_Price = GetDefaultPriceForService(roomService.Room_Service_Name)
            });
        }

        // Adicionar RoomServicePrices ao banco de dados
        db.RoomServicePrice.AddRange(roomServicePrices);
        db.SaveChanges();
    }

    // Função auxiliar para definir um preço padrão com base no nome do serviço
    private static double GetDefaultPriceForService(string serviceName)
    {
        return serviceName switch
        {
            "Room Cleaning" => 25.0,
            "Laundry Service" => 15.0,
            "In-Room Dining" => 20.0,
            "Concierge Assistance" => 30.0,
            "Spa Treatments" => 50.0,
            "Valet Parking" => 10.0,
            "Pet Sitting" => 35.0,
            "Child Care" => 40.0,
            "Room Service Delivery" => 18.0,
            _ => 10.0 // Preço padrão caso o serviço não esteja na lista
        };
    }


}
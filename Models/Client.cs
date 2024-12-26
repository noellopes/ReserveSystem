using System.ComponentModel.DataAnnotations;

    namespace ReserveSystem.Models
    {
        public class Client
        {
            public int ClientId { get; set; }

            public required string Client_Name { get; set; }

            public required string Client_Phone { get; set; }

            public required string Client_Adress { get; set; }

            public required string Client_Email { get; set; }

            public required string Client_Nif { get; set; }

            public required bool Client_Login { get; set; }

            public required bool Client_Status { get; set; }

        //public ICollection<CleaningShedule> cleaningSchedules { get; set; }
    }
}
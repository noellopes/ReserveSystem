namespace ReserveSystem.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientPhone { get; set; }
        public string ClientAddress { get; set; }
        public string ClientEmail { get; set; }
        public string ClientNIF { get; set; }
        public string ClientLogin { get; set; }
        public bool ClientStatus { get; set; }

        public ICollection<Booking> bookings { get; set; }
        public ICollection<Consumptions> consumptions { get; set; }
    }
}

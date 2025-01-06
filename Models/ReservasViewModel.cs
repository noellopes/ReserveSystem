namespace ReserveSystem.Models
{
    public class ReservasViewModel
    {
        public IEnumerable<Reserva> Reservas { get; set; }
        public PagingInfo PagingInfo { get; set; }

        public string SearchPrato { get; set; }
        public string SearchCliente { get; set; }
    }
}

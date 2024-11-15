namespace ReserveSystem.Models
{
    public class Reserva
    {
        public int Id_reserva { get; set; }
        public int Numerocliente { get; set; }
        public string Tiporeserva { get; set; }
        public DateTime Datareserva { get; set; }
        public DateTime Datainicio { get; set; }
        public DateTime Datafim { get; set; }
        public int Totalparticipante { get; set; }
        public decimal Preçototal { get; set; }

        public Cliente Cliente { get; set; } // Relacionamento com Cliente
    }
}

namespace ReserveSystem.Models
{
    public class Buffet
    {
        public int BuffetId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public List<Prato> Pratos { get; set; } = new List<Prato>();
    }
}

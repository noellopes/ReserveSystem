namespace ReserveSystem.Models
{
   
    public class Sala
    {
        public int SalaId { get; set; }
        public string Nome { get; set; }
        public int Capacidade { get; set; }
        public decimal Preco { get; set; }
        public bool Disponivel { get; set; }
    }

}

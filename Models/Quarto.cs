using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Quarto
    {
        public int QuartoId { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();

        public ICollection<Client> Clients { get; set; } = new List<Client>();

        public ICollection<ItemQuarto> ItemQuartos { get; set; } = new List<ItemQuarto>();

    }
}


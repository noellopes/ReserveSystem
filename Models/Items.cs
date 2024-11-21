using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Items
    {
        [Key]
        public int ItemId { get; set; }

        public string Nome { get; set; }

        public int QuantidadeArmazem { get; set; }
    }
}

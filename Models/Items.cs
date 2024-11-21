using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Items
    {
        [Key]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Quantidade is required.")]
        [Range(0, double.MaxValue, ErrorMessage = "Quantidade em armazem tem de ser maior ou igual que 0.")]
        public int QuantidadeArmazem { get; set; }
    }
}

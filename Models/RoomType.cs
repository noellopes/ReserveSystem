using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomType
    {
        [Key]
        public int RoomTypeId { get; set; } // Chave primária

        [Required]
        public bool HasView { get; set; } // Indica se o quarto tem vista

        [Required]
        public string Type { get; set; } // Tipo de quarto (ex: Single, Double, etc.)

        [Required]
        public int RoomCapacity { get; set; } // Capacidade do quarto (número de pessoas)

        [Required]
        public bool AcessibilityRoom { get; set; } // Indica se o quarto é adaptado

        public ICollection<Room> Rooms { get; set; } = new List<Room>(); // Relação de um para muitos com RoomModel
    }
}

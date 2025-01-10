using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class RoomTypePrice
    {
        [Key] // Chave primária da tabela
        public int RTPriceId { get; set; }

        [ForeignKey("RoomType")] [Required]public int RoomTypeId { get; set; }

        public float BasePrice { get; set; }

        // Navegação para RoomType
        public RoomType RoomType { get; set; }
    }
}

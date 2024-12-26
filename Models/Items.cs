using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Items
    {
        [Key]
        public int ItemId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Stock quantity is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Stock quantity must be a non-negative number.")]
        public int QuantityStock { get; set; }

    }
}

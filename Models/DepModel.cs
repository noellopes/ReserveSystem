using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class DepModel
    {
        [Key]
        [Required(ErrorMessage = "ID is required")]
        public int depID { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        public required List<DepModel> depname { get; set; }

        [Required(ErrorMessage = "Department description is required")]
        public required String depDescription { get; set; }
    }
}

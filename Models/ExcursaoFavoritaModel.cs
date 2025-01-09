using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class ExcursaoFavoritaModel
    {

            [Key]
            public int Id { get; set; }
            [Display(Name = "Nome do Cliente")]
        [Required(ErrorMessage = "O cliente é obrigatório.")]
        public int ClienteId { get; set; }
            [Display(Name = "Excursão")]
        [Required(ErrorMessage = "A excursão é obrigatória.")]
        public int ExcursaoId { get; set; }

            [Display(Name = "Comentário à escursão")]
        [StringLength(500, ErrorMessage = "O comentário não pode ter mais do que 500 caracteres.")]
        public string? Comentario { get; set; }

            
            // Navigation properties
            public virtual ClienteTestModel? Cliente { get; set; }
            public virtual ExcursaoModel? Excursao { get; set; }
        }

    }



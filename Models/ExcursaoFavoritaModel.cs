using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class ExcursaoFavoritaModel
    {

            [Key]
            public int Id { get; set; }
            [Display(Name = "Nome do Cliente")]
            public int ClienteId { get; set; }
            [Display(Name = "Excursão")]
            public int ExcursaoId { get; set; }

            [Display(Name = "Comentário à escursão")]
            public string? Comentario { get; set; }

            
            // Navigation properties
            public virtual ClienteTestModel? Cliente { get; set; }
            public virtual ExcursaoModel? Excursao { get; set; }
        }

    }



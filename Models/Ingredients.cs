using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Ingrediente
    {
        public int IngredienteId { get; set; }

        [Display(Name = "Nome do Ingrediente")]
        [Required(ErrorMessage = "O nome do ingrediente é obrigatório."), StringLength(300)]
        public string Nome { get; set; }


        [Display(Name = "Unidade de medida")]
        [Required(ErrorMessage = "A unidade de medida é obrigatória."), StringLength(10)]
        public string UnidadeMedida { get; set; }
    }
}

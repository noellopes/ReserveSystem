using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Prato
    {
       public int pratoID { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome do prato é obrigatório"), StringLength(300)]
        public string nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição do prato é obrigatória"), StringLength(900)]
        public string descricao { get; set; }
    }
}

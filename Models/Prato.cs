using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Prato
    {
        public int PratoID { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome do prato é obrigatório"), StringLength(300)]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O descrição é obrigatória"), StringLength(300)]
        public string Descricao { get; set; }
    }
}

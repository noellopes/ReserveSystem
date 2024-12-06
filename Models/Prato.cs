using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Prato
    {
        public int PratoId { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome do prato é obrigatório"), StringLength(300)]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "A descrição é obrigatória"), StringLength(900)]
        public string Descricao { get; set; }

        [Display(Name = "Preço (€)")]
        [Required(ErrorMessage = "O preço é obrigatório")]
        [Range(0.01, 10000, ErrorMessage = "O preço deve estar entre 0,01 e 10.000")]
        public decimal Preco { get; set; }
    }
}

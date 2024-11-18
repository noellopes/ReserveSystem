using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class PersonalTrainerModel
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage = "Formato do email invalido")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Telefone obrigatório")]
        public String Phone { get; set; }


    }
}

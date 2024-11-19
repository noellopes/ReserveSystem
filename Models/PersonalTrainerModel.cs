using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class PersonalTrainerModel
    {
        [Key]
<<<<<<< HEAD
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Insira um endereço de email válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "O telefone deve ter exatamente 9 dígitos.")]
        public string Phone { get; set; } // Use string para facilitar a validação de tamanho
=======
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage = "Formato do email invalido")]
        public String Email { get; set; }

        [Required(ErrorMessage = "Telefone obrigatório")]
        public String Phone { get; set; }


>>>>>>> a63cfa9949389b21f4bf574611a4a1543a965846
    }
}

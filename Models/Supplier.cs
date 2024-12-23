using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Supplier
    {
        // Primary Key
        public int SupplierID { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O nome do fornecedor é obrigatório"), StringLength(300)]
        public string SupplierName { get; set; }

        [Display(Name = "Morada")]
        [Required(ErrorMessage = "A morada do fornecedor é obrigatória"), StringLength(300)]
        public string SupplierAddress { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O telefone do fornecedor é obrigatório")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "O telefone deve conter exatamente 9 dígitos.")]

        public string SupplierPhone { get; set; } 

        [Display(Name = "Email")]
        [Required(ErrorMessage = "O email do fornecedor é obrigatório"), StringLength(300)]
        public string SupplierEmail { get; set; }
    }
}

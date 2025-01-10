using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class Suppliers
    {
        //Primary key
        [Key]
        public int SupplierID { get; set; }
        [Display(Name = "Nome")]
        [Required(ErrorMessage ="O nome do fornecedor é obrigatório"), StringLength(200)]
        public string SupplierName { get; set; }

        [Display(Name = "Morada")]
        [Required(ErrorMessage = "A morada do fornecedor é obrigatório"), StringLength(200)]
        public string SupplierAddress {  get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O telefone do fornecedor é obrigatório"), StringLength(200)]
        public string SupplierPhone { get; set; }

        [Display(Name = "Email")]
        public string SupplierEmail { get; set; }

    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ReserveSystem.Models
{
    public class ClienteTestModel
    {

        [Key] 
        public int ClienteId { get; set; }

        [Required] 
        [StringLength(100)] 
        public string Nome { get; set; }

        [Required]
        [EmailAddress] 
        public string Email { get; set; }

        [Phone]
        public string Telefone { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<ReservaExcursaoModel>? ReservaExcursoes { get; set; }
    }
}


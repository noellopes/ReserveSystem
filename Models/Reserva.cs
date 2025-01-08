using ReserveSystem.Models;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.Runtime;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReserveSystem.Models
{
    public class Reserva
    {
        [Key]
        public int IdReserva { get; set; }

        [Required(ErrorMessage = "O cliente é obrigatório.")]
        public int IdCliente { get; set; }

        [ForeignKey("IdCliente")]
        public Cliente? Cliente { get; set; }
        
        [Range(1, 20)]
        public int? IdMesa { get; set; }
        public int NumeroPessoas { get; set; }

        [Required(ErrorMessage = "A data e hora são obrigatórias.")]
        public DateTime DataHora { get; set; }

        [StringLength(500, ErrorMessage = "A observação não pode exceder 500 caracteres.")]
        public string? Observacao { get; set; }

        public int? IdPrato { get; set; }
        [ForeignKey("IdPrato")]
        public Prato? Prato { get; set; }

        public Boolean Aprovacao { get; set; }
        public int? NumeroMesa { get; internal set; }
    }
}
